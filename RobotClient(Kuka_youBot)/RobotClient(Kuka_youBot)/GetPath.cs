using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Media3D;

namespace RobotClient_Kuka_youBot_
{
    public partial class GetPath : Form
    {
        public GetPath(List<Point3D> obstacles, int coeff)
        {
            InitializeComponent();
            _obstaclesPoints = obstacles;
            _coeff = coeff;
        }

        private List<Point3D> _obstaclesPoints = new List<Point3D>();
        private Point3D _startPoint = new Point3D();
        private Point3D _endPoint = new Point3D();
        private int _safeDistance;
        private Size3D _boxSize = new Size3D();
        private int _percentageComparer;
        private int[,] _adjencyMatrixManipulator;
        private List<GraphVertex> _graphVertices = new List<GraphVertex>();
        private int _iterations;
        private int _distanceBetweenPoints;
        private List<Point3D> _firstManipulatorPath = new List<Point3D>();
        private List<Point3D> _secondManipulatorPath = new List<Point3D>();
        private int _coeff;

        private void btnStartAlgoritm_Click(object sender, EventArgs e)
        {
            _startPoint = new Point3D((double)nudStartXVertex.Value, (double)nudStartYVertex.Value, (double)nudStartZVertex.Value);
            _endPoint = new Point3D((double)nudEndXVertex.Value, (double)nudEndYVertex.Value, (double)nudEndZVertex.Value);
            _boxSize = new Size3D((int)nudWidthObject.Value, (int)nudLengthObject.Value, (int)nudHeightObject.Value);
            _percentageComparer = (int)nudPercentagePointCloud.Value;
            _iterations = (int)nudIterationCount.Value;
            _distanceBetweenPoints = (int)nudDistanceBetweenVertexes.Value;
            _safeDistance = GetSafeDistance(_boxSize);
            rbLog.AppendText("Обработка введенной информации..\n");
            rbLog.ScrollToCaret();
            rbLog.Refresh();
            DateTimeOffset start = DateTimeOffset.Now;
            PathRegion finalPathRegion = new PathRegion();
            Stack<int> stackFirstManipulator = new Stack<int>();
            PathResultInformation pathResultInformation = new PathResultInformation();
            DatabaseInformationInputer dbGet = new DatabaseInformationInputer();
            rbLog.AppendText("Получение информации из базы данных..\n");
            rbLog.ScrollToCaret();
            rbLog.Refresh();
            var getAllDb = (from p in dbGet.info
                            join c in dbGet.pathRegions on p.regionGraph.id equals c.id
                            where (c.maxX >= _startPoint.X && c.minX <= _startPoint.X && c.maxY >= _startPoint.Y && c.minY <= _startPoint.Y &&
                            c.maxZ >= _startPoint.Z && c.minZ <= _startPoint.Z) ||
                            (c.maxX >= _endPoint.X && c.minX <= _endPoint.X && c.maxY >= _endPoint.Y && c.minY <= _endPoint.Y &&
                            c.maxZ >= _endPoint.Z && c.minZ <= _endPoint.Z)
                            select new
                            {
                                graphVertex = p.graphVertexes,
                                adjencyMatrix = p.adjencyMatrix,
                                obstaclesPoint = p.obstaclesPoint,
                                pathRegion = p.regionGraph,
                                safeDistance = p.safeDistance
                            }).ToList();
            rbLog.AppendText("Проверка подходящих вариантов из базы данных..\n");
            rbLog.ScrollToCaret();
            rbLog.Refresh();
            if (!getAllDb.Count.Equals(0))
            {
                for (int i = 0; i < getAllDb.Count; i++)
                {
                    PathRegion pathRegion = getAllDb[i].pathRegion;
                    Tuple<bool, bool> comparerResult = PathParametersComparer.RegionCompare(_startPoint, _endPoint, pathRegion, _safeDistance);
                    bool isSolutionFind = false;
                    if (!comparerResult.Equals(new Tuple<bool, bool>(false, false)) &&
                        ComparerItemsInalizer.ComparerPointCloudComparerInPercenrage(_obstaclesPoints,
                        (List<Point3D>)CompleteSolutionAnalizer.GetObstaclesVertexes(getAllDb[i].obstaclesPoint), pathRegion) >= _percentageComparer &&
                        PathParametersComparer.AnalizeSafeDistance(_safeDistance, getAllDb[i].safeDistance))
                    {
                        switch (comparerResult)
                        {
                            case var tuple when tuple.Item1.Equals(true) && tuple.Item2.Equals(false):
                                {
                                    rbLog.AppendText("Стартовая точка входит в регион. Идет достроение веротяностной карты (графа)..\n");
                                    rbLog.ScrollToCaret();
                                    rbLog.Refresh();
                                    isSolutionFind = true;
                                    _adjencyMatrixManipulator = CompleteSolutionAnalizer.GetAdjencyMatrix(getAllDb[i].adjencyMatrix);
                                    _graphVertices = CompleteSolutionAnalizer.GetGraphVertexes(getAllDb[i].graphVertex);
                                    _graphVertices.Add(new GraphVertex(_graphVertices.Count, _startPoint, true));
                                    _graphVertices.Add(new GraphVertex(_graphVertices.Count, _endPoint, true));
                                    SolutionFinderFromDb(_endPoint, pathRegion, ref finalPathRegion, ref isSolutionFind, _adjencyMatrixManipulator, _graphVertices,
                                         _graphVertices.Count - 1, _graphVertices.Count - 2);
                                    break;
                                }
                            case var tuple when tuple.Item1.Equals(false) && tuple.Item2.Equals(true):
                                {
                                    rbLog.AppendText("Конечная точка входит в регион. Идет достроение вероятностной карты (графа)..\n");
                                    rbLog.ScrollToCaret();
                                    rbLog.Refresh();
                                    isSolutionFind = true;
                                    _adjencyMatrixManipulator = CompleteSolutionAnalizer.GetAdjencyMatrix(getAllDb[i].adjencyMatrix);
                                    _graphVertices = CompleteSolutionAnalizer.GetGraphVertexes(getAllDb[i].graphVertex);
                                    _graphVertices.Add(new GraphVertex(_graphVertices.Count, _startPoint, true));
                                    _graphVertices.Add(new GraphVertex(_graphVertices.Count, _endPoint, true));
                                    SolutionFinderFromDb(_startPoint, pathRegion, ref finalPathRegion, ref isSolutionFind, _adjencyMatrixManipulator, _graphVertices,
                                        _graphVertices.Count - 1, _graphVertices.Count - 2);
                                    break;
                                }
                            case var tuple when tuple.Item1.Equals(true) && tuple.Item2.Equals(true):
                                {
                                    rbLog.AppendText("Обе точки входят в регион..\n");
                                    rbLog.AppendText("Добавляем точки в карту..\n");
                                    rbLog.ScrollToCaret();
                                    rbLog.Refresh();
                                    _adjencyMatrixManipulator = CompleteSolutionAnalizer.GetAdjencyMatrix(getAllDb[i].adjencyMatrix);
                                    _graphVertices = CompleteSolutionAnalizer.GetGraphVertexes(getAllDb[i].graphVertex);
                                    List<GraphVertex> startEndVertexes = new List<GraphVertex>();
                                    startEndVertexes.AddRange(new List<GraphVertex> {
                                    new GraphVertex(_graphVertices.Count, _startPoint, true),
                                    new GraphVertex(_graphVertices.Count + 1, _endPoint, true)});
                                    _adjencyMatrixManipulator = ResizeAdjencyMatrixManipulator(_adjencyMatrixManipulator, startEndVertexes.Count);
                                    TryToConnect(_graphVertices, _distanceBetweenPoints, _adjencyMatrixManipulator, AlgoritmTryType.DatabaseDataWork, startEndVertexes); ///////
                                    _graphVertices.AddRange(startEndVertexes);
                                    Deikstra(ref _graphVertices, _adjencyMatrixManipulator, _graphVertices.Count - 2);
                                    stackFirstManipulator = GetPathAfterDeikstra(_graphVertices, _adjencyMatrixManipulator, _graphVertices.Count - 1);
                                    GetFinalPathAndDraw(stackFirstManipulator, Brushes.Purple, _graphVertices, _startPoint, _endPoint);
                                    finalPathRegion = pathRegion;
                                    isSolutionFind = true;
                                    break;
                                }
                        }
                        if (isSolutionFind)
                        {
                            rbLog.AppendText("Решение найдено, происходит сохранение в базу данных..\n");
                            rbLog.ScrollToCaret();
                            rbLog.Refresh();
                            pathResultInformation = new PathResultInformation(finalPathRegion, _obstaclesPoints, _adjencyMatrixManipulator, _graphVertices, _safeDistance);
                            break;
                        }
                    }
                    if (!isSolutionFind)
                    {
                        _adjencyMatrixManipulator = new int[0, 0];
                        _graphVertices.Clear();
                        rbLog.AppendText("Не было найдено подходящих вариантов из базы данных..\n");
                        rbLog.ScrollToCaret();
                        rbLog.Refresh();
                    }
                }
            }
            else
            {
                rbLog.AppendText("Подходящих решений не найдено. Поиск нового решения..\n");
                rbLog.ScrollToCaret();
                rbLog.Refresh();
                WorkAtOverAgain(ref stackFirstManipulator, ref pathResultInformation);
            }
            try
            {
                DatabaseInformationInputer dbOut = new DatabaseInformationInputer();
                dbOut.info.Add(pathResultInformation);
                dbOut.SaveChanges();
            }
            catch (Exception ex)
            {
                WorkAtOverAgain(ref stackFirstManipulator, ref pathResultInformation);

            }
            MessageBox.Show($"Путь найден!\n{start.ToString()}\n{DateTimeOffset.Now.ToString()}\nВсего вершин: {_graphVertices.Count}", "Оповещение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private int GetSafeDistance(Size3D boxSize)
        {
            int safeDistance = (int)(boxSize.X > boxSize.Y ? boxSize.X : boxSize.Y);
            if (safeDistance.Equals((int)boxSize.X))
                safeDistance = (int)(boxSize.X > boxSize.Z ? boxSize.X : boxSize.Z);
            else
                safeDistance = (int)(boxSize.Y > boxSize.Z ? boxSize.Y : boxSize.Z);
            return safeDistance;
        }

        private void GetPath_Load(object sender, EventArgs e)
        {
            rbAutomatic.Checked = true;
            Tuple<double, double> resultX = GetMaxMinCoordForInfo(_obstaclesPoints, CoordinateType.X);
            lbminX.Text += resultX.Item1;
            lbmaxX.Text += resultX.Item2;
            Tuple<double, double> resultY = GetMaxMinCoordForInfo(_obstaclesPoints, CoordinateType.Y);
            lbminY.Text += resultY.Item1;
            lbmaxY.Text += resultY.Item2;
            Tuple<double, double> resultZ = GetMaxMinCoordForInfo(_obstaclesPoints, CoordinateType.Z);
            lbminZ.Text += resultZ.Item1;
            lbmaxZ.Text += resultZ.Item2;
            nudStartXVertex.Minimum = nudEndXVertex.Minimum = (decimal)resultX.Item1;
            nudStartYVertex.Minimum = nudEndYVertex.Minimum = (decimal)resultY.Item1;
            nudStartZVertex.Minimum = nudEndZVertex.Minimum = (decimal)resultZ.Item1;
            nudStartXVertex.Maximum = nudEndXVertex.Maximum = (decimal)resultX.Item2;
            nudStartYVertex.Maximum = nudEndYVertex.Maximum = (decimal)resultY.Item2;
            nudStartZVertex.Maximum = nudEndZVertex.Maximum = (decimal)resultZ.Item2;
            lbPointCloudVertexCount.Text += _obstaclesPoints.Count;
        }

        private double GetMinCoord(List<double> values, MaxMinType maxMinType)
        {
            double value = values[0];
            for (int i = 0; i < values.Count; i++)
            {
                switch(maxMinType)
                {
                    case MaxMinType.Max:
                        {
                            if (value <= values[i])
                                value = values[i];
                            break;
                        }
                    case MaxMinType.Min:
                        {
                            if (value >= values[i])
                                value = values[i];
                            break;
                        }
                }             
            }
            return value;
        }

        private Tuple<double, double> GetMaxMinCoordForInfo(List<Point3D> obstacles, CoordinateType coordinateType)
        {
            Tuple<double, double> coords = new Tuple<double, double>(-1, -1);
            switch (coordinateType)
            {
                case CoordinateType.X:
                    {
                        double minX = GetMinCoord(obstacles.Select(coord => coord.X).ToList(), MaxMinType.Min);
                        double maxX = GetMinCoord(obstacles.Select(coord => coord.X).ToList(), MaxMinType.Max);
                        coords = new Tuple<double, double>(minX, maxX);
                        break;
                    }
                case CoordinateType.Y:
                    {
                        double minY = GetMinCoord(obstacles.Select(coord => coord.Y).ToList(), MaxMinType.Min);
                        double maxY = GetMinCoord(obstacles.Select(coord => coord.Y).ToList(), MaxMinType.Max);
                        coords = new Tuple<double, double>(minY, maxY);
                        break;
                    }
                case CoordinateType.Z:
                    {
                        double minZ = GetMinCoord(obstacles.Select(coord => coord.Z).ToList(), MaxMinType.Min);
                        double maxZ = GetMinCoord(obstacles.Select(coord => coord.Z).ToList(), MaxMinType.Max);
                        coords = new Tuple<double, double>(minZ, maxZ);
                        break;
                    }
            }
            return coords;
        }

        private void WorkAtOverAgain(ref Stack<int> stackFirstManipulator, ref PathResultInformation pathResultInformation)
        {
            int iteration = 0;
            Initalize();
            int pathStackCapacity = -1;
            Tuple<int, int, int, int, int, int> region = GetRegionMarks(_startPoint, _endPoint);
            rbLog.AppendText("Определяем регион вхождения точек..\n");
            rbLog.ScrollToCaret();
            rbLog.Refresh();
            PathRegion pathRegion = new PathRegion(region.Item1, region.Item4, region.Item2, region.Item5, region.Item3, region.Item6);
            do
            {
                rbLog.AppendText("Составляем вероятностную дорожную карту..\n");
                rbLog.ScrollToCaret();
                rbLog.Refresh();
                GetGraphPath(1, 0, pathRegion);
                rbLog.AppendText("Обработка графа алгоритмом Дейкстры..\n");
                rbLog.ScrollToCaret();
                rbLog.ScrollToCaret();
                rbLog.Refresh();
                Deikstra(ref _graphVertices, _adjencyMatrixManipulator);
                rbLog.AppendText("Попытка найти путь в графе..\n");
                rbLog.ScrollToCaret();
                rbLog.Refresh();
                stackFirstManipulator = GetPathAfterDeikstra(_graphVertices, _adjencyMatrixManipulator);
                pathStackCapacity = stackFirstManipulator.Count;
                if (stackFirstManipulator.Count > 1)
                {
                    rbLog.AppendText("Путь найден..\n");
                    rbLog.ScrollToCaret();
                    rbLog.Refresh();
                    GetFinalPathAndDraw(stackFirstManipulator, Brushes.Purple, _graphVertices, _startPoint, _endPoint);
                }
                iteration++;
                if (iteration >= 2 && iteration <= 4)
                {
                    rbLog.Text += "Расширяем регион карты..\n";
                    rbLog.ScrollToCaret();
                    rbLog.Refresh();
                    pathRegion = new PathRegion((pathRegion.minX - _safeDistance) > 0 ? pathRegion.minX - _safeDistance : 0,
                        pathRegion.maxX + _safeDistance, (pathRegion.minY - _safeDistance) > 0 ? pathRegion.minY - _safeDistance : 0,
                        pathRegion.maxY + _safeDistance, (pathRegion.minZ - _safeDistance) > 0 ? pathRegion.minZ - _safeDistance : 0, pathRegion.maxZ + _safeDistance);
                }
            }
            while (pathStackCapacity <= 1);
            rbLog.AppendText("Сохраняем решение в базу данных..\n");
            rbLog.ScrollToCaret();
            rbLog.Refresh();
            pathResultInformation =
                new PathResultInformation(
                    new PathRegion(region.Item1, region.Item4, region.Item2, region.Item5, region.Item3, region.Item6),
                    _obstaclesPoints, _adjencyMatrixManipulator, _graphVertices, _safeDistance);
        }

        private void Initalize()
        {
            rbLog.AppendText("Инициализируем вершины вероятностной дорожной карты..\n");
            rbLog.ScrollToCaret();
            rbLog.Refresh();
            _graphVertices.Add(new GraphVertex(0, _startPoint, true));
            _graphVertices.Add(new GraphVertex(1, _endPoint, true));
            _adjencyMatrixManipulator = new int[0, 0];
        }

        private void GetGraphPath(int pEnd, int pStart, PathRegion pathRegion)
        {
            List<Point3D> testFirstManipulator = new List<Point3D>();
            rbLog.AppendText("Добавляем вершины..\n");
            rbLog.ScrollToCaret();
            rbLog.Refresh();
            for (int i = 0; i < _iterations; i++)
            {
                Point3D currentPoint = new Point3D(TrueRandom.GetRandomInt(pathRegion.minX, pathRegion.maxX), TrueRandom.GetRandomInt(pathRegion.minY, pathRegion.maxY),
                    TrueRandom.GetRandomInt(pathRegion.minZ, pathRegion.maxZ));
                testFirstManipulator.Add(currentPoint);
                _graphVertices.Add(new GraphVertex(i, currentPoint, true));
            }
            rbLog.AppendText("Удаление некорректных вершин..\n");
            rbLog.ScrollToCaret();
            rbLog.Refresh();
            IsCorrectVertex(ref _graphVertices, _safeDistance, pEnd, pStart);
            _adjencyMatrixManipulator = new int[_graphVertices.Count, _graphVertices.Count];
            for (int i = 0; i < _graphVertices.Count; i++)
                _graphVertices[i].Number = i;
            rbLog.AppendText("Составление матрицы смежности..\n");
            rbLog.ScrollToCaret();
            rbLog.Refresh();
            TryToConnect(_graphVertices, _distanceBetweenPoints, _adjencyMatrixManipulator, AlgoritmTryType.CleanDataWork);
        }

        private void IsCorrectVertex(ref List<GraphVertex> graphVertices, int safeDistance, int pEnd, int pStart)
        {
            foreach (var item in graphVertices)
                for (int i = 0; i < _obstaclesPoints.Count; i++)
                    if (Math.Abs(item.Coords.X - _obstaclesPoints[i].X) <= safeDistance &&
                        Math.Abs(item.Coords.Y - _obstaclesPoints[i].Y) <= safeDistance &&
                        Math.Abs(item.Coords.Z - _obstaclesPoints[i].Z) <= safeDistance &&
                        !graphVertices[pEnd].Equals(item) && !graphVertices[pStart].Equals(item))
                        item.Check = false;
            graphVertices.RemoveAll(x => x.Check.Equals(false));
        }

        private void GetFinalPathAndDraw(Stack<int> stack, Brush brush, List<GraphVertex> vertexes, Point3D startPoint, Point3D endPoint)
        {
            List<int> vertexesNumberPath = new List<int>();
            List<Point3D> pathPoints = new List<Point3D>();
            rbLog.AppendText("Восстанавливаем траекторию..\n");
            rbLog.ScrollToCaret();
            rbLog.Refresh();
            while (stack.Count > 0)
            {
                vertexesNumberPath.Add(stack.Peek());
                stack.Pop();
            }
            rbLog.AppendText("Сбор координат точек траектории..\n");
            rbLog.ScrollToCaret();
            rbLog.Refresh();
            for (int i = 0; i < vertexesNumberPath.Count; i++)
                pathPoints.Add(new Point3D(vertexes[vertexesNumberPath[i]].Coords.X, vertexes[vertexesNumberPath[i]].Coords.Y,
                    vertexes[vertexesNumberPath[i]].Coords.Z));
            rbLog.AppendText("Разбиение траектории на две - для каждого манипулятора..\n");
            rbLog.ScrollToCaret();
            rbLog.Refresh();
            for (int i = 0; i < pathPoints.Count; i++)
            {
                _firstManipulatorPath.Add(new Point3D(pathPoints[i].X, pathPoints[i].Y + (_boxSize.Y / 2), pathPoints[i].Z));
                _secondManipulatorPath.Add(new Point3D(pathPoints[i].X, pathPoints[i].Y - (_boxSize.Y / 2), pathPoints[i].Z));
            }
        }

        private Stack<int> GetPathAfterDeikstra(List<GraphVertex> vertexes, int[,] matrix, int pEnd = 1)
        {
            bool check = true;
            Stack<int> stack = new Stack<int>();
            int length = vertexes[pEnd].distance;
            stack.Push(pEnd);
            int counter = 0;
            while (length > 0)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    counter++;
                    if (matrix[pEnd, j] > 0 && vertexes[pEnd].distance - matrix[pEnd, j] == vertexes[j].distance)
                    {
                        counter = 0;
                        stack.Push(j);
                        length = length - matrix[pEnd, j];
                        pEnd = j;
                        break;
                    }
                    if (counter.Equals(matrix.GetLength(0)))
                    {
                        check = false;
                        break;
                    }

                }
                if (!check)
                    break;
            }
            return stack;
        }

