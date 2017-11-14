using System;
using System.Linq;
using MoviesApp.Data;

namespace MoviesApp.Helpers
{
    public static class OneToOneSelectHelper
    {
        public static void RunAll()
        {
            SelectFilmsAndFilmImages();
            SelectFilmImagesAndFilms();
        }

        private static void SelectFilmsAndFilmImages()
        {
            ConsoleHelper.WriteCaller();
            var films = MoviesContext.Instance.Films.Where(f => f.FilmImage != null).ToList();
            films.ForEach(f => Console.WriteLine($"{f.Title} - {f.FilmImage.Title}"));
        }

        private static void SelectFilmImagesAndFilms()
        {
            ConsoleHelper.WriteCaller();
            var images = MoviesContext.Instance.FilmImages.ToList();
            images.ForEach(i => Console.WriteLine($"{i.Title} - {i.Film.Title}"));
        }
    }
}
