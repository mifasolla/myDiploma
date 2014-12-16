using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using diploma_project_1.Graphs.GreedyAlg;
using diploma_project_1.Utils;

namespace diploma_project_1.Graphs
{
    class GraphFragmentation
    {
        private Graph myGraph;

        

        public double [,] subgraph(List<int> vertices, double[,] myMatrix, int i){

           // double[,] myMatrix = MyUtils.copyMatrix(myGraph.AdjacencyMatrix);
            //List<int> vertices = new List<int>(); 
           // List<List<int>> ordering = new List<List<int>>();
          //  GreedyOptimalOrdering order = new SubOrderingAlgorithm(myGraph);
            //ordering = order.solve();

           // for(int j = 0; j < ordering[i].Count; j++)
            //vertices.Add(ordering[i][j]);
            
            myMatrix = changedMatrix(myMatrix, vertices, myGraph.Size);
            return myMatrix;

        }

private double[,] changedMatrix(double[,] myMatrix,List<int> vertices, int size)
{
 	for(int i = 0; i < size; i++)
        for(int j = 0; j < size; j++)
        if(myMatrix[i,j] == 1)
            if(!(vertices.Contains(i) && vertices.Contains(j)))
                myMatrix[i,j] = 0;

    return myMatrix;
}
    }
}

