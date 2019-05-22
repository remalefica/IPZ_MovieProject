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
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

		[HttpGet("{id}")]
		public async Task<ActionResult<User>> GetById(string id)
        {
            var user = await _userService.GetById(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

		[HttpPost("Create")]
        public async Task<ActionResult<User>> Create([FromBody][Required]User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdUser = await _userService.AddUserAsync(user);

            return CreatedAtAction(nameof(GetById), new { id = createdUser.Id }, user);
        }


        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> Delete([Range(1, int.MaxValue)]int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _userService.DeleteUserAsync(id.ToString());

            return NoContent();
        }

        [HttpPut("put/{id}")]
        public async Task<ActionResult> Update(string  id, [FromBody]User user)
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
