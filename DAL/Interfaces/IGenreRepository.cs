using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
	public interface IGenreRepository
	{
		Task<Genre> GetById(int id);
        Task<IEnumerable<Genre>> GetByFilmId(int filmId);
		void AddGenre(Genre genre);
	}
}
