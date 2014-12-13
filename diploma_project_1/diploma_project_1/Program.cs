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
        private static int orderingWidth = 7;

        static void Main(string[] args) {
            myGraph.getFromFile(fileName);
            myGraph.printToConsole();

            myAlgorithm = new GreedyOptimalOrdering(myGraph, orderingWidth);
            var solution = myAlgorithm.solve();
        }
    }

}
