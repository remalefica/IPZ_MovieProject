using BLL.Interfaces;
using DAL.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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

			var film = await _unitOfWork.FilmRepository.GetById(vote.FilmId);
			film.RatingAvg = await CountRatingAvg(vote.FilmId);

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

			_unitOfWork.VoteRepository.UpdateVote(voteDb);

			var film = await _unitOfWork.FilmRepository.GetById(voteDb.FilmId);
			film.RatingAvg = await CountRatingAvg(voteDb.FilmId);

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
        public async Task<Vote> GetByFilmUserIdAsync(int filmId, string userId)
        {
            if (filmId <= 0)
            {
                throw new ArgumentException("Id must be more then zero", nameof(filmId));
            }

            return await _unitOfWork.VoteRepository.GetByFilmUserId(filmId, userId);
        }

        public async Task<IEnumerable<Vote>> GetByUserIdAsync(string userId)
        {
            var user = await _unitOfWork.UserRepository.GetById(userId);

            if (user == null)
            {
                throw new ArgumentException("not found", nameof(userId));
            }

            return await _unitOfWork.VoteRepository.GetByUserId(userId);
        }

		private async Task<double> CountRatingAvg(int filmId)
		{
			var votes = await _unitOfWork.VoteRepository.GetByFilmId(filmId);

			if (votes.Count() > 0)
			{
				double rating = 0;
				foreach (var vote in votes)
				{
					rating += vote.Rating;
				}
				return rating / votes.Count();
			}

			return 0;

		}
    }
}
