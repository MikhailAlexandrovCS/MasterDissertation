using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace RobotClient_Kuka_youBot_
{
    public class PathParametersComparer
    {
        public static bool AnalizeSafeDistance(int safeDistanceCurrent, int safeDistanceFromDatabase)
        {
            return safeDistanceCurrent <= safeDistanceFromDatabase;
        }

        public static Tuple<bool, bool> RegionCompare(Point3D startPoint, Point3D endPoint, PathRegion pathRegion, int safeDistance)
        {
            if (pathRegion.maxX + safeDistance > startPoint.X && pathRegion.maxX + safeDistance > endPoint.X &&
                pathRegion.maxY + safeDistance > startPoint.Y && pathRegion.maxY + safeDistance > endPoint.Y &&
                pathRegion.maxZ + safeDistance > startPoint.Z && pathRegion.maxZ + safeDistance > endPoint.Z &&
                pathRegion.minX - safeDistance < startPoint.X && pathRegion.minX - safeDistance < endPoint.X &&
                pathRegion.minY - safeDistance < startPoint.Y && pathRegion.minY - safeDistance < endPoint.Y &&
                pathRegion.minZ - safeDistance < startPoint.Z && pathRegion.minZ - safeDistance < endPoint.Z)
                return new Tuple<bool, bool>(true, true);
            else
                if (pathRegion.maxX + safeDistance > startPoint.X && pathRegion.maxY + safeDistance > startPoint.Y &&
                pathRegion.maxZ + safeDistance > startPoint.Z && pathRegion.minX - safeDistance < startPoint.X &&
                pathRegion.minY - safeDistance < startPoint.Y && pathRegion.minZ - safeDistance < startPoint.Z)
                return new Tuple<bool, bool>(true, false);
            else
                if (pathRegion.maxX + safeDistance > endPoint.X && pathRegion.maxY + safeDistance > endPoint.Y &&
                pathRegion.maxZ + safeDistance > endPoint.Z && pathRegion.minX - safeDistance < endPoint.X &&
                pathRegion.minY - safeDistance < endPoint.Y && pathRegion.minZ - safeDistance < endPoint.Z)
                return new Tuple<bool, bool>(false, true);
            return new Tuple<bool, bool>(false, false);
        }
    }
}