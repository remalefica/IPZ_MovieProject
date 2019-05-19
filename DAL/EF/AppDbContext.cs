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
            new Film() { Id = 1, Name = "Pulp Fiction", Director = "Quentin Tarantino", FilmImgPath = "https://img0.liveinternet.ru/images/attach/c/5/87/551/87551274_743664_kinopoisk_ruPulpFiction1480737.jpg" },
            new Film() { Id = 2, Name = "BLSLLSLD", Director = "MR WORK PLS", FilmImgPath = "http://bm.img.com.ua/img/prikol/images/large/0/0/307600.jpg" });

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

