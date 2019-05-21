using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
	public interface ICommentService
	{
		Task<Comment> AddCommentAsync(Comment comment);
		Task DeleteCommentAsync(int id);
        Task<Comment> GetByIdAsync(int id);
        Task<IEnumerable<Comment>> GetByFilmIdAsync(int filmId);
        Task<IEnumerable<Comment>> GetByUserIdAsync(string userId);
    }
}
