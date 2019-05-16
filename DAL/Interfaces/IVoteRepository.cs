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
        Task<Vote> GetByFilmId(int filmId);
        Task<Vote> GetByUserId(string userId);

    }
}
