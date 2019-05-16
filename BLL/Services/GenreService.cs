using BLL.Interfaces;
using DAL.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class GenreService : IGenreService
    {
        private IUnitOfWork _unitOfWork;

        public GenreService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<Genre> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id must be more then zero", nameof(id));
            }

            return await _unitOfWork.GenreRepository.GetById(id);
        }

        public async Task<Genre> GetByFilmIdAsync(int filmId)
        {
            if (filmId <= 0)
            {
                throw new ArgumentException("Id must be more then zero", nameof(filmId));
            }

            return await _unitOfWork.GenreRepository.GetByFilmId(filmId);
        }
        public async Task<Genre> AddGenreAsync(Genre genre)
        {
            if (genre == null)
            {
                throw new ArgumentNullException(nameof(genre));
            }

            _unitOfWork.GenreRepository.AddGenre(genre);
            await _unitOfWork.SaveAsync();
            return genre;
        }
    }
}
