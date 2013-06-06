using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CollaborativeFiltering.Model;

namespace CollaborativeFiltering.DataEvaluation
{
    public class DataSetRun
    {
        public List<Rating> TrainingData { get; set; }
        public List<Rating> TestData { get; set; }
    }
}
