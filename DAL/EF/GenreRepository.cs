using DAL.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class GenreRepository : IGenreRepository
    {
        private AppDbContext _dbContext;
        public GenreRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        }
        public async Task<Genre> GetById(int id)
        {
            return await _dbContext.Genres
                        .Where(g => g.Id == id)
                        .FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Genre>> GetByFilmId(int filmId)
        {
            return await _dbContext.Genres
                        .Where(g => g.FilmId == filmId)
                        .ToListAsync();
        }

        public void AddGenre(Genre genre)
        {
            _dbContext.Genres.Add(genre);
        }
    }
}
