using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace RobotClient_Kuka_youBot_
{
    public class PathRegion
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        public int minX { get; set; }
        [Required]
        public int minY { get; set; }
        [Required]
        public int minZ { get; set; }
        [Required]
        public int maxX { get; set; }
        [Required]
        public int maxY { get; set; }
        [Required]
        public int maxZ { get; set; }

        public PathRegion() { }

        public PathRegion(int xMin, int xMax, int yMin, int yMax, int zMin, int zMax)
        {
            minX = xMin;
            minY = yMin;
            minZ = zMin;
            maxX = xMax;
            maxY = yMax;
            maxZ = zMax;
        }

        public static RegionType GetRegionType(Point3D vertex, PathRegion regionDb)
        {
            if (vertex.X < regionDb.minX &&
                vertex.Y > regionDb.minY && vertex.Y < regionDb.maxY &&
                vertex.Z > regionDb.minZ && vertex.Z < regionDb.maxZ)
                return RegionType.One;
            if (vertex.X > regionDb.minX && vertex.X < regionDb.maxX &&
                vertex.Y < regionDb.minY &&
                vertex.Z > regionDb.minZ && vertex.Z < regionDb.maxZ)
                return RegionType.Two;
            if (vertex.X > regionDb.maxX &&
                vertex.Y > regionDb.minY && vertex.Y < regionDb.maxY &&
                vertex.Z > regionDb.minZ && vertex.Z < regionDb.maxZ)
                return RegionType.Three;
            if (vertex.X > regionDb.minX && vertex.X < regionDb.maxX &&
                vertex.Y > regionDb.minY && vertex.Y < regionDb.maxY &&
                vertex.Z > regionDb.maxZ)
                return RegionType.Four;
            if (vertex.X > regionDb.minX && vertex.X < regionDb.maxX &&
                vertex.Y > regionDb.minY && vertex.Y < regionDb.maxY &&
                vertex.Z < regionDb.minZ)
                return RegionType.Five;
            if (vertex.X > regionDb.minX && vertex.X < regionDb.maxX &&
                vertex.Y > regionDb.maxY &&
                vertex.Z > regionDb.minZ && vertex.Z < regionDb.maxZ)
                return RegionType.Six;
            return RegionType.None;
        }

        public static PathRegion GetNewPathRegionUsingDbRP(PathRegion oldRegion, RegionType regionType, Point3D vertex, int safeDistance)
        {
            PathRegion partionRegion = new PathRegion();
            switch (regionType)
            {
                case RegionType.One:
                    {
                        partionRegion.minX = (int)(vertex.X - safeDistance);
                        partionRegion.maxX = oldRegion.minX;
                        partionRegion.minY = oldRegion.minY;
                        partionRegion.maxY = oldRegion.maxY;
                        partionRegion.minZ = oldRegion.minZ;
                        partionRegion.maxZ = oldRegion.maxZ;
                        break;
                    }
                case RegionType.Two:
                    {
                        partionRegion.minX = oldRegion.minX;
                        partionRegion.maxX = oldRegion.maxX;
                        partionRegion.minY = (int)(vertex.Y - safeDistance);
                        partionRegion.maxY = oldRegion.minY;
                        partionRegion.minZ = oldRegion.minZ;
                        partionRegion.maxZ = oldRegion.maxZ;
                        break;
                    }
                case RegionType.Three:
                    {
                        partionRegion.minX = oldRegion.maxX;
                        partionRegion.maxX = (int)(vertex.X + safeDistance);
                        partionRegion.minY = oldRegion.minY;
                        partionRegion.maxY = oldRegion.maxX;
                        partionRegion.minZ = oldRegion.minZ;
                        partionRegion.maxZ = oldRegion.maxZ;
                        break;
                    }
                case RegionType.Four:
                    {
                        partionRegion.minX = oldRegion.minX;
                        partionRegion.maxX = oldRegion.maxX;
                        partionRegion.minY = oldRegion.minY;
                        partionRegion.maxY = oldRegion.maxY;
                        partionRegion.minZ = oldRegion.maxZ;
                        partionRegion.maxZ = (int)(vertex.Z + safeDistance);
                        break;
                    }
                case RegionType.Five:
                    {
                        partionRegion.minX = oldRegion.minX;
                        partionRegion.maxX = oldRegion.maxX;
                        partionRegion.minY = oldRegion.minY;
                        partionRegion.maxY = oldRegion.maxY;
                        partionRegion.minZ = (int)(vertex.Z - safeDistance);
                        partionRegion.maxZ = oldRegion.minZ;
                        break;
                    }
                case RegionType.Six:
                    {
                        partionRegion.minX = oldRegion.minX;
                        partionRegion.maxX = oldRegion.maxX;
                        partionRegion.minY = oldRegion.maxY;
                        partionRegion.maxY = (int)(vertex.Y + safeDistance);
                        partionRegion.minZ = oldRegion.minZ;
                        partionRegion.maxZ = oldRegion.maxZ;
                        break;
                    }
            }
            return partionRegion;
        }

        public static PathRegion ConnectTwoPathRegions(PathRegion oldRegion, PathRegion extraRegion)
        {
            return new PathRegion(
                oldRegion.minX < extraRegion.minX ? oldRegion.minX : extraRegion.minX,
                oldRegion.maxX > extraRegion.maxX ? oldRegion.maxX : extraRegion.maxX,
                oldRegion.minY < extraRegion.minY ? oldRegion.minY : extraRegion.minY,
                oldRegion.maxY > extraRegion.maxY ? oldRegion.maxY : extraRegion.maxY,
                oldRegion.minZ < extraRegion.minZ ? oldRegion.minZ : extraRegion.minZ,
                oldRegion.maxZ > extraRegion.maxZ ? oldRegion.maxZ : extraRegion.maxZ);
        }
    }
}