        private double GetDistanceBetween2Points(Point3D start, Point3D end)
        {
            return Math.Sqrt(Math.Pow(end.X - start.X, 2) + Math.Pow(end.Y - start.Y, 2) + Math.Pow(end.Z - start.Z, 2));
        }

        private bool CheckForConnection(GraphVertex newVertex, GraphVertex treeVertex)
        {
            Point3D test13 = new Point3D(
                (newVertex.Coords.X + treeVertex.Coords.X * 0.3) / (1 + 0.3),
                (newVertex.Coords.Y + treeVertex.Coords.Y * 0.3) / (1 + 0.3),
                (newVertex.Coords.Z + treeVertex.Coords.Z * 0.3) / (1 + 0.3)
                );

            Point3D test23 = new Point3D(
                (newVertex.Coords.X + treeVertex.Coords.X * 0.67) / (1 + 0.67),
                (newVertex.Coords.Y + treeVertex.Coords.Y * 0.67) / (1 + 0.67),
                (newVertex.Coords.Z + treeVertex.Coords.Z * 0.67) / (1 + 0.67)
                );

            Point3D test33 = new Point3D(
                (newVertex.Coords.X + treeVertex.Coords.X * 0.9) / (1 + 0.9),
                (newVertex.Coords.Y + treeVertex.Coords.Y * 0.9) / (1 + 0.9),
                (newVertex.Coords.Z + treeVertex.Coords.Z * 0.9) / (1 + 0.9)
                );

            Point3D test43 = new Point3D(
                (newVertex.Coords.X + treeVertex.Coords.X * 0.5) / (1 + 0.5),
                (newVertex.Coords.Y + treeVertex.Coords.Y * 0.5) / (1 + 0.5),
                (newVertex.Coords.Z + treeVertex.Coords.Z * 0.5) / (1 + 0.5)
                );

            Point3D test53 = new Point3D(
                (newVertex.Coords.X + treeVertex.Coords.X * 0.8) / (1 + 0.8),
                (newVertex.Coords.Y + treeVertex.Coords.Y * 0.8) / (1 + 0.8),
                (newVertex.Coords.Z + treeVertex.Coords.Z * 0.8) / (1 + 0.8)
                );

            if (IsCorrectVertex(test13) && IsCorrectVertex(test23) && IsCorrectVertex(test33) && IsCorrectVertex(test43)
                && IsCorrectVertex(test53))
                return true;
            return false;
        }

        private bool IsCorrectVertex(Point3D point3D)
        {
            for (int i = 0; i < _obstaclesPoints.Count; i++)
                if (Math.Abs(point3D.X - _obstaclesPoints[i].X) <= _safeDistance &&
                    Math.Abs(point3D.Y - _obstaclesPoints[i].Y) <= _safeDistance &&
                    Math.Abs(point3D.Z - _obstaclesPoints[i].Z) <= _safeDistance)
                {
                    return false;
                }
            return true;
        }

        private void TryToConnect(List<GraphVertex> vertexes, int maxDistance, int[,] matrix, AlgoritmTryType algoritmTryType, List<GraphVertex> extraVertexes = null)
        {
            if (algoritmTryType.Equals(AlgoritmTryType.CleanDataWork))
            {
                for (int i = 0; i < vertexes.Count; i++)
                    for (int j = 0; j < vertexes.Count; j++)
                    {
                        if (i != j && GetDistanceBetween2Points(vertexes[i].Coords, vertexes[j].Coords) <= _distanceBetweenPoints
                        && CheckForConnection(vertexes[i], vertexes[j]))
                            matrix[vertexes[i].Number, vertexes[j].Number] = matrix[vertexes[j].Number, vertexes[i].Number] =
                                (int)GetDistanceBetween2Points(vertexes[i].Coords, vertexes[j].Coords);
                    }
            }
            if (algoritmTryType.Equals(AlgoritmTryType.DatabaseDataWork))
            {
                for (int i = 0; i < extraVertexes.Count; i++)
                    for (int j = 0; j < vertexes.Count; j++)
                        if (i != j && GetDistanceBetween2Points(extraVertexes[i].Coords, vertexes[j].Coords) <= _distanceBetweenPoints
                        && CheckForConnection(extraVertexes[i], vertexes[j]))
                            matrix[extraVertexes[i].Number, vertexes[j].Number] = matrix[vertexes[j].Number, extraVertexes[i].Number] =
                                (int)GetDistanceBetween2Points(extraVertexes[i].Coords, vertexes[j].Coords);
            }
        }

