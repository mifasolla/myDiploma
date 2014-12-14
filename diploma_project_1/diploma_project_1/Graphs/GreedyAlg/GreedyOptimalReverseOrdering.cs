using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using diploma_project_1.Utils;

namespace diploma_project_1.Graphs.GreedyAlg {
    class GreedyOptimalReverseOrdering : IOrderingAlgorithm {
        private Graph myGraph;
        private int orderWidth;

        private double[,] workingMatrix = null;

        public GreedyOptimalReverseOrdering(Graph myGraph, int orderWidth) {
            this.myGraph = myGraph;
            this.orderWidth = orderWidth;
        }

        public List<List<int>> solve() {
            List<List<int>> ordering = new List<List<int>>();
            workingMatrix = MyUtils.copyMatrix(myGraph.AdjacencyMatrix);
            List<VertexPriority> vertexPriorities = calculateVertexPriorities();
            List<int> availableVerticesList = availableVertices(workingMatrix, myGraph.Size);

            while (availableVerticesList.Count > 0) {
                List<int> verticesForNextPosition = calculateNextPosition(availableVerticesList, vertexPriorities, orderWidth);
                ordering.Add(verticesForNextPosition);
                workingMatrix = recalculateWorkingMatrix(workingMatrix, verticesForNextPosition, myGraph.Size);
                // verticesForNextPosition = null;
                availableVerticesList = availableVertices(workingMatrix, myGraph.Size);
            }
            return ordering;
        }


        private double[,] recalculateWorkingMatrix(double[,] workingMatrix, List<int> verticesForNextPosition, int p) {
            for (int j = 0; j < verticesForNextPosition.Count; j++)
                for (int i = 0; i < p; i++) {
                    if (workingMatrix[i, verticesForNextPosition[j]] == 1)
                        workingMatrix[i, verticesForNextPosition[j]] = 0;

                    workingMatrix[verticesForNextPosition[j], i] = -1;
                }


            return workingMatrix;
        }

        private List<int> calculateNextPosition(List<int> availableVerticesList, List<VertexPriority> vertexPriorities, int orderWidth) {
            List<int> verticesForPosition = new List<int>();


            if (availableVerticesList.Count <= orderWidth)
                verticesForPosition = availableVerticesList;

            else {

                int selectedVertices = 0;
                foreach (VertexPriority priority in vertexPriorities) {
                    if (availableVerticesList.Contains(priority.vertexNumber)) {
                        verticesForPosition.Add(priority.vertexNumber);
                        if (++selectedVertices == orderWidth) {
                            break;
                        }
                    }
                }
            }
            return verticesForPosition;
        }

        private List<int> availableVertices(double[,] workingMatrix, int p) {
            List<int> vertices = new List<int>();

            for (int i = 0; i < p; i++) {

                int sum = 0;

                for (int j = 0; j < p; j++)
                    if ((workingMatrix[i, j] == 1) || (workingMatrix[i, j] == -1)) sum++;

                if (sum == 0)
                    vertices.Add(i);
            }

            return vertices;
        }


        private List<VertexPriority> calculateVertexPriorities() {
            List<VertexPriority> vertexPriorities = new List<VertexPriority>(myGraph.Size);
            for (int i = 0; i < myGraph.Size; i++)
                vertexPriorities.Add(new VertexPriority(i, myGraph.outboundEdgesFromVertex(i)));

            vertexPriorities.Sort();
            return vertexPriorities;
        }

    }
}
