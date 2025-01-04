using System.Threading.Tasks;
using SmartFlow.Models;

namespace SmartFlow.Interface
{
    /// <summary>
    /// Interface for authentication services.
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="user">The user object containing registration details.</param>
        /// <returns>True if registration is successful, false otherwise.</returns>
        Task<bool> Register(User user);

        /// <summary>
        /// Authenticates a user with a username and password.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <returns>The authenticated user object, or null if authentication fails.</returns>
        Task<User> Login(string username, string password);
    }
}
