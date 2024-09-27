using AppCore.Entities;
using AppCore.Enums;
using AppServices.DTOs.UserDTOs;
using AppServices.Service.UserServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController:ControllerBase {
        private readonly IConfiguration _config;
        private readonly IUserService _userService;

        public TokenController(IConfiguration config, IUserService userService) {
            _config = config;
            _userService = userService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> GetToken(UserLoginDTO userLoginDTO) {
            if(userLoginDTO.Password != "123") return Unauthorized("Password is wrong!");

            var userDTO = _userService.GetUserByEmail(userLoginDTO.Email);
            if(userDTO == null)
                return NotFound();
            string token = GenerateToken(userDTO);
            return Ok(token);
        }

        private string GenerateToken(UserDTO userDTO) {
            var keyBytes = Encoding.UTF8.GetBytes(_config.GetSection("JwtTokenOptions")["SigningKey"]);
            var symmetricKey = new SymmetricSecurityKey(keyBytes);

            var signingCredentials = new SigningCredentials(
                symmetricKey,
                SecurityAlgorithms.HmacSha256);
            string role = userDTO.Role == RoleEnum.Employee ? "Employee" : RoleEnum.Manager == userDTO.Role ? "Manager" : "Admin";
            var claims = new List<Claim>()
            {
                new Claim("Id", userDTO.Id.ToString()),
                new Claim("Name", userDTO.Name),
                new Claim("Surname", userDTO.Surname),
                new Claim("Email", userDTO.Email),
                new Claim("Role", role),
                new Claim("CreatedDate", userDTO.CreatedDate.ToString()),
                new Claim("UpdatedDate", userDTO.UpdatedDate.ToString()),
                new Claim("DepartmentId", userDTO.DepartmentId.ToString())

            };

            //var roleClaims = new List<Claim>()
            //{
            //    new Claim("Role", "Admin"),
            //    new Claim("Role", "Manager"),
            //    new Claim("Role", "Employee"),
            //};

            //claims.AddRange(roleClaims);

            var token = new JwtSecurityToken(
                issuer: _config.GetSection("JwtTokenOptions")["Issuer"],
                audience: _config.GetSection("JwtTokenOptions")["Audience"],
                claims: claims,
                expires: DateTime.Now.Add(TimeSpan.FromSeconds(double.Parse(_config.GetSection("JwtTokenOptions")["Expiration"]))),
                signingCredentials: signingCredentials);

            var tokenData = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenData;
        }

    }
}
