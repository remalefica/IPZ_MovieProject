using BLL.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public async Task<User> AddUserAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _unitOfWork.UserRepository.AddUser(user);
            await _unitOfWork.SaveAsync();
            return user;
        }

        public async Task DeleteUserAsync(string idString)
        {

			if(!int.TryParse(idString, out int id))
			{
				throw new ArgumentException("Id must be a number", nameof(idString));
			}

            if (id <= 0)
            {
                throw new ArgumentException("Id must be >= 0", nameof(id));
            }

            var user = await _unitOfWork.UserRepository.GetById(idString);

            if (user == null)
            {
                throw new ArgumentException("not found", nameof(id));
            }

            _unitOfWork.UserRepository.DeleteUser(user);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateUserAsync(string idString, User user)
        {

			if (!int.TryParse(idString, out int id))
			{
				throw new ArgumentException("Id must be a number", nameof(idString));
			}

			if (id <= 0)
            {
                throw new ArgumentException("Id must be more then zero", nameof(id));
            }

            var userDb = await _unitOfWork.UserRepository.GetById(idString);

            userDb = user ?? throw new ArgumentNullException(nameof(user));
            await _unitOfWork.SaveAsync();
        }
        public async Task<User> GetByIdAsync(string idString)
        {
            return await _unitOfWork.UserRepository.GetById(idString);
        }

    }
}
