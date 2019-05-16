using DAL.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
	public class CommentRepository : ICommentRepository
	{
		private AppDbContext _dbContext;
		public CommentRepository(AppDbContext dbContext)
		{
			_dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
		}

		public void AddComment(Comment comment)
		{
			_dbContext.Comments.Add(comment);
		}

		public void DeleteComment(Comment comment)
		{
			_dbContext.Entry(comment).State = EntityState.Deleted;
		}
        public async Task <Comment> GetById(int id)
        {
            return await _dbContext.Comments
                        .Where(c => c.Id == id)
                        .FirstOrDefaultAsync();
        }
        public async Task<Comment> GetByFilmId(int filmId)
        {
            return await _dbContext.Comments
                        .Where(c => c.FilmId == filmId)
                        .FirstOrDefaultAsync(); ;
        }
        public async Task<Comment> GetByUserId(string userId)
        {
            return await _dbContext.Comments
                        .Where(c => c.UserId == userId)
                        .FirstOrDefaultAsync(); ;
        }
    } 
}
