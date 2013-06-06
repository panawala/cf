using System.Collections.Generic;
using CollaborativeFiltering.BusinessLogic;
using CollaborativeFiltering.Model;
using CollaborativeFiltering.Prediction.Interface;
using System;
using CollaborativeFiltering.Utility;
using CollaborativeFiltering.ItemNearestNeighbor.Interface;
using CollaborativeFiltering.ItemNearestNeighbor.Service;

namespace CollaborativeFiltering.Prediction.Service
{
    public class WeightedPrediction : IPrediction
    {

        public Dictionary<int, double> GetAllItemsPrediction(int userId)
        {
            Dictionary<int, double> itemPredictions = new Dictionary<int, double>();
            List<int> notRatedItems = UserService.GetNotRatedItems(userId);
            Logger.Instance.WriteLine("found {0} not rated items for {1} ", notRatedItems.Count, userId);

            foreach (var notRatedItemId in notRatedItems)
            {
                double predictionRate = this.Predict(userId, notRatedItemId);
                Logger.Instance.WriteLine("{0} user for {1} item predict {2}... ", userId, notRatedItemId, predictionRate);
                Console.WriteLine("{0} user for {1} item predict {2}... ", userId, notRatedItemId, predictionRate);


                itemPredictions.Add(notRatedItemId, predictionRate);
                Console.WriteLine("--------------------{0} / {1} is Completed... -----------", itemPredictions.Count, notRatedItems.Count);
                Logger.Instance.WriteLine("--------------------{0} / {1} is Completed... -----------", itemPredictions.Count, notRatedItems.Count);
            }
            return itemPredictions;

        }

        public double Predict(int userId, int itemId)
        {
            Console.WriteLine("predict {0} rate..", itemId);
            Logger.Instance.WriteLine("predict {0} rate..", itemId);

            Console.WriteLine("find nearest neighbors for {0}...", itemId);
            Logger.Instance.WriteLine("find nearest neighbors for {0}...", itemId);
            IItemNearestNeighbor iItemNearestNeighbor = new ThresholdNearestNeighbor();
            Dictionary<int, double> itemSimilarities = iItemNearestNeighbor.GetNNSimilarity(userId, itemId);

            return this.WeightCalculate(userId, itemSimilarities);
        }

        private double WeightCalculate(int userId, Dictionary<int, double> itemSimilarities)
        {
            double allRates = 0d;
            double allSimilarities = 1d;
            foreach (var similarItem in itemSimilarities.Keys)
            {
                double itemRate = RatingService.GetRate(userId, similarItem);
                allRates += itemRate * itemSimilarities[similarItem];
                allSimilarities += itemSimilarities[similarItem];
            }

            return allRates / allSimilarities;
        }

    }
}
