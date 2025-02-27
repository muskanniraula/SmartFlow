﻿using System;
using global::SmartFlow.Services;
using Microsoft.AspNetCore.Components;
using SmartFlow.Models.Constant;
using SmartFlow.Services;

namespace SmartFlow.Components.Pages
{
    public partial class Register
    {
        [CascadingParameter]
        private string FullName { get; set; }
        private string Username { get; set; }
        private string Password { get; set; }
        private PreferredCurrency Currency { get; set; }

        private string _errorMessage = "";

        private void RegisterHandler()
        {
            try
            {
                // Check if the username already exists

                // Proceed to create a new user if the username doesn't exist
                var user = UserService.Create(Guid.NewGuid(), Username, Password, Currency);

                if (user != null)
                {
                    Navigation.NavigateTo("/"); // Navigate to login page after successful registration
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