        private int[,] ResizeAdjencyMatrixManipulator(int[,] adjencyMatrixManipulator, int addCount)
        {
            int[,] newM = new int[adjencyMatrixManipulator.GetLength(0) + addCount, adjencyMatrixManipulator.GetLength(1) + addCount];
            for (int i = 0; i < adjencyMatrixManipulator.GetLength(0); i++)
                for (int j = 0; j < adjencyMatrixManipulator.GetLength(1); j++)
                    newM[i, j] = adjencyMatrixManipulator[i, j];
            return newM;
        }

        private int GetIndexVertex(Point3D vertex)
        {
            int index = -1;
            for (int i = 0; i < _graphVertices.Count; i++)
                if (_graphVertices[i].Coords.Equals(vertex))
                {
                    index = i;
                    break;
                }
            return index;
        }

        private void SolutionFinderFromDb(Point3D vertex, PathRegion pathRegion, ref PathRegion finalPathRegion, ref bool isSolutionFind, int[,] adjencyMatrix,
            List<GraphVertex> graphVertices, int pEnd, int pStart)
        {
            rbLog.AppendText("Определение подходящего региона..\n");
            rbLog.ScrollToCaret();
            rbLog.Refresh();
            RegionType regionType = PathRegion.GetRegionType(vertex, pathRegion);
            if (!regionType.Equals(RegionType.None))
            {
                rbLog.AppendText("Регион определен. Обновление региона..\n");
                rbLog.ScrollToCaret();
                rbLog.Refresh();
                PathRegion newExtraRegion = PathRegion.GetNewPathRegionUsingDbRP(pathRegion, regionType, vertex, _safeDistance);
                Stack<int> stackFirstManipulator = new Stack<int>();
                int iteration = 0;
                int pathStackCapacity = -1;
                do
                {
                    if (iteration.Equals(0))
                    {
                        rbLog.AppendText("Достраиваем граф на первой итерации..\n");
                        rbLog.ScrollToCaret();
                        rbLog.Refresh();
                        GetGraphPath(newExtraRegion, pEnd, pStart);
                    }
                    else
                    {
                        rbLog.AppendText("Добавляем вершины по общему региону..\n");
                        rbLog.ScrollToCaret();
                        rbLog.Refresh();
                        GetGraphPath(finalPathRegion, pEnd, pStart);
                    }
                    rbLog.AppendText("Обрабатываем карту алгоритмом Дейкстры..\n");
                    rbLog.ScrollToCaret();
                    rbLog.Refresh();
                    pStart = GetIndexVertex(_startPoint);
                    pEnd = GetIndexVertex(_endPoint);
                    Deikstra(ref _graphVertices, _adjencyMatrixManipulator, pStart);
                    rbLog.AppendText("Пытаемся найти путь..\n");
                    rbLog.ScrollToCaret();
                    rbLog.Refresh();
                    stackFirstManipulator = GetPathAfterDeikstra(_graphVertices, _adjencyMatrixManipulator, pEnd);
                    pathStackCapacity = stackFirstManipulator.Count;
                    rbLog.AppendText("Проверка, что путь найден..\n");
                    rbLog.ScrollToCaret();
                    rbLog.Refresh();
                    if (stackFirstManipulator.Count > 1)
                    {
                        rbLog.AppendText("Путь найден..\n");
                        rbLog.ScrollToCaret();
                        rbLog.Refresh();
                        GetFinalPathAndDraw(stackFirstManipulator, Brushes.Purple, _graphVertices, _startPoint, _endPoint);
                    }
                    else
                    {
                        rbLog.AppendText("Путь не найден..\n");
                        rbLog.ScrollToCaret();
                        rbLog.Refresh();
                    }
                    rbLog.AppendText("Обновляем регион..\n");
                    rbLog.ScrollToCaret();
                    rbLog.Refresh();
                    finalPathRegion = PathRegion.ConnectTwoPathRegions(pathRegion, newExtraRegion);
                    iteration++;
                }
                while (pathStackCapacity <= 1);
            }
            else
                isSolutionFind = false;
        }

