using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace diploma_project_1.Graphs.GreedyAlg
{
    class GreedyOptimalBackOrdering : GreedyOptimalOrdering
    {
        public GreedyOptimalBackOrdering(Graph ofGraph, int orderWidth)
            : base(ofGraph, orderWidth)
        {
        }

        public GreedyOptimalBackOrdering(Graph ofGraph)
            : base(ofGraph)
        {
        }

        public override double[,] recalculateWorkingMatrix(double[,] workingMatrix, List<int> verticesForNextPosition, int p)
        {
            for (int j = 0; j < verticesForNextPosition.Count; j++)
                for (int i = 0; i < p; i++)
                {
                    if (workingMatrix[i, verticesForNextPosition[j]] == 1)
                        workingMatrix[i, verticesForNextPosition[j]] = 0;

                    workingMatrix[verticesForNextPosition[j], i] = -1;
                }


            return workingMatrix;
        }

        public override List<int> availableVertices(double[,] workingMatrix, int p)
        {
            List<int> vertices = new List<int>();

            for (int i = 0; i < p; i++)
            {

                int sum = 0;

                for (int j = 0; j < p; j++)
                    if ((workingMatrix[i, j] == 1) || (workingMatrix[i, j] == -1)) sum++;

                if (sum == 0)
                    vertices.Add(i);
            }

            return vertices;
        }


        public override List<VertexPriority> calculateVertexPriorities()
        {
            List<VertexPriority> vertexPriorities = new List<VertexPriority>(myGraph.Size);
            for (int i = 0; i < myGraph.Size; i++)
                vertexPriorities.Add(new VertexPriority(i, myGraph.inboundEdgesToVertex(i)));

            vertexPriorities.Sort();
            return vertexPriorities;
        }


    }


}

