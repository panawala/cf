using System.Collections.Generic;
using CollaborativeFiltering.BusinessLogic;
using CollaborativeFiltering.Model;
using CollaborativeFiltering.Prediction.Interface;
using CollaborativeFiltering.Prediction.Service;
using CollaborativeFiltering.Recommandation.Interface;
using System.Linq;
using System;
using CollaborativeFiltering.Utility;

namespace CollaborativeFiltering.Recommandation.Service
{
    public class UserTopNRecommandation : IUserTopNRecommandation
    {

        public IEnumerable<KeyValuePair<int,double>> GetTopNItems(int userId,int n)
        {
            IPrediction userPrediction = new WeightedPrediction();
            Dictionary<int, double> allItemPrediction = userPrediction.GetAllItemsPrediction(userId);
            var topNItems = allItemPrediction
                .OrderByDescending(s => s.Value)
                .Take(n);
            return topNItems;
        }
        private Dictionary<int, double> GetKItems(int k)
        {
            return null;
        }
    }
}
