using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
	public interface IFilmRepository
	{
		Task<IEnumerable<Film>> GetByGenre(GenreListEnum genre);
		Task<Film> GetByName(string name);
		Task<IEnumerable<Film>> GetTenMostPopular();
		Task<Film> GetById(int id);
		void AddFilm(Film film);
		void DeleteFilm(Film film);
		void UpdateFilm(Film film);
	}
}
