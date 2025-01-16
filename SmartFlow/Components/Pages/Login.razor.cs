using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using SmartFlow.Models.Constant;
using SmartFlow.Services;

namespace SmartFlow.Components.Pages
{
    public partial class Login
    {
        [CascadingParameter] private string Username { get; set; }
        private string Password { get; set; }

        private string _errorMessage = "";

        // OnInitialized is not needed for the login, it is only useful for setup logic
        protected override void OnInitialized()
        {
            // Initialization logic (if needed) can be placed here
        }

        private void LoginHandler()
        {
            try
            {
                var user = UserService.Login(Username, Password);  // Attempt to login

                // If login is successful, navigate to the dashboard
                if (user != null)
                {
                    GlobalState.CurrentUser = user;
                    NavigateToDashboard();
                }
                else
                {
                    _errorMessage = "Invalid Username or Password";  // Set the error message if login fails
                }
            }
            catch (Exception e)
            {
                _errorMessage = "An error occurred: " + e.Message;  // Display error message if login fails
                Console.WriteLine(e.Message);
            }
        }

        private void NavigateToRegister()
        {
            Navigation.NavigateTo("/register");  // Navigates to register page
        }

        private void NavigateToDashboard()
        {
            Navigation.NavigateTo("/dashboard");  // Navigates to dashboard
        }
    }
}