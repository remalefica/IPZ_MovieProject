using System;
using Entities;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
	public interface ICommentRepository
	{
		void AddComment(Comment comment);
		void DeleteComment(Comment comment);
	}
}
