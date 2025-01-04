using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using SmartFlow.Services;

namespace SmartFlow.Components.Pages
{
    public partial class Login
    {
        [CascadingParameter]

        private string Username { get; set; }

        private string Password { get; set; }
        private string currency { get; set; }

        private string _errorMessage = "";

        protected override void OnInitialized()
        {

            try
            {
                UserService.Login(UserService.SeedUsername, UserService.SeedPassword);
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
                var user = UserService.Login(Username, Password);

                if (user != null)
                {
                    NavManager.NavigateTo("/home");
                }
            }
            catch (Exception e)
            {
                _errorMessage = e.Message;
                Console.WriteLine(e);
            }
        }
    }
}
