using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CollaborativeFiltering.Model;
using CollaborativeFiltering.DataSource;

namespace CollaborativeFiltering.BusinessLogic
{
    public class ItemService
    {
        public static List<int> GetCommonUsers(int itemAId, int itemBId)
        {
            List<int> userA = GetRatedUsers(itemAId);
            List<int> userB = GetRatedUsers(itemBId);
            List<int> commonUsers = new List<int>();

            foreach (var user in userA)
            {
                if (userB.Contains(user))
                {
                    commonUsers.Add(user);
                }
            }
            return commonUsers;
        }
        //private static Dictionary<string, List<User>> commonUsers = new Dictionary<string, List<User>>();
        //public static List<User> GetCommonUsers(Item itemA, Item itemB)
        //{
        //    string commonKey = itemA.ItemId.ToString() + "_" + itemB.ItemId.ToString();
        //    if (!commonUsers.ContainsKey(commonKey))
        //    {
        //        List<User> comUsers = new List<User>();
        //        foreach (var item in DataStore.UserRatingItems)
        //        {
        //            if (item.Value.Contains(itemA.ItemId) && item.Value.Contains(itemB.ItemId))
        //            {
        //                comUsers.Add(new User() { UserId = item.Key });
        //            }
        //        }
        //        commonUsers.Add(commonKey, comUsers);
        //        return comUsers;
        //    }
        //    else
        //    {
        //        return commonUsers[commonKey];
        //    }
            
        //}

        private static Dictionary<int, List<int>> itemRatedUserCache = new Dictionary<int, List<int>>();

        public static List<int> GetRatedUsers(int itemId)
        {
            if (itemRatedUserCache.ContainsKey(itemId))
            {
                return itemRatedUserCache[itemId];
            }
            else
            {
                List<int> users = DataStore.AllRatings
                    .Where(s => s.ItemId == itemId)
                    .Select(s => s.UserId )
                    .ToList();
                itemRatedUserCache.Add(itemId, users);

                return users;
            }
        }
    }
}
