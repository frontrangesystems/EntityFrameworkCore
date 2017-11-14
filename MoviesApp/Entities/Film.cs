using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesApp.Entities
{
    [Table(nameof(Film))]
    public partial class Film
    {
        public Film()
        {
            FilmActors = new HashSet<FilmActor>();
            FilmCategories = new HashSet<FilmCategory>();
        }

        [Key]
        public int FilmId { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        public string Description { get; set; }

        public int? ReleaseYear { get; set; }

        public int? Runtime { get; set; }

        public int? RatingId { get; set; }

        [ForeignKey(nameof(RatingId))]
        public Rating Rating { get; set; }

        public FilmImage FilmImage { get; set; }

        public ICollection<FilmActor> FilmActors { get; set; }
        public ICollection<FilmCategory> FilmCategories { get; set; }

    }

}
