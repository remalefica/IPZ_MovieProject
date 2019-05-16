using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IPZ_MovieProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService ?? throw new ArgumentNullException(nameof(genreService));
        }
        [HttpGet("genres")]

        [HttpGet("{id}")]
        public async Task<ActionResult<Genre>> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var genre = await _genreService.GetByIdAsync(id);

            if (genre == null)
            {
                return NotFound();
            }

            return Ok(genre);
        }
        [HttpPost()]
        public async Task<ActionResult<Genre>> Create([FromBody][Required]Genre genre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdGenre = await _genreService.AddGenreAsync(genre);
            var genreNew = await _genreService.GetByIdAsync(1);

            return CreatedAtAction(nameof(GetById), new { id = createdGenre.Id }, genre);
        }
        /* MUST BE MODIFIED*/
        [HttpGet("{id}")]
        public async Task<ActionResult<Genre>> GetByFilmId(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var genre = await _genreService.GetByFilmIdAsync(id);

            if (genre == null)
            {
                return NotFound();
            }

            return Ok(genre);
        }
    }
}