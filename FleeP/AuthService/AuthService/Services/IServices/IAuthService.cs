using AuthService.Models;

namespace AuthService.Services.IServices
{
    public interface IAuthService
    {
        string HashPassword(string password);
        bool VerifyPassword(string password, string hash);
        string GenerateJwtToken(User user);
        string EncryptJwt(string token);
    }
}
