using BLL.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Interfaces;

namespace BLL.Services
{
	public class FilmService : IFilmService
	{
		private IUnitOfWork _unitOfWork;

		public FilmService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
		}

		public async Task<Film> AddFilmAsync(Film film)
		{
			if(film == null)
			{
				throw new ArgumentNullException(nameof(film));
			}

			film.RatingAvg = CountFilmRatingAvg(film);
			_unitOfWork.FilmRepository.AddFilm(film);
			await _unitOfWork.SaveAsync();
			return film;
		}

		public async Task DeleteFilmAsync(int id)
		{
			if(id <= 0)
			{
				throw new ArgumentException("Id must be >= 0", nameof(id));
			}

			var film = await _unitOfWork.FilmRepository.GetById(id);

			if (film == null)
			{
				throw new ArgumentException("not found", nameof(id));
			}

			_unitOfWork.FilmRepository.DeleteFilm(film);
			await _unitOfWork.SaveAsync();
		}

		public async Task<IEnumerable<Film>> GetByGenreAsync(GenreListEnum genre)
		{
			return await _unitOfWork.FilmRepository.GetByGenre(genre);
		}

		public async Task<Film> GetByIdAsync(int id)
		{
			if(id <= 0)
			{
				throw new ArgumentException("Id must be more then zero", nameof(id));
			}

			return await _unitOfWork.FilmRepository.GetById(id);
		}

		public async Task<Film> GetByNameAsync(string name)
		{
			if(string.IsNullOrEmpty(name))
			{
				throw new ArgumentException("Name can`t be empty", nameof(name));
			}

			return await _unitOfWork.FilmRepository.GetByName(name);
		}

		public async Task<IEnumerable<Film>> GetTenMostPopularAsync()
		{
			return await _unitOfWork.FilmRepository.GetTenMostPopular();
		}

		public async Task UpdateFilmAsync(int id, Film film)
		{
			if (id <= 0)
			{
				throw new ArgumentException("Id must be more then zero", nameof(id));
			}

			var filmDb = await _unitOfWork.FilmRepository.GetById(id);

			filmDb = film ?? throw new ArgumentNullException(nameof(film));

			filmDb.RatingAvg = CountFilmRatingAvg(film);

			_unitOfWork.FilmRepository.UpdateFilm(filmDb);

			await _unitOfWork.SaveAsync();
		}


		private double CountFilmRatingAvg(Film film)
		{
			if(film.Votes.Count() > 0)
			{
				double rating = 0;
				foreach (var vote in film.Votes)
				{
					rating += vote.Rating;
				}
				return rating / film.Votes.Count();
			}

			return 0;
		}
	}
}
