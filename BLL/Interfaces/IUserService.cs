using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
	public interface IUserService
	{
        Task<User> AddUserAsync(User user);
        Task DeleteUserAsync(int id);
        Task UpdateUserAsync(int id, User user);
        Task<User> GetByIdAsync(int id);
    }
}
