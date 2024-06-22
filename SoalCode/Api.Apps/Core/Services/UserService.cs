using Core.Dtos;
using Core.RequestInputs;
using DataAccess;
using DataAccess.Models;
using DataAccess.SharedObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class UserService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly SecurityConfig _securityConfig;
        public UserService(ApplicationDbContext dbContext, IOptions<SecurityConfig> securityOption)
        {
            _dbContext = dbContext;
            _securityConfig = securityOption.Value;
        }

        public async Task<TokenDto> Login(LoginInput input)
        {
            var dataUser = await _dbContext.Users
                .FirstOrDefaultAsync(x => x.UserName.Equals(input.UserName) && x.Password.Equals(input.Password));

            if (dataUser == null)
                return new TokenDto();

            var token = await GenerateToken(dataUser);

            return token;
        }

        private async Task<TokenDto> GenerateToken(User user)
        {
            var secretKey = Encoding.ASCII.GetBytes(_securityConfig.SecretKey);
            var accessTokenExpireAt = DateTime.Now.AddMinutes(_securityConfig.TokenExpired);

            var accessTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()),
                    new Claim(JwtRegisteredClaimNames.Sid, user.UserName)
                }),
                Expires = accessTokenExpireAt,
                Issuer = _securityConfig.Issuer,
                Audience = _securityConfig.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha512Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var accessToken = tokenHandler.CreateToken(accessTokenDescriptor);

            return await Task.FromResult(new TokenDto
            {
                AccessToken = tokenHandler.WriteToken(accessToken),
                ExpiredAt = accessTokenExpireAt
            });
        }
    }
}
