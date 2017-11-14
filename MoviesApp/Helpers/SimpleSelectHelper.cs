using System.Linq;
using ConsoleTables;
using MoviesApp.Data;
using MoviesApp.Entities;
using MoviesApp.Extensions;
using MoviesApp.Models;

namespace MoviesApp.Helpers
{
    public static class SimpleSelectHelper
    {
        public static void RunAll()
        {
            SelectRatings();
            SelectFilms();
            SelectActors();
        }

        public static void SelectFilms()
        {
            var data = MoviesContext.Instance.Films.Select(d => d.Copy<Film, FilmModel>());
            // Note: In this example the query is executed on the line below, when the 
            // ConsoleTable.From method iterates on the collection
            ConsoleTable.From(data).Write();
        }

        public static void SelectRatings()
        {
            // Note: This code executes the query against the database on the line below.
            // Any time a collection is iterated, or an extension method such as 'ToList'
            // is called, the query is performed.
            var data = MoviesContext.Instance.Ratings.ToList();
            ConsoleTable.From(data).Write();
        }
        public static void SelectActors()
        {
            var data = MoviesContext.Instance.Actors.Select(d => d.Copy<Actor, ActorModel>());
            ConsoleTable.From(data).Write();
        }
    }
}
