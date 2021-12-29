using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_Astitou_Backend.Model
{
    public partial class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string TokenForgotPassword { get; set; }

        [NotMapped] public string Token { get; set; }
    }
}
