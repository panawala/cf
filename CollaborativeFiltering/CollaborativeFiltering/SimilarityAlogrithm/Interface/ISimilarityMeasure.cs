
namespace CollaborativeFiltering.SimilarityAlogrithm.Interface
{
    interface ISimilarityMeasure
    {
        double calculate(double[] vector1, double[] vector2);
    }
}
