using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CollaborativeFiltering.SimilarityAlogrithm.Interface;

namespace CollaborativeFiltering.SimilarityAlogrithm.Service
{
    public class PredicateSimilarityMeasure : ISimilarityMeasure
    {
        public double calculate(double[] vector1, double[] vector2)
        {
            int k = vector1.Length;
            int same = 0;
            for (int i = 0; i < k; i++)
            {
                if (vector1[i] == vector2[i])
                {
                    same++;
                }
            }
            return (double)same / (double)k;
        }
    }
}
