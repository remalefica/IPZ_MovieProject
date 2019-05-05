using DAL.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.EF
{
    public class UserRepository : IUserRepository
    {
        private AppDbContext _dbContext;
        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException();

           
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
