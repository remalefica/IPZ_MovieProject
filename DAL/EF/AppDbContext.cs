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
				 user.Property(u => u.UserName).IsRequired();

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
					FilmTrailerPath = "<iframe src='https://www.imdb.com/videoembed/vi781228825' allowfullscreen width='854' height='400'></iframe>",

                    OriginCountry = "USA | Germany",
					Budget = 63000000,
					DurationInMinutes = 112
				},
				new Film
				{
					Id = 4,
					Name = "Inception",
					Director = "Christopher Nolan",
					Year = 1,
					Description = "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O.",
					FilmImgPath = "https://m.media-amazon.com/images/M/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwNTI5OTM0Mw@@._V1_SY1000_CR0,0,675,1000_AL_.jpg",
                    FilmTrailerPath = "<iframe src='Http://www.imdb.com/videoembed/vi4219471385' allowfullscreen width='854' height='400'></iframe>",

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
					FilmTrailerPath = "<iframe src='https://www.imdb.com/videoembed/vi324468761' allowfullscreen width='854' height='400'></iframe>",

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
					FilmTrailerPath = "",
					OriginCountry = "USA",
					Budget = 6000000,
					DurationInMinutes = 175
				},
				new Film
				{
					Id = 7,
					Name = "1 + 1 (Intouchables)",
					Director = "Olivier Nakache, Éric Toledano",
					Year = 2011,
					Description = "After he becomes a quadriplegic from a paragliding accident, an aristocrat hires a young man from the projects to be his caregiver.",
					FilmImgPath = "https://filmix.co/uploads/posters/big/neprikasaemye-2011_34099_0.jpg",
					FilmTrailerPath = "<iframe src='https://www.imdb.com/videoembed/vi59285529' allowfullscreen width='854' height='400'></iframe>",
                    OriginCountry = "France",
					Budget = 9500000,
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
					FilmTrailerPath = "<iframe src='https://www.imdb.com/videoembed/vi4018733337' allowfullscreen width='854' height='400'></iframe>",

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
					FilmTrailerPath = "<iframe src='https://www.imdb.com/videoembed/vi2312218649' allowfullscreen width='854' height='400'></iframe>",

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
					FilmTrailerPath = "<iframe src='https://www.imdb.com/videoembed/vi2073101337' allowfullscreen width='854' height='400'></iframe>",

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
					FilmTrailerPath = "<iframe src='https://www.imdb.com/videoembed/vi1032782617' allowfullscreen width='854' height='400'></iframe>",

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
					FilmTrailerPath = "<iframe src='https://www.imdb.com/videoembed/vi4175083801' allowfullscreen width='854' height='400'></iframe>",

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
					FilmTrailerPath = "<iframe src='https://www.imdb.com/videoembed/vi3133192729' allowfullscreen width='854' height='400'></iframe>",

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
					FilmTrailerPath = "<iframe src='https://www.imdb.com/videoembed/vi1451538969' allowfullscreen width='854' height='400'></iframe>",

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
					FilmTrailerPath = "<iframe src='https://www.imdb.com/videoembed/vi3402283289' allowfullscreen width='854' height='400'></iframe>",

                    OriginCountry = "UK | Netherlands | France | USA",
					Budget = 100000000,
					DurationInMinutes = 106
				},
				new Film
				{
					Id = 16,
					Name = "The Lion King",
					Director = "Jon Favreau",
					Year = 2019,
					Description = "After the murder of his father, a young lion prince flees his kingdom only to learn the true meaning of responsibility and bravery.",
					FilmImgPath = "https://m.media-amazon.com/images/M/MV5BMjIwMjE1Nzc4NV5BMl5BanBnXkFtZTgwNDg4OTA1NzM@._V1_SY1000_CR0,0,674,1000_AL_.jpg",
					FilmTrailerPath = "<iframe src='https://www.imdb.com/videoembed/vi1166654489' allowfullscreen width='854' height='400'></iframe>",
                    OriginCountry = " USA"
				},
				new Film
				{
					Id = 17,
					Name = "Scream",
					Director = "Wes Craven",
					Year = 1996,
					Description = "A year after the murder of her mother, a teenage girl is terrorized by a new killer, who targets the girl and her friends by using horror films as part of a deadly game.",
					FilmImgPath = "https://m.media-amazon.com/images/M/MV5BMjA2NjU5MTg5OF5BMl5BanBnXkFtZTgwOTkyMzQxMDE@._V1_SY1000_CR0,0,673,1000_AL_.jpg",
					FilmTrailerPath = "<iframe src='https://www.imdb.com/videoembed/vi1175821337' allowfullscreen width='854' height='400'></iframe>",
                    OriginCountry = "USA",
                    Budget = 14000000,
					DurationInMinutes = 111
				},
				new Film
				{
					Id = 18,
					Name = "La La Land",
					Director = "Damien Chazelle",
					Year = 2016,
					Description = "While navigating their careers in Los Angeles, a pianist and an actress fall in love while attempting to reconcile their aspirations for the future.",
					FilmImgPath = "https://m.media-amazon.com/images/M/MV5BMzUzNDM2NzM2MV5BMl5BanBnXkFtZTgwNTM3NTg4OTE@._V1_SY1000_SX675_AL_.jpg",
					FilmTrailerPath = "<iframe src='https://www.imdb.com/videoembed/vi2514728473' allowfullscreen width='854' height='400'></iframe>",

                    OriginCountry = "USA | Hong Kong",
					RatingAvg = 30000000,
					DurationInMinutes = 128
				},
				new Film
				{
					Id = 19,
					Name = "n",
					Director = "",
					Year = 1,
					Description = "",
					FilmImgPath = "",
					FilmTrailerPath = "",
					OriginCountry = "",
					Budget = 1,
					DurationInMinutes = 1
				},
				new Film
				{
					Id = 20,
					Name = "o",
					Director = "",
					Year = 1,
					Description = "",
					FilmImgPath = "",
					FilmTrailerPath = "",
					OriginCountry = "",
					Budget = 1,
					DurationInMinutes = 1
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
                   FilmId = 1
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
                // ANIMATION
                new Genre
                {
                    Id = 6,
                    GenreName = GenreListEnum.Animation,

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
                });
            });

                // DOCUMENTARY 
                //new Genre
                //{
                //    Id = 14,
                //    GenreName = GenreListEnum.Documentary,

                //},

                // DRAMA
            ////    new Genre
            ////    {
            ////        Id = 15,
            ////        GenreName = GenreListEnum.Drama,
            ////        FilmId = 1

            ////    },
            ////    new Genre
            ////    {
            ////        Id = 16,
            ////        GenreName = GenreListEnum.Drama,
            ////        FilmId = 2

            ////    },
            ////    new Genre
            ////    {
            ////        Id = 17,
            ////        GenreName = GenreListEnum.Drama,
            ////        FilmId = 3

            ////    },
            ////    new Genre
            ////    {
            ////        Id = 18,
            ////        GenreName = GenreListEnum.Drama,
            ////        FilmId = 6
            ////    },
            ////    new Genre
            ////    {
            ////        Id = 19,
            ////        GenreName = GenreListEnum.Drama,
            ////        FilmId = 7
            ////    },
            ////    new Genre
            ////    {
            ////        Id = 20,
            ////        GenreName = GenreListEnum.Drama,
            ////        FilmId = 9
            ////    },


            ////    // FAMILT
            ////    //genre.HasData(
            ////    //new
            ////    //{
            ////    //    Id = 21,
            ////    //    GenreName = GenreListEnum.Family,

            ////    //});

            ////    // FANTASY
            ////    //genre.HasData(
            ////    //new
            ////    //{
            ////    //    Id = 22,
            ////    //    GenreName = GenreListEnum.Fantasy,


            ////    //});

            ////    // HISTORY
            ////    //genre.HasData(
            ////    //new
            ////    //{
            ////    //    Id = 23,
            ////    //    GenreName = GenreListEnum.History,


            ////    //},

            ////    // HORROR
            ////    //genre.HasData(
            ////    //new
            ////    //{
            ////    //    Id = 24,
            ////    //    GenreName = GenreListEnum.Horror,

            ////    //});

            ////    // MUSIC
            ////    //genre.HasData(
            ////    //new
            ////    //{
            ////    //    Id = 25,
            ////    //    GenreName = GenreListEnum.Music,

            ////    //});

            ////    // MUSICAL 
            ////    //genre.HasData(
            ////    //new
            ////    //{
            ////    //    Id = 26,
            ////    //    GenreName = GenreListEnum.Musical,

            ////    //});

            ////    //new
            ////    //{
            ////    //    Id = 27,
            ////    //    GenreName = GenreListEnum.Mystery,

            ////    //});

            ////    // ROMANCE
            ////    new Genre
            ////    {
            ////        Id = 28,
            ////        GenreName = GenreListEnum.Romance,
            ////        FilmId = 2

            ////    },

            ////    // SCI-FI
            ////    new Genre
            ////    {
            ////        Id = 29,
            ////        GenreName = GenreListEnum.SciFi,
            ////        FilmId = 4
            ////    },

            ////    // SHORT
            ////    //genre.HasData(
            ////    //new
            ////    //{
            ////    //    Id = 30,
            ////    //    GenreName = GenreListEnum.Short,

            ////    //});

            ////    // SPORT
            ////    //genre.HasData(
            ////    //new
            ////    //{
            ////    //    Id = 31,
            ////    //    GenreName = GenreListEnum.Sport,

            ////    //});

            ////    // SUPERHERO
            ////    //genre.HasData(
            ////    //new
            ////    //{
            ////    //    Id = 32,
            ////    //    GenreName = GenreListEnum.Superhero,


            ////    //});

            ////    // THRILLER 
            ////    new Genre
            ////    {
            ////        Id = 33,
            ////        GenreName = GenreListEnum.Thriller,
            ////        FilmId = 4
            ////    },
            ////    new Genre
            ////    {
            ////        Id = 33,
            ////        GenreName = GenreListEnum.Thriller,
            ////        FilmId = 5
            ////    });
            ////});
            ////    // WAR 
            ////    ////genre.HasData(
            ////    ////new
            ////    ////{
            ////    ////    Id = 34,
            ////    ////    GenreName = GenreListEnum.War,

            ////    ////});

            ////    // WESTERN 
            ////    //    genre.HasData(
            ////    //    new
            ////    //    {
            ////    //        Id = 35,
            ////    //        GenreName = GenreListEnum.Western,

            ////    //    });
            ////    //


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

                    vote.HasAlternateKey(v => v.UserId);
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

