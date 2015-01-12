using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using diploma_project_1.Utils;

namespace diploma_project_1.Graphs.GreedyAlg
{
    class GreedyGreedyAlgorithm : GreedyOptimalBackOrdering
    {
        private int k;
        private GreedyOptimalBackOrdering subOrderingAlgorithm;
        List<List<int>> subOrderingSolution = new List<List<int>>();

        public GreedyGreedyAlgorithm(Graph ofGraph, int orderWidth, int level)
            : base(ofGraph, orderWidth)
        {
            k = level;
        }

        public override List<List<int>> solve()
        {


            // newMatrix = new GraphFragmentation();

            List<List<int>> ordering = new List<List<int>>();

            List<int> vertices = new List<int>();
            List<int> availableVerticesList = new List<int>();
            List<VertexPriority> vertexPriority = new List<VertexPriority>();
            List<int> nextPosition = new List<int>();

            subOrderingAlgorithm = new SubOrderingAlgorithm(myGraph);
            subOrderingSolution = subOrderingAlgorithm.solve();
            double[,] myMatrix = MyUtils.copyMatrix(myGraph.AdjacencyMatrix);

            vertices = defineSubgraphVertices(subOrderingSolution);
           

            vertexPriority = calculateVertexPriorities();
            myMatrix = changedMatrix(myMatrix, vertices, myGraph.Size);
           




            availableVerticesList = base.availableVertices(myMatrix, myGraph.Size);

            while (availableVerticesList.Count > 0)
            {
                nextPosition = base.calculateNextOrderingPosition(availableVerticesList, vertexPriority);
                ordering.Add(nextPosition);
                myMatrix = base.recalculateWorkingMatrix(myMatrix, nextPosition, myGraph.Size);
                availableVerticesList = base.availableVertices(myMatrix, myGraph.Size);
            }

            return ordering;

        }


        private List<int> defineSubgraphVertices(List<List<int>> subOrderingSolution)
        {
            List<int> vertices = new List<int>();
            for (int i = 0; i < k; i++)
                for (int j = 0; j < subOrderingSolution[i].Count; j++)
                    vertices.Add(subOrderingSolution[i][j]);

            return vertices;
        }

        public double[,] changedMatrix(double[,] myMatrix, List<int> vertices, int size)
        {
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    if (myMatrix[i, j] == 1)
                        if (!(vertices.Contains(i) && vertices.Contains(j)))
                            myMatrix[i, j] = -1;

            return myMatrix;
        }
    }
}
