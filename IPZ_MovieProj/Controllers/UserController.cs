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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult<User>> GetById(string name)
        {
            var user = await _userService.GetByNameAsync(name);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

		[HttpGet("username/{name}")]
		public async Task<ActionResult<User>> GetByUsername(string name)
		{
			var user = await _userService.GetByNameAsync(name);

			if (user == null)
			{
				return NotFound();
			}

			return Ok(user);
		}

		[HttpPost()]
        public async Task<ActionResult<User>> Create([FromBody][Required]User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdUser = await _userService.AddUserAsync(user);

            return CreatedAtAction(nameof(GetById), new { id = createdUser.Id }, user);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([Range(1, int.MaxValue)]int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _userService.DeleteUserAsync(id.ToString());

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([Range(1, int.MaxValue)]int id, [FromBody]User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _userService.UpdateUserAsync(id.ToString(), user);

            return NoContent();
        }
    }

}
