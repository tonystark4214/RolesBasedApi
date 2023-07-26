using Microsoft.AspNetCore.Mvc;
using Project220723.Models;
using Project220723.Repository;
using System.Net;

namespace Project220723.Controllers
{
    public class LoginController : Controller
    {
        public readonly InterfaceLogin login;
        public LoginController(InterfaceLogin login)
        {
            this.login = login;
        }

        [HttpPost]
        [Route("VerifyCredentials")]
        public IActionResult GetCredentials([FromBody] Credentials cred)
        {
            Token token1 = new Token();
            var data = login.GetCredentials(cred);
            if (data != "error")
            {
                var token = login.GenerateJSONWebToken(data);

                return Ok(token);
            }
            return Ok("Invalid Credentials");
        }
    }
}