        private int GetVertexMinDist(List<GraphVertex> vertexes)
        {
            int ivertex = -1;
            int minDist = int.MaxValue;
            for (int i = 0; i < vertexes.Count; i++)
                if ((vertexes[i].isVisited == false) && (vertexes[i].distance < minDist))
                {
                    minDist = vertexes[i].distance;
                    ivertex = i;
                }
            return ivertex;
        }

        private void Deikstra(ref List<GraphVertex> vertexes, int[,] matrix, int pStart = 0)
        {
            for (int i = 0; i < vertexes.Count; i++)
            {
                vertexes[i].distance = int.MaxValue - 1;
                vertexes[i].isVisited = false;
            }

            vertexes[pStart].distance = 0;

            while (GetVertexMinDist(vertexes) != -1)
            {
                int iminDist = GetVertexMinDist(vertexes);
                if (iminDist == int.MaxValue - 1)
                    break;
                for (int i = 0; i < vertexes.Count; i++)
                    if ((matrix[iminDist, i] != 0) && vertexes[i].isVisited == false)
                        if (vertexes[iminDist].distance + matrix[iminDist, i] < vertexes[i].distance)
                            vertexes[i].distance = vertexes[iminDist].distance + matrix[iminDist, i];
                vertexes[iminDist].isVisited = true;
            }
        }

