﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace diploma_project_1.Graphs.GreedyAlg
{
    class SubOrderingAlgorithm : GreedyOptimalBackOrdering
    {


        public SubOrderingAlgorithm(Graph myGraph)
            : base(myGraph)
        {
        }

        public override List<VertexPriority> calculateVertexPriorities()
        {
            return null;
        }



    }
}
