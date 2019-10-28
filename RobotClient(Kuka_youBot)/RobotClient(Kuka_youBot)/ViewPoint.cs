using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace RobotClient_Kuka_youBot_
{
    class ViewPoint
    {
        public float l = 100;
        public float _angle_view_beta = 45;
        public float _angle_view_alfa = 0;
        public float orientation_z = 1;
        public float orientation_hor = 1;

        public Vector3 target = new Vector3();
        public Vector3 view = new Vector3();

        public void MoveForward(float k)
        {
            Vector3 bias = (view - target) * k;
            target += bias;
            view += bias;
        }
        public void MoveSide(float k)
        {
            Vector3 bias = (view - target) * k;
            var bias2 = new Vector3(bias.Y, -bias.X, 0);
            bias2 *= (view - target).Length / bias2.Length;
            target += bias2;
            view += bias2;
        }
        public void MoveVert(float k)
        {
            k *= l;
            var v = new Vector3(0, 0, k);
            target += v;
            view += v;
        }

        public ViewPoint()
        {
            view = new Vector3(500, 500, 500);
            _angle_view_beta = -35;
            _angle_view_alfa = -135;
            orientation_z = 1;

            fixTarget();
        }

        public float angle_view_beta //vertical angle (from XY plane towards Z axis)
        {
            set
            {
                _angle_view_beta = value;

                fixAngles();

                fixTarget();
            }
            get
            {
                return _angle_view_beta;
            }
        }

        public float angle_view_alfa//horizontal angle in XY plane
        {
            set
            {
                _angle_view_alfa = value;

                fixAngles();

                fixTarget();
            }
            get
            {
                return _angle_view_alfa;
            }
        }


        private void fixAngles()
        {
            while (_angle_view_beta > 179) _angle_view_beta = 179;
            while (_angle_view_beta < -179) _angle_view_beta = -179;
            while (_angle_view_alfa > 180) _angle_view_alfa -= 360;
            while (_angle_view_alfa < -180) _angle_view_alfa += 360;
        }

        double k_pi = Math.PI / 180;
        private void fixTarget()
        {
            float angle_beta_rad = (float)(_angle_view_beta * k_pi);
            float angle_alfa_rad = (float)(_angle_view_alfa * k_pi);

            target.Z = (float)(l * Math.Sin(angle_beta_rad));
            float viewX2plusviewY2 = (float)(l * Math.Cos(angle_beta_rad));
            target.X = (float)(viewX2plusviewY2 * Math.Cos(angle_alfa_rad));
            target.Y = (float)(viewX2plusviewY2 * Math.Sin(angle_alfa_rad));

            target += view;
        }

        public void setView(Vector3 view, Vector3 target)
        {
            this.view = view;
            this.target = target;

            var d = target - view;

            _angle_view_alfa = (float)(Math.Atan2(d.Y, d.X) / k_pi);//horizontal
            var l = Math.Sqrt(d.Y * d.Y + d.X * d.X);
            _angle_view_beta = (float)(Math.Atan2(d.Z, l) / k_pi);//vertical

            fixAngles();
            fixTarget();
        }


        public string GetInfo()
        {
            return string.Format("alpha {0}, beta {1}, v={2}, t={3}",
                angle_view_alfa, angle_view_beta, view.ToString(), target.ToString());
        }
    }
}