        private void GetGraphPath(PathRegion pathRegion, int pEnd, int pStart)
        {
            List<Point3D> testFirstManipulator = new List<Point3D>();
            int countGraphVerticesBeforeAdding = _graphVertices.Count;
            rbLog.AppendText("Добавляем вершины в граф..\n");
            rbLog.ScrollToCaret();
            rbLog.Refresh();
            for (int i = 0; i < _iterations; i++)
            {
                Point3D currentPoint = new Point3D(TrueRandom.GetRandomInt(pathRegion.minX, pathRegion.maxX), TrueRandom.GetRandomInt(pathRegion.minY, pathRegion.maxY),
                    TrueRandom.GetRandomInt(pathRegion.minZ, pathRegion.maxZ));
                testFirstManipulator.Add(currentPoint);
                _graphVertices.Add(new GraphVertex(countGraphVerticesBeforeAdding + i, currentPoint, true));
            }
            rbLog.AppendText("Удаление некорректных вершин..\n");
            rbLog.ScrollToCaret();
            rbLog.Refresh();
            rbLog.AppendText("Расширяем матрицу весов..\n");
            rbLog.ScrollToCaret();
            rbLog.Refresh();
            IsCorrectVertex(ref _graphVertices, _safeDistance, pEnd, pStart);
            _adjencyMatrixManipulator = ResizeAdjencyMatrixManipulator(_adjencyMatrixManipulator, _graphVertices.Count - _adjencyMatrixManipulator.GetLength(0));
            int countLastAdjencyMatrix = _adjencyMatrixManipulator.GetLength(0);
            for (int i = countGraphVerticesBeforeAdding; i < _adjencyMatrixManipulator.GetLength(0); i++)
                _graphVertices[i].Number = i;
            rbLog.AppendText("Соединяем новые вершины..\n");
            rbLog.ScrollToCaret();
            rbLog.Refresh();
            TryToConnect(_graphVertices, _distanceBetweenPoints, _adjencyMatrixManipulator, AlgoritmTryType.CleanDataWork);
        }

