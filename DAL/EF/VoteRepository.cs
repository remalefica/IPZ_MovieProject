using DAL.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace DAL.EF
{
	public class VoteRepository : IVoteRepository
	{
		private AppDbContext _dbContext;

		public VoteRepository(AppDbContext dbContext)
		{
			_dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
		}

		public void AddVote(Vote vote)
		{
			_dbContext.Votes.Add(vote);
		}
        public async Task<Vote> GetById(int id)
        {
            return await _dbContext.Votes
                        .Where(c => c.Id == id)
                        .FirstOrDefaultAsync();
        }
        public void UpdateVote(Vote vote)
        {
            _dbContext.Votes.Update(vote);
        }
        public async Task<Vote> GetByFilmId(int filmId)
        {
            return await _dbContext.Votes
                        .Where(v => v.FilmId == filmId)
                        .FirstOrDefaultAsync(); ;
        }
        public async Task<Vote> GetByUserId(string userId)
        {
            return await _dbContext.Votes
                        .Where(v => v.UserId == userId)
                        .FirstOrDefaultAsync(); ;
        }
    }
}
