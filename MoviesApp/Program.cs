using System;
using System.Linq;
using MoviesApp.Helpers;

namespace MoviesApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO: fix seeding film image table
            // SeedDataHelper.SeedDatabase();
            // SimpleSelectHelper.RunAll();
            // OneToOneSelectHelper.RunAll();
            // OneToManySelectHelper.RunAll();
            ManyToManySelectHelper.RunAll();
        }
    }
}
