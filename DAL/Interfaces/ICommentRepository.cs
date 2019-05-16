using System;
using Entities;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
	public interface ICommentRepository
	{
        Task <Comment> GetById(int id);
        Task<Comment> GetByFilmId(int filmId);
        Task<Comment> GetByUserId(string userId);
        void AddComment(Comment comment);
		void DeleteComment(Comment comment);
     
    }
}
