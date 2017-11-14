using Microsoft.EntityFrameworkCore;
using MoviesApp.Entities;

namespace MoviesApp.Data
{
    public class MoviesContext : DbContext
    {
        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Film> Films { get; set; }
        public virtual DbSet<FilmActor> FilmActors { get; set; }
        public virtual DbSet<FilmCategory> FilmCategories { get; set; }
        public virtual DbSet<FilmImage> FilmImages { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }

        private static MoviesContext _context;
        public static MoviesContext Instance
        {
            get
            {
                if (_context == null)
                {
                    _context = new MoviesContext();
                    // var serviceProvider = _context.GetInfrastructure<IServiceProvider>();
                    // var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                    // loggerFactory.AddProvider(new MyLoggerProvider());
                }
                return _context;
            }
        }

                protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // MySQL
                optionsBuilder.UseMySql("server=localhost;userid=root;pwd=rootpw;port=3306;database=MoviesApp;sslmode=none;");

                // SQL Server
                // optionsBuilder.UseSqlServer("Server=.;Database=MoviesAppSqlServer;User Id=web;Password=web;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FilmActor>(entity =>
            {
                entity.HasKey(e => new { e.FilmId, e.ActorId });
            });

            modelBuilder.Entity<FilmCategory>(entity =>
            {
                entity.HasKey(e => new { e.FilmId, e.CategoryId });
            });
        }

    }
}
