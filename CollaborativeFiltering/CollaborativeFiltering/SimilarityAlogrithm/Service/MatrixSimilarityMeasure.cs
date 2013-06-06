using CollaborativeFiltering.SimilarityAlogrithm.Interface;

namespace CollaborativeFiltering.SimilarityAlogrithm.Service
{
    public class MatrixSimilarityMeasure:ISimilarityMeasure
    {
        public double calculate(double[] vector1, double[] vector2)
        {
            double cross = 0d;
            double union = 0d;
            for (int i = 0; i < vector1.Length; i++)
            {
                if (vector1[i] != 0 && vector2[i] != 0)
                {
                    if (vector1[i] == vector2[i])
                    {
                        cross++;
                    }
                        union++;
                }
            }
            if (union != 0)
                return cross / union;
            else
                return 0;
        }

    }
}
