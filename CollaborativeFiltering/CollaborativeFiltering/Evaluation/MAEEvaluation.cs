using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CollaborativeFiltering.BusinessLogic;
using CollaborativeFiltering.Prediction.Interface;
using CollaborativeFiltering.Prediction.Service;
using CollaborativeFiltering.DataSource;

namespace CollaborativeFiltering.Evaluation
{
    public class MAEEvaluation
    {
        public static double Evaluate(int userId)
        {
            List<int> ratedItems = UserService.GetRatedItems(userId);

            IPrediction prediction = new WeightedPrediction();
            int N = ratedItems.Count;
            double absoluteError = 0d;
            foreach(var ratedItem in ratedItems)
            {
                double predicateRate = prediction.Predict(userId, ratedItem);
                double realRate = RatingService.GetRate(userId, ratedItem);
                absoluteError += Math.Abs(predicateRate - realRate);
            }

            return absoluteError / (double)N;
        }

        public static double Evaluate()
        {
            List<int> userIds=DataStore.AllRatings
                .Select(s=>s.UserId)
                .Distinct()
                .ToList();

            int N = DataStore.AllRatings.Count;
            double absoluteError = 0d;
            foreach (var userId in userIds)
            {
                List<int> ratedItems = UserService.GetRatedItems(userId);
                IPrediction prediction = new WeightedPrediction();
                foreach (var ratedItem in ratedItems)
                {
                    double predicateRate = prediction.Predict(userId, ratedItem);
                    double realRate = RatingService.GetRate(userId, ratedItem);
                    absoluteError += Math.Abs(predicateRate - realRate);
                }
            }

            return absoluteError / (double)N;
        }

        //public static double Evaluate()
        //{
        //    int N = DataStore.AllRatings.Count;
        //    double absoluteError = 0d;
        //    IPrediction prediction = new WeightedPrediction();
        //    foreach (var rating in DataStore.AllRatings)
        //    {
        //        double predicateRate = prediction.Predict(rating.UserId, rating.ItemId);
        //        double realRate = rating.Score;
        //        absoluteError += Math.Abs(predicateRate - realRate);
        //    }

        //    return absoluteError / (double)N;
        //}
    }
}
