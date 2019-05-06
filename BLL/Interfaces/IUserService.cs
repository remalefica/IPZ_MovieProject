using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
	public interface IUserService
	{
        Task AddUserAsync(User user);
        Task DeleteUserAsync(User user);
        Task UpdateUserAsync(User user);
    }
}
