using System.Collections.Generic;
using CollaborativeFiltering.Model;

namespace CollaborativeFiltering.Prediction.Interface
{
    interface IPrediction
    {
        Dictionary<int, double> GetAllItemsPrediction(int userId);
        double Predict(int userId, int item);
    }
}
