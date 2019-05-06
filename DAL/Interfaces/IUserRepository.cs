using System;
using Entities;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
	public interface IUserRepository
	{
		void AddUser(User user);
		void DeleteUser(User user);
		void UpdateUser(User user);
	}
}
