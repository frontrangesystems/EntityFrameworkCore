using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesApp.Entities
{
    [Table(nameof(FilmActor))]
    public partial class FilmActor
    {
        public int FilmId { get; set; }
        public int ActorId { get; set; }

        public Actor Actor { get; set; }
        public Film Film { get; set; }
    }

}
