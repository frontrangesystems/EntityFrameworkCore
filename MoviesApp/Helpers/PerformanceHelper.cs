using System.Linq;
using Microsoft.EntityFrameworkCore;
using MoviesApp.Data;

namespace MoviesApp.Helpers
{
    public static class PerformanceHelper
    {
        public static void RunAll()
        {
            MoviesContext.UseLogger = true;

//            PoorlyPerformingQuery();
            OptimizedQuery();

            MoviesContext.UseLogger = false;
        }

        private static void PoorlyPerformingQuery()
        {
            ConsoleHelper.WriteCaller();

            var films = MoviesContext.Instance.Films;
            foreach (var film in films)
            {
                MoviesContext.Instance.Entry(film).Collection(f => f.FilmActors).Load();
                foreach (var filmActor in film.FilmActors)
                {
                    MoviesContext.Instance.Entry(filmActor).Reference(fa => fa.Actor).Load();
                }
            }
        }

        private static void OptimizedQuery()
        {
            ConsoleHelper.WriteCaller();

            var films = MoviesContext.Instance.Films
                .Include(f => f.FilmActors)
                .ThenInclude(fa => fa.Actor)
                .ToList();
            foreach (var film in films)
            {
                foreach (var filmActor in film.FilmActors)
                {
                    // do nothing
                }
            }
        }
    }
}