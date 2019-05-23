using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
	public interface IFilmService
	{
        Task<IEnumerable<Film>> GetByGenreAsync(GenreListEnum genre);
        Task<Film> GetByNameAsync(string name);
        Task<IEnumerable<Film>> GetTenMostPopularAsync();
        Task<IEnumerable<Film>> GetFiveMostPopularAsync();
        Task<Film> GetByIdAsync(int id);
        Task<Film> AddFilmAsync(Film film);
        Task DeleteFilmAsync(int id);
        Task UpdateFilmAsync(int id, Film film);
    }
}
