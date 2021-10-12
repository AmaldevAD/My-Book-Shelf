using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAppBackend.Models.Auth
{
    interface IAuth
    {
        Response Login(Login credentials);
        Response Register(Register userDetails);
    }
}