        private Tuple<int, int, int, int, int, int> GetRegionMarks(Point3D start, Point3D end)
        {
            int epsilon = _safeDistance * 2;
            int minResX = ((int)(start.X < end.X ? start.X : end.X) - epsilon) < 0 ? 0 : (int)(start.X < end.X ? start.X : end.X) - epsilon;
            int minResY = ((int)(start.Y < end.Y ? start.Y : end.Y) - epsilon) < 0 ? 0 : (int)(start.Y < end.Y ? start.Y : end.Y) - epsilon;
            int minResZ = ((int)(start.Z < end.Z ? start.Z : end.Z) - epsilon) < 0 ? 0 : (int)(start.Z < end.Z ? start.Z : end.Z) - epsilon;
            int maxResX = ((int)(start.X > end.X ? start.X : end.X) + epsilon) < 0 ? 0 : (int)(start.X > end.X ? start.X : end.X) + epsilon;
            int maxResY = ((int)(start.Y > end.Y ? start.Y : end.Y) + epsilon) < 0 ? 0 : (int)(start.Y > end.Y ? start.Y : end.Y) + epsilon;
            int maxResZ = ((int)(start.Z > end.Z ? start.Z : end.Z) + epsilon) < 0 ? 0 : (int)(start.Z > end.Z ? start.Z : end.Z) + epsilon;
            if (start.X.Equals(end.X))
            {
                minResX /= 4;
                maxResX *= 4;
            }
            if (start.Y.Equals(end.Y))
            {
                minResY /= 4;
                maxResY *= 4;
            }
            if (start.Z.Equals(end.Z))
            {
                minResZ /= 4;
                maxResZ *= 4;
            }
            return new Tuple<int, int, int, int, int, int>(minResX, minResY, minResZ, maxResX, maxResY, maxResZ);
        }

