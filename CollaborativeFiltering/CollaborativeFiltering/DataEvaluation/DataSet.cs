using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CollaborativeFiltering.Model;
using CollaborativeFiltering.DataSource;

namespace CollaborativeFiltering.DataEvaluation
{
    public  class DataSet
    {
        public List<DataSetRun> GenerateTestData(double ratio)
        {
            int count = Convert.ToInt32(1 / ratio);
            int testItemCount=Convert.ToInt32(DataStore.AllRatings.Count*ratio);
            int size=DataStore.AllRatings.Count;
            List<DataSetRun> dataSetRuns = new List<DataSetRun>();
            for(int i=0;i<count;i++)
            {
                DataSetRun dsr = new DataSetRun();
                dsr.TrainingData = DataStore.AllRatings
                .Skip(3)
                .Take(testItemCount)
                .ToList();  
                dsr.TestData = DataStore.AllRatings.GetRange(i * testItemCount, (i + 1) * testItemCount);
                List<Rating> allRatings = DataStore.AllRatings.ToList();
                allRatings.RemoveRange(i * testItemCount,  testItemCount);
                dsr.TrainingData = allRatings;
                dataSetRuns.Add(dsr);
            }
            return dataSetRuns;
        }



    }
}
