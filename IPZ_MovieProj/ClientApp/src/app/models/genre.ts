import { Film } from "./film";

export const enum Genre
	{
		Action = 1,
		Adventure = 2,
		Animation = 3,
		Biography = 4,
		Comedy = 5,
		Crime = 6,
		Documentary = 7,
		Drama = 8,
		Family = 9,
		Fantasy = 10,
		History = 11,
		Horror = 12,
		Music = 13,
		Musical = 14,
		Mystery = 15,
		Romance = 16,
		SciFi = 17,
		Short = 18,
		Sport = 19,
		Superhero = 20,
		Thriller = 21,
		War = 22,
		Western = 23
	}


export class GenreFilm{

		public id: number;
		public filmId: number;
		public film: Film;
		public genreName: Genre;

	getFilmGenre(genre: Genre) : string {
		switch (genre) {
		  case Genre.Action:
			return 'Action';
		  case Genre.Adventure:
			return 'Adventure';
		  case Genre.Biography:
			return 'Biography';
		  case Genre.Comedy:
			return 'Comedy';
		  case Genre.Crime:
			return 'Crime';
		  case Genre.Documentary:
			return 'Documentary';
		  case Genre.Drama:
			return 'Drama';
		  case Genre.Family:
			return 'Family';
		  case Genre.Fantasy:
			return 'Fantasy';
		  case Genre.History:
			return 'History';
		  case Genre.Horror:
			return 'Horror';
		  case Genre.Music:
			return 'Music';
		  case Genre.Musical:
			return 'Musical';
		  case Genre.Mystery:
			return 'Mystery';
		  case Genre.Romance:
			return 'Romance';
		  case Genre.SciFi:
			return 'SciFi';
		  case Genre.Short:
			return 'Short';
		  case Genre.Sport:
			return 'Sport';
		  case Genre.Superhero:
			return 'Superhero';
		  case Genre.Thriller:
			return 'Thriller';
		  case Genre.War:
			return 'War';
		  case Genre.Western:
			return 'Western';
		  default:
			break;
		}
	}
}

