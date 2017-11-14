using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MoviesApp.Data;

namespace MoviesApp.Helpers
{
    public static class ManyToManySelectHelper
    {
        public static void RunAll()
        {
            ActorsForFilms();
            FilmsForActors();
            FilmsForCategory();
        }

        private static void ActorsForFilms()
        {
            ConsoleHelper.WriteCaller();
            var films = MoviesContext.Instance.Films
            .Include(f => f.FilmActors)
            .ThenInclude(fa => fa.Actor);
            foreach (var film in films)
            {
                Console.WriteLine(film.Title);
                if (film.FilmActors.Any()){
                    foreach (var filmActor in film.FilmActors)
                    {
                        var actor = filmActor.Actor;
                        Console.WriteLine($"\t{actor.FirstName} {actor.LastName}");
                    }
                }
            }
        }

        private static void FilmsForActors()
        {
            
        }

        private static void FilmsForCategory()
        {
        }
    }
}
