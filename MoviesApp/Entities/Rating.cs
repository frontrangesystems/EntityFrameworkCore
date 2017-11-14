using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesApp.Entities
{
    [Table(nameof(Rating))]
    public class Rating
    {
        public Rating()
        {
            Films = new HashSet<Film>();
        }

        [Key]
        public int RatingId { get; set; }

        [Required]
        [StringLength(10)]
        public string Code { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public ICollection<Film> Films { get; set; }
    }

}
