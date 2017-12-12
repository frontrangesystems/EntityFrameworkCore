using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MoviesApp.Data;
using MoviesApp.Entities;
using MoviesApp.Extensions;

namespace MoviesApp.Helpers
{
    public static class SeedDataHelper
    {
        private static List<Actor> Actors
        {
            get
            {
                var id = 1;
                return new[]
                {
                    new Actor {ActorId = id++, FirstName = "Mark", LastName = "Hamill"},
                    new Actor {ActorId = id++, FirstName = "Harrison", LastName = "Ford"},
                    new Actor {ActorId = id++, FirstName = "Carrie", LastName = "Fisher"},
                    new Actor {ActorId = id++, FirstName = "Peter", LastName = "Cushing"},
                    new Actor {ActorId = id++, FirstName = "Alec", LastName = "Guinness"},
                    new Actor {ActorId = id++, FirstName = "Anthony", LastName = "Daniels"},
                    new Actor {ActorId = id++, FirstName = "Kenny", LastName = "Baker"},
                    new Actor {ActorId = id++, FirstName = "Peter", LastName = "Mayhew"},
                    new Actor {ActorId = id++, FirstName = "David", LastName = "Prowse"},
                    new Actor {ActorId = id++, FirstName = "Frank", LastName = "Oz"},
                    new Actor {ActorId = id++, FirstName = "Phil", LastName = "Brown"},
                    new Actor {ActorId = id++, FirstName = "Robert", LastName = "Downy Jr."},
                    new Actor {ActorId = id++, FirstName = "Chris", LastName = "Evans"},
                    new Actor {ActorId = id++, FirstName = "Mark", LastName = "Ruffalo"},
                    new Actor {ActorId = id++, FirstName = "Chris", LastName = "Henmsworth"},
                    new Actor {ActorId = id++, FirstName = "Scarlett", LastName = "Johansson"},
                    new Actor {ActorId = id++, FirstName = "Jeremy", LastName = "Renner"},
                    new Actor {ActorId = id++, FirstName = "Tom", LastName = "Hiddleston"},
                    new Actor {ActorId = id++, FirstName = "Samuel L.", LastName = "Jackson"},
                    new Actor {ActorId = id++, FirstName = "Natalie", LastName = "Portman"},
                    new Actor {ActorId = id++, FirstName = "Felicity", LastName = "Jones"}
                }.ToList();
            }
        }

        private static List<Film> Films
        {
            get
            {
                var id = 1;
                return new[]
                {
                    new Film
                    {
                        FilmId = id++,
                        Title = "Captain America: The Winter Soldier",
                        Description =
                            "As Steve Rogers struggles to embrace his role in the modern world, he teams up with a fellow Avenger and S.H.I.E.L.D agent, Black Widow, to battle a new threat from history: an assassin known as the Winter Soldier.",
                        ReleaseYear = 2014,
                        RatingId = 3
                    },
                    new Film
                    {
                        FilmId = id++,
                        Title = "The Avengers",
                        Description =
                            "Earth's mightiest heroes must come together and learn to fight as a team if they are to stop the mischievous Loki and his alien army from enslaving humanity.",
                        ReleaseYear = 2012,
                        RatingId = 3
                    },
                    new Film
                    {
                        FilmId = id++,
                        Title = "Thor",
                        Description =
                            "The powerful but arrogant god Thor is cast out of Asgard to live amongst humans in Midgard (Earth), where he soon becomes one of their finest defenders.",
                        ReleaseYear = 2011,
                        RatingId = 3
                    },
                    new Film
                    {
                        FilmId = id++,
                        Title = "Avengers: Age of Ultron",
                        Description =
                            "When Tony Stark and Bruce Banner try to jump-start a dormant peacekeeping program called Ultron, things go horribly wrong and it's up to Earth's mightiest heroes to stop the villainous Ultron from enacting his terrible plan.",
                        ReleaseYear = 2015,
                        RatingId = 3
                    },
                    new Film
                    {
                        FilmId = id++,
                        Title = "Captain America: The First Avenger",
                        Description =
                            "Steve Rogers, a rejected military soldier transforms into Captain America after taking a dose of a \"Super-Soldier serum\". But being Captain America comes at a price as he attempts to take down a war monger and a terrorist organization.",
                        ReleaseYear = 2011,
                        RatingId = 3
                    },
                    new Film
                    {
                        FilmId = id++,
                        Title = "Star Wars: Episode IV - A New Hope",
                        Description =
                            "Luke Skywalker joins forces with a Jedi Knight, a cocky pilot, a Wookiee, and two droids to save the galaxy from the Empire's world-destroying battle-station, while also attempting to rescue Princess Leia from the evil Darth Vader. ",
                        ReleaseYear = 1977,
                        RatingId = 2
                    },
                    new Film
                    {
                        FilmId = id++,
                        Title = "Star Wars: Episode V - The Empire Strikes Back",
                        Description =
                            "After the rebels are overpowered by the Empire on their newly established base, Luke Skywalker begins Jedi training with Master Yoda. His friends accept shelter from a questionable ally as Darth Vader hunts them in a plan to capture Luke.",
                        ReleaseYear = 1980,
                        RatingId = 2
                    },
                    new Film
                    {
                        FilmId = id++,
                        Title = "Star Wars: Episode VI - Return of the Jedi",
                        Description =
                            "After a daring mission to rescue Han Solo from Jabba the Hutt, the rebels dispatch to Endor to destroy a more powerful Death Star. Meanwhile, Luke struggles to help Vader back from the dark side without falling into the Emperor's trap.",
                        ReleaseYear = 1983,
                        RatingId = 2
                    },
                    new Film
                    {
                        FilmId = id++,
                        Title = "Star Wars: Episode I - The Phantom Menace",
                        Description =
                            "Two Jedi Knights escape a hostile blockade to find allies and come across a young boy who may bring balance to the Force, but the long dormant Sith resurface to claim their old glory.",
                        ReleaseYear = 1999,
                        RatingId = 2
                    },
                    new Film
                    {
                        FilmId = id++,
                        Title = "Star Wars: Episode II - Attack of the Clones",
                        Description =
                            "Ten years after initially meeting, Anakin Skywalker shares a forbidden romance with Padmé, while Obi-Wan investigates an assassination attempt on the Senator and discovers a secret clone army crafted for the Jedi.",
                        ReleaseYear = 2002,
                        RatingId = 2
                    },
                    new Film
                    {
                        FilmId = id++,
                        Title = "Star Wars: Episode III - Revenge of the Sith",
                        Description =
                            "Three years into the Clone Wars, the Jedi rescue Palpatine from Count Dooku. As Obi-Wan pursues a new threat, Anakin acts as a double agent between the Jedi Council and Palpatine and is lured into a sinister plan to rule the galaxy.",
                        ReleaseYear = 2005,
                        RatingId = 3
                    },
                    new Film
                    {
                        FilmId = id++,
                        Title = "Rogue One",
                        Description =
                            "Three decades after the Empire's defeat, a new threat arises in the militant First Order. Stormtrooper defector Finn and spare parts scavenger Rey are caught up in the Resistance's search for the missing Luke Skywalker.",
                        ReleaseYear = 2016,
                        RatingId = 3
                    }
                }.ToList();
            }
        }

        private static List<Rating> Ratings
        {
            get
            {
                var id = 1;
                return new[]
                {
                    new Rating {RatingId = id++, Code = "G", Name = "General Audiences"},
                    new Rating {RatingId = id++, Code = "PG", Name = "Parental Guidance Suggested"},
                    new Rating {RatingId = id++, Code = "PG-13", Name = "Parents Strongly Cautioned"},
                    new Rating {RatingId = id++, Code = "R", Name = "Restricted"}
                }.ToList();
            }
        }

        private static List<FilmActor> FilmActors => new[]
        {
            new FilmActor {FilmId = 6, ActorId = 1},
            new FilmActor {FilmId = 7, ActorId = 1},
            new FilmActor {FilmId = 8, ActorId = 1},
            new FilmActor {FilmId = 9, ActorId = 1},
            new FilmActor {FilmId = 10, ActorId = 1},
            new FilmActor {FilmId = 11, ActorId = 1},
            new FilmActor {FilmId = 6, ActorId = 2},
            new FilmActor {FilmId = 7, ActorId = 2},
            new FilmActor {FilmId = 8, ActorId = 2},
            new FilmActor {FilmId = 9, ActorId = 2},
            new FilmActor {FilmId = 10, ActorId = 2},
            new FilmActor {FilmId = 11, ActorId = 2},
            new FilmActor {FilmId = 6, ActorId = 3},
            new FilmActor {FilmId = 7, ActorId = 3},
            new FilmActor {FilmId = 8, ActorId = 3},
            new FilmActor {FilmId = 9, ActorId = 3},
            new FilmActor {FilmId = 10, ActorId = 3},
            new FilmActor {FilmId = 11, ActorId = 3},
            new FilmActor {FilmId = 6, ActorId = 4},
            new FilmActor {FilmId = 7, ActorId = 4},
            new FilmActor {FilmId = 8, ActorId = 4},
            new FilmActor {FilmId = 9, ActorId = 4},
            new FilmActor {FilmId = 10, ActorId = 4},
            new FilmActor {FilmId = 11, ActorId = 4},
            new FilmActor {FilmId = 6, ActorId = 5},
            new FilmActor {FilmId = 7, ActorId = 5},
            new FilmActor {FilmId = 8, ActorId = 5},
            new FilmActor {FilmId = 9, ActorId = 5},
            new FilmActor {FilmId = 10, ActorId = 5},
            new FilmActor {FilmId = 11, ActorId = 5},
            new FilmActor {FilmId = 6, ActorId = 6},
            new FilmActor {FilmId = 7, ActorId = 6},
            new FilmActor {FilmId = 8, ActorId = 6},
            new FilmActor {FilmId = 9, ActorId = 6},
            new FilmActor {FilmId = 10, ActorId = 6},
            new FilmActor {FilmId = 11, ActorId = 6},
            new FilmActor {FilmId = 6, ActorId = 7},
            new FilmActor {FilmId = 7, ActorId = 7},
            new FilmActor {FilmId = 8, ActorId = 7},
            new FilmActor {FilmId = 9, ActorId = 7},
            new FilmActor {FilmId = 10, ActorId = 7},
            new FilmActor {FilmId = 11, ActorId = 7},
            new FilmActor {FilmId = 6, ActorId = 8},
            new FilmActor {FilmId = 7, ActorId = 8},
            new FilmActor {FilmId = 8, ActorId = 8},
            new FilmActor {FilmId = 9, ActorId = 8},
            new FilmActor {FilmId = 10, ActorId = 8},
            new FilmActor {FilmId = 11, ActorId = 8},
            new FilmActor {FilmId = 6, ActorId = 9},
            new FilmActor {FilmId = 7, ActorId = 9},
            new FilmActor {FilmId = 8, ActorId = 9},
            new FilmActor {FilmId = 9, ActorId = 9},
            new FilmActor {FilmId = 10, ActorId = 9},
            new FilmActor {FilmId = 11, ActorId = 9},
            new FilmActor {FilmId = 7, ActorId = 10},
            new FilmActor {FilmId = 6, ActorId = 11},
            new FilmActor {FilmId = 7, ActorId = 11},
            new FilmActor {FilmId = 8, ActorId = 11},
            new FilmActor {FilmId = 9, ActorId = 11},
            new FilmActor {FilmId = 10, ActorId = 11},
            new FilmActor {FilmId = 11, ActorId = 11},
            new FilmActor {FilmId = 2, ActorId = 12},
            new FilmActor {FilmId = 4, ActorId = 12},
            new FilmActor {FilmId = 1, ActorId = 13},
            new FilmActor {FilmId = 2, ActorId = 13},
            new FilmActor {FilmId = 4, ActorId = 13},
            new FilmActor {FilmId = 5, ActorId = 13},
            new FilmActor {FilmId = 2, ActorId = 14},
            new FilmActor {FilmId = 4, ActorId = 14},
            new FilmActor {FilmId = 2, ActorId = 15},
            new FilmActor {FilmId = 3, ActorId = 15},
            new FilmActor {FilmId = 4, ActorId = 15},
            new FilmActor {FilmId = 1, ActorId = 16},
            new FilmActor {FilmId = 2, ActorId = 16},
            new FilmActor {FilmId = 4, ActorId = 16},
            new FilmActor {FilmId = 5, ActorId = 16},
            new FilmActor {FilmId = 2, ActorId = 17},
            new FilmActor {FilmId = 4, ActorId = 17},
            new FilmActor {FilmId = 2, ActorId = 18},
            new FilmActor {FilmId = 3, ActorId = 18},
            new FilmActor {FilmId = 1, ActorId = 19},
            new FilmActor {FilmId = 2, ActorId = 19},
            new FilmActor {FilmId = 4, ActorId = 19},
            new FilmActor {FilmId = 5, ActorId = 19},
            new FilmActor {FilmId = 3, ActorId = 20},
            new FilmActor {FilmId = 12, ActorId = 21}
        }.ToList();

        private static List<FilmImage> FilmImages
        {
            get
            {
                var id = 1;
                return new[]
                {
                    new FilmImage
                    {
                        FilmImageId = id++,
                        FilmId = 12,
                        Title = "Rogue One Movie Poster",
                        ImageUrl =
                            "https://images-na.ssl-images-amazon.com/images/M/MV5BMjEwMzMxODIzOV5BMl5BanBnXkFtZTgwNzg3OTAzMDI@._V1_SY1000_SX675_AL_.jpg"
                    }
                }.ToList();
            }
        }

        private static List<Category> Categories
        {
            get
            {
                var id = 1;
                return new[]
                {
                    new Category {CategoryId = id++, Name = "Action"},
                    new Category {CategoryId = id++, Name = "Animation"},
                    new Category {CategoryId = id++, Name = "Children"},
                    new Category {CategoryId = id++, Name = "Classics"},
                    new Category {CategoryId = id++, Name = "Comedy"},
                    new Category {CategoryId = id++, Name = "Documentary"},
                    new Category {CategoryId = id++, Name = "Drama"},
                    new Category {CategoryId = id++, Name = "Family"},
                    new Category {CategoryId = id++, Name = "Foreign"},
                    new Category {CategoryId = id++, Name = "Games"},
                    new Category {CategoryId = id++, Name = "Horror"},
                    new Category {CategoryId = id++, Name = "Music"},
                    new Category {CategoryId = id++, Name = "New"},
                    new Category {CategoryId = id++, Name = "Sci-Fi"},
                    new Category {CategoryId = id++, Name = "Sports"},
                    new Category {CategoryId = id++, Name = "Travel"}
                }.ToList();
            }
        }

        private static List<FilmCategory> FilmCategories => new[]
        {
            new FilmCategory {FilmId = 1, CategoryId = 1},
            new FilmCategory {FilmId = 2, CategoryId = 1},
            new FilmCategory {FilmId = 3, CategoryId = 1},
            new FilmCategory {FilmId = 4, CategoryId = 1},
            new FilmCategory {FilmId = 5, CategoryId = 1},
            new FilmCategory {FilmId = 6, CategoryId = 4},
            new FilmCategory {FilmId = 7, CategoryId = 4},
            new FilmCategory {FilmId = 8, CategoryId = 4},
            new FilmCategory {FilmId = 6, CategoryId = 14},
            new FilmCategory {FilmId = 7, CategoryId = 14},
            new FilmCategory {FilmId = 8, CategoryId = 14},
            new FilmCategory {FilmId = 9, CategoryId = 14},
            new FilmCategory {FilmId = 10, CategoryId = 14},
            new FilmCategory {FilmId = 11, CategoryId = 14},
            new FilmCategory {FilmId = 12, CategoryId = 14}
        }.ToList();

        public static void SeedDatabase()
        {
            WriteDataCount();
             AddSeedData();
//            AddOrUpdateSeedData();
            WriteDataCount();
        }

        private static void WriteDataCount()
        {
            var count = MoviesContext.Instance.Ratings.Count();
            Console.WriteLine($"ratings: {count}");
            count = MoviesContext.Instance.Films.Count();
            Console.WriteLine($"films: {count}");
            count = MoviesContext.Instance.FilmImages.Count();
            Console.WriteLine($"film images: {count}");
            count = MoviesContext.Instance.Categories.Count();
            Console.WriteLine($"categories: {count}");
            count = MoviesContext.Instance.FilmCategories.Count();
            Console.WriteLine($"film categories: {count}");
        }

        private static void AddSeedData()
        {
            if (!MoviesContext.Instance.Ratings.Any())
            {
                Console.WriteLine("Seeding ratings");
                Ratings.ForEach(r =>
                {
                    r.RatingId = 0;
                    MoviesContext.Instance.Ratings.Add(r);
                });
                MoviesContext.Instance.SaveChanges();
                Console.WriteLine("Done");
            }
            else
            {
                Console.WriteLine("Skipping Ratings");
            }
            if (!MoviesContext.Instance.Films.Any())
            {
                Console.WriteLine("Seeding films");
                Films.ForEach(f =>
                {
                    f.FilmId = 0;
                    MoviesContext.Instance.Films.Add(f);
                });
                MoviesContext.Instance.SaveChanges();
                Console.WriteLine("Done");
            }
            else
            {
                Console.WriteLine("Skipping films");
            }

            if (!MoviesContext.Instance.Categories.Any())
            {
                Console.WriteLine("Seeding categories");
                Categories.ForEach(c =>
                {
                    c.CategoryId = 0;
                    MoviesContext.Instance.Categories.Add(c);
                });
                MoviesContext.Instance.SaveChanges();
                Console.WriteLine("Done");
            }
            else
            {
                Console.WriteLine("Skipping categories");
            }

            if (!MoviesContext.Instance.FilmCategories.Any())
            {
                Console.WriteLine("Seeding film categories");
                FilmCategories.ForEach(fc => MoviesContext.Instance.FilmCategories.Add(fc));
                MoviesContext.Instance.SaveChanges();
                Console.WriteLine("Done");
            }
            else
            {
                Console.WriteLine("Skipping film categories");
            }
        }

        private static void AddOrUpdateSeedData()
        {
            AddOrUpdateActors();
            AddOrUpdateRatings();
            AddOrUpdateFilms();
            AddOrUpdateFilmImages();
            AddOrUpdateCategories();
            AddOrUpdateFilmCategories();
            AddOrUpdateFilmActors();
        }

        private static void AddOrUpdateActors()
        {
            var updatedCount = 0;
            var addedCount = 0;

            Console.WriteLine("Seeding actors");
            Actors.ForEach(a =>
            {
                var entity = MoviesContext.Instance.Actors
                    .SingleOrDefault(e => e.ActorId == a.ActorId);
                if (entity == null)
                {
                    MoviesContext.Instance.Actors.Attach(a);
                    MoviesContext.Instance.Entry(a).State = EntityState.Added;
                    addedCount++;
                }
                else
                {
                    a.Copy(entity);
                    updatedCount++;
                }
            });

            Console.WriteLine($"Done. Updated: {updatedCount}, Added: {addedCount}");

            MoviesContext.Instance.SaveChanges();
        }

        private static void AddOrUpdateFilmActors()
        {
            var updatedCount = 0;
            var addedCount = 0;

            Console.WriteLine("Seeding film actors");
            FilmActors.ForEach(fa =>
            {
                var filmActor = MoviesContext.Instance.FilmActors
                    .SingleOrDefault(a => a.FilmId == fa.FilmId && a.ActorId == fa.ActorId);
                if (filmActor == null)
                {
                    MoviesContext.Instance.FilmActors.Attach(fa);
                    MoviesContext.Instance.Entry(fa).State = EntityState.Added;
                    addedCount++;
                }
            });
            Console.WriteLine($"Done. Updated: {updatedCount}, Added: {addedCount}");

            MoviesContext.Instance.SaveChanges();
        }

