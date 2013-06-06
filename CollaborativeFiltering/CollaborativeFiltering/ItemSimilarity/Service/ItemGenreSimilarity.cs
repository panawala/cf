using System;
using CollaborativeFiltering.ItemSimilarity.Interface;
using CollaborativeFiltering.Model;
using CollaborativeFiltering.DataSource;
using System.Linq;
using CollaborativeFiltering.SimilarityAlogrithm.Service;
using CollaborativeFiltering.SimilarityAlogrithm.Interface;

namespace CollaborativeFiltering.ItemSimilarity.Service
{
    public class ItemGenreSimilarity : IItemSimilarity
    {
        public double Calculate(int itemA, int itemB)
        {
            MovieItem movieItemA = DataStore.AllItems
                .Where(s => s.ItemId == itemA)
                .First();
            MovieItem movieItemB = DataStore.AllItems
                .Where(s => s.ItemId == itemB)
                .First();

            double[] movieAGenres = movieItemA.Genres;
            double[] movieBGenres = movieItemB.Genres;

            return (new PersonSimilarityMeasure()).calculate(movieAGenres, movieBGenres);

        }
    }
}
