using System;
using System.Linq;
using ConsoleTables;
using MoviesApp.Data;
using MoviesApp.Entities;
using MoviesApp.Extensions;
using MoviesApp.Models;

namespace MoviesApp.Helpers
{
    public static class DeleteHelper
    {
        public static void RunAll()
        {
            DeleteActor();
            DeleteFilm();
        }

        private static void DeleteActor()
        {
            ConsoleHelper.WriteCaller();

            WriteActors();

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
                Console.WriteLine("Existing Actors");
                WriteActors();

                MoviesContext.Instance.Actors.Remove(actor);

                MoviesContext.Instance.SaveChanges();

                Console.WriteLine("With actor removed");
                WriteActors();
            }
        }

        private static void DeleteFilm()
        {
            ConsoleHelper.WriteCaller();

            WriteFilms();

            Console.WriteLine("Enter Film Title search");
            var title = Console.ReadLine();

            var film = MoviesContext.Instance.Films
                .FirstOrDefault(f => f.Title.Contains(title));

            if (film == null)
            {
                Console.WriteLine($"Film with title that contains '{title}' not found");
            }
            else
            {
                ConsoleTable.From(new[] {film.Copy<Film, FilmModel>()}).Write();
                Console.WriteLine("Are you sure you want to delete this film?");
                if (Console.ReadKey().Key == ConsoleKey.Y)
                {
                    MoviesContext.Instance.Films.Remove(film);

                    MoviesContext.Instance.SaveChanges();

                    WriteFilms();
                }
                else
                {
                    Console.WriteLine(" No Films deleted");
                }
            }
        }

        private static void WriteActors()
        {
            var actors = MoviesContext.Instance.Actors
                .Select(a => a.Copy<Actor, ActorModel>());
            ConsoleTable.From(actors).Write();
        }

        private static void WriteFilms()
        {
            var films = MoviesContext.Instance.Films
                .Select(f => f.Copy<Film, FilmModel>());
            ConsoleTable.From(films).Write();
        }
    }
}