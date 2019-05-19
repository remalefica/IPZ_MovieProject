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

			modelBuilder.Entity<Genre>(genre => {
				genre.Property(g => g.GenreName)
						.HasConversion<int>();
			});

            modelBuilder.Entity<Film>().HasData(
                new Genre()
                {
                    Id = 1,
                    GenreName = GenreListEnum.Action,
                    FilmId = 1
                    //Film = Film 
                }
                );

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
                new Film()
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
                    RatingAvg = 0,
                    DurationInMinutes = 142

                },
                new Film()
                {
                    Id = 2,
                    Name = "Forrest Gump",
                    Director = "Robert Zemeckis",
                    Year = 1994,
                    Description = "The presidencies of Kennedy and Johnson, the events of Vietnam, Watergate, and other history unfold through the perspective of an Alabama man with an IQ of 75.",
                    FilmImgPath = "https://cdn.steemitimages.com/DQmVvesz6vdUEMP8Jh8JALyRmMcHHsE8nYko5iMtFNziMPs/f84b961743b78e47edf22fce1cde3d2c.jpg",
                    FilmTrailerPath = "https://www.youtube.com/embed/eYSnxZKTZzU",
                    OriginCountry = "USA",
                    Budget = 55000000,
                    RatingAvg = 0,
                    DurationInMinutes = 142
                },
                new Film()
                {
                    Id = 3,
                    Name = "",
                    Director = "",
                    Year = 1,
                    Description = "",
                    FilmImgPath = "",
                    FilmTrailerPath = "",
                    OriginCountry = "",
                    Budget = 1,
                    RatingAvg = 0,
                    DurationInMinutes = 112
                },
                new Film()
                {
                    Id = 4,
                    Name = "",
                    Director = "",
                    Year = 1,
                    Description = "",
                    FilmImgPath = "",
                    FilmTrailerPath = "",
                    OriginCountry = "",
                    Budget = 1,
                    RatingAvg = 0,
                    DurationInMinutes = 1
                },
                new Film()
                {
                    Id = 5,
                    Name = "",
                    Director = "",
                    Year = 1,
                    Description = "",
                    FilmImgPath = "",
                    FilmTrailerPath = "",
                    OriginCountry = "",
                    Budget = 1,
                    RatingAvg = 0,
                    DurationInMinutes = 1
                },
                new Film()
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
                    RatingAvg = 0,
                    DurationInMinutes = 175
                },
                new Film()
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
                    RatingAvg = 0,
                    DurationInMinutes = 112
                },
                new Film()
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
                    RatingAvg = 0,
                    DurationInMinutes = 117
                },
                new Film()
                {
                    Id = 9,
                    Name = "",
                    Director = "",
                    Year = 1,
                    Description = "",
                    FilmImgPath = "",
                    FilmTrailerPath = "",
                    OriginCountry = "",
                    Budget = 1,
                    RatingAvg = 0,
                    DurationInMinutes = 1
                },
                new Film()
                {
                    Id = 10,
                    Name = "",
                    Director = "",
                    Year = 1,
                    Description = "",
                    FilmImgPath = "",
                    FilmTrailerPath = "",
                    OriginCountry = "",
                    Budget = 1,
                    RatingAvg = 0,
                    DurationInMinutes = 1
                },
                new Film()
                {
                    Id = 11,
                    Name = "",
                    Director = "",
                    Year = 1,
                    Description = "",
                    FilmImgPath = "",
                    FilmTrailerPath = "",
                    OriginCountry = "",
                    Budget = 1,
                    RatingAvg = 0,
                    DurationInMinutes = 1
                },
                new Film()
                {
                    Id = 12,
                    Name = "",
                    Director = "",
                    Year = 1,
                    Description = "",
                    FilmImgPath = "",
                    FilmTrailerPath = "",
                    OriginCountry = "",
                    Budget = 1,
                    RatingAvg = 0,
                    DurationInMinutes = 1
                },
                new Film()
                {
                    Id = 13,
                    Name = "",
                    Director = "",
                    Year = 1,
                    Description = "",
                    FilmImgPath = "",
                    FilmTrailerPath = "",
                    OriginCountry = "",
                    Budget = 1,
                    RatingAvg = 0,
                    DurationInMinutes = 1
                },
                new Film()
                {
                    Id = 14,
                    Name = "",
                    Director = "",
                    Year = 1,
                    Description = "",
                    FilmImgPath = "",
                    FilmTrailerPath = "",
                    OriginCountry = "",
                    Budget = 1,
                    RatingAvg = 0,
                    DurationInMinutes = 1
                },
                new Film()
                {
                    Id = 15,
                    Name = "",
                    Director = "",
                    Year = 1,
                    Description = "",
                    FilmImgPath = "",
                    FilmTrailerPath = "",
                    OriginCountry = "",
                    Budget = 1,
                    RatingAvg = 0,
                    DurationInMinutes = 1
                },
                new Film()
                {
                    Id = 16,
                    Name = "",
                    Director = "",
                    Year = 1,
                    Description = "",
                    FilmImgPath = "",
                    FilmTrailerPath = "",
                    OriginCountry = "",
                    Budget = 1,
                    RatingAvg = 0,
                    DurationInMinutes = 1
                },
                new Film()
                {
                    Id = 17,
                    Name = "",
                    Director = "",
                    Year = 1,
                    Description = "",
                    FilmImgPath = "",
                    FilmTrailerPath = "",
                    OriginCountry = "",
                    Budget = 1,
                    RatingAvg = 0,
                    DurationInMinutes = 1
                },
                new Film()
                {
                    Id = 18,
                    Name = "",
                    Director = "",
                    Year = 1,
                    Description = "",
                    FilmImgPath = "",
                    FilmTrailerPath = "",
                    OriginCountry = "",
                    Budget = 1,
                    RatingAvg = 0,
                    DurationInMinutes = 1
                },
                new Film()
                {
                    Id = 19,
                    Name = "",
                    Director = "",
                    Year = 1,
                    Description = "",
                    FilmImgPath = "",
                    FilmTrailerPath = "",
                    OriginCountry = "",
                    Budget = 1,
                    RatingAvg = 0,
                    DurationInMinutes = 1
                },
                new Film()
                {
                    Id = 20,
                    Name = "",
                    Director = "",
                    Year = 1,
                    Description = "",
                    FilmImgPath = "",
                    FilmTrailerPath = "",
                    OriginCountry = "",
                    Budget = 1,
                    RatingAvg = 0,
                    DurationInMinutes = 1
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

