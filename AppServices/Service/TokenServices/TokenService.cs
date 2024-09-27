using AppPersistence.Context;
using AppServices.DTOs.UserDTOs;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Service {
    public class TokenService {
        private readonly AppDbContext _context;

        private readonly string _secretKey;
        private readonly string _issuer;
        private readonly string _audience;

        public TokenService(IConfiguration config) {
            _secretKey = config["Jwt:SecretKey"];
            _issuer = config["Jwt:Issuer"];
            _audience = config["Jwt:Audience"];

        }
        public string GenerateToken(UserDTO user) {
            //var claims = new {
            //    new Claim(JwtRegisteredClaimNames.Sub,user),
            //    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            //    new Claim(ClaimTypes.NameIdentifier,user.Id.ToString())
            //};

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

            return "";
        }

    }
}
