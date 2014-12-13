using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using diploma_project_1.Graphs;
using diploma_project_1.Graphs.GreedyAlg;

namespace diploma_project_1 {

    class Program {

        const string fileName = "graph_1.txt";
        private static Graph myGraph = new Graph();
        private static IOrderingAlgorithm myAlgorithm, subOr, myBackAlgorithm;
        private static int orderingWidth = 3;
        private static List<List<int>> solution = new List<List<int>>();
        private static List<List<int>> solutionSubOrdering = new List<List<int>>();
        private static List<List<int>> reverseSolution = new List<List<int>>();

        static void Main(string[] args) {
            myGraph.getFromFile(fileName);
            //myGraph.printToConsole();

            //myAlgorithm = new GreedyOptimalOrdering(myGraph, orderingWidth);
           // solution = myAlgorithm.solve();
           // printListToFile(solution);

            //subOr = new subOrderingAlgorithm(myGraph);
            //solutionSubOrdering = subOr.solve();
            //printListToFile(solutionSubOrdering);

            myBackAlgorithm = new GreedyOptimalReverseOrdering(myGraph, orderingWidth);
            reverseSolution = myBackAlgorithm.solve();



            
            //Console.Read();

        }

        public static void printListToFile(List<List<int>> list)
        {
            StreamWriter f = new StreamWriter("subOrdering.txt") ;
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list[i].Count; j++)
                    f.Write(list[i][j] + "  ");
                f.WriteLine();
            }
            f.Close();
        }
    }
}
