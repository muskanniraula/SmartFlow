using System.Threading.Tasks;
using SmartFlow.Models;

namespace SmartFlow.Interface
{
    public interface IAuthService
    {
        /// Registers a new user.
        Task<bool> Register(User user);

        /// Authenticates a user with a username and password.
        Task<User> Login(string username, string password);
    }
}
