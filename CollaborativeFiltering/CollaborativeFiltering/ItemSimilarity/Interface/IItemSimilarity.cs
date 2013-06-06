using CollaborativeFiltering.Model;
using CollaborativeFiltering.SimilarityAlogrithm.Interface;

namespace CollaborativeFiltering.ItemSimilarity.Interface
{
    public interface IItemSimilarity
    {
        double Calculate(int itemA, int itemB);
    }
}
