using System.Collections.Generic;
using CollaborativeFiltering.ItemNearestNeighbor.Interface;
using CollaborativeFiltering.ItemSimilarity.Interface;
using CollaborativeFiltering.ItemSimilarity.Service;
using CollaborativeFiltering.Model;

namespace CollaborativeFiltering.ItemNearestNeighbor.Service
{
    public class ItemKNearestNeighbor : IItemNearestNeighbor
    {
        private List<int> allItems = new List<int>();
        private Dictionary<int, double> OtherItemsSimilarity = new Dictionary<int, double>();
        private int k = 20;

        public Dictionary<int, double> GetNNSimilarity(int itemId)
        {
            IItemSimilarity itemSimilarity = new ItemCollaborativeSimilarity();
            foreach (var otherItemId in this.allItems)
            {
                double similarity = itemSimilarity.Calculate(itemId, otherItemId);
                this.OtherItemsSimilarity.Add(otherItemId, similarity);
            }

            //do something to choose the k highest similar items
            return this.OtherItemsSimilarity;
        }

        public Dictionary<int, double> GetNNSimilarity(int userId, int itemId)
        {
            throw new System.NotImplementedException();
        }
    }
}
