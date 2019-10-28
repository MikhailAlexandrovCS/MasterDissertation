using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace RobotClient_Kuka_youBot_
{
    public class ComparerItemsInalizer
    {
        public static int ComparerPointCloudComparerInPercenrage(IList<Point3D> currentPointCloud, IList<Point3D> databasePointCloud, PathRegion pathRegion)
        {
            int resultPercentage = 0;
            int countMatchingVertexes = 0;
            IList<Point3D> currentPointCloudVertexesInRegion = GetVertexesFromPointCloudInRegion(currentPointCloud, pathRegion);
            IList<Point3D> databasePointCloudVertexesInRegion = GetVertexesFromPointCloudInRegion(databasePointCloud, pathRegion);
            foreach (var point in currentPointCloudVertexesInRegion)
                if (databasePointCloudVertexesInRegion.Contains(point))
                    countMatchingVertexes++;
            try
            {
                resultPercentage = (countMatchingVertexes * 100) / databasePointCloudVertexesInRegion.Count;
            }
            catch (DivideByZeroException e)
            {
                resultPercentage = 0;
            }
            return resultPercentage;
        }

        private static bool IsVertexInRegionCheck(Point3D vertex, PathRegion pathRegion)
        {
            if (vertex.X >= pathRegion.minX && vertex.X <= pathRegion.maxX &&
                vertex.Y >= pathRegion.minY && vertex.Y <= pathRegion.maxY &&
                vertex.Z >= pathRegion.minZ && vertex.Z <= pathRegion.maxZ)
                return true;
            return false;
        }

        private static IList<Point3D> GetVertexesFromPointCloudInRegion(IList<Point3D> vertexes, PathRegion pathRegion)
        {
            List<Point3D> pointsInRegion = new List<Point3D>();
            for (int i = 0; i < vertexes.Count; i++)
                if (IsVertexInRegionCheck(vertexes[i], pathRegion))
                    pointsInRegion.Add(vertexes[i]);
            return pointsInRegion;
        }
    }
}
