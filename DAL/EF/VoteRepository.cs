using DAL.Interfaces;
using System;
using Entities;
using System.Collections.Generic;
using System.Text;

namespace DAL.EF
{
	public class VoteRepository : IVoteRepository
	{
        private AppDbContext _dbContext;
        public void AddVote(Vote vote)
        {
            _dbContext.Votes.Add(vote);
        }
    }
}
