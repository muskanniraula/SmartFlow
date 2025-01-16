
using SmartFlow.Interface;
using SmartFlow.Models;
using SmartFlow.Models.Constant;

namespace SmartFlow.Services
{
    public class UserService : GenericService<Models.User>, IUserService
    {
        /// Defining the static user credentials to list out when program is executed for the first time

        public const string SeedUsername = "admin";
        public const string SeedPassword = "admin";
        private static PreferredCurrency Seedcurrency = PreferredCurrency.NPR;

        /// Defining a static path for all the required files for the service and domain logic
        private static string appDataDirectoryPath = UtilityService.GetAppDirectoryPath();
        private static string appUsersFilePath = UtilityService.GetAppUsersFilePath();


        /// Defining a static method to automatically create first admin user during the program execution in the first state

        public void SeedUser()
        {

            var users = GetAll(appUsersFilePath).FirstOrDefault();

            if (users == null)
            {
                Create(Guid.Empty, SeedUsername, SeedPassword, Seedcurrency);
            }
        }


        /// Defining a method to allow login access to a user as per the entered credentials
        public User Login(string username, string password)
        {
            var loginErrorMessage = "Invalid username or password.";

            var users = GetAll(appUsersFilePath);

            var user = users.FirstOrDefault(u => u.Username == username);

            if (user == null)
            {
                throw new Exception(loginErrorMessage);
            }

            var passwordIsValid = UtilityService.VerifyHash(password, user.Password);

            if (!passwordIsValid)
            {
                throw new Exception(loginErrorMessage);
            }

            return user;
        }


        /// Defining a method to return a user as per its identifier
        public Models.User GetById(Guid id)
        {
            var user = GetAll(appUsersFilePath).FirstOrDefault(x => x.Userid == id);

            return user;
        }

        /// Defining a method to create a new user as per the model's properties
        public List<User> Create(Guid userId, string Username, string Password, PreferredCurrency currency)
        {
            Username = Username.Trim();

            if (Username == "" || Password == "")
            {
                throw new Exception("Please insert correct and valid input for each of the fields.");
            }

            var users = GetAll(appUsersFilePath);

            var UsernameExists = users.Any(x => x.Username == Username);

            if (UsernameExists)
            {
                throw new Exception("Username already exists. Please choose any other username.");
            }

            var numberOfAdmins = users.Count();

            var user = new User()
            {
                Username = Username,
                Password = UtilityService.HashSecret(Password),
                currency = currency
            };

            users.Add(user);

            SaveAll(users, appUsersFilePath);

            return users;
        }
    }
}