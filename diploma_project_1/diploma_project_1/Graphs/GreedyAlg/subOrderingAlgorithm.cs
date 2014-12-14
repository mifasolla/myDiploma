using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace diploma_project_1.Graphs.GreedyAlg
{
    class SubOrderingAlgorithm : IOrderingAlgorithm
    {
        private Graph myGraph;
        private double[,] workingAdjacencyMatrix = null;


        public SubOrderingAlgorithm(Graph myGraph)
        {
            this.myGraph = myGraph;
        }

        public List<List<int>> solve()
        {
            List<List<int>> subOrdering = new List<List<int>>();
            workingAdjacencyMatrix = myGraph.AdjacencyMatrix;
            List<int> availableVerticesList = availableVertices(workingAdjacencyMatrix, myGraph.Size);
            while (availableVerticesList.Count > 0)
            {
               
                subOrdering.Add(availableVerticesList);
                workingAdjacencyMatrix = recalculateWorkingMatrix(workingAdjacencyMatrix, availableVerticesList, myGraph.Size);
                availableVerticesList = null;
                availableVerticesList = availableVertices(workingAdjacencyMatrix, myGraph.Size);
            }
            return subOrdering;
        }

        private List<int> availableVertices(double[,] matrix, int size)
        {
            List<int> vertices = new List<int>();

            for (int j = 0; j < size; j++)
            {

                int sum = 0;

                for (int i = 0; i < size; i++)
                    if ((matrix[i, j] == 1) || (matrix[i, j] == -1)) sum++;

                if (sum == 0)
                    vertices.Add(j);
            }

            return vertices;
        }

        private double[,] recalculateWorkingMatrix(double[,] matrix, List<int> list, int size)
        {
            for (int j = 0; j < list.Count; j++)
                for (int i = 0; i < size; i++)
                {
                    if (matrix[list[j], i] == 1)
                        matrix[list[j], i] = 0;

                    matrix[i, list[j]] = -1;
                }


            return matrix;
        }
    }
}
