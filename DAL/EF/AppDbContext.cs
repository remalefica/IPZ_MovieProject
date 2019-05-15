using System.Linq;

using Entities;
using Microsoft.EntityFrameworkCore;

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
	}
}

