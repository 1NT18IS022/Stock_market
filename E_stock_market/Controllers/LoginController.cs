using E_stock_market.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;


using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using E_stock_market.Database;

namespace E_stock_market.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
       
        private IConfiguration _config;
        private readonly DataContext _context;
        private ILogger<LoginController> _logger;

        public LoginController(IConfiguration config, DataContext context, ILogger<LoginController> logger)
        {
            _config = config;
            _context = context;
            _logger = logger;
        }

        [HttpPost("register")]
        public ActionResult<loginuser> Register(userdto req)
        {
               loginuser user1 = new loginuser();
        var data=_context.userdata.FirstOrDefault(x=> x.UserName == req.Username);
            if (data != null)
            {_logger.LogError("Username already taken");
                return BadRequest("Username already taken");
            }

            string passwordHash=BCrypt.Net.BCrypt.HashPassword(req.Password);
            user1.UserName = req.Username;
            user1.Role = req.Role;
            user1.PasswordHash = passwordHash;
            _context.Add(user1);
            _context.SaveChanges();

            return Ok(req);

        }


        [HttpPost("Login")]
        public ActionResult<userdto> Login(userdto req)
        {
           
            var data=_context.userdata.Where(x=>x.UserName==req.Username).FirstOrDefault();
            if (data==null)
            {_logger.LogError("user not found");
                return BadRequest("user not found");
            }

           if(!BCrypt.Net.BCrypt.Verify(req.Password,data.PasswordHash))
            {_logger.LogError("wrong password");
                return BadRequest("wrong password");
            }

            string token = CreateToken(data);

            return Ok(token);

        }


        private string CreateToken(loginuser user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.Role,user.Role),

            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("Jwt:Key").Value!));
            var cred=new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims:claims,
                expires:DateTime.Now.AddSeconds(30),
                signingCredentials:cred
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }






    }
}
