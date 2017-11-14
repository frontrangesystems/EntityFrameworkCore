namespace MoviesApp.Models
{
    public class FilmModel
    {
        public int FilmId { get; set; }
        public string Title { get; set; }
        public int? ReleaseYear { get; set; }
        public int? Runtime { get; set; }
        public int? RatingId { get; set; }
    }
}