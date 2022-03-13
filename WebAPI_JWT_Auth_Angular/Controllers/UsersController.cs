using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAPI_JWT_Auth_Angular.Data;
using WebAPI_JWT_Auth_Angular.Models;
using WebAPI_JWT_Auth_Angular.Models.BindingModel;
using WebAPI_JWT_Auth_Angular.Models.DTO;

namespace WebAPI_JWT_Auth_Angular.Controllers
{
    [Route("")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public readonly ILogger<UsersController> _logger;
        public readonly UserManager<AppUser> _userManager;
        public readonly SignInManager<AppUser> _signInManager;
        public readonly JWTConfig _jWTConfig;
        public UsersController(
            ILogger<UsersController> logger,
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IOptions<JWTConfig> jWTConfig
            )
        {
            this._logger = logger;
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._jWTConfig = jWTConfig.Value;
    }
        public IActionResult Get()
        {
            return Ok("dsasdsdfdfsd");
        }

        [HttpPost("RegisterUser")]
        public async Task<object> RegisterUser([FromBody] RegisterUserModel model)
        {
            try
            {
                var user = new AppUser()
                {
                    FullName = model.FullName,
                    Email = model.Email,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    UserName = model.Email
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return await Task.FromResult("Registered");
                }
                return await Task.FromResult(string.Join(",", result.Errors.Select(x => x.Description).ToArray()));
            }catch (Exception ex)
            {
                return await Task.FromResult(ex.Message);
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("GetAllUsers")]
        public async Task<object> GetAllUSers()
        {
            try
            {
                var users = _userManager.Users.Select(x=>new UserDTO(
                    x.FullName, x.Email, x.UserName, x.DateCreated
                    ));
                return await Task.FromResult(users);
            }
            catch (Exception ex)
            {
                return await Task<object>.FromResult(ex.Message);
            }
        }

        [HttpPost("Login")]
        public async Task<object> Login([FromBody] LoginModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.Email == null || model.Password == null)
                        return await Task.FromResult("Parametors are missing");
                    var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
                    if (result.Succeeded)
                    {
                        var appUser = await _userManager.FindByEmailAsync(model.Email);
                        var userDTO = new UserDTO(appUser.FullName, appUser.Email, appUser.UserName, appUser.DateCreated);
                        userDTO.Token = GenerateToken(appUser);
                        return await Task.FromResult(userDTO);
                    }
                }
                return await Task.FromResult("invald Email or Password");
            }
            catch(Exception ex)
            {
                return await Task.FromResult(ex.Message); 
            }
        }

        private string GenerateToken(AppUser user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jWTConfig.Key);
            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new System.Security.Claims.ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.NameId, user.Id),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddSeconds(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Audience = _jWTConfig.Audience,
                Issuer = _jWTConfig.Issuer
            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);
        }
    }
}
