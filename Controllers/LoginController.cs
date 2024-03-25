using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using EMS.Data;
using EMS.DTOs;
using EMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace EMS
{
    [ApiController]
    [Route("/api/[controller]")]
    public class LoginController : Controller
    {
        /*** Properties ***/
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;
        /*** Constructor ***/
        public LoginController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        /*** Methods ***/
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(
            [FromBody] UserLoginDTO userLogin
        )
        {
            var comparisonType = StringComparison.OrdinalIgnoreCase;
            var existingUser = await _db.Users.FirstOrDefaultAsync(
                u =>
                    string.Equals(u.Username, userLogin.Username, comparisonType)
                );

            if (existingUser == null) return NotFound("User does not exist");
            if (!Authenticate(existingUser, userLogin)) return Unauthorized("Wrong Password");

            var token = Generate(existingUser);

            var userDTO = _mapper.Map<UserDTO>(existingUser);
            return Ok(new
            {
                user = userDTO,
                token
            });
        }

        private bool Authenticate(User existingUser, UserLoginDTO userLogin)
        {
            if (existingUser.Password != userLogin.Password) return false;
            return true;
        }

        private string Generate(User user)
        {
            var jwtSecret = Environment.GetEnvironmentVariable("JWT_SECRET") ?? "P@s5w0rd";
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(ClaimTypes.NameIdentifier, user.Username ?? ""),
                new Claim(ClaimTypes.Email, user.Email ?? ""),
                new Claim(ClaimTypes.Role, user.Role ?? "")
            };

            var token = new JwtSecurityToken(
                Environment.GetEnvironmentVariable("JWT_ISSUER"),
                Environment.GetEnvironmentVariable("JWT_AUDIENCE"),
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}