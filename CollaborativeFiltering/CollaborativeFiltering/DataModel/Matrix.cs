using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollaborativeFiltering.DataModel
{
    public class Matrix 
    {
        private double[,] data;
        
        public Matrix(int n)
        {
            data = new double[n, n];
        }

        public void SetData(int m, int n, double itemdata)
        {
            data[m, n] = itemdata;
        }

        public double GetData(int m, int n)
        {
            return data[m, n];
        }
    }
}
