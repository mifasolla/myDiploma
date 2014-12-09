using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace diploma_project_1.Graphs.GreedyAlg {

    class GreedyOptimalOrdering : IOrderingAlgorithm {

        private Graph myGraph;
        private int orderingWidth;

      //  private HashSet<int> processedVertices = null;
        private double[,] workingAdjacencyMatrix = null;

        public GreedyOptimalOrdering(Graph ofGraph, int orderingWidth) {
            myGraph = ofGraph;
            this.orderingWidth = orderingWidth;
        }

         
        public List<List<int>> solve() {
           // processedVertices = new HashSet<int>();
            workingAdjacencyMatrix = myGraph.AdjacencyMatrix;
            List<List<int>> ordering = new List<List<int>>();

            List<VertexPriority> vertexPriorities = calculateVertexPriorities();

            List<int> availableVerticesList = availableVertices(workingAdjacencyMatrix, myGraph.Size);

            while (availableVerticesList.Count > 0) {
                List<int> nextPosition = calculateNextOrderingPosition(availableVerticesList, vertexPriorities);
                ordering.Add(nextPosition);
                workingAdjacencyMatrix = recalculateWorkingMatrix(workingAdjacencyMatrix, nextPosition, myGraph.Size);
               // processedVertices.UnionWith(nextPosition);
                availableVerticesList = availableVertices(workingAdjacencyMatrix, myGraph.Size);
            }

            return ordering;
        }

        private List<VertexPriority> calculateVertexPriorities() {
            List<VertexPriority> vertexPriorities = new List<VertexPriority>(myGraph.Size);
            for (int i = 0; i < myGraph.Size; i++)
                vertexPriorities.Add(new VertexPriority(i, myGraph.outboundEdgesFromVertex(i)));

            vertexPriorities.Sort();
            return vertexPriorities;
        }

        private double[,] recalculateWorkingMatrix(double[,] matrix, List<int> list, int size) {

           // int k = processedVertices.Count;
            // int [] massiv = new int [k];

            // processedVertices.CopyTo(massiv);

            /// 
            /// В списке содержатся элементы, которые соответствуют вершинам,
            /// поставленным на очередное пустое место в упорядочении.
            /// 
            /// В матрице смежности обнуляются элементы в определённых столбцах,
            /// которые отвечают выбранным для упорядочения вершинам.
            ///
            
            for (int j = 0; j < list.Count; j++)
                for (int i = 0; i < size; i++)
                    matrix[list[j], i] = 0;

                return matrix;
        }

        private List<int> availableVertices(double[,] matrix, int size) {

            int sum = 0;
            List<int> vertices = new List<int>();

            for (int j = 0; j < size; j++) {

                for (int i = 0; i < size; i++)
                    if (matrix[i, j] == 1) sum++;

                if (sum == 0)
                    vertices.Add(j);
            }

            return vertices;
        }

        private List<int> calculateNextOrderingPosition(List<int> availableVertices, List<VertexPriority> vertexPriorities) {

            List<int> verticesForPosition = new List<int>();
            
           
            if (availableVertices.Count <= orderingWidth)
                verticesForPosition = availableVertices;
            else {
                // Как выбрать orderingWidth элементов с availableVertices, у которых
                // самые большие значения приоритетов..
            }

            return verticesForPosition;
        }




    }

}
