using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace diploma_project_1.Graphs {

    class Graph {

        private List<List<int>> graphData = new List<List<int>>();

        private int size;
        private double[,] adjacencyMatrix = null;

        public int Size {
            get {
                return size;
            }
        }

        public double[,] AdjacencyMatrix {
            get {
                if (adjacencyMatrix == null) {
                    convertCraph();
                }

                return adjacencyMatrix;
            }
        }


        public void getFromFile(String fileName) {
            using (StreamReader streamReader = new StreamReader(fileName)) {
                string sw = streamReader.ReadLine();
                while (sw != null) {
                    List<int> line = sw.Split(' ').ToList().ConvertAll(item => int.Parse(item));
                    if (line.Count == 1 && line[0] == -1) {
                        line.Clear();
                    }
                    graphData.Add(line);
                    sw = streamReader.ReadLine();
                }

                size = graphData.Count;
                adjacencyMatrix = null;
            }
        }

        public void printToConsole() {
            for (int i = 0; i < graphData.Count; i++) {
                for (int j = 0; j < graphData[i].Count; j++)
                    Console.Write(graphData[i][j] + " ");
                Console.WriteLine();


            }
        }

        public int outboundEdgesFromVertex(int vertexNumber) {

            if (graphData[vertexNumber].Count == 1 && graphData[vertexNumber][0] < 0)
                return 0;

            else
                return graphData[vertexNumber].Count;
        }

        public int inboundEdgesToVertex(int vertexNumber) {
            int priority = 0;
            for (int i = 0; i < Size; i++)
                priority += (int)AdjacencyMatrix[i, vertexNumber];

            return priority;
        }
        private void convertCraph() {

            adjacencyMatrix = new double[size, size];

            for (int i = 0; i < size; i++) {
                List<int> list = new List<int>();
                list.AddRange(graphData[i]);
                for (int j = 0; j < graphData[i].Count; j++)
                    adjacencyMatrix[i, list[j]] = 1;
            }

        }


       
    }

}
