using System;
using Entities;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
	interface ICommentRepository
	{
        void AddComment(Comment comment);
        void DeleteComment(Comment comment);
    }
}
