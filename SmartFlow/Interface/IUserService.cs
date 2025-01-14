using SmartFlow.Models;
using SmartFlow.Models.Constant;
using System;
using System.Collections.Generic;

namespace SmartFlow.Interface
{
    public interface IUserService
    {
        /// <summary>
        /// Automatically creates the first admin user during the program execution if no user exists.
        /// </summary>
        void SeedUser();

        /// <summary>
        /// Allows a user to log in with their credentials.
        /// </summary>
        /// <param name="username">Username for login</param>
        /// <param name="password">Password for login</param>
        /// <returns>The authenticated user</returns>
        /// <exception cref="Exception">Thrown when login fails due to invalid credentials</exception>
        User Login(string username, string password);

        /// <summary>
        /// Retrieves a user by their unique identifier.
        /// </summary>
        /// <param name="id">User's unique ID</param>
        /// <returns>The user associated with the given ID</returns>
        User GetById(Guid id);

        /// <summary>
        /// Creates a new user with the specified details.
        /// </summary>
        /// <param name="userId">User ID of the creator</param>
        /// <param name="Username">The new user's username</param>
        /// <param name="Password">The new user's password</param>
        /// <param name="currency">Preferred currency for the user</param>
        /// <returns>An updated list of users</returns>
        /// <exception cref="Exception">Thrown for invalid input or duplicate username</exception>
        List<User> Create(Guid userId, string Username, string Password, PreferredCurrency currency);
    }
}
