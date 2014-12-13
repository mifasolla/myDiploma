using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace diploma_project_1.Graphs.GreedyAlg {

    class VertexPriority : IComparable<VertexPriority> {

        public int vertexNumber
        {
            get;
            private set;
        }

        public int vertexPriority
        {
            get;
            private set;
        }

        public VertexPriority(int vertex, int priority) {
            vertexNumber = vertex;
            vertexPriority = priority;
        }


        public int CompareTo(VertexPriority obj) {
            if (vertexPriority < obj.vertexPriority)
                return 1;
            else if (vertexPriority == obj.vertexPriority)
                return 0;
            
            return -1;
        }
        


       
    }

}
