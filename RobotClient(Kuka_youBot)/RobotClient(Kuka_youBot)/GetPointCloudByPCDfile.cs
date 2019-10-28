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
    public partial class GetPointCloudByPCDfile : Form
    {
        private Form1 _mainForm;

        public GetPointCloudByPCDfile(object parentMainForm)
        {
            InitializeComponent();
            _mainForm = parentMainForm as Form1;
        }

        private void GetPointCloudByPCDfile_Load(object sender, EventArgs e)
        {
            label2.Text = string.Empty;
            label3.Text = string.Empty;
            tbPCDfilePath.Enabled = false;
            tbCoordsFile.Enabled = false;
            label6.Text = string.Empty;
            btnConvertToCoordsPCDFileInformation.Enabled = false;
            numericUpDown1.Enabled = false;
        }

        private void btnOpenPCDFile_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.InitialDirectory = "c:\\";
                openFileDialog1.Filter = "pcd files (*.pcd)|*.pcd|All files (*.*)|*.*";
                openFileDialog1.RestoreDirectory = true;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    tbPCDfilePath.Text = openFileDialog1.FileName;
                btnConvertToCoordsPCDFileInformation.Enabled = true;
                numericUpDown1.Enabled = true;
                label2.ForeColor = Color.Green;
                label2.Text = "Операция выполнена!";
            }
            catch(Exception ex)
            {
                label2.ForeColor = Color.Red;
                label2.Text = "Ошибка!";
            }
        }

        private void btnConvertToCoordsPCDFileInformation_Click(object sender, EventArgs e)
        {
            label6.Text = "Операция выполняется..";
            label6.Refresh();
            try
            {
                string pcdFile = Encoding.UTF8.GetString(File.ReadAllBytes(tbPCDfilePath.Text));
                GetPCDfile(pcdFile);
                List<Point3D> coords = GetCoords(pcdFile, (int)numericUpDown1.Value, progressBar1);
                coords = ChangeCoords(coords);
                SetPointsInFile(coords);
                File.Delete(@"F:\test.txt");
                foreach (var coord in coords)
                    _mainForm.pointCloud.Add(coord);
                _mainForm.coeff = (int)numericUpDown1.Value;
                label3.ForeColor = Color.Green;
                label3.Text = "Операция выполнена!";
            }
            catch(Exception ex)
            {
                label3.ForeColor = Color.Red;
                label3.Text = "Ошибка!";
            }
            label6.Text = string.Empty;
        }

        private static void GetPCDfile(string text)
        {
            StreamWriter sw = new StreamWriter(@"F:\test.txt");
            if (sw != null)
                sw.Write(text);
            sw.Close();
        }

        private static double GetMinCoordX(List<Point3D> coords)
        {
            double tmp = coords[0].X;
            for (int i = 1; i < coords.Count; i++)
                if (tmp > coords[i].X)
                    tmp = coords[i].X;
            return tmp;
        }

        private static double GetMinCoordY(List<Point3D> coords)
        {
            double tmp = coords[0].Y;
            for (int i = 1; i < coords.Count; i++)
                if (tmp > coords[i].Y)
                    tmp = coords[i].Y;
            return tmp;
        }

        private static double GetMinCoordZ(List<Point3D> coords)
        {
            double tmp = coords[0].Z;
            for (int i = 1; i < coords.Count; i++)
                if (tmp > coords[i].Z)
                    tmp = coords[i].Z;
            return tmp;
        }

        private static List<Point3D> ChangeCoords(List<Point3D> coords)
        {
            double minX = GetMinCoordX(coords);
            double minY = GetMinCoordY(coords);
            double minZ = GetMinCoordZ(coords);
            for (int i = 0; i < coords.Count; i++)
            {
                if (minX < 0)
                    coords[i] = new Point3D(coords[i].X + Math.Abs(minX), coords[i].Y, coords[i].Z);
                if (minY < 0)
                    coords[i] = new Point3D(coords[i].X, coords[i].Y + Math.Abs(minY), coords[i].Z);
                if (minZ < 0)
                    coords[i] = new Point3D(coords[i].X, coords[i].Y, coords[i].Z + Math.Abs(minZ));
            }
            return coords;
        }

        private static List<Point3D> GetCoords(string pcdFile, int coeff, ProgressBar progressBar)
        {
            double x = 0, y = 0, z = 0;
            List<Point3D> coords = new List<Point3D>();
            string[] lines = pcdFile.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            progressBar.Minimum = 0;
            progressBar.Maximum = lines.Length - 11;
            progressBar.Step = 1;
            for (int index = 11; index < lines.Length; index++)
            {
                progressBar.Value++;
                try
                {
                    string[] lineArray = lines[index].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    x = Convert.ToDouble(lineArray[0], System.Globalization.CultureInfo.InvariantCulture) * coeff;
                    y = Convert.ToDouble(lineArray[1], System.Globalization.CultureInfo.InvariantCulture) * coeff;
                    z = Convert.ToDouble(lineArray[2], System.Globalization.CultureInfo.InvariantCulture) * coeff;
                    double ty = y * Math.Cos(1.570796) + z * Math.Sin(1.570796);
                    double tz = y * (-1) * Math.Sin(1.570796) + z * Math.Cos(1.570796);
                    coords.Add(new Point3D(x, ty, tz));
                }
                catch (FormatException e)
                {
                    continue;
                }
                catch (IndexOutOfRangeException e)
                {
                    continue;
                }
            }
            return coords;
        }

        private void SetPointsInFile(List<Point3D> coords)
        {
            string path = @"F:\ConvertedPointClouds\pointCloud" + Guid.NewGuid().ToString() + ".txt";
            tbCoordsFile.Text = path;
            StreamWriter sw = new StreamWriter(path);
            if (sw != null)
            {
                for (int index = 0; index < coords.Count; index++)
                    sw.WriteLine(coords[index]);
            }
            sw.Close();
        }
    }
}
