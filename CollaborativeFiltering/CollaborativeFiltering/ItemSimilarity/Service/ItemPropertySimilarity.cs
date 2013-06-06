using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CollaborativeFiltering.ItemSimilarity.Interface;
using CollaborativeFiltering.Model;
using CollaborativeFiltering.DataSource;
using CollaborativeFiltering.SimilarityAlogrithm.Service;

namespace CollaborativeFiltering.ItemSimilarity.Service
{
    public class ItemPropertySimilarity : IItemSimilarity
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

            return (new PredicateSimilarityMeasure()).calculate(movieAGenres, movieBGenres);
        }
    }
}
