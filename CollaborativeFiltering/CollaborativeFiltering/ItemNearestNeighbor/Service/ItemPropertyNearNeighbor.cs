using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CollaborativeFiltering.ItemNearestNeighbor.Interface;
using CollaborativeFiltering.Model;
using CollaborativeFiltering.DataSource;
using CollaborativeFiltering.ItemSimilarity.Service;

namespace CollaborativeFiltering.ItemNearestNeighbor.Service
{
    public class ItemPropertyNearNeighbor : IItemNearestNeighbor
    {
        public Dictionary<int, double> GetNNSimilarity(int userId, int item)
        {
            throw new NotImplementedException();
        }


        private double threshold = 0d;
        public Dictionary<int, double> GetNNSimilarity(int item)
        {
            Dictionary<int, double> neighbors = new Dictionary<int, double>();
            List<MovieItem> otherItems = DataStore.AllItems
                .Where(s => s.ItemId != item)
                .ToList();
            foreach (var movieItem in otherItems)
            {
                double similarity = (new ItemPropertySimilarity()).Calculate(item, movieItem.ItemId);
                if (similarity >= this.threshold)
                {
                    neighbors.Add(movieItem.ItemId, similarity);
                }
            }
            return neighbors;
        }
    }
}
