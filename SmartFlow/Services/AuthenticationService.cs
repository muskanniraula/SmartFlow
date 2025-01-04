using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Maui.Storage;
using SmartFlow.Models;

namespace SmartFlow.Services
{
    public class AuthenticationService
    {
        public bool Register(string username, string password, string currency)
        {
            if (Preferences.Get("username", null) != null)
            {
                return false; // User already exists
            }

            Preferences.Set("username", username);
            Preferences.Set("password", password);
            Preferences.Set("currency", currency);
            return true;
        }

        public bool Login(string username, string password)
        {
            var storedUsername = Preferences.Get("username", null);
            var storedPassword = Preferences.Get("password", null);

            return storedUsername == username && storedPassword == password;
        }
    }
}
