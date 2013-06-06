using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CollaborativeFiltering.Model;
using CollaborativeFiltering.DataSource;

namespace CollaborativeFiltering.BusinessLogic
{
    public class RatingService
    {
        private static Dictionary<string, double> userItemRateCache = new Dictionary<string, double>();
        public static double GetRate(int userId, int itemId)
        {
            string commonCode = userId.ToString() + "_" + itemId.ToString();
            if (!userItemRateCache.ContainsKey(commonCode))
            {
                double rate = DataStore.AllRatings
                .Where(s => s.UserId == userId && s.ItemId == itemId)
                .Select(s => s.Score)
                .First();
                userItemRateCache.Add(commonCode, rate);
                return rate;
            }
            else
            {
                return userItemRateCache[commonCode];
            }
             
        }
    }
}
