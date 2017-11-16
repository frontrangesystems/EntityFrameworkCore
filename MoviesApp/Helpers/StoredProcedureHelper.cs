using System.Linq;
using ConsoleTables;
using Microsoft.EntityFrameworkCore;
using MoviesApp.Data;
using MoviesApp.Entities;
using MoviesApp.Extensions;
using MoviesApp.Models;

namespace MoviesApp.Helpers
{
    public static class StoredProcedureHelper
    {
        /* Execute the following SQL against MySQL server to create the stored procedures.
        DELIMITER $$
        CREATE DEFINER=`root`@`localhost` PROCEDURE `FilmStartsWithTitle`(in prefix varchar(50))
        BEGIN

        set prefix = concat(prefix, '%');
        select * from film where title like prefix order by title;

        END$$
        DELIMITER ;

        DELIMITER $$
        CREATE DEFINER=`root`@`localhost` PROCEDURE `FindActor`(in find varchar(50))
        BEGIN

        declare findName varchar(52);
        set findName = concat('%', find, '%');
        select * from actor where firstname like findName or lastname like findName order by lastname, firstname;

        END$$
        DELIMITER ;

        DELIMITER $$
        CREATE DEFINER=`root`@`localhost` PROCEDURE `PagedActors`(in pageSize int, in pageNumber int)
        BEGIN

        declare skip int;
        set skip = pageSize * (pageNumber - 1);

        select * from actor order by LastName, FirstName limit skip, pageSize;

        END$$
        DELIMITER ;
         */

        public static void RunAll()
        {
            FindFilms();
            FindActors();
        }

        private static void FindFilms()
        {
            ConsoleHelper.WriteCaller();

            var sql = "call FilmStartsWithTitle({0})";
            var films = MoviesContext.Instance.Films
                .FromSql(sql, "t")
                .Select(f => f.Copy<Film, FilmModel>());
            ConsoleTable.From(films).Write();
        }

        private static void FindActors()
        {
            ConsoleHelper.WriteCaller();

            var sql = "call FindActor({0})";
            var actors = MoviesContext.Instance.Actors
                .FromSql(sql, "on")
                .Select(a => a.Copy<Actor, ActorModel>());
            ConsoleTable.From(actors).Write();
        }
    }
}