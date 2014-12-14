using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace diploma_project_1.Utils {
    public static class MyUtils {

        public static double[,] copyMatrix(double[,] p) {
            double[,] copy = new double[p.GetLength(0), p.GetLength(1)];

            for (int i = 0; i < p.GetLength(0); i++) {
                for (int j = 0; j < p.GetLength(1); j++) {
                    copy[i, j] = p[i, j];
                }
            }

            return copy;
        }

    }
}
