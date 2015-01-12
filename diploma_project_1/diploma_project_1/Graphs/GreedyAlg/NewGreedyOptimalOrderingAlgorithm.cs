using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using diploma_project_1.Utils;

namespace diploma_project_1.Graphs.GreedyAlg
{
    class NewGreedyOptimalOrderingAlgorithm : GreedyOptimalOrdering
    {
        
        
        // private GraphFragmentation newMatrix;

        //private int orderWidth;
        private int k;
        private GreedyOptimalOrdering supOrderingAlgorithm;
        List<List<int>> supOrderingSolution = new List<List<int>>();

        public NewGreedyOptimalOrderingAlgorithm(Graph myGraph, int orderWidth, int level)
            : base(myGraph, orderWidth)
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

            supOrderingAlgorithm = new SupOrderingAlgorithm(myGraph); 
            supOrderingSolution = supOrderingAlgorithm.solve();
            double[,] myMatrix = MyUtils.copyMatrix(myGraph.AdjacencyMatrix);

            vertices = defineSubgraphVertices(supOrderingSolution);
           // Console.Write(k);
            //Console.WriteLine();
            //for (int i = 0; i < vertices.Count; i++)
             //   Console.Write(vertices[i] + " ");
            //Console.WriteLine();

            vertexPriority = calculateVertexPriorities();
            myMatrix = changedMatrix(myMatrix, vertices, myGraph.Size);
            //for (int i = 0; i < myGraph.Size; i++)
            //{
            //    for (int j = 0; j < myGraph.Size; j++)
            //        Console.Write(myMatrix[i,j] + " ");
            //    Console.WriteLine();
            //}
      


               
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

        

        //public List<VertexPriority> calculateVertexPriorities(List<int> vertices, double[,] myMatrix)
        //{
        //    List<VertexPriority> vertexPriorities = new List<VertexPriority>();
        //    int sum = 0;

        //    for (int i = 0; i < vertices.Count; i++)
        //    {
        //        for (int j = 0; j < myGraph.Size; j++)
        //        {
        //            if (myMatrix[vertices[i], j] == 1) sum++;
        //        }

        //        vertexPriorities.Add(new VertexPriority(vertices[i], sum));
        //    }

        //    vertexPriorities.Sort();

        //    return vertexPriorities;
        //}

        public double[,] changedMatrix(double[,] myMatrix, List<int> vertices, int size)
        {
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    if (myMatrix[i, j] == 1)
                        if (!(vertices.Contains(i) && vertices.Contains(j)))
                            myMatrix[i, j] = -1;

            return myMatrix;
        }

        //public List<int> availableVertices(double[,] matrix, int size, List<int> vertices)
        //{
        //    List<int> availableVertices = new List<int>();
        //    int sum = 0;

        //    for (int j = 0; j < vertices.Count; j++)
        //    {
        //        for (int i = 0; i < myGraph.Size; i++)
        //            if (matrix[i, vertices[j]] == 1) sum++;
        //        if (sum == 0)
        //            availableVertices.Add(vertices[j]);
        //    }

        //    return availableVertices;

        //}
    }
}
