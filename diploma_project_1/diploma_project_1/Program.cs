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
        private static GreedyOptimalOrdering newOrderingsAlgorithm;
        private static GreedyOptimalBackOrdering greedyOrdering; 
         

        private static int orderingWidth = 3;

        private static List<List<int>> solution = new List<List<int>>();
        private static List<List<int>> solutionSubOrdering = new List<List<int>>();
        private static List<List<int>> solutionSupOrdering = new List<List<int>>();
        private static List<List<int>> reverseSolution = new List<List<int>>();
        private static List<List<int>> solutions = new List<List<int>>();
        private static List<List<int>> greedySolutions = new List<List<int>>();

        static void Main(string[] args) {
            myGraph.getFromFile(fileName);
            myGraph.printToConsole();

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

            int level;
            
        
            supOr = new SupOrderingAlgorithm(myGraph);
            solutionSupOrdering = supOr.solve();
            level = solutionSupOrdering.Count;

            StreamWriter f2 = new StreamWriter("SupOrder.txt");
            for (int i = 0; i < solutionSupOrdering.Count; i++)
            {
                for (int j = 0; j < solutionSupOrdering[i].Count; j++)
                    f2.Write(solutionSupOrdering[i][j] + "  ");
                f2.WriteLine();
            }
            f2.Close();

            //for (int k = 2; k < level + 1; k++)
            //{
            //    Console.Write("Level is " + k);
            //    Console.WriteLine();
            //    newOrderingsAlgorithm = new NewGreedyOptimalOrderingAlgorithm(myGraph, orderingWidth, k);
            //    solutions = newOrderingsAlgorithm.solve();

            //    for (int i = 0; i < solutions.Count; i++)
            //    {
            //        for (int j = 0; j < solutions[i].Count; j++)
            //            Console.Write(solutions[i][j] + "  ");
            //        Console.WriteLine();
            //    }
            //    Console.WriteLine();
            //}

            for (int k = 2; k < solutionSubOrdering.Count + 1; k++)
            {
                Console.Write("Level is " + k);
                Console.WriteLine();
                greedyOrdering = new GreedyGreedyAlgorithm(myGraph, orderingWidth, k);
                greedySolutions = greedyOrdering.solve();

                for (int i = 0; i < greedySolutions.Count; i++)
                {
                    for (int j = 0; j < greedySolutions[i].Count; j++)
                        Console.Write(greedySolutions[i][j] + "  ");
                    Console.WriteLine();
                }
                Console.WriteLine();
            }

            Console.Read();

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