        private void rbAutomatic_CheckedChanged(object sender, EventArgs e)
        {
            if(rbAutomatic.Checked)
            {
                nudIterationCount.Value = 200;
                nudPercentagePointCloud.Value = 95;
                nudDistanceBetweenVertexes.Value = _coeff / 2;
                nudIterationCount.ReadOnly = nudPercentagePointCloud.ReadOnly = nudDistanceBetweenVertexes.ReadOnly = true;
                nudIterationCount.Enabled = nudPercentagePointCloud.Enabled = nudDistanceBetweenVertexes.Enabled = false;
            }
            else
            {
                nudIterationCount.ReadOnly = nudPercentagePointCloud.ReadOnly = nudDistanceBetweenVertexes.ReadOnly = false;
                nudIterationCount.Enabled = nudPercentagePointCloud.Enabled = nudDistanceBetweenVertexes.Enabled = true;
            }
        }

        private int GetValueFromLabel(Label label)
        {
            return Convert.ToInt32(Convert.ToDouble(label.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[3]));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Get2DPicture form = new Get2DPicture(_obstaclesPoints, new Size(GetValueFromLabel(lbmaxX), GetValueFromLabel(lbmaxY)), _firstManipulatorPath,
                _secondManipulatorPath, _graphVertices, _adjencyMatrixManipulator, _startPoint, _endPoint);
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PreviewObjectType previewObjectType;
            if (MessageBox.Show("На 3D отображении отобразить стартовую и конечные точки реального размера?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                .Equals(DialogResult.Yes))
                previewObjectType = PreviewObjectType.RealValueObject;
            else
                previewObjectType = PreviewObjectType.None;
            Get3DPicture form = new Get3DPicture(_obstaclesPoints, _firstManipulatorPath, _secondManipulatorPath, 
                GetSafeDistance(new Size3D((int)nudWidthObject.Value, (int)nudLengthObject.Value, (int)nudHeightObject.Value)), previewObjectType);
            form.ShowDialog();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            PreviewObjectType previewObjectType;
            if (MessageBox.Show("На 3D отображении отобразить стартовую и конечные точки реального размера?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                .Equals(DialogResult.Yes))
                previewObjectType = PreviewObjectType.RealValueObject;
            else
                previewObjectType = PreviewObjectType.None;
            PreviewPicture form = new PreviewPicture(_obstaclesPoints, new Point3D((double)nudStartXVertex.Value, (double)nudStartYVertex.Value, (double)nudStartZVertex.Value),
                new Point3D((double)nudEndXVertex.Value, (double)nudEndYVertex.Value, (double)nudEndZVertex.Value), GetValueFromLabel(lbmaxX), GetValueFromLabel(lbmaxY),
                GetSafeDistance(new Size3D((int)nudWidthObject.Value, (int)nudLengthObject.Value, (int)nudHeightObject.Value)), previewObjectType);
            form.ShowDialog();
        }
    }
}
