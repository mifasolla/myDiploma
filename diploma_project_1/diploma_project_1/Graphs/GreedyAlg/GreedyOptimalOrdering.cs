﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using diploma_project_1.Utils;

namespace diploma_project_1.Graphs.GreedyAlg
{

    class GreedyOptimalOrdering : IOrderingAlgorithm
    {

        protected Graph myGraph;
        protected int orderingWidth;


        // private HashSet<int> processedVertices = null;
        protected double[,] workingAdjacencyMatrix = null;

        

        public GreedyOptimalOrdering(Graph ofGraph, int orderingWidth)
        {
            myGraph = ofGraph;
            this.orderingWidth = orderingWidth;
        }

        public GreedyOptimalOrdering(Graph ofGraph)
        {
            myGraph = ofGraph;
        }


        public virtual List<List<int>> solve()
        {
            
            // processedVertices = new HashSet<int>();
            workingAdjacencyMatrix = MyUtils.copyMatrix(myGraph.AdjacencyMatrix);
            List<List<int>> ordering = new List<List<int>>();
            List<int> nextPosition = new List<int>();


            List<VertexPriority> vertexPriorities = calculateVertexPriorities();
           // List<VertexPriority> vertexPriorities1 = calculateVertexPriorities(nextPosition, workingAdjacencyMatrix); 
            List<int> availableVerticesList = availableVertices(workingAdjacencyMatrix, myGraph.Size);

            while (availableVerticesList.Count > 0)
            {
                if (vertexPriorities == null)
                    nextPosition = calculateNextOrderingPosition(availableVerticesList);
                else
                    nextPosition = calculateNextOrderingPosition(availableVerticesList, vertexPriorities);
                ordering.Add(nextPosition);
                workingAdjacencyMatrix = recalculateWorkingMatrix(workingAdjacencyMatrix, nextPosition, myGraph.Size);
                //  processedVertices.UnionWith(nextPosition);
                availableVerticesList = null;
                availableVerticesList = availableVertices(workingAdjacencyMatrix, myGraph.Size);
            }

            return ordering;
        }

        //public virtual List<VertexPriority> calculateVertexPriorities(List<int> nextPosition, double[,] workingAdjacencyMatrix)
        //{
        //    throw new NotImplementedException();
        //}

        public virtual List<VertexPriority> calculateVertexPriorities()
        {
            List<VertexPriority> vertexPriorities = new List<VertexPriority>(myGraph.Size);
            for (int i = 0; i < myGraph.Size; i++)
                vertexPriorities.Add(new VertexPriority(i, myGraph.outboundEdgesFromVertex(i)));

            vertexPriorities.Sort();
            return vertexPriorities;
        }

        public virtual double[,] recalculateWorkingMatrix(double[,] matrix, List<int> list, int size)
        {

            /// 
            /// В списке содержатся элементы, которые соответствуют вершинам,
            /// поставленным на очередное пустое место в упорядочении.
            /// 
            /// В матрице смежности обнуляются элементы в определённых столбцах,
            /// которые отвечают выбранным для упорядочения вершинам.
            ///

            for (int j = 0; j < list.Count; j++)
                for (int i = 0; i < size; i++)
                {
                    if (matrix[list[j], i] == 1)
                        matrix[list[j], i] = 0;

                    matrix[i, list[j]] = -1;
                }


            return matrix;
        }

        public virtual List<int> availableVertices(double[,] matrix, int size)
        {


            List<int> vertices = new List<int>();

            for (int j = 0; j < size; j++)
            {

                int sum = 0;

                for (int i = 0; i < size; i++)
                    if ((matrix[i, j] == 1) || (matrix[i, j] == -1)) sum++;

                if (sum == 0)
                    vertices.Add(j);
            }

            return vertices;
        }

        protected List<int> calculateNextOrderingPosition(List<int> availableVertices, List<VertexPriority> vertexPriorities)
        {

            List<int> verticesForPosition = new List<int>();


            if (availableVertices.Count <= orderingWidth)
                verticesForPosition = availableVertices;
            else
            {

                int selectedVertices = 0;
                foreach (VertexPriority priority in vertexPriorities)
                {
                    if (availableVertices.Contains(priority.vertexNumber))
                    {
                        verticesForPosition.Add(priority.vertexNumber);
                        if (++selectedVertices == orderingWidth)
                        {
                            break;
                        }
                    }
                }

            }

            return verticesForPosition;
        }

        protected List<int> calculateNextOrderingPosition(List<int> availableVertices)
        {
            return availableVertices;
        }


    }

}
