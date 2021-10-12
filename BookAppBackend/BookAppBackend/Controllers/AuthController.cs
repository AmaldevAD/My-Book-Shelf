using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BookAppBackend.Models.Auth;
using System.Web.Http.Cors;

namespace BookAppBackend.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AuthController : ApiController
    {
        private IAuth repo;

        public AuthController()
        {
            this.repo = new AuthSql();
        }

        [HttpPost]
        [Route("Register")]
        public Response PostRegister(Register userDetails)
        {
            return this.repo.Register(userDetails);
        }

        [HttpPost]
        [Route("login")]
        public Response Post(Login userLogin)
        {
            return this.repo.Login(userLogin);
        }

    }
}
