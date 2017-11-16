using System;
using System.Linq;
using MoviesApp.Data;
using MoviesApp.Entities;

namespace MoviesApp.Helpers
{
    public static class InsertHelper
    {
        public static void RunAll()
        {
            AddActor();
            AddFilm();
        }

        private static void AddActor()
        {
            ConsoleHelper.WriteCaller();

            var count = MoviesContext.Instance.Actors.Count();
            Console.WriteLine($"Actors: {count}");

            var actor = new Actor {FirstName = "Dwayne", LastName = "Johnson"};
            MoviesContext.Instance.Actors.Add(actor);

            MoviesContext.Instance.SaveChanges();

            count = MoviesContext.Instance.Actors.Count();
            Console.WriteLine($"Actors: {count}");
        }

        private static void AddFilm()
        {
            ConsoleHelper.WriteCaller();

            var count = MoviesContext.Instance.Films.Count();
            Console.WriteLine($"Films: {count}");

            var rating = MoviesContext.Instance.Ratings.FirstOrDefault(r => r.Code == "g");

            var film = new Film
            {
                Title = "Moana",
                Description = "In Ancient Polynesia, when a terrible curse incurred by the Demigod Maui reaches Moana's island, she answers the Ocean's call to seek out the Demigod to set things right.",
                Rating = rating,
                ReleaseYear = 2016
            };

            MoviesContext.Instance.Films.Add(film);

            MoviesContext.Instance.SaveChanges();

            count = MoviesContext.Instance.Films.Count();
            Console.WriteLine($"Films: {count}");
        }
    }
}