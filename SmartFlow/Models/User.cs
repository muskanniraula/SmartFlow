using System;
using SmartFlow.Models.Constant;

namespace SmartFlow.Models
{
    public class User
    {


        public Guid CreatedBy { get; set; }
    public Guid Userid { get; set; } = Guid.NewGuid();
        public string Username { get; set; }
        public string Password { get; set; }
        public PreferredCurrency currency { get; set; }

    }
}
