using System.Collections.Generic;
using CollaborativeFiltering.Model;
using CollaborativeFiltering.DataSource;
using System.Linq;

namespace CollaborativeFiltering.BusinessLogic
{
    public class UserService
    {
        private static Dictionary<int, List<int>> userNotRatedItems = new Dictionary<int, List<int>>();
        public static List<int> GetNotRatedItems(int userId)
        {
            if (userNotRatedItems.ContainsKey(userId))
            {
                return userNotRatedItems[userId];
            }
            else
            {
                List<int> notRatingItems = DataStore.AllRatings
                              .Where(s => s.UserId != userId)
                              .Select(s => s.ItemId)
                              .ToList();
                userNotRatedItems.Add(userId, notRatingItems);
                return notRatingItems;        
            }
           
        }

        private static Dictionary<int, List<int>> userRatedItems = new Dictionary<int, List<int>>();

        public static List<int> GetRatedItems(int userId)
        {
            if (!userRatedItems.Keys.Contains(userId))
            {
                List<int> ratedItems = DataStore.AllRatings
                .Where(s => s.UserId == userId)
                .Select(s =>  s.ItemId )
                .ToList();
                userRatedItems.Add(userId, ratedItems);
                return ratedItems;
            }
            else
            {
                return userRatedItems[userId];
            }
        }

    }
}
