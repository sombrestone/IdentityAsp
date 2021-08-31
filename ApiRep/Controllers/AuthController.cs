using ApiRep.Infrastructure;
using ApiRep.Models;
using ApiRep.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRep.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly UserManager<User> userManager;
        readonly IConfiguration configuration;

        public AuthController(UserManager<User> userManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.configuration = configuration;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            User user = await userManager.FindByNameAsync(model.Username);
            if (user != null) return Conflict("User already exsists.");
            user = new User { Email = model.Email, UserName = model.Username };
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded) throw new LogicException("User not created. Check details.",422);
            return Ok("User successfully created.");
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            User user = await userManager.FindByNameAsync(model.Username);
            if (user == null) return NotFound("User not found.");
            if (!(await userManager.CheckPasswordAsync(user,model.Password)))
                throw new Exception("Wrong password.");
            var token = new JwtSecurityToken(
                issuer: configuration["JWT:ValidIssuer"],
                audience: configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(1),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
                    , SecurityAlgorithms.HmacSha256)
            );
            return Ok(new {token= new JwtSecurityTokenHandler().WriteToken(token)});
        }
    }
}
