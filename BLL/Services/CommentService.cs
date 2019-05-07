using BLL.Interfaces;
using DAL.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CommentService : ICommentService
    {
        private IUnitOfWork _unitOfWork;

        public CommentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<Comment> AddCommentAsync(Comment comment)
        {
            if (comment == null)
            {
                throw new ArgumentNullException(nameof(comment));
            }

            _unitOfWork.CommentRepository.AddComment(comment);
            await _unitOfWork.SaveAsync();
            return comment;
        }
        public async Task DeleteCommentAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id must be >= 0", nameof(id));
            }

            var comment = await _unitOfWork.CommentRepository.GetById(id);

            if (comment == null)
            {
                throw new ArgumentException("not found", nameof(id));
            }

            _unitOfWork.CommentRepository.DeleteComment(comment);
            await _unitOfWork.SaveAsync();
        }
        public async Task<Comment> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id must be more then zero", nameof(id));
            }

            return await _unitOfWork.CommentRepository.GetById(id);
        }
    }
}
