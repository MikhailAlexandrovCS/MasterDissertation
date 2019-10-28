using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace RobotClient_Kuka_youBot_
{
    public class GraphVertex
    {
        public int Number { get; set; }
        public Point3D Coords { get; set; }
        public bool Check { get; set; }
        public int distance { get; set; }
        public bool isVisited { get; set; }

        public GraphVertex(int number, Point3D coords)
        {
            Number = number;
            Coords = coords;
        }

        public GraphVertex(int number, Point3D coords, bool check)
        {
            Number = number;
            Coords = coords;
            Check = check;
        }
    }
}