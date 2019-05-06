using DAL.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

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
	} 
}
