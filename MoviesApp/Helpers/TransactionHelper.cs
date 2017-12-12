using System;
using System.Linq;
using MoviesApp.Data;
using MoviesApp.Entities;

namespace MoviesApp.Helpers
{
    public static class TransactionHelper
    {
        public static void RunAll()
        {
            DataNotSaved();
            DataSaved();
            TransactionRolledBackException();
            TransactionRolledBackBusinessRule();
        }

        private static void DataNotSaved()
        {
            ConsoleHelper.WriteCaller();

            var film = new Film
            {
                Title = "Willy Wonka & the Chocolate Factory",
                ReleaseYear = 1971,
                RatingId = 1
            };
            var actor = new Actor
            {
                FirstName = "Gene",
                LastName = "Wilder"
            };

            using (var transaction = MoviesContext.Instance.Database.BeginTransaction())
            {
                MoviesContext.Instance.Films.Add(film);
                MoviesContext.Instance.SaveChanges();

                MoviesContext.Instance.Actors.Add(actor);
                MoviesContext.Instance.SaveChanges();
            }

            var filmFound = MoviesContext.Instance.Films
                .Any(f => f.Title == film.Title &&
                          f.ReleaseYear == film.ReleaseYear &&
                          f.RatingId == film.RatingId) ? "Yes" : "No";
            var actorFound = MoviesContext.Instance.Actors
                .Any(a => a.FirstName == actor.FirstName &&
                          a.LastName == actor.LastName) ? "Yes" : "No";

            Console.Write($"Film Found: {filmFound}\nActor Found: {actorFound}");
        }

        private static void DataSaved()
        {
            ConsoleHelper.WriteCaller();

            var film = new Film
            {
                Title = "Willy Wonka & the Chocolate Factory",
                ReleaseYear = 1971,
                RatingId = 1
            };
            var actor = new Actor
            {
                FirstName = "Gene",
                LastName = "Wilder"
            };

            using (var transaction = MoviesContext.Instance.Database.BeginTransaction())
            {
                MoviesContext.Instance.Films.Add(film);
                MoviesContext.Instance.SaveChanges();

                MoviesContext.Instance.Actors.Add(actor);
                MoviesContext.Instance.SaveChanges();

                MoviesContext.Instance.Database.CommitTransaction();
            }

            var filmFound = MoviesContext.Instance.Films
                .Any(f => f.Title == film.Title &&
                          f.ReleaseYear == film.ReleaseYear &&
                          f.RatingId == film.RatingId) ? "Yes" : "No";
            var actorFound = MoviesContext.Instance.Actors
                .Any(a => a.FirstName == actor.FirstName &&
                          a.LastName == actor.LastName) ? "Yes" : "No";

            Console.Write($"Film Found: {filmFound}\nActor Found: {actorFound}");
        }

        private static void TransactionRolledBackException()
        {
            ConsoleHelper.WriteCaller();

            var count = MoviesContext.Instance.Films.Count();
            Console.WriteLine($"Film Count: {count}");
            using (var transaction = MoviesContext.Instance.Database.BeginTransaction())
            {
                try
                {
                    for (int i = 0; i < 5; i++)
                    {
                        MoviesContext.Instance.Films.Add(new Film { Title = $"Temp Film {i}" });
                    }
                    MoviesContext.Instance.SaveChanges();

                    throw new ApplicationException("Simulated exception");

                    transaction.Commit();
                    Console.WriteLine("Transaction committed");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception encountered: {ex.Message}");
                    transaction.Rollback();
                    Console.WriteLine("Transaction rolled back");
                }
            }
            count = MoviesContext.Instance.Films.Count();
            Console.WriteLine($"Film Count: {count}");

            // clean up after ourselves
            var films = MoviesContext.Instance.Films.Where(f => f.Title.StartsWith("temp"));
            MoviesContext.Instance.Films.RemoveRange(films);
            MoviesContext.Instance.SaveChanges();
        }

        private static void TransactionRolledBackBusinessRule()
        {
            ConsoleHelper.WriteCaller();

            var count = MoviesContext.Instance.Films.Count();
            Console.WriteLine($"Film Count: {count}");
            using (var transaction = MoviesContext.Instance.Database.BeginTransaction())
            {
                try
                {
                    for (int i = 0; i < 5; i++)
                    {
                        MoviesContext.Instance.Films.Add(new Film { Title = $"Temp Film {i}" });
                    }
                    MoviesContext.Instance.SaveChanges();

                    var cancelReceivedFromUser = true;
                    if (cancelReceivedFromUser)
                    {
                        transaction.Rollback();
                        Console.WriteLine("Transaction rolled back due to user cancel");
                    }
                    else
                    {
                        transaction.Commit();
                        Console.WriteLine("Transaction committed");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception encountered: {ex.Message}");
                    transaction.Rollback();
                    Console.WriteLine("Transaction rolled back due to exception");
                }
            }

            count = MoviesContext.Instance.Films.Count();
            Console.WriteLine($"Film Count: {count}");

            // clean up after ourselves
            var films = MoviesContext.Instance.Films.Where(f => f.Title.StartsWith("temp"));
            MoviesContext.Instance.Films.RemoveRange(films);
            MoviesContext.Instance.SaveChanges();
        }
    }
}