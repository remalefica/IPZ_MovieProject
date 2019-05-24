using System.Collections.Generic;
using System.Linq;

using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using static System.Net.WebRequestMethods;

namespace DAL
{
	public sealed class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(user =>
             {
                 user.Property(u => u.Username).IsRequired();

             });

            modelBuilder.Entity<Film>(film =>
            {
                film.Property(f => f.Name).IsRequired();
                film.HasAlternateKey(f => f.Name);
                film.HasMany(f => f.Genres)
                    .WithOne(gs => gs.Film);
            });

            modelBuilder.Entity<Film>().HasData(
                new Film
                {
                    Id = 1,
                    Name = "The Shawshank Redemption",
                    Director = "Frank Darabont",
                    Year = 1994,
                    Description = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
                    FilmImgPath = "https://images.gowatchit.com/posters/original/p15987_p_v7_aa.jpg?1473180482",
                    FilmTrailerPath = "https://www.youtube.com/embed/BXUEUwwgIyU",
                    OriginCountry = "USA",
                    Budget = 25000000,
                    RatingAvg = 9.3,
                    DurationInMinutes = 142

                },
                new Film
                {
                    Id = 2,
                    Name = "Forrest Gump",
                    Director = "Robert Zemeckis",
                    Year = 1994,
                    Description = "The presidencies of Kennedy and Johnson, the events of Vietnam, Watergate, and other history unfold through the perspective of an Alabama man with an IQ of 75.",
                    FilmImgPath = "https://m.media-amazon.com/images/M/MV5BNWIwODRlZTUtY2U3ZS00Yzg1LWJhNzYtMmZiYmEyNmU1NjMzXkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_.jpg",
                    FilmTrailerPath = "https://www.youtube.com/embed/eYSnxZKTZzU",
                    OriginCountry = "USA",
                    Budget = 55000000,
                    RatingAvg = 8.7,
                    DurationInMinutes = 142
                },
                new Film
                {
                    Id = 3,
                    Name = "Fight Club",
                    Director = "David Fincher",
                    Year = 1999,
                    Description = "An insomniac office worker and a devil-may-care soapmaker form an underground fight club that evolves into something much, much more.",
                    FilmImgPath = "https://m.media-amazon.com/images/M/MV5BMjJmYTNkNmItYjYyZC00MGUxLWJhNWMtZDY4Nzc1MDAwMzU5XkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SY1000_CR0,0,676,1000_AL_.jpg",
                    FilmTrailerPath = "https://www.youtube.com/embed/D3Yw9Yc1YmY",
                    RatingAvg = 8.8,
                    OriginCountry = "USA | Germany",
                    Budget = 63000000,
                    DurationInMinutes = 112
                },
                new Film
                {
                    Id = 4,
                    Name = "Inception",
                    Director = "Christopher Nolan",
                    Year = 2010,
                    Description = "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O.",
                    FilmImgPath = "https://m.media-amazon.com/images/M/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwNTI5OTM0Mw@@._V1_SY1000_CR0,0,675,1000_AL_.jpg",
                    FilmTrailerPath = "https://www.youtube.com/embed/YoHD9XEInc0",
                    RatingAvg = 8.7,
                    OriginCountry = "USA | UK",
                    Budget = 160000000,
                    DurationInMinutes = 148
                },
                new Film
                {
                    Id = 5,
                    Name = "The Dark Knight",
                    Director = "Christopher Nolan",
                    Year = 2008,
                    Description = "It's tough to picture anyone other than Christian Bale as Batman in Christopher Nolan's trilogy, but plenty of other actors were considered. See who they were.",
                    FilmImgPath = "https://m.media-amazon.com/images/M/MV5BMTMxNTMwODM0NF5BMl5BanBnXkFtZTcwODAyMTk2Mw@@._V1_SY1000_CR0,0,675,1000_AL_.jpg",
                    FilmTrailerPath = "https://www.youtube.com/embed/g8evyE9TuYk",
                    RatingAvg = 9,
                    OriginCountry = "USA | UK",
                    Budget = 185000000,
                    DurationInMinutes = 152
                },
                new Film
                {
                    Id = 6,
                    Name = "The Godfather",
                    Director = "Francis Ford Coppola",
                    Year = 1974,
                    Description = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.",
                    FilmImgPath = "https://m.media-amazon.com/images/M/MV5BM2MyNjYxNmUtYTAwNi00MTYxLWJmNWYtYzZlODY3ZTk3OTFlXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SY1000_CR0,0,704,1000_AL_.jpg",
                    FilmTrailerPath = "https://www.youtube.com/embed/sY1S34973zA",
                    OriginCountry = "USA",
                    Budget = 6000000,
                    DurationInMinutes = 175,
                    RatingAvg = 9.2
                },
                new Film
                {
                    Id = 7,
                    Name = "1 + 1 (Intouchables)",
                    Director = "Olivier Nakache, Éric Toledano",
                    Year = 2011,
                    Description = "After he becomes a quadriplegic from a paragliding accident, an aristocrat hires a young man from the projects to be his caregiver.",
                    FilmImgPath = "https://m.media-amazon.com/images/M/MV5BMTYxNDA3MDQwNl5BMl5BanBnXkFtZTcwNTU4Mzc1Nw@@._V1_SY1000_CR0,0,674,1000_AL_.jpg",
                    FilmTrailerPath = "https://www.youtube.com/embed/34WIbmXkewU",
                    OriginCountry = "France",
                    Budget = 9500000,
                    RatingAvg = 8.5,
                    DurationInMinutes = 112
                },
                new Film
                {
                    Id = 8,
                    Name = "The Big Lebowski",
                    Director = "Joel Coen, Ethan Coen (uncredited)",
                    Year = 1998,
                    Description = "Jeff The Dude Lebowski, mistaken for a millionaire of the same name, seeks restitution for his ruined rug and enlists his bowling buddies to help get it.",
                    FilmImgPath = "https://m.media-amazon.com/images/M/MV5BMTQ0NjUzMDMyOF5BMl5BanBnXkFtZTgwODA1OTU0MDE@._V1_SY1000_CR0,0,670,1000_AL_.jpg",
                    FilmTrailerPath = "https://www.youtube.com/embed/cd-go0oBF4Y",
                    RatingAvg = 7.8,
                    OriginCountry = "USA | UK",
                    Budget = 15000000,
                    DurationInMinutes = 117
                },
                new Film
                {
                    Id = 9,
                    Name = "The Wolf of Wall Street ",
                    Director = "Martin Scorsese",
                    Year = 2013,
                    Description = "Based on the true story of Jordan Belfort, from his rise to a wealthy stock-broker living the high life to his fall involving crime, corruption and the federal government.",
                    FilmImgPath = "https://m.media-amazon.com/images/M/MV5BMjIxMjgxNTk0MF5BMl5BanBnXkFtZTgwNjIyOTg2MDE@._V1_SY1000_CR0,0,674,1000_AL_.jpg",
                    FilmTrailerPath = "https://www.youtube.com/embed/iszwuX1AK6A",
                    RatingAvg = 8.2,
                    OriginCountry = "USA",
                    Budget = 100000000,
                    DurationInMinutes = 180
                },
                new Film
                {
                    Id = 10,
                    Name = "The Lord of the Rings: The Return of the King",
                    Director = "Peter Jackson",
                    Year = 2003,
                    Description = "Gandalf and Aragorn lead the World of Men against Sauron's army to draw his gaze from Frodo and Sam as they approach Mount Doom with the One Ring.",
                    FilmImgPath = "https://m.media-amazon.com/images/M/MV5BNzA5ZDNlZWMtM2NhNS00NDJjLTk4NDItYTRmY2EwMWZlMTY3XkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_SY1000_CR0,0,675,1000_AL_.jpg",
                    FilmTrailerPath = "https://www.youtube.com/embed/r5X-hFf6Bwo",
                    RatingAvg = 8.9,
                    OriginCountry = "New Zealand | USA",
                    Budget = 94000000,
                    DurationInMinutes = 201
                },
                new Film
                {
                    Id = 11,
                    Name = "The Matrix",
                    Director = "Lana Wachowski (as The Wachowski Brothers), Lilly Wachowski (as The Wachowski Brothers)",
                    Year = 1999,
                    Description = "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.",
                    FilmImgPath = "https://m.media-amazon.com/images/M/MV5BNzQzOTk3OTAtNDQ0Zi00ZTVkLWI0MTEtMDllZjNkYzNjNTc4L2ltYWdlXkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_SY1000_CR0,0,665,1000_AL_.jpg",
                    FilmTrailerPath = "https://www.youtube.com/embed/m8e-FF8MsqU",
                    RatingAvg = 8.1,
                    OriginCountry = "USA",
                    Budget = 63000000,
                    DurationInMinutes = 136
                },
                new Film
                {
                    Id = 12,
                    Name = "Spider-Man: Homecoming",
                    Director = "Jon Watts",
                    Year = 2017,
                    Description = "Peter Parker balances his life as an ordinary high school student in Queens with his superhero alter-ego Spider-Man, and finds himself on the trail of a new menace prowling the skies of New York City.",
                    FilmImgPath = "https://m.media-amazon.com/images/M/MV5BNTk4ODQ1MzgzNl5BMl5BanBnXkFtZTgwMTMyMzM4MTI@._V1_SY1000_CR0,0,658,1000_AL_.jpg",
                    FilmTrailerPath = "https://www.youtube.com/embed/n9DwoQ7HWvI",
                    RatingAvg = 8.7,
                    OriginCountry = "USA",
                    Budget = 175000000,
                    DurationInMinutes = 133
                },
                new Film
                {
                    Id = 13,
                    Name = "Song of the Sea",
                    Director = "Tomm Moore",
                    Year = 2014,
                    Description = "Ben, a young Irish boy, and his little sister Saoirse, a girl who can turn into a seal, go on an adventure to free the fairies and save the spirit world.",
                    FilmImgPath = "https://m.media-amazon.com/images/M/MV5BMTQ2MDMwNjEwNV5BMl5BanBnXkFtZTgwOTkxMzI0MzE@._V1_SY1000_CR0,0,691,1000_AL_.jpg",
                    FilmTrailerPath = "https://www.youtube.com/embed/B7ZIugIa8KI",
                    RatingAvg = 7.2,
                    OriginCountry = "Ireland | Denmark | Belgium | Luxembourg | France",
                    Budget = 857524,
                    DurationInMinutes = 93
                },
                new Film
                {
                    Id = 14,
                    Name = "Bohemian Rhapsody",
                    Director = "Bryan Singer",
                    Year = 2018,
                    Description = "The story of the legendary rock band Queen and lead singer Freddie Mercury, leading up to their famous performance at Live Aid (1985).",
                    FilmImgPath = "https://m.media-amazon.com/images/M/MV5BMTA2NDc3Njg5NDVeQTJeQWpwZ15BbWU4MDc1NDcxNTUz._V1_SY1000_CR0,0,674,1000_AL_.jpg",
                    FilmTrailerPath = "https://www.youtube.com/embed/mP0VHJYFOAU",
                    RatingAvg = 7.7,
                    OriginCountry = "UK | USA",
                    Budget = 52000000,
                    DurationInMinutes = 134
                },
                new Film
                {
                    Id = 15,
                    Name = "Dunkirk",
                    Director = "Christopher Nolan",
                    Year = 2017,
                    Description = "Allied soldiers from Belgium, the British Empire, and France are surrounded by the German Army, and evacuated during a fierce battle in World War II.",
                    FilmImgPath = "https://m.media-amazon.com/images/M/MV5BN2YyZjQ0NTEtNzU5MS00NGZkLTg0MTEtYzJmMWY3MWRhZjM2XkEyXkFqcGdeQXVyMDA4NzMyOA@@._V1_SY1000_CR0,0,674,1000_AL_.jpg",
                    FilmTrailerPath = "https://www.youtube.com/embed/F-eMt3SrfFU",
                    RatingAvg = 7.9,
                    OriginCountry = "UK | Netherlands | France | USA",
                    Budget = 100000000,
                    DurationInMinutes = 106
                },
                new Film
                {
                    Id = 16,
                    Name = "Cobain: Montage of Heck",
                    Director = "Brett Morgen",
                    Year = 2015,
                    Description = "An authorized documentary on the late musician Kurt Cobain, from his early days in Aberdeen, Washington to his success and downfall with the grunge band Nirvana.",
                    FilmImgPath = "https://m.media-amazon.com/images/M/MV5BMjIyOTcxMTU2NV5BMl5BanBnXkFtZTgwNjcyMDg3NDE@._V1_.jpg",
                    FilmTrailerPath = "https://www.youtube.com/embed/uH00BUAvJmQ",
                    OriginCountry = " USA",
                    RatingAvg = 6.8
                },
                new Film
                {
                    Id = 17,
                    Name = "Scream",
                    Director = "Wes Craven",
                    Year = 1996,
                    Description = "A year after the murder of her mother, a teenage girl is terrorized by a new killer, who targets the girl and her friends by using horror films as part of a deadly game.",
                    FilmImgPath = "https://m.media-amazon.com/images/M/MV5BMjA2NjU5MTg5OF5BMl5BanBnXkFtZTgwOTkyMzQxMDE@._V1_SY1000_CR0,0,673,1000_AL_.jpg",
                    FilmTrailerPath = "https://www.youtube.com/embed/AWm_mkbdpCA",
                    OriginCountry = "USA",
                    Budget = 14000000,
                    DurationInMinutes = 111,
                    RatingAvg = 7.2
                },
                new Film
                {
                    Id = 18,
                    Name = "La La Land",
                    Director = "Damien Chazelle",
                    Year = 2016,
                    Description = "While navigating their careers in Los Angeles, a pianist and an actress fall in love while attempting to reconcile their aspirations for the future.",
                    FilmImgPath = "https://m.media-amazon.com/images/M/MV5BMzUzNDM2NzM2MV5BMl5BanBnXkFtZTgwNTM3NTg4OTE@._V1_SY1000_SX675_AL_.jpg",
                    FilmTrailerPath = "https://www.youtube.com/embed/0pdqf4P9MB8",
                    RatingAvg = 8,
                    OriginCountry = "USA | Hong Kong",
                    Budget = 30000000,
                    DurationInMinutes = 128
                },
                new Film
                {
                    Id = 19,
                    Name = "The Hateful Eight",
                    Director = "Quentin Tarantino",
                    Year = 2015,
                    Description = "In the dead of a Wyoming winter, a bounty hunter and his prisoner find shelter in a cabin currently inhabited by a collection of nefarious characters.",
                    FilmImgPath = "https://m.media-amazon.com/images/M/MV5BMjA1MTc1NTg5NV5BMl5BanBnXkFtZTgwOTM2MDEzNzE@._V1_SY1000_CR0,0,674,1000_AL_.jpg",
                    FilmTrailerPath = "https://www.youtube.com/embed/nIOmotayDMY",
                    OriginCountry = "USA",
                    Budget = 44000000,
                    DurationInMinutes = 168,
                    RatingAvg = 7.9
                },
                new Film
                {
                    Id = 20,
                    Name = "In a Heartbeat",
                    Director = "Esteban Bravo Beth David",
                    Year = 2017,
                    Description = "A boy has a crush on another boy and he is too shy to confess, but his heart is not so reticent.",
                    FilmImgPath = "https://m.media-amazon.com/images/M/MV5BNmMwOGQ4YjAtOWYzYS00N2U4LThhMTYtYTdhYzk5ZmViMjgwXkEyXkFqcGdeQXVyOTcwNTAwMw@@._V1_.jpg",
                    FilmTrailerPath = "https://www.youtube.com/embed/0pauY5cgRU4",
                    OriginCountry = "USA",
                    Budget = 5000,
                    RatingAvg = 8,
                    DurationInMinutes = 4
                },
                new Film
                {
                    Id = 21,
                    Name = "I, Tonya",
                    Director = "Craig Gillespie",
                    Year = 2017,
                    Description = "Competitive ice skater Tonya Harding rises amongst the ranks at the U.S. Figure Skating Championships, but her future in the activity is thrown into doubt when her ex-husband intervenes.",
                    FilmImgPath = "https://m.media-amazon.com/images/M/MV5BMjI5MDY1NjYzMl5BMl5BanBnXkFtZTgwNjIzNDAxNDM@._V1_SY1000_CR0,0,674,1000_AL_.jpg",
                    FilmTrailerPath = "https://www.youtube.com/embed/OXZQ5DfSAAc",
                    OriginCountry = "UK | USA",
                    Budget = 5000,
                    RatingAvg = 6.5,
                    DurationInMinutes = 4
                });

