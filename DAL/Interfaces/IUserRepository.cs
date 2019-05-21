using System;
using Entities;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
	public interface IUserRepository
	{
		void AddUser(User user);
		void DeleteUser(User user);
		void UpdateUser(User user);
        Task<User> GetById(string id);
		Task<User> GetByUsername(string id);
	}
}
