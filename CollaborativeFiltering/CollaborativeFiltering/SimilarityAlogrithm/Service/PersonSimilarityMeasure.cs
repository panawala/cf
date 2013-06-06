using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CollaborativeFiltering.SimilarityAlogrithm.Interface;

namespace CollaborativeFiltering.SimilarityAlogrithm.Service
{
    public class PersonSimilarityMeasure : ISimilarityMeasure
    {
        public double calculate(double[] vector1, double[] vector2)
        {
            int n = vector1.Length;
            double rho = 0.0d;
            double avgV1 = this.getAverage(vector1);
            double avgV2 = this.getAverage(vector2);
            double sV1 = this.getStdDev(avgV1, vector1);
            double sV2 = this.getStdDev(avgV2, vector2);

            double v1v2 = 0;
            for (int i = 0; i < n; i++)
            {
                v1v2 += (vector1[i] - avgV1) * (vector2[i] - avgV2);
            }

            if (sV1 == 0.0d || sV2 == 0.0d)
            {
                double indV1 = 0.0d;
                double indV2 = 0.0d;
                for (int i = 0; i < n; i++)
                {
                    indV1 += (vector1[0] - vector1[i]);
                    indV2 += (vector2[0] - vector2[i]);
                }

                if (indV1 == 0.0d && indV2 == 0.0d)
                {
                    return 1.0d;
                }
                else
                {
                    if (sV1 == 0.0d)
                    {
                        sV1 = sV2;
                    }
                    else
                    {
                        sV2 = sV1;
                    }
                }
            }
            rho = v1v2 / ((double)n * (sV1 * sV2));
            return rho;
        }

        private double getAverage(double[] v)
        {
            double avg = 0;
            for (int i = 0; i < v.Length; i++)
            {
                avg += v[i];
            }
            return avg / (double)v.Length;
        }

        private double getStdDev(double m, double[] v)
        {
            double sigma = 0;
            for (int i = 0; i < v.Length; i++)
            {
                sigma += (v[i] - m) * (v[i] - m);
            }
            return Math.Sqrt(sigma / (double)v.Length);
        }

    }
}
