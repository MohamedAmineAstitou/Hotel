using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Astitou_Backend.Ressource
{
    public class NewUserResource
    {
        public NewUserResource(string username, string password, string email)
        {
            Username = username;
            Password = password;
            Email = email;
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
