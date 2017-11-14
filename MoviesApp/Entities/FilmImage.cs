using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesApp.Entities
{
    [Table(nameof(FilmImage))]
    public class FilmImage
    {
        [Key]
        public int FilmImageId { get; set; }

        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public int FilmId { get; set; }

        [ForeignKey(nameof(FilmId))]
        public Film Film { get; set; }
    }

}
