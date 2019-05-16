using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{

	public class Genre
	{
		public int Id { get; set; }
		public int FilmId { get; set; }
		public Film Film { get; set; }
		public GenreListEnum GenreName { get; set; }
	}
}
