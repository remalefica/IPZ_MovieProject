using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
	interface IUnitOfWork: IDisposable
	{
		IFilmRepository FilmRepository { get; }
		ICommentRepository CommentRepository { get; }
		IUserRepository UserRepository { get; }
		IVoteRepository VoteRepository { get; }

		Task<int> Save();
	}
}
