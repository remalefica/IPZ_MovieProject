using System.Collections.Generic;
using System.Linq;

using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

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
					FilmImgPath = "https://www.imdb.com/title/tt0109830/mediaviewer/rm1954748672",
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
					FilmImgPath = "https://www.imdb.com/title/tt0137523/mediaviewer/rm590641920",
					FilmTrailerPath = "https://www.imdb.com/title/tt0137523/videoplayer/vi781228825?ref_=tt_ov_vi",
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
					FilmImgPath = "https://www.imdb.com/title/tt1375666/mediaviewer/rm3426651392",
                    FilmTrailerPath = "https://www.imdb.com/title/tt1375666/videoplayer/vi4219471385?ref_=tt_ov_vi",
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
					FilmImgPath = "https://www.imdb.com/title/tt0468569/mediaviewer/rm4023877632",
					FilmTrailerPath = "https://www.imdb.com/title/tt0468569/videoplayer/vi324468761?ref_=tt_ov_vi",
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
					FilmTrailerPath = "https://www.youtube.com/embed/qCSW7hqBMTg",
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
					FilmTrailerPath = "https://www.imdb.com/videoembed/vi4018733337",
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
					FilmImgPath = "https://www.imdb.com/title/tt0993846/mediaviewer/rm2842940160",
					FilmTrailerPath = "https://www.imdb.com/title/tt0993846/videoplayer/vi2312218649?ref_=tt_ov_vi",
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
					FilmImgPath = "https://www.imdb.com/title/tt0167260/mediaviewer/rm584928512",
					FilmTrailerPath = "https://www.imdb.com/title/tt0167260/videoplayer/vi2073101337?ref_=tt_ov_vi",
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
					FilmImgPath = "https://www.imdb.com/title/tt0133093/mediaviewer/rm525547776",
					FilmTrailerPath = "https://www.imdb.com/title/tt0133093/videoplayer/vi1032782617?ref_=tt_ov_vi",
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
					FilmImgPath = "https://www.imdb.com/title/tt2250912/mediaviewer/rm3491180544",
					FilmTrailerPath = "https://www.imdb.com/title/tt2250912/videoplayer/vi4175083801?ref_=tt_ov_vi",
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
					FilmImgPath = "https://www.imdb.com/title/tt1865505/mediaviewer/rm1350432768",
					FilmTrailerPath = "https://www.imdb.com/title/tt1865505/videoplayer/vi3133192729?ref_=tt_ov_vi",
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
					Description = "",
					FilmImgPath = "https://images.gowatchit.com/posters/original/p15987_p_v7_aa.jpg?1473180482",
					FilmTrailerPath = "",
					OriginCountry = "",
					Budget = 1,
					RatingAvg = 1,
					DurationInMinutes = 1
				},
				new Film
				{
					Id = 15,
					Name = "j",
					Director = "",
					Year = 1,
					Description = "",
					FilmImgPath = "https://images.gowatchit.com/posters/original/p15987_p_v7_aa.jpg?1473180482",
					FilmTrailerPath = "",
					OriginCountry = "",
					Budget = 1,
					RatingAvg = 1,
					DurationInMinutes = 1
				},
				new Film
				{
					Id = 16,
					Name = "k",
					Director = "",
					Year = 1,
					Description = "",
					FilmImgPath = "https://images.gowatchit.com/posters/original/p15987_p_v7_aa.jpg?1473180482",
					FilmTrailerPath = "",
					OriginCountry = "",
					Budget = 1,
					RatingAvg = 1,
					DurationInMinutes = 1
				},
				new Film
				{
					Id = 17,
					Name = "l",
					Director = "",
					Year = 1,
					Description = "",
					FilmImgPath = "https://images.gowatchit.com/posters/original/p15987_p_v7_aa.jpg?1473180482",
					FilmTrailerPath = "",
					OriginCountry = "",
					Budget = 1,
					RatingAvg = 1,
					DurationInMinutes = 1
				},
				new Film
				{
					Id = 18,
					Name = "m",
					Director = "",
					Year = 1,
					Description = "",
					FilmImgPath = "https://images.gowatchit.com/posters/original/p15987_p_v7_aa.jpg?1473180482",
					FilmTrailerPath = "",
					OriginCountry = "",
					Budget = 1,
					RatingAvg = 1,
					DurationInMinutes = 1
				},
				new Film
				{
					Id = 19,
					Name = "n",
					Director = "",
					Year = 1,
					Description = "",
					FilmImgPath = "https://images.gowatchit.com/posters/original/p15987_p_v7_aa.jpg?1473180482",
					FilmTrailerPath = "",
					OriginCountry = "",
					Budget = 1,
					RatingAvg = 1,
					DurationInMinutes = 1
				},
				new Film
				{
					Id = 20,
					Name = "o",
					Director = "",
					Year = 1,
					Description = "",
					FilmImgPath = "https://images.gowatchit.com/posters/original/p15987_p_v7_aa.jpg?1473180482",
					FilmTrailerPath = "",
					OriginCountry = "",
					Budget = 1,
					RatingAvg = 1,
					DurationInMinutes = 1
				});

			modelBuilder.Entity<Genre>(genre =>
			{
				genre.Property(g => g.GenreName)
						.HasConversion<int>();
				genre.HasData(
				new
				{
					Id = 1,
					GenreName = GenreListEnum.Action,
					FilmId = 1
					//Film = Film 
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

