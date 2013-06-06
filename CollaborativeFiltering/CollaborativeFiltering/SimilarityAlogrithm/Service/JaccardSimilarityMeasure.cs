using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CollaborativeFiltering.SimilarityAlogrithm.Interface;

namespace CollaborativeFiltering.SimilarityAlogrithm.Service
{
    public class JaccardSimilarityMeasure : ISimilarityMeasure
    {
        public double calculate(double[] vector1, double[] vector2)
        {
            int cross = 0;
            int union = 0;
            for (int i = 0; i < vector1.Length; i++)
            {
                if (vector1[i] != 0 || vector2[i] != 0)
                {
                    union++;
                }
                if (vector1[i] != 0 && vector2[i] != 0)
                {
                    cross++;
                }
            }
            return (double)cross / (double)union;
        }
    }
}
