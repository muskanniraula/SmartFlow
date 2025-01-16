using SmartFlow.Models;
using SmartFlow.Models.Constant;
using System;
using System.Collections.Generic;

namespace SmartFlow.Interface
{
    public interface IUserService
    {
        /// Automatically creates the first admin user during the program execution if no user exists.
        void SeedUser();

        /// Allows a user to log in with their credentials.
        User Login(string username, string password);


        /// Retrieves a user by their unique identifier.
        User GetById(Guid id);

        /// Creates a new user with the specified details.
        List<User> Create(Guid userId, string Username, string Password, PreferredCurrency currency);
    }
}
