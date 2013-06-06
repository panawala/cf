using System.Collections.Generic;
using CollaborativeFiltering.Model;

namespace CollaborativeFiltering.Recommandation.Interface
{
    interface IUserTopNRecommandation
    {
        IEnumerable<KeyValuePair<int, double>> GetTopNItems(int userId, int n);
    }
}
