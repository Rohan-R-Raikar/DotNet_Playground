using AuthService.Models;
using AuthService.Services.IServices;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace AuthService.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public String HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }

        public string GenerateJwtToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("Password", user.PasswordHash)
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpiryMinutes"])),
                signingCredentials: creds
            );

            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            return EncryptJwt(jwtToken);
        }

        public string EncryptJwt(string token)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(_configuration["Jwt:AesKey"]);
            byte[] ivBytes = Encoding.UTF8.GetBytes(_configuration["Jwt:AesIV"]);

            using var aes = Aes.Create();
            aes.Key = keyBytes;
            aes.IV = ivBytes;

            var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            var tokenBytes = Encoding.UTF8.GetBytes(token);

            byte[] encrypted;
            using (var ms = new MemoryStream())
            using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
            {
                cs.Write(tokenBytes, 0, tokenBytes.Length);
                cs.FlushFinalBlock();
                encrypted = ms.ToArray();
            }

            var base64 = Convert.ToBase64String(encrypted);

            var urlFriendly = base64.Replace("+", "-").Replace("/", "_").Replace("=", "");

            return urlFriendly;
        }
    }
}
