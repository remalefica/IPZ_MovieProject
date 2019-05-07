using DAL.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace DAL.EF
{
	public class UserRepository : IUserRepository
	{
		private AppDbContext _dbContext;
		public UserRepository(AppDbContext dbContext)
		{
			_dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));


		}
        public async Task<User> GetById(int id)
        {
            return await _dbContext.Users
                        .Where(c => c.Id == id)
                        .FirstOrDefaultAsync();
        }

        public void AddUser(User user)
		{
			_dbContext.Users.Add(user);
		}

		public void DeleteUser(User user)
		{
			_dbContext.Entry(user).State = EntityState.Deleted;
		}

		public void UpdateUser(User user)
		{
			_dbContext.Users.Update(user);
		}
	}
}
