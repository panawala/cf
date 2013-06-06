using System;
using CollaborativeFiltering.SimilarityAlogrithm.Interface;

namespace CollaborativeFiltering.SimilarityAlogrithm.Service
{
    public class CosineSimilarityMeasure : ISimilarityMeasure
    {
        public double calculate(double[] vector1, double[] vector2)
        {
            double a = this.getDotProduct(vector1, vector2);
            double b = this.getNorm(vector1) * this.getNorm(vector2);
            return a / b;
        }

        private double getDotProduct(double[] v1, double[] v2) 
        {
            double sum = 0.0d;
            int n=v1.Length;
            for(int i=0;i<n;i++)
            {
                sum += v1[i] * v2[i];
            }
            return sum;
        }

        private double getNorm(double[] v)
        {
            double sum = 0.0d;
            int n = v.Length;
            for (int i = 0; i < n; i++)
            {
                sum += v[i] * v[i];
            }
            return Math.Sqrt(sum);
        }
    }
}
