using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IGenreService
    {
        Task<Genre> GetByIdAsync(int id);
        Task<Genre> GetByFilmIdAsync(int filmId);
        Task <Genre> AddGenreAsync(Genre genre);
    }
}
