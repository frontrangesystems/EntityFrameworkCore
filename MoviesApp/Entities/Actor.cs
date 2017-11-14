using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesApp.Entities
{

    [Table(nameof(Actor))]
    public partial class Actor
    {
        public Actor()
        {
            FilmActors = new HashSet<FilmActor>();
        }

        [Key]
        public int ActorId { get; set; }
       
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
       
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        public ICollection<FilmActor> FilmActors { get; set; }
    }

}
