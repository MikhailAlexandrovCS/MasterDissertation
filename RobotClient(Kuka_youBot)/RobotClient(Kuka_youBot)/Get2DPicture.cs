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

namespace RobotClient_Kuka_youBot_
{
    public partial class Get2DPicture : Form
    {
        public Get2DPicture(List<Point3D> obstaclePoints, Size size, List<Point3D> pathFirstManipulator, List<Point3D> pathSecondManipulator,
            List<GraphVertex> graphVetices, int[,] adjencyMatrixManipulator, Point3D startPoint, Point3D endPoint)
        {
            InitializeComponent();
            _adjencyMatrix = adjencyMatrixManipulator;
            _grapgVertices = graphVetices;
            _pathFirstManipulator = pathFirstManipulator;
            _pathSecondManipulator = pathSecondManipulator;
            _formMapSize = size;
            _obstaclesPoints = obstaclePoints;
            _startPoint = startPoint;
            _endPoint = endPoint;
        }

        private Point3D _startPoint = new Point3D();
        private Point3D _endPoint = new Point3D();
        private List<Point3D> _obstaclesPoints = new List<Point3D>();
        private Size _formMapSize = new Size();
        private List<Point3D> _pathFirstManipulator = new List<Point3D>();
        private List<Point3D> _pathSecondManipulator = new List<Point3D>();
        private List<GraphVertex> _grapgVertices = new List<GraphVertex>();
        private int[,] _adjencyMatrix;

        private void Get2DPicture_Load(object sender, EventArgs e)
        {
            this.Size = new Size(_formMapSize.Width + 100, _formMapSize.Height + 100);
            pbMap.Size = new Size(_formMapSize.Width + 100, _formMapSize.Height + 100);
        }

        private void pbMap_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < _obstaclesPoints.Count; i++)
                e.Graphics.FillEllipse(Brushes.Black, (float)_obstaclesPoints[i].X, (float)_obstaclesPoints[i].Y, 2, 2);
            for (int i = 0; i < _adjencyMatrix.GetLength(0); i++)
                for (int j = 0; j < _adjencyMatrix.GetLength(1); j++)
                    if (i != j && !_adjencyMatrix[i, j].Equals(0))
                        e.Graphics.DrawLine(new Pen(Brushes.Red), (float)_grapgVertices[i].Coords.X, (float)_grapgVertices[i].Coords.Y,
                        (float)_grapgVertices[j].Coords.X, (float)_grapgVertices[j].Coords.Y);
            for (int i = 0; i < _grapgVertices.Count; i++)
                e.Graphics.FillEllipse(Brushes.Red, (float)_grapgVertices[i].Coords.X, (float)_grapgVertices[i].Coords.Y, 6, 6);
            for (int i = 0; i < _pathFirstManipulator.Count - 1; i++)
            {
                e.Graphics.DrawLine(new Pen(Brushes.Purple, 4), (float)_pathFirstManipulator[i].X, (float)_pathFirstManipulator[i].Y, (float)_pathFirstManipulator[i + 1].X, (float)_pathFirstManipulator[i + 1].Y);
                e.Graphics.DrawLine(new Pen(Brushes.Purple, 4), (float)_pathFirstManipulator[i].X, (float)_pathFirstManipulator[i].Y, (float)_pathFirstManipulator[i + 1].X, (float)_pathFirstManipulator[i + 1].Y);
            }
            e.Graphics.FillEllipse(Brushes.Green, (float)_startPoint.X, (float)_startPoint.Y, 10, 10);
            e.Graphics.FillEllipse(Brushes.Blue, (float)_endPoint.X, (float)_endPoint.Y, 10, 10);
        }
    }
}
