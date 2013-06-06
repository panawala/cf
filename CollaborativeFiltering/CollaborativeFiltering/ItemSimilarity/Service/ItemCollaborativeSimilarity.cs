using System;
using CollaborativeFiltering.ItemSimilarity.Interface;
using CollaborativeFiltering.Model;
using CollaborativeFiltering.BusinessLogic;
using System.Collections.Generic;
using CollaborativeFiltering.Utility;
using CollaborativeFiltering.SimilarityAlogrithm.Service;

namespace CollaborativeFiltering.ItemSimilarity.Service
{
    public class ItemCollaborativeSimilarity : IItemSimilarity
    {
        public double Calculate(int itemAId, int itemBId)
        {
            Logger.Instance.WriteLine("calculating {0} and {1} similarity...", itemAId, itemBId);

            List<int> commonUsers = ItemService.GetCommonUsers(itemAId, itemBId);
            double[] itemARates = new double[commonUsers.Count];
            double[] itemBRates = new double[commonUsers.Count];
            int i = 0;
            foreach (var user in commonUsers)
            {
                double rateA = RatingService.GetRate(user, itemAId);
                double rateB = RatingService.GetRate(user, itemBId);
                itemARates[i] = rateA;
                itemBRates[i] = rateB;
                i++;
            }

            double similarity = (new PersonSimilarityMeasure()).calculate(itemARates, itemBRates);

            Logger.Instance.WriteLine("their similarity is {0}", similarity);
            return similarity;
        }
    }
}