        private static void AddOrUpdateFilmCategories()
        {
            var updatedCount = 0;
            var addedCount = 0;

            Console.WriteLine("Seeding film categories");
            FilmCategories.ForEach(fc =>
            {
                var filmCategory = MoviesContext.Instance.FilmCategories
                    .SingleOrDefault(e => e.FilmId == fc.FilmId && e.CategoryId == fc.CategoryId);
                if (filmCategory == null)
                {
                    MoviesContext.Instance.FilmCategories.Attach(fc);
                    MoviesContext.Instance.Entry(fc).State = EntityState.Added;
                    addedCount++;
                }
            });
            Console.WriteLine($"Done. Updated: {updatedCount}, Added: {addedCount}");

            MoviesContext.Instance.SaveChanges();
        }

        private static void AddOrUpdateCategories()
        {
            var updatedCount = 0;
            var addedCount = 0;

            Console.WriteLine("Seeding categories");
            Categories.ForEach(c =>
            {
                var category = MoviesContext.Instance.Categories.SingleOrDefault(e => e.CategoryId == c.CategoryId);
                if (category == null)
                {
                    MoviesContext.Instance.Categories.Attach(c);
                    MoviesContext.Instance.Entry(c).State = EntityState.Added;
                    addedCount++;
                }
                else
                {
                    c.Copy(category);
                    updatedCount++;
                }
            });
            Console.WriteLine($"Done. Updated: {updatedCount}, Added: {addedCount}");

            MoviesContext.Instance.SaveChanges();
        }

        private static void AddOrUpdateFilmImages()
        {
            var updatedCount = 0;
            var addedCount = 0;

            Console.WriteLine("Seeding film images");
            FilmImages.ForEach(i =>
            {
                var image = MoviesContext.Instance.FilmImages.SingleOrDefault(e => e.FilmImageId == i.FilmImageId);
                if (image == null)
                {
                    MoviesContext.Instance.FilmImages.Attach(i);
                    MoviesContext.Instance.Entry(i).State = EntityState.Added;
                    addedCount++;
                }
            });
            Console.WriteLine($"Done. Updated: {updatedCount}, Added: {addedCount}");

            MoviesContext.Instance.SaveChanges();
        }

        private static void AddOrUpdateFilms()
        {
            var updatedCount = 0;
            var addedCount = 0;

            Console.WriteLine("Seeding films");
            Films.ForEach(f =>
            {
                var film = MoviesContext.Instance.Films.SingleOrDefault(e => e.FilmId == f.FilmId);
                if (film == null)
                {
                    MoviesContext.Instance.Films.Attach(f);
                    MoviesContext.Instance.Entry(f).State = EntityState.Added;
                    addedCount++;
                }
                else
                {
                    f.Copy(film);
                    updatedCount++;
                }
            });
            Console.WriteLine($"Done. Updated: {updatedCount}, Added: {addedCount}");

            MoviesContext.Instance.SaveChanges();
        }

        private static void AddOrUpdateRatings()
        {
            var updatedCount = 0;
            var addedCount = 0;
            Console.WriteLine("Seeding ratings");
            Ratings.ForEach(r =>
            {
                var rating = MoviesContext.Instance.Ratings.SingleOrDefault(e => e.RatingId == r.RatingId);
                if (rating == null)
                {
                    MoviesContext.Instance.Ratings.Attach(r);
                    MoviesContext.Instance.Entry(r).State = EntityState.Added;
                    addedCount++;
                }
                else
                {
                    r.Copy(rating);
                    updatedCount++;
                }
            });
            Console.WriteLine($"Done. Updated: {updatedCount}, Added: {addedCount}");

            MoviesContext.Instance.SaveChanges();
        }
    }
}