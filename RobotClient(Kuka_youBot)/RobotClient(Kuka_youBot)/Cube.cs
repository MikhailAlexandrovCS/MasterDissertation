using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace RobotClient_Kuka_youBot_
{
    class Cube
    {
        Vector3[] verticies;

        public void Draw(float scale)
        {
            GL.PushMatrix();
            GL.Scale(scale, scale, scale);

            GL.Begin(PrimitiveType.Quads);
            //back
            DrawPolygon(verticies, 0, 3, 2, 1);
            //top
            DrawPolygon(verticies, 2, 3, 7, 6);
            //left
            DrawPolygon(verticies, 0, 4, 7, 3);
            //right
            DrawPolygon(verticies, 1, 2, 6, 5);
            //front
            DrawPolygon(verticies, 4, 5, 6, 7);
            //bottom
            DrawPolygon(verticies, 0, 1, 5, 4);
            GL.End();

            GL.PopMatrix();
        }
        public float kx, ky, kz;
        public Cube(float kx, float ky, float kz)
        {
            this.kx = kx;
            this.ky = ky;
            this.kz = kz;
            verticies = new Vector3[]{new Vector3(-1,-1,-1), new Vector3(1,-1,-1),
            new Vector3(1,1,-1), new Vector3(-1,1,-1), new Vector3(-1,-1,1),
            new Vector3(1,-1,1), new Vector3(1,1,1), new Vector3(-1,1,1)};

            for (int i = 0; i < verticies.Length; i++)
            {
                verticies[i][0] *= kx / 2;
                verticies[i][1] *= ky / 2;
                verticies[i][2] *= kz / 2;
            }
        }

        void DrawPolygon(Vector3[] verticies, int a, int b, int c, int d)
        {

            var n = GetNormal(verticies[a], verticies[b], verticies[c]);
            GL.Normal3(n);
            GL.Vertex3(verticies[a]);
            GL.Vertex3(verticies[b]);
            GL.Vertex3(verticies[c]);
            GL.Vertex3(verticies[d]);
        }
        Vector3 GetNormal(Vector3 v1, Vector3 v2, Vector3 v3)
        {
            Vector3 a, b;
            a = v1 - v2;
            b = v1 - v3;
            var v = Vector3.Cross(a, b);
            v.Normalize();
            return v;
        }
    }
}
