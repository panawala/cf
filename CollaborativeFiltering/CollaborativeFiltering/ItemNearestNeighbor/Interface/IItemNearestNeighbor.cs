using System.Collections.Generic;
using CollaborativeFiltering.Model;

namespace CollaborativeFiltering.ItemNearestNeighbor.Interface
{
    interface IItemNearestNeighbor
    {
        /// <summary>
        /// get user relatively item similarity
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        Dictionary<int, double> GetNNSimilarity(int userId, int item);

        /// <summary>
        /// get no-user item similarity
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Dictionary<int, double> GetNNSimilarity(int item);
    }
}
