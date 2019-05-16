using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
	public class Film
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string FilmImgPath { get; set; }
		public string FilmTrailerPath { get; set; }
		public int Year { get; set; }
		public int DurationInMinutes { get; set; }
		public string Description { get; set; }
		public string Director { get; set; }
		public string OriginCountry { get; set; }
		public int Budget { get; set; }
		public double RatingAvg { get; set; }
		public IEnumerable<Comment> Comments { get; set; }
		public IEnumerable<Vote> Votes { get; set; }
		public IEnumerable<Genre> Genres { get; set; }
	}

}
