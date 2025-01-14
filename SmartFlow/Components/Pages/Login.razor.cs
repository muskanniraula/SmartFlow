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
        [CascadingParameter]

        private string Username { get; set; }
        private string Password { get; set; }
        //private string currency { get; set; }

        private string _errorMessage = "";

        protected override void OnInitialized()
        {

            try
            {
                UserService.Login(Username, Password);
            }
            catch (Exception e)
            {
                _errorMessage = e.Message;
                Console.WriteLine(e.Message);
            }
        }

        private void LoginHandler()
        {
            try
            {
                var user = UserService.Login(Username, Password);  // Attempt to login

                // If login is successful, navigate to the home page
                // Redirect to home after successful login

                if (user != null)
                {
                    GlobalState.CurrentUser = user;
                    //GlobalState.CurrentUser.currency = currency;
                    NavigateToDashboard();
                }
                else
                {
                    _errorMessage = "Invalid Username or Password";
                }
            }

            catch (Exception e)
            {
                _errorMessage = e.Message;  // Display error message if login fails
                Console.WriteLine(e.Message);
            }
        }
        private void NavigateToRegister()
        {
            Navigation.NavigateTo("/register");  // Navigates to register page
        }
        private void NavigateToHome()
        {
            Navigation.NavigateTo("/home");  // Navigates to register page
        }
        private void NavigateToDashboard()
        {
            Navigation.NavigateTo("/dashboard");  // Navigates to register page
        }

    }
}