using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesApp.Entities
{
    [Table(nameof(Category))]
    public partial class Category
    {
        public Category()
        {
            FilmCategories = new HashSet<FilmCategory>();
        }
       
        [Key]
        public int CategoryId { get; set; }
       
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public ICollection<FilmCategory> FilmCategories { get; set; }
    }

}
