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

        private static IOrderingAlgorithm myAlgorithm;
        private static GreedyOptimalOrdering myBackAlgorithm;
        private static GreedyOptimalBackOrdering subOr;
        private static GreedyOptimalOrdering supOr;
         

        private static int orderingWidth = 3;

        private static List<List<int>> solution = new List<List<int>>();
        private static List<List<int>> solutionSubOrdering = new List<List<int>>();
        private static List<List<int>> solutionSupOrdering = new List<List<int>>();
        private static List<List<int>> reverseSolution = new List<List<int>>();

        static void Main(string[] args) {
            myGraph.getFromFile(fileName);
            //myGraph.printToConsole();

            myAlgorithm = new GreedyOptimalOrdering(myGraph, orderingWidth);
            solution = myAlgorithm.solve();

            StreamWriter f = new StreamWriter("Ordering.txt");
            for (int i = 0; i < solution.Count; i++) {
                for (int j = 0; j < solution[i].Count; j++)
                    f.Write(solution[i][j] + "  ");
                f.WriteLine();
            }
            f.Close();



            subOr = new SubOrderingAlgorithm(myGraph);
            solutionSubOrdering = subOr.solve();

            printListToFile(solutionSubOrdering);

            myBackAlgorithm = new GreedyOptimalBackOrdering(myGraph, orderingWidth);
            reverseSolution = myBackAlgorithm.solve();

            StreamWriter f1 = new StreamWriter("BackOrdering.txt");
            for (int i = 0; i < reverseSolution.Count; i++)
            {
                for (int j = 0; j < reverseSolution[i].Count; j++)
                    f1.Write(reverseSolution[i][j] + "  ");
                f1.WriteLine();
            }
            f1.Close();

            supOr = new SupOrderingAlgorithm(myGraph);
            solutionSupOrdering = supOr.solve();

            StreamWriter f2 = new StreamWriter("SupOrder.txt");
            for (int i = 0; i < solutionSupOrdering.Count; i++)
            {
                for (int j = 0; j < solutionSupOrdering[i].Count; j++)
                    f2.Write(solutionSupOrdering[i][j] + "  ");
                f2.WriteLine();
            }
            f2.Close();
           



            //Console.Read();

        }


        public static void printListToFile(List<List<int>> list) {
            StreamWriter f = new StreamWriter("subOrder.txt");
            for (int i = 0; i < list.Count; i++) {
                for (int j = 0; j < list[i].Count; j++)
                    f.Write(list[i][j] + "  ");
                f.WriteLine();
            }
            f.Close();
        }
    }
}
