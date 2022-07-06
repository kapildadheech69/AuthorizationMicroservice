using Authorization.Infrastructure;
using Authorization.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;


namespace Authorization.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class Authenticate : ControllerBase
    {
        private readonly IUserModel _user;
        public Authenticate(IUserModel user)
        {
            _user = user;
        }

        // GET: api/<Authenticate>


        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] UserModel login)
        {
            IActionResult response = Unauthorized();
            var user = _user.AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = _user.GenerateJSONWebToken(user);

                return Ok(new { token = tokenString, userId = login.EmployeeId.ToString() });
            }

            return response;
        }

    }
}

