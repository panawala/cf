using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CollaborativeFiltering.ItemSimilarity.Interface;
using CollaborativeFiltering.SimilarityAlogrithm.Interface;
using CollaborativeFiltering.SimilarityAlogrithm.Service;

namespace CollaborativeFiltering.ItemSimilarity.Service
{
    public class ItemHybridSimilarity : IItemSimilarity
    {
        public double Calculate(int itemA, int itemB)
        {
            double theta = 0.9d;
            IItemSimilarity collaborateSimilarity = new ItemCollaborativeSimilarity();
            IItemSimilarity genreSimilarity = new ItemGenreSimilarity();
            
            return theta * collaborateSimilarity.Calculate(itemA, itemB) + (1 - theta) * genreSimilarity.Calculate(itemA, itemB);
        }
    }
}
