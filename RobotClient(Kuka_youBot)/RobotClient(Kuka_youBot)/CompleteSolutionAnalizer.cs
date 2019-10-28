using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace RobotClient_Kuka_youBot_
{
    public class CompleteSolutionAnalizer
    {
        public static int[,] GetAdjencyMatrix(string stringAdjencyMatrix)
        {
            string[] rows = stringAdjencyMatrix.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            int[,] adjencyMatrix = new int[rows.Length, rows.Length];
            for (int i = 0; i < rows.Length; i++)
            {
                string[] rowItems = rows[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < rowItems.Length; j++)
                    adjencyMatrix[i, j] = Convert.ToInt32(rowItems[j]);
            }
            return adjencyMatrix;
        }

        public static List<GraphVertex> GetGraphVertexes(string stringGraphVertexes)
        {
            List<GraphVertex> point3s = new List<GraphVertex>();
            string[] points = stringGraphVertexes.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < points.Length; i++)
            {
                string[] pointsItem = points[i].Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                point3s.Add(new GraphVertex(i, new Point3D(Convert.ToInt32(pointsItem[0]), Convert.ToInt32(pointsItem[1]), Convert.ToInt32(pointsItem[2])), true));
            }
            return point3s;
        }

        public static ICollection<Point3D> GetObstaclesVertexes(string stringGraphVertexes)
        {
            List<Point3D> point3s = new List<Point3D>();
            string[] points = stringGraphVertexes.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < points.Length; i++)
            {
                string[] pointsItem = points[i].Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                point3s.Add(new Point3D(Convert.ToDouble(pointsItem[0]), Convert.ToDouble(pointsItem[1]), Convert.ToDouble(pointsItem[2])));
            }
            return point3s;
        }
    }
}

