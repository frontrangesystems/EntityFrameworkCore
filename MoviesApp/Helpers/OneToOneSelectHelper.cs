using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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

            var films = MoviesContext.Instance.Films
                .Include(f=>f.FilmImage)
                .Where(f => f.FilmImage != null).ToList();
            films.ForEach(f => Console.WriteLine($"{f.Title} - {f.FilmImage.Title}"));
        }

        private static void SelectFilmImagesAndFilms()
        {
            ConsoleHelper.WriteCaller();

            var images = MoviesContext.Instance.FilmImages
                .Include(f => f.Film).ToList();
            images.ForEach(i => Console.WriteLine($"{i.Title} - {i.Film.Title}"));
        }
    }
}
