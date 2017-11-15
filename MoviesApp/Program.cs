using System;
using MoviesApp.Helpers;

namespace MoviesApp
{
    class Program
    {
        static void Main(string[] args)
        {
//             SeedDataHelper.SeedDatabase();
            // SimpleSelectHelper.RunAll();
            // OneToOneSelectHelper.RunAll();
            // OneToManySelectHelper.RunAll();
//            ManyToManySelectHelper.RunAll();
//            RawSqlHelper.RunAll();
            TransactionHelper.RunAll();
            Console.ReadKey();
        }
    }
}
