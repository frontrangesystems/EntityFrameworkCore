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
                if (film.FilmActors.Any())
                {
                    foreach (var filmActor in film.FilmActors)
                    {
                        var actor = filmActor.Actor;
                        Console.WriteLine($"\t{actor.FirstName} {actor.LastName}");
                    }
                }
                else
                {
                    Console.WriteLine("\tNone");
                }
            }
        }

        private static void FilmsForActors()
        {
            ConsoleHelper.WriteCaller();

            var actors = MoviesContext.Instance.Actors
                .OrderBy(a=>a.LastName)
                .ThenBy(a=>a.FirstName)
                .Include(a => a.FilmActors)
                .ThenInclude(fa => fa.Film);

            foreach (var actor in actors)
            {
                Console.WriteLine($"{actor.FirstName} {actor.LastName}");
                if (actor.FilmActors.Any())
                {
                    foreach (var filmActor in actor.FilmActors.OrderBy(fa=>fa.Film.Title))
                    {
                        var film = filmActor.Film;
                        Console.WriteLine($"\t{film.Title}");
                    }
                }
                else
                {
                    Console.WriteLine("\tNone");
                }
            }
        }

        private static void FilmsForCategory()
        {
            ConsoleHelper.WriteCaller();

            var categories = MoviesContext.Instance.Categories
                .Include(c => c.FilmCategories)
                .ThenInclude(fc => fc.Film);

            foreach (var category in categories)
            {
                Console.WriteLine(category.Name);
                if (category.FilmCategories.Any())
                {
                    foreach (var filmCategory in category.FilmCategories)
                    {
                        var film = filmCategory.Film;
                        Console.WriteLine($"\t{film.Title}");
                    }
                }
                else
                {
                    Console.WriteLine("\tNone");
                }
            }
        }
    }
}