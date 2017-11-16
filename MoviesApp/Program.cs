﻿using System;
using MoviesApp.Data;
using MoviesApp.Helpers;

namespace MoviesApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            MoviesContext.UseLogger = true;

//            SeedDataHelper.SeedDatabase();
//            SimpleSelectHelper.RunAll();
//            OneToOneSelectHelper.RunAll();
//            OneToManySelectHelper.RunAll();
//            ManyToManySelectHelper.RunAll();
//            InsertHelper.RunAll();
//            UpdateHelper.RunAll();
//            DeleteHelper.RunAll();
//            PerformanceHelper.RunAll();
//            StoredProcedureHelper.RunAll();
//            RawSqlHelper.RunAll();
//            TransactionHelper.RunAll();

            Console.WriteLine("Press a key to exit.");
            Console.ReadKey();
        }
    }
}