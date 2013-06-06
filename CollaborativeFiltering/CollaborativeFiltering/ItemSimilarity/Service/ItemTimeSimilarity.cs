using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CollaborativeFiltering.ItemSimilarity.Interface;
using CollaborativeFiltering.DataSource;

namespace CollaborativeFiltering.ItemSimilarity.Service
{
    public class ItemTimeSimilarity : IItemSimilarity
    {
        public double Calculate(int itemA, int itemB)
        {
            string itemAtime = DataStore.AllItems
                .Where(s => s.ItemId == itemA)
                .Select(s => s.ReleaseDate)
                .First();

            string itemBtime = DataStore.AllItems
                .Where(s => s.ItemId == itemA)
                .Select(s => s.ReleaseDate)
                .First();

            TimeSpan ts = DataStore.AllItems
                .Max(s => Convert.ToDateTime(s.ReleaseDate)) -
                DataStore.AllItems
                .Min(s => Convert.ToDateTime(s.ReleaseDate));

            double timeSpan =(double) ts.Milliseconds;

            double itemSpan=(double)((Convert.ToDateTime(itemAtime) - Convert.ToDateTime(itemBtime)).Milliseconds);

            return (double)(timeSpan - Math.Abs(itemSpan)) / (double)timeSpan;

        }
    }
}
