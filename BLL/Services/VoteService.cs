using BLL.Interfaces;
using DAL.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
	public class VoteService : IVoteService
	{
        private IUnitOfWork _unitOfWork;

        public VoteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<Vote> AddVoteAsync(Vote vote)
        {
            if (vote == null)
            {
                throw new ArgumentNullException(nameof(vote));
            }

            _unitOfWork.VoteRepository.AddVote(vote);
            await _unitOfWork.SaveAsync();
            return vote;
        }
        public async Task UpdateVoteAsync(int id, Vote vote)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id must be more then zero", nameof(id));
            }

            var voteDb = await _unitOfWork.VoteRepository.GetById(id);

            voteDb = vote ?? throw new ArgumentNullException(nameof(vote));
            await _unitOfWork.SaveAsync();
        }
        public async Task<Vote> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id must be more then zero", nameof(id));
            }

            return await _unitOfWork.VoteRepository.GetById(id);
        }
    }
}
