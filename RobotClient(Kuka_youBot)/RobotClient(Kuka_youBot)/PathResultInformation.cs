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
    public class PathResultInformation
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int infoId { get; set; }
        [Required]
        public PathRegion regionGraph { get; set; }
        [Required]
        public string obstaclesPoint { get; set; }
        [Required]
        public string adjencyMatrix { get; set; }
        [Required]
        public string graphVertexes { get; set; }
        [Required]
        public int safeDistance { get; set; }

        public PathResultInformation(PathRegion region, List<Point3D> obstacles, int[,] matrix, List<GraphVertex> graphVerts, int safeDist)
        {
            regionGraph = region;
            obstaclesPoint = FormInfo(InformationType.obstacleList, obstacles);
            adjencyMatrix = FormInfo(InformationType.matrix, null, matrix);
            graphVertexes = FormInfo(InformationType.grapgVertexes, GetCoordFromGraphVertex(graphVerts));
            safeDistance = safeDist;
        }

        public PathResultInformation() { }

        private string FormInfo(InformationType informationType, ICollection<Point3D> point3s = null, int[,] matrix = null)
        {
            const int border = 50;
            string result = null;
            switch (informationType)
            {
                case InformationType.obstacleList:
                case InformationType.grapgVertexes:
                    {
                        foreach (var item in point3s)
                            if (item.X >= regionGraph.minX - border && item.X <= regionGraph.maxX + border &&
                                item.Y >= regionGraph.minY - border && item.Y <= regionGraph.maxY + border &&
                                item.Z >= regionGraph.minZ - border && item.Z <= regionGraph.maxZ + border)
                                result += $"{item.X};{item.Y};{item.Z}|";
                        break;
                    }
                case InformationType.matrix:
                    {
                        for (int i = 0; i < matrix.GetLength(0); i++)
                        {
                            for (int j = 0; j < matrix.GetLength(1); j++)
                                result += matrix[i, j] + " ";
                            result += "|";
                        }
                        break;
                    }
            }
            return result;
        }

        private List<Point3D> GetCoordFromGraphVertex(List<GraphVertex> graphVertexes)
        {
            List<Point3D> tempSaveCoords = new List<Point3D>();
            foreach (var item in graphVertexes)
                tempSaveCoords.Add(item.Coords);
            return tempSaveCoords;
        }
    }
}