            modelBuilder.Entity<Genre>(genre =>
            {
                genre.Property(g => g.GenreName)
                        .HasConversion<int>();
                genre.HasData(
               // ACTION
               new Genre
               {
                   Id = 1,
                   GenreName = GenreListEnum.Action,
                   FilmId = 11
               },
               new Genre
               {
                   Id = 2,
                   GenreName = GenreListEnum.Action,
                   FilmId = 4
               },
               new Genre
               {
                   Id = 3,
                   GenreName = GenreListEnum.Action,
                   FilmId = 5
               },
               new Genre
               {
                   Id = 27,
                   GenreName = GenreListEnum.Action,
                   FilmId = 12
               },
               new Genre
               {
                   Id = 36,
                   GenreName = GenreListEnum.Action,
                   FilmId = 15
               },

                // ADVENTURE
                new Genre
                {
                    Id = 4,
                    GenreName = GenreListEnum.Adventure,
                    FilmId = 4

                },
                new Genre
                {
                    Id = 5,
                    GenreName = GenreListEnum.Adventure,
                    FilmId = 10
                },
                new Genre
                {
                    Id = 28,
                    GenreName = GenreListEnum.Adventure,
                    FilmId = 12
                },
                new Genre
                {
                    Id = 30,
                    GenreName = GenreListEnum.Adventure,
                    FilmId = 13
                },
                // ANIMATION
                new Genre
                {
                    Id = 6,
                    GenreName = GenreListEnum.Animation,
                    FilmId = 13
                },
                new Genre
                {
                    Id = 49,
                    GenreName = GenreListEnum.Animation,
                    FilmId = 16
                },


                // BIOGRAPHY
                new Genre
                {
                    Id = 7,
                    GenreName = GenreListEnum.Biography,
                    FilmId = 7
                },
                new Genre
                {
                    Id = 8,
                    GenreName = GenreListEnum.Biography,
                    FilmId = 9
                },
                new Genre
                {
                    Id = 33,
                    GenreName = GenreListEnum.Biography,
                    FilmId = 14
                },
                new Genre
                {
                    Id = 50,
                    GenreName = GenreListEnum.Biography,
                    FilmId = 16
                },
                new Genre
                {
                    Id = 61,
                    GenreName = GenreListEnum.Comedy,
                    FilmId = 21
                },

                // COMEDY
                new Genre
                {
                    Id = 9,
                    GenreName = GenreListEnum.Comedy,
                    FilmId = 7
                },
                new Genre
                {
                    Id = 10,
                    GenreName = GenreListEnum.Comedy,
                    FilmId = 8
                },
                new Genre
                {
                    Id = 43,
                    GenreName = GenreListEnum.Comedy,
                    FilmId = 18
                },
                new Genre
                {
                    Id = 60,
                    GenreName = GenreListEnum.Comedy,
                    FilmId = 21
                },
                // CRIME
                new Genre
                {
                    Id = 11,
                    GenreName = GenreListEnum.Crime,
                    FilmId = 5
                },
                new Genre
                {
                    Id = 12,
                    GenreName = GenreListEnum.Crime,
                    FilmId = 6
                },
                new Genre
                {
                    Id = 13,
                    GenreName = GenreListEnum.Crime,
                    FilmId = 9
                },
                new Genre
                {
                    Id = 52,
                    GenreName = GenreListEnum.Crime,
                    FilmId = 19
                },

                // DOCUMENTARY 
                new Genre
                {
                    Id = 48,
                    GenreName = GenreListEnum.Documentary,
                    FilmId = 16
                },

                // DRAMA
                new Genre
                {
                    Id = 14,
                    GenreName = GenreListEnum.Drama,
                    FilmId = 1

                },
                new Genre
                {
                    Id = 15,
                    GenreName = GenreListEnum.Drama,
                    FilmId = 2

                },
                new Genre
                {
                    Id = 16,
                    GenreName = GenreListEnum.Drama,
                    FilmId = 3

                },
                new Genre
                {
                    Id = 17,
                    GenreName = GenreListEnum.Drama,
                    FilmId = 6
                },
                new Genre
                {
                    Id = 18,
                    GenreName = GenreListEnum.Drama,
                    FilmId = 7
                },
                new Genre
                {
                    Id = 19,
                    GenreName = GenreListEnum.Drama,
                    FilmId = 9
                },
                new Genre
                {
                    Id = 20,
                    GenreName = GenreListEnum.Drama,
                    FilmId = 10
                },
                new Genre
                {
                    Id = 31,
                    GenreName = GenreListEnum.Drama,
                    FilmId = 13
                },
                new Genre
                {
                    Id = 34,
                    GenreName = GenreListEnum.Drama,
                    FilmId = 14
                },
                new Genre
                {
                    Id = 37,
                    GenreName = GenreListEnum.Drama,
                    FilmId = 15
                },
                new Genre
                {
                    Id = 44,
                    GenreName = GenreListEnum.Drama,
                    FilmId = 18
                },
                new Genre
                {
                    Id = 53,
                    GenreName = GenreListEnum.Drama,
                    FilmId = 19
                },
                new Genre
                {
                    Id = 59,
                    GenreName = GenreListEnum.Drama,
                    FilmId = 21
                },


                // FAMIL
                new Genre
                {
                    Id = 32,
                    GenreName = GenreListEnum.Family,
                    FilmId = 13
                },

                // FANTASY
                new Genre
                {
                    Id = 21,
                    GenreName = GenreListEnum.Fantasy,
                    FilmId = 10
                },

            // HISTORY
            new Genre
            {
                Id = 38,
                GenreName = GenreListEnum.History,
                FilmId = 15
            },

                // HORROR
                new Genre
                {
                    Id = 41,
                    GenreName = GenreListEnum.Horror,
                    FilmId = 17
                },

                // MUSIC

                new Genre
                {
                    Id = 35,
                    GenreName = GenreListEnum.Music,
                    FilmId = 14
                },
                 new Genre
                 {
                     Id = 45,
                     GenreName = GenreListEnum.Music,
                     FilmId = 18
                 },
                 new Genre
                 {
                     Id = 51,
                     GenreName = GenreListEnum.Music,
                     FilmId = 16
                 },

            // MUSICAL 
            new Genre
            {
                Id = 46,
                GenreName = GenreListEnum.Musical,
                FilmId = 18
            },

                // mistery
                new Genre
                {
                    Id = 42,
                    GenreName = GenreListEnum.Mystery,
                    FilmId = 17
                },
                new Genre
                {
                    Id = 54,
                    GenreName = GenreListEnum.Mystery,
                    FilmId = 19
                },

                // ROMANCE
                new Genre
                {
                    Id = 22,
                    GenreName = GenreListEnum.Romance,
                    FilmId = 2

                },

                // SCI-FI
                new Genre
                {
                    Id = 23,
                    GenreName = GenreListEnum.SciFi,
                    FilmId = 4
                },
                new Genre
                {
                    Id = 26,
                    GenreName = GenreListEnum.SciFi,
                    FilmId = 11
                },
                new Genre
                {
                    Id = 29,
                    GenreName = GenreListEnum.SciFi,
                    FilmId = 12
                },

                // SHORT
                new Genre
                {
                    Id = 57,
                    GenreName = GenreListEnum.Short,
                    FilmId = 20
                },

            // SPORT
            new Genre 
            {
                Id = 58,
                GenreName = GenreListEnum.Sport,
                FilmId = 21
            },

            // SUPERHERO
            new Genre 
                {
                    Id = 47,
                    GenreName = GenreListEnum.Superhero,
                    FilmId = 12
                },

            // THRILLER 
            new Genre
                {
                    Id = 24,
                    GenreName = GenreListEnum.Thriller,
                    FilmId = 4
                },
                new Genre
                {
                    Id = 25,
                    GenreName = GenreListEnum.Thriller,
                    FilmId = 5
                },

                new Genre
                {
                    Id = 39,
                    GenreName = GenreListEnum.Thriller,
                    FilmId = 15
                },
                new Genre
                {
                    Id = 55,
                    GenreName = GenreListEnum.Thriller,
                    FilmId = 19
                },
                // WAR 
                new Genre
                {
                    Id = 40,
                    GenreName = GenreListEnum.War,
                    FilmId = 15
                },

                // WESTERN 
                 new Genre
                 {
                      Id = 56,
                      GenreName = GenreListEnum.Western,
                      FilmId = 19
                 });
            });


            modelBuilder.Entity<Comment>(comment =>
                {
                    comment.HasOne(c => c.Film)
                        .WithMany(f => f.Comments)
                        .HasForeignKey(c => c.FilmId);

                    comment.HasOne(c => c.User)
                        .WithMany(u => u.Comments)
                        .HasForeignKey(c => c.UserId);

                    comment.Property(c => c.FilmId)
                        .IsRequired();

                });

                modelBuilder.Entity<Vote>(vote =>
                {
                    vote.HasOne(v => v.Film)
                        .WithMany(f => f.Votes)
                        .HasForeignKey(v => v.FilmId);

                    vote.HasOne(v => v.User)
                        .WithMany(f => f.Votes)
                        .HasForeignKey(v => v.UserId);

                    vote.Property(v => v.FilmId)
                        .IsRequired();
                });

			base.OnModelCreating(modelBuilder);
		}


		public DbSet<Film> Films { get; set; }
		public DbSet<Comment> Comments { get; set; }
		public DbSet<Vote> Votes { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Genre> Genres { get; set; }
	}
}

