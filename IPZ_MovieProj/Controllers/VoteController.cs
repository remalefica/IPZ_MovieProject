using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace IPZ_MovieProj.Controllers
{
    [Route("api/vote")]
    [ApiController]
    public class VoteController : ControllerBase
    {
        private readonly IVoteService _voteService;

        public VoteController(IVoteService voteService)
        {
            _voteService = voteService ?? throw new ArgumentNullException(nameof(voteService));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Vote>> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var vote = await _voteService.GetByIdAsync(id);

            if (vote == null)
            {
                return NotFound();
            }

            return Ok(vote);
        }

        [HttpGet("user/{id}")]
        public async Task<ActionResult<IEnumerable<Vote>>> GetByUserId(string id)
        {
            var vote = await _voteService.GetByUserIdAsync(id);

            if (vote== null)
            {
                return NotFound();
            }

            return Ok(vote);
        }

        [HttpGet("user/{userId}/last")]
		public async Task<ActionResult<IEnumerable<Vote>>> GetByUserIdLast(string userId)
		{
			var vote = (await _voteService.GetByUserIdAsync(userId)).Last();

			if (vote == null)
			{
				return NotFound();
			}

			return Ok(vote);
		}

		[HttpGet("film/{filmId}/user/{userId}")]
		public async Task<ActionResult<Vote>> GetByFilmUserId(int filmId, string userId)
		{
			if (filmId <= 0)
			{
				return BadRequest();
			}

			var vote = await _voteService.GetByFilmUserIdAsync(filmId, userId);

			return Ok(vote);
		}

		[HttpPost("make-vote")]
        public async Task<ActionResult<Vote>> Create([FromBody][Required]Vote vote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdVote = await _voteService.AddVoteAsync(vote);

            return CreatedAtAction(nameof(GetById), new { id = createdVote.Id }, vote);
        }


        [HttpPut("update-vote/{id}")]
        public async Task<ActionResult> Update([Range(1, int.MaxValue)]int id, [FromBody]Vote vote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _voteService.UpdateVoteAsync(id, vote);

            return NoContent();
        }

    }
}