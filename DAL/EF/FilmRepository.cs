using DAL.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.EF
{
	public class FilmRepository : IFilmRepository
	{
		private AppDbContext _dbContext;

		public FilmRepository(AppDbContext dbContext)
		{
			_dbContext = dbContext ?? throw new ArgumentNullException();

			/*if(dbContext != null)
			{
				_dbContext = dbContext;
			}
			else
			{
				throw new ArgumentNullException()
			}*/
		}

		public void AddFilm(Film film)
		{
			_dbContext.Films.Add(film);
		}

		public void DeleteFilm(Film film)
		{
			_dbContext.Entry(film).State = EntityState.Deleted;
		}

		public async Task<IEnumerable<Film>> GetByGenre(Genre genre)
		{
			return await _dbContext.Films
				.Where(f => f.Genres.Any(g => g == genre))
				.ToListAsync();
		}

		public async Task<Film> GetById(int id)
		{
			return await _dbContext.Films
						.Where(f => f.Id == id)
						.FirstOrDefaultAsync();
		}

		public async Task<Film> GetByName(string name)
		{
			return await _dbContext.Films
					.Where(f => f.Name == name)
					.FirstOrDefaultAsync();
		}

		public async Task<IEnumerable<Film>> GetTenMostPopular()
		{
			return await _dbContext.Films
					.Select(f => new { Film = f, VoteNumber = f.Votes.Count() })
					.OrderByDescending(fs => fs.VoteNumber)
					.Select(f => f.Film)
					.Take(10)
					.ToListAsync();
		}

		public void UpdateFilm(Film film)
		{
			_dbContext.Films.Update(film);
		}
	}
}
