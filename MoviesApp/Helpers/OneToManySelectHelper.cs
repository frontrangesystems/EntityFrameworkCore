using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MoviesApp.Data;

namespace MoviesApp.Helpers
{
    public static class OneToManySelectHelper
    {
        public static void RunAll()
        {
            FilmsForRating();
        }
        public static void FilmsForRating()
        {
            ConsoleHelper.WriteCaller();
            var ratings = MoviesContext.Instance.Ratings.Include(r => r.Films);
            foreach (var rating in ratings)
            {
                Console.WriteLine($"{rating.Code}\t{rating.Name}");
                if (!rating.Films.Any())
                {
                    Console.WriteLine("\t-- none --");
                }
                foreach (var film in rating.Films)
                {
                    Console.WriteLine($"\t{film.Title}");
                }
            }
        }
    }
}
