using System;
using System.Collections.Generic;
using CollaborativeFiltering.ItemNearestNeighbor.Interface;
using CollaborativeFiltering.Model;
using CollaborativeFiltering.ItemSimilarity.Interface;
using CollaborativeFiltering.ItemSimilarity.Service;
using CollaborativeFiltering.BusinessLogic;
using System.Linq;

namespace CollaborativeFiltering.ItemNearestNeighbor.Service
{
    public class ThresholdNearestNeighbor : IItemNearestNeighbor
    {
        private List<int> comparedItems = new List<int>();
        private Dictionary<int, double> OtherItemsSimilarity = new Dictionary<int, double>();

        private double threshold = 0;

        public Dictionary<int, double> GetNNSimilarity(int userId, int itemId)
        {
            List<int> userRatedItems = UserService.GetRatedItems(userId);

            //IItemSimilarity itemSimilarity = new ItemCollaborativeSimilarity();
            IItemSimilarity itemSimilarity = new ItemHybridSimilarity();
            //IItemSimilarity itemSimilarity = new ItemGenreSimilarity();
            foreach (var otherItemId in userRatedItems)
            {
                double similarity = itemSimilarity.Calculate(itemId, otherItemId);
                if (similarity >= threshold)
                {
                    this.OtherItemsSimilarity.Add(otherItemId, similarity);
                }
            }

            return this.OtherItemsSimilarity;
        }



        public Dictionary<int, double> GetNNSimilarity(int item)
        {
            throw new NotImplementedException();
        }
    }
}
