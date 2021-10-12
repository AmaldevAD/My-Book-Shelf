using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookAppBackend.Models.Auth
{
    public class Register
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Phone { get; set; }
    }

    public class Login
    {
        public string Email { get; set; }
        public string Password { get; set; }
       
    }

    public class Response
    {
        public bool Status { get; set; }
        public string Success { get; set; }
    }

}