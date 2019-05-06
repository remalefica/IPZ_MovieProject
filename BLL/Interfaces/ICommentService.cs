using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
	public interface ICommentService
	{
		Task AddComment(Comment comment);
		Task DeleteComment(Comment comment);
	}
}
