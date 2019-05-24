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
			_dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

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
            film.RatingAvg = CountRatingAvg(film);
			_dbContext.Films.Add(film);
		}

		public void DeleteFilm(Film film)
		{
			_dbContext.Entry(film).State = EntityState.Deleted;
		}

		public async Task<IEnumerable<Film>> GetByGenre(GenreListEnum genre)
		{
			return await _dbContext.Films
				.Where(f => f.Genres.Any(g => g.GenreName == genre))
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
					.OrderByDescending(fs => fs.RatingAvg)
					.Take(20)
					.ToListAsync();
		}
        public async Task<IEnumerable<Film>> GetFiveMostPopular()
        {
            return await _dbContext.Films
                    .OrderByDescending(fs => fs.RatingAvg)
                    .Take(5)
                    .ToListAsync();
        }

        public void UpdateFilm(Film film)
		{
			_dbContext.Films.Update(film);
		}

        private double CountRatingAvg(Film film)
        {
            if (film.Votes != null && film.Votes.Count() > 0)
            {
                double rating = 0;
                foreach (var vote in film.Votes)
                {
                    rating += vote.Rating;
                }
                return film.RatingAvg = rating / film.Votes.Count();
            }
                return film.RatingAvg = 0;
        }
	}
}
