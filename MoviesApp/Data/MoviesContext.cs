using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MoviesApp.Entities;
using MoviesApp.Providers;

namespace MoviesApp.Data
{
    public class MoviesContext : DbContext
    {
        private static MoviesContext _context;
        private static bool _useLogger;
        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Film> Films { get; set; }
        public virtual DbSet<FilmActor> FilmActors { get; set; }
        public virtual DbSet<FilmCategory> FilmCategories { get; set; }
        public virtual DbSet<FilmImage> FilmImages { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }

        public static bool UseLogger
        {
            get => _useLogger;
            set
            {
                _useLogger = value;
                _context = null;
            }
        }

        public static MoviesContext Instance
        {
            get
            {
                if (_context == null)
                {
                    _context = new MoviesContext();

                    if (UseLogger)
                    {
                        var serviceProvider = _context.GetInfrastructure();
                        var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                        loggerFactory.AddProvider(new MyLoggerProvider());
                    }
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
            modelBuilder.Entity<FilmActor>(entity => { entity.HasKey(e => new {e.FilmId, e.ActorId}); });

            modelBuilder.Entity<FilmCategory>(entity => { entity.HasKey(e => new {e.FilmId, e.CategoryId}); });
        }
    }
}