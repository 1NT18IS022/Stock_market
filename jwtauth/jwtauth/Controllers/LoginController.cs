using AuthenticationPlugin;

using jwtauth.Database;
using jwtauth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace E_stock_market.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IConfiguration _config;
        private readonly AuthService _auth;


        public LoginController(IConfiguration config, DataContext context)
        {
            _context = context;
            _config = config;
            _auth = new AuthService(config);
        }




        [HttpPost("Register")]
        public ActionResult<user> Register(user data)
        {
            var user = _context.Users.Where(x => x.Username == data.Username).FirstOrDefault();
            if (user != null)
                return BadRequest("Username taken please try different one");

            _context.Add(data);
            _context.SaveChanges();
            return Ok("registered succesfully");
        }

        [HttpPost("Login")]
        public IActionResult Login(user data)
        {
            var user = _context.Users.Where(x => x.Username == data.Username).FirstOrDefault();
            if (user == null)
                return NotFound();

            if (user.Password != data.Password)
            {
                return Unauthorized();
            }
            var claims = new[]
             {
                new Claim(JwtRegisteredClaimNames.Name , user.Username),
                 new Claim(ClaimTypes.Name, user.Username),
                 new Claim(ClaimTypes.Role,user.Role)
                };

            var token = _auth.GenerateAccessToken(claims);
            return new ObjectResult(new
            {
                access_token = token.AccessToken,
                expires_in = token.ExpiresIn,
                token_type = token.TokenType,
                creation_Time = token.ValidFrom,
                expiration_Time = token.ValidTo,
            });



        }

        private ObjectResult Generatetoken()
        {

            var claims = new[]
{
   new Claim(JwtRegisteredClaimNames.Email, "abc@email.com"),
   new Claim(ClaimTypes.Email, "abc@email.com"),
 };
            var token = _auth.GenerateAccessToken(claims);

            return new ObjectResult(new
            {
                access_token = token.AccessToken,
                expires_in = token.ExpiresIn,
                token_type = token.TokenType,
                creation_Time = token.ValidFrom,
                expiration_Time = token.ValidTo,
            });

        }






    }


}
