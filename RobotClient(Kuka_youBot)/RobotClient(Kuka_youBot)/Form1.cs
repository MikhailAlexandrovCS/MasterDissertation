using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Media3D;

namespace RobotClient_Kuka_youBot_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public List<Point3D> pointCloud = new List<Point3D>();
        public int coeff;

        private void btnGetPointCloud_Click(object sender, EventArgs e)
        {
            GetPointCloudByPCDfile form = new GetPointCloudByPCDfile(this);
            form.ShowDialog();
        }

        private void btnGetPath_Click(object sender, EventArgs e)
        {
            //GetVertexes();
            //coeff = 100;
            GetPath form = new GetPath(pointCloud, coeff);
            form.ShowDialog();
        }

        private void GetVertexes()
        {
            StreamReader sr = new StreamReader(@"F:\ConvertedPointClouds\artificialPointCloud3130acd2-d992-4440-ab91-bab52cbb3d9b.txt");
            if (sr != null)
            {
                string s = null;
                while ((s = sr.ReadLine()) != null)
                {
                    string[] tmp = s.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);


                    pointCloud.Add(new Point3D(Convert.ToDouble(tmp[0]),
                        Convert.ToDouble(tmp[1]), Convert.ToDouble(tmp[2])));
                }
            }
            sr.Close();
        }
    }
}
