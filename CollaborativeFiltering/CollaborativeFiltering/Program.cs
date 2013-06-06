using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using CollaborativeFiltering.BusinessLogic;
using CollaborativeFiltering.Model;
using CollaborativeFiltering.Recommandation.Service;
using CollaborativeFiltering.DataSource;
using CollaborativeFiltering.ItemSimilarity.Interface;
using CollaborativeFiltering.ItemSimilarity.Service;
using CollaborativeFiltering.Evaluation;

namespace CollaborativeFiltering
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime datetime = Convert.ToDateTime("1970-01-01");
            Console.WriteLine(datetime.Ticks);
            //DateTime dataTime = Convert.ToDateTime((long)890454351);
            DateTime t = new DateTime(890454351,DateTimeKind.Local);
            Console.WriteLine(t);
            DateTime t1 = new DateTime(890454351, DateTimeKind.Unspecified);
            Console.WriteLine(t1);
            DateTime t2 = new DateTime(890454351, DateTimeKind.Utc);
            Console.WriteLine(t2);

            return;
            //var test = DataStore.UserRatingItems;

            //IItemSimilarity itemSimilarity = new ItemCollaborativeSimilarity();
            //double similarity = itemSimilarity.Calculate(new Item() { ItemId = 393 }, new Item() { ItemId = 381 });
            
            //Console.WriteLine(similarity);

            //return;

            double evaluation = MAEEvaluation.Evaluate(224);
            //double evaluation = MAEEvaluation.Evaluate();
            Console.WriteLine("evaluation: " + evaluation);
            return;

            UserTopNRecommandation utnr = new UserTopNRecommandation();
            var recomandationItems = utnr.GetTopNItems(3, 200);

            //ItemService itemService = new ItemService();
            //List<User> commonUsers = itemService.GetCommonUsers(new Item() { ItemId = 2 }, new Item() { ItemId = 5 });
        }
        
    }
}
