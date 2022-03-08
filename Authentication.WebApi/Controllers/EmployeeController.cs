using Authentication.WebApi.Data;
using Authentication.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Authentication.WebApi.Controllers
{
    [Authorize]
    [Route("/")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public EmployeeController(ApplicationDbContext db, IOptions<JWTSettings> jWTSettings)
        {
            this.Db = db;
            this._jWTSettings = jWTSettings.Value;
        }

        private readonly ApplicationDbContext Db;
        private readonly JWTSettings _jWTSettings;
        public IActionResult Get()
        {

            return Ok(Db.Employees.ToList());
        }

        [AllowAnonymous]
        [HttpGet("Login")]
        public async Task<IActionResult> Login([FromBody] IdentityUser user)
        {
            user = await Db.Users.Where(x => x.UserName == user.UserName).FirstOrDefaultAsync();

            //Sign Your JWT Token Here
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jWTSettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Email)
                }),
                Expires = DateTime.UtcNow.AddDays(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Ok(tokenHandler.WriteToken(token));
        }
    }
}
