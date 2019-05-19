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
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class FilmController : ControllerBase
	{
		private readonly IFilmService _filmService;

		public FilmController(IFilmService filmService)
		{
			_filmService = filmService ?? throw new ArgumentNullException(nameof(filmService));
		}

		[HttpGet("all")]
		public async Task<ActionResult<Film[]>> GetTenMostPopular()
		{
			var films = await _filmService.GetTenMostPopularAsync();

			if (films == null || !films.Any())
			{
				return Ok(Array.Empty<Film>());
			}

			return Ok(films);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Film>> GetById(int id)
		{
			if (id <= 0)
			{
				return BadRequest();
			}

			var film = await _filmService.GetByIdAsync(id);

			if (film == null)
			{
				return NotFound();
			}

			return Ok(film);
		}

		[HttpGet("{genre}")]
		public async Task<ActionResult<Film[]>> GetByGenre(GenreListEnum genre)
		{
			var films = await _filmService.GetByGenreAsync(genre);

			if (films == null || !films.Any())
			{
				return Ok(Array.Empty<Film>());
			}

			return Ok(films);
		}

		[HttpGet("{name}")]
		public async Task<ActionResult<Film>> GetByName(string name)
		{
			if (string.IsNullOrEmpty(name))
			{
				return BadRequest();
			}

			var film = await _filmService.GetByNameAsync(name);

			if (film == null)
			{
				return NotFound();
			}

			return Ok(film);
		}

		[HttpPost()]
		public async Task<ActionResult<Film>> Create([FromBody][Required]Film film)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var createdFilm = await _filmService.AddFilmAsync(film);

			return CreatedAtAction(nameof(GetById), new { id = createdFilm.Id }, film);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete([Range(1, int.MaxValue)]int id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			await _filmService.DeleteFilmAsync(id);

			return NoContent();
		}

		[HttpPut("{id}")]
		public async Task<ActionResult> Update([Range(1, int.MaxValue)]int id, [FromBody]Film film)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			await _filmService.UpdateFilmAsync(id, film);

			return NoContent();
		}
	}
}