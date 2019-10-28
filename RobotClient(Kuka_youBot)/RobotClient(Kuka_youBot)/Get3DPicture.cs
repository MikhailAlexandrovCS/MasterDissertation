using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Media3D;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace RobotClient_Kuka_youBot_
{
    public partial class Get3DPicture : Form
    {
        public Get3DPicture(List<Point3D> pointCloud, List<Point3D> firstManipulatorPath, List<Point3D> secondManipulatorPath, int safeDistance, PreviewObjectType previewObjectType)
        {
            InitializeComponent();
            _pointCloud = pointCloud;
            _firstPathManipulator = firstManipulatorPath;
            _secondPathManipulator = secondManipulatorPath;
            _previewObjectType = previewObjectType;
            _safeDistance = safeDistance;
            this.glControl1.Click += new EventHandler(mouseClick);
            this.glControl1.MouseDown += new MouseEventHandler(mouseDown);
            this.glControl1.MouseMove += new MouseEventHandler(mouseMove);
            _viewPoint = new ViewPoint() { };
            UpdateModelviewMat();
            glControl1.Invalidate();
        }

        private PreviewObjectType _previewObjectType;
        private ViewPoint _viewPoint;
        private int _safeDistance;
        private Matrix4 _modelview = new Matrix4();
        private List<Point3D> _firstPathManipulator = new List<Point3D>();
        private List<Point3D> _secondPathManipulator = new List<Point3D>();
        private List<Point3D> _pointCloud = new List<Point3D>();
        private Cube cube = new Cube(100, 200, 300);
        private float _speed = 0.2f;
        private Vector3 _sr;
        private Vector3 _er;
        private double x1 = 0;
        private double x2 = 0;
        private double y1 = 0;
        private double y2 = 0;
        private bool rotating = false;
        private TypeRotating rotatingAxis = TypeRotating.NUL;
        private bool moved = false;

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.ClearColor(Color.White);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref _modelview);
            InitCamera();
            InitLight();
            GL.Disable(EnableCap.Lighting);
            DrawAxes();
            if (_previewObjectType.Equals(PreviewObjectType.RealValueObject))
            {
                sphere(_safeDistance, 100, 100, (int)_firstPathManipulator[_firstPathManipulator.Count - 1].X, (int)_firstPathManipulator[_firstPathManipulator.Count - 1].Y,
                    (int)_firstPathManipulator[_firstPathManipulator.Count - 1].Z, PointType.EndPoint);
                sphere(_safeDistance, 100, 100, (int)_firstPathManipulator[0].X, (int)_firstPathManipulator[0].Y,
                    (int)_firstPathManipulator[0].Z, PointType.StartPoint);
            }
            else
            {
                sphere(10, 100, 100, (int)_firstPathManipulator[_firstPathManipulator.Count - 1].X, (int)_firstPathManipulator[_firstPathManipulator.Count - 1].Y,
                    (int)_firstPathManipulator[_firstPathManipulator.Count - 1].Z, PointType.EndPoint);
                sphere(10, 100, 100, (int)_firstPathManipulator[0].X, (int)_firstPathManipulator[0].Y,
                    (int)_firstPathManipulator[0].Z, PointType.StartPoint);
            }
            DrawPointCloud(_pointCloud);
            DrawGraphPath(_firstPathManipulator);
            DrawGraphPath(_secondPathManipulator);
            glControl1.SwapBuffers();
        }

        void sphere(double r, int nx, int ny, int X, int Y, int Z, PointType pointType)
        {
            int ix, iy;
            double x = X, y = Y, z = Z;

            for (iy = 0; iy < ny; ++iy)
            {
                GL.Begin(BeginMode.QuadStrip);
                if (pointType.Equals(PointType.StartPoint))
                    GL.Color3(Color.Blue);
                else
                    GL.Color3(Color.Orange);
                for (ix = 0; ix <= nx; ++ix)
                {
                    x = X + r * Math.Sin(iy * Math.PI / ny) * Math.Cos(2 * ix * Math.PI / nx);
                    y = Y + r * Math.Sin(iy * Math.PI / ny) * Math.Sin(2 * ix * Math.PI / nx);
                    z = Z + r * Math.Cos(iy * Math.PI / ny);
                    GL.Normal3(x, y, z);//нормаль направлена от центра
                    GL.TexCoord2((double)ix / (double)nx, (double)iy / (double)ny);
                    GL.Vertex3(x, y, z);

                    x = X + r * Math.Sin((iy + 1) * Math.PI / ny) * Math.Cos(2 * ix * Math.PI / nx);
                    y = Y + r * Math.Sin((iy + 1) * Math.PI / ny) * Math.Sin(2 * ix * Math.PI / nx);
                    z = Z + r * Math.Cos((iy + 1) * Math.PI / ny);
                    GL.Normal3(x, y, z);
                    GL.TexCoord2((double)ix / (double)nx, (double)(iy + 1) / (double)ny);
                    GL.Vertex3(x, y, z);
                }
                GL.End();
            }
        }

        private void mouseMove(object sender, EventArgs e)
        {
            if (!this.rotating)
            {
                return;
            }

            var me = (e as System.Windows.Forms.MouseEventArgs);

            int w = glControl1.Width;
            int h = glControl1.Height;

            float dx = (float)(me.X - this.x1);
            float dy = (float)(me.Y - this.y1);

            if (Math.Abs(dx) < 1 && Math.Abs(dy) < 1 && rotatingAxis == TypeRotating.NUL)
            {
                return;
            }
            if (moved && me.Button == System.Windows.Forms.MouseButtons.Left)
            {
                rotatingAxis = TypeRotating.X;

                float drotation = (dx / w) * 180;
                float drotation2 = (dy / h) * 180;

                _viewPoint.angle_view_beta -= drotation2;
                _viewPoint.angle_view_alfa -= drotation;
            }
            else if (moved && me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                _viewPoint.MoveForward(dy / h);
            }

            UpdateModelviewMat();

            this.x1 = me.X;
            this.y1 = me.Y;
            glControl1.Invalidate();

            moved = true;
        }

        private void mouseDown(object sender, EventArgs e)
        {
            var me = (e as System.Windows.Forms.MouseEventArgs);
            this.x1 = me.X;
            this.y1 = me.Y;
            this.x2 = me.X;
            this.y2 = me.Y;
            this.rotating = true;
        }

        private void mouseClick(object sender, EventArgs e)
        {
            var me = (e as MouseEventArgs);
            double y = me.Y;
            double x = me.X;
            int w = glControl1.Width;
            int h = glControl1.Height;

            float xpos = (float)(2 * (x / w) - 1);
            float ypos = (float)(2 * (1 - y / h) - 1);
            Vector4 startRay = new Vector4(xpos, ypos, 1, 1);
            Vector4 endRay = new Vector4(xpos, ypos, -1, 1);
            Matrix4 modelview = new Matrix4();
            Matrix4 projection = new Matrix4();
            GL.GetFloat(GetPName.ModelviewMatrix, out modelview);
            GL.GetFloat(GetPName.ProjectionMatrix, out projection);
            Matrix4 trans = modelview * projection;
            if (trans.Determinant > 0)
            {
                trans.Invert();
                startRay = Vector4.Transform(startRay, trans);
                endRay = Vector4.Transform(endRay, trans);
                _sr = startRay.Xyz / startRay.W;
                _er = endRay.Xyz / endRay.W;
            }
        }

        public void DrawGraphPath(List<Point3D> vertexes)
        {
            GL.Begin(BeginMode.Lines);
            GL.Color3(Color.Red);
            for (int i = 0; i < vertexes.Count - 1; i++)
            {
                GL.Vertex3(vertexes[i].X, vertexes[i].Y, vertexes[i].Z);
                GL.Vertex3(vertexes[i + 1].X, vertexes[i + 1].Y, vertexes[i + 1].Z);
            }
            GL.End();
        }

        public void DrawPointCloud(List<Point3D> vertexes)
        {
            GL.Begin(BeginMode.Points);
            for (int i = 0; i < vertexes.Count; i++)
            {
                GL.Color3(Color.ForestGreen);
                GL.Vertex3(vertexes[i].X, vertexes[i].Y, vertexes[i].Z);
            }
            GL.End();
        }

        public void DrawAxes()
        {
            GL.Begin(BeginMode.Lines);
            GL.Color3(Color.Black);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(400, 0, 0);
            GL.Vertex3(0, 400, 0);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 0, 400);
            GL.Vertex3(0, 0, 0);
            GL.End();
        }

        private void InitCamera()
        {
            var p = Matrix4.CreatePerspectiveFieldOfView(
                (float)(80 * Math.PI / 180),
                1, 1, 5000);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref p);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref _modelview);
        }

        private static void InitLight()
        {
            GL.Enable(EnableCap.Lighting);
            GL.Light(LightName.Light0, LightParameter.Position, new float[] { 0, 1000.0f, 1000, 1.0f });
            GL.Light(LightName.Light0, LightParameter.Diffuse, new float[] { 1.0f, 1.0f, 1.0f, 1.0f });
            GL.Enable(EnableCap.Light0);
            GL.Light(LightName.Light1, LightParameter.Position, new float[] { 1000.0f, 1000.0f, 0, 1.0f });
            GL.Light(LightName.Light1, LightParameter.Diffuse, new float[] { 1.0f, 1.0f, 1.0f, 1.0f });
            GL.Enable(EnableCap.Light1);
            GL.Enable(EnableCap.DepthTest);
        }

        private void glControl1_Load(object sender, EventArgs e)
        {
            cube = new Cube(500, 100, 100);
            InitCamera();
            InitLight();
            glControl1.Invalidate();
        }

        private void UpdateModelviewMat()
        {
            _modelview = Matrix4.LookAt(_viewPoint.view.X, _viewPoint.view.Y, _viewPoint.view.Z,
                _viewPoint.target.X, _viewPoint.target.Y, _viewPoint.target.Z, 0, 0, _viewPoint.orientation_z);
        }

        private void glControl1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case 'w':
                    {
                        _viewPoint.MoveForward(-_speed);
                        UpdateModelviewMat();
                        break;
                    }
                case 's':
                    {
                        _viewPoint.MoveForward(_speed);
                        UpdateModelviewMat();
                        break;
                    }
                case 'a':
                    {
                        _viewPoint.MoveSide(_speed);
                        UpdateModelviewMat();
                        break;
                    }
                case 'd':
                    {
                        _viewPoint.MoveSide(-_speed);
                        UpdateModelviewMat();
                        break;
                    }
                case '1':
                    {
                        _viewPoint.setView(new Vector3(0, 0, 0), new Vector3(10, 0, 0));
                        UpdateModelviewMat();
                        break;
                    }
            }
        }
    }
}
