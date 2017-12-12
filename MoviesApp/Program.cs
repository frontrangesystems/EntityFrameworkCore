using System;
using Microsoft.EntityFrameworkCore;
using MoviesApp.Data;
using MoviesApp.Helpers;

namespace MoviesApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //MoviesContext.UseLogger = true;

            SeedDataHelper.SeedDatabase();
            // run against SQL Server
//            SimpleSelectHelper.RunAll();
//            OneToOneSelectHelper.RunAll();
//            OneToManySelectHelper.RunAll();
//            ManyToManySelectHelper.RunAll();
//            InsertHelper.RunAll();
//            UpdateHelper.RunAll();
//            DeleteHelper.RunAll();
//            PerformanceHelper.RunAll();
//            RawSqlHelper.RunAll();
//            StoredProcedureHelper.RunAll();
//            TransactionHelper.RunAll();

            Console.WriteLine("Press a key to exit.");
            Console.ReadKey();
        }
    }
}