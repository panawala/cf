using System.Collections.Generic;
using CollaborativeFiltering.Model;
using System.IO;
using System;
using System.Linq;

namespace CollaborativeFiltering.DataSource
{
    public class DataStore
    {
        private static List<MovieItem> allItems;
        public static List<MovieItem> AllItems 
        {
            get
            {
                if (allItems != null)
                {
                    return allItems;
                }
                else
                {
                    allItems=ProcessItem(@"c:\ml-100k\");
                    return allItems;
                }
                
            }
        }

        private static List<User> allUsers;
        public static List<User> AllUsers
        {
            get
            {
                if (allUsers != null)
                {
                    return allUsers;
                }
                else
                {
                    allUsers=ProcessUser(@"c:\ml-100k\");
                    return allUsers;
                }
                 
            }
        }

        private static List<Rating> allRatings;
        public static List<Rating> AllRatings
        {
            get
            {
                if (allRatings != null)
                {
                    return allRatings;
                }
                else
                {
                    allRatings = ProcessScore(@"c:\ml-100k\");
                    return allRatings;
                }
                
            }
        }

        private static List<User> ProcessUser(string path)
        {
            List<User> users = new List<User>();
            string ratingPath = path + "u.user";
            StreamReader srReadFile = new StreamReader(ratingPath);
            while (!srReadFile.EndOfStream)
            {
                string line = srReadFile.ReadLine();
                //Console.WriteLine(strReadLine);
                int userId = Convert.ToInt32(line.Split('|').First());
                users.Add(new User() { UserId = userId });
            }

            srReadFile.Close();
            return users;
        }

        private static List<MovieItem> ProcessItem(string path)
        {
            List<MovieItem> MovieItems = new List<MovieItem>();
            string ratingPath = path + "u.item";
            StreamReader srReadFile = new StreamReader(ratingPath);
            while (!srReadFile.EndOfStream)
            {
                string line = srReadFile.ReadLine();
                int itemId = Convert.ToInt32(line.Split('|').First());

                string[] spilits = line.Split('|');
                string movieName = string.Empty;
                string releaseDate = string.Empty;

                if (!string.IsNullOrEmpty(spilits[1]))
                {
                    if (spilits[1].Contains('('))
                    {
                        movieName = spilits[1].Substring(0, spilits[1].LastIndexOf('('));
                        releaseDate = spilits[1].Substring(spilits[1].LastIndexOf('(') + 1, spilits[1].LastIndexOf(')') - spilits[1].LastIndexOf('(') - 1);
                    }
                    else
                    {
                        movieName = spilits[1];
                    }

                }
                string videoReleaseDate = string.Empty;
                if (!string.IsNullOrEmpty(spilits[2]))
                    videoReleaseDate = spilits[2];
                string url = string.Empty;

                if (!string.IsNullOrEmpty(spilits[4]))
                    url = spilits[4];
                double[] genres = new double[19];
                for (int i = 0; i < 19; i++)
                {
                    genres[i] = Convert.ToDouble(spilits[5 + i]);
                }

                MovieItem mi = new MovieItem()
                {
                    ItemId = itemId,
                    MovieTitle = movieName,
                    ReleaseDate = releaseDate,
                    VideoReleaseDate = videoReleaseDate,
                    IMDbUrl = url,
                    Genres = genres
                };
               MovieItems.Add(mi);
            }

            srReadFile.Close();
            return MovieItems;
        }

        private static List<Rating> ProcessScore(string path)
        {
            List<Rating> ratings = new List<Rating>();
            string ratingPath = path + "u.data";
            StreamReader srReadFile = new StreamReader(ratingPath);
            while (!srReadFile.EndOfStream)
            {
                string line = srReadFile.ReadLine();
                string[] lineStr = line.Split('\t');
                int userId = Convert.ToInt32(lineStr[0]);
                int itemId = Convert.ToInt32(lineStr[1]);
                int score = Convert.ToInt32(lineStr[2]);
                string timestamp = lineStr[3];
                ratings.Add(new Rating { ItemId = itemId, UserId = userId, Score = score, Timestamp = timestamp });
            }

            srReadFile.Close();

            return ratings;
        }


        private static Dictionary<int, List<int>> userRatingItems = new Dictionary<int, List<int>>();
        public static Dictionary<int, List<int>> UserRatingItems
        {
            get
            {
                if (userRatingItems.Count != 0)
                {
                    return userRatingItems;
                }
                else
                {
                    foreach (var rating in AllRatings)
                    {
                        if (userRatingItems.ContainsKey(rating.UserId))
                        {
                            userRatingItems[rating.UserId].Add( rating.ItemId );
                        }
                        else
                        {
                            userRatingItems.Add(rating.UserId, new List<int>() { rating.ItemId });
                        }
                    }
                    return userRatingItems;
                }
                
            }
        }



    }
}
