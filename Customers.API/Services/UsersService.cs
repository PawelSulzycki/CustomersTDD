﻿using Customers.API.Models;

namespace Customers.API.Services
{
    public interface IUsersService
    {
        Task<List<User>> GetAllUsers();
    }

    public class UsersService : IUsersService
    {
        public Task<List<User>> GetAllUsers()
        {
            throw new NotImplementedException();
        }
    }
}
