using System;
using Entities;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
	public interface IVoteRepository
	{
		void AddVote(Vote vote);
        void UpdateVote(Vote vote);
        Task<Vote> GetById(int id);
        Task<Vote> GetByFilmUserId(int filmId, string userId);
        Task<Vote> GetByUserIdLast(string userId);
        Task<IEnumerable<Vote>> GetByFilmId(int filmId);
		Task<IEnumerable<Vote>> GetByUserId(string userId);

    }
}
