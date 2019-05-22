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
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService ?? throw new ArgumentNullException(nameof(commentService));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var comment = await _commentService.GetByIdAsync(id);

            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment);
        }

		[HttpGet("film/{id}")]
		public async Task<ActionResult<User>> GetByFilmId(int id)
		{
			if (id <= 0)
			{
				return BadRequest();
			}

			var comment = await _commentService.GetByFilmIdAsync(id);

			if (comment == null)
			{
				return NotFound();
			}

			return Ok(comment);
		}

		[HttpPost()]
        public async Task<ActionResult<Comment>> Create([FromBody][Required]Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdComment = await _commentService.AddCommentAsync(comment);

            return CreatedAtAction(nameof(GetById), new { id = createdComment.Id }, comment);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([Range(1, int.MaxValue)]int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _commentService.DeleteCommentAsync(id);

            return NoContent();
        }
    }
}