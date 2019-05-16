﻿using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
	interface IGenreRepository
	{
		Task<Genre> GetById(int id);
		Task<Genre> GetByFilmId(string filmId);
		void AddGenre(Genre genre);
	}
}
