using System;
using System.Linq;
using ConsoleTables;
using Microsoft.EntityFrameworkCore;
using MoviesApp.Data;
using MoviesApp.Entities;
using MoviesApp.Extensions;
using MoviesApp.Models;

namespace MoviesApp.Helpers
{
    public static class PerformanceHelper
    {
        public static void RunAll()
        {
            MoviesContext.UseLogger = true;

            PoorlyPerformingQuery();
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
    public static class UpdateHelper
    {
        public static void RunAll()
        {
            UpdateActor();
            UpdateFilm();
        }

        private static void UpdateFilm()
        {
            Console.WriteLine("Update a Film");

            Console.WriteLine("Enter a Film ID");
            var filmId = Console.ReadLine().ToInt();

            var film = MoviesContext.Instance.Films
                .SingleOrDefault(a => a.FilmId == filmId);
            if (film == null)
            {
                Console.WriteLine($"Film with id {filmId} not found");
            }
            else
            {
                ConsoleTable.From(new[] {film.Copy<Film, FilmModel>()})
                    .Write();

                Console.WriteLine("Enter the Title");
                var title = Console.ReadLine().Trim();

                Console.WriteLine("Enter the Release Year");
                var releaseYear = Console.ReadLine().ToInt();

                Console.WriteLine("Enter the Rating");
                var ratingCode = Console.ReadLine().Trim();

                if (!string.IsNullOrWhiteSpace(title) && film.Title != title)
                {
                    film.Title = title;
                }

                if (releaseYear > 0 && film.ReleaseYear != releaseYear)
                {
                    film.ReleaseYear = releaseYear;
                }

                if (!string.IsNullOrWhiteSpace(ratingCode))
                {
                    var rating = MoviesContext.Instance.Ratings.FirstOrDefault(r => r.Code == ratingCode);
                    film.Rating = rating;
                }

                MoviesContext.Instance.SaveChanges();

                var films = MoviesContext.Instance.Films
                    .Where(a => a.FilmId == filmId)
                    .Select(a => a.Copy<Film, FilmModel>());
                ConsoleTable.From(films).Write();
            }
        }

        private static void UpdateActor()
        {
            Console.WriteLine("Update an Actor");

            Console.WriteLine("Enter an Actor ID");
            var actorId = Console.ReadLine().ToInt();

            var actor = MoviesContext.Instance.Actors
                .SingleOrDefault(a => a.ActorId == actorId);
            if (actor == null)
            {
                Console.WriteLine($"Actor with id {actorId} not found");
            }
            else
            {
                ConsoleTable.From(new[] {actor.Copy<Actor, ActorModel>()})
                    .Write();

                Console.WriteLine("Enter the First Name");
                var firstName = Console.ReadLine().Trim();

                Console.WriteLine("Enter the Last Name");
                var lastName = Console.ReadLine().Trim();

                actor.FirstName = firstName;
                actor.LastName = lastName;

                MoviesContext.Instance.SaveChanges();

                var actors = MoviesContext.Instance.Actors
                    .Where(a => a.ActorId == actorId)
                    .Select(a => a.Copy<Actor, ActorModel>());
                ConsoleTable.From(actors).Write();
            }
        }
    }
}