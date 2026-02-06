using AuthService.Data;
using AuthService.Models;
using AuthService.DTOs;
using AuthService.Services.IServices;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IAuthService _authService;

        public AuthApiController(ApplicationDbContext applicationDbContext,
            IConfiguration configuration, IAuthService authService)
        {
            _authService = authService;
            _context = applicationDbContext;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CustomRegisterRequest request)
        {
            if (await _context.Users.AnyAsync(u => u.Email == request.Email))
                return BadRequest("Email already exists.");

            var user = new User
            {
                Email = request.Email,
                PasswordHash = _authService.HashPassword(request.Password),
                FullName = request.FullName
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { message = "User registered successfully" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] CustomLoginRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (user == null || !_authService.VerifyPassword(request.Password, user.PasswordHash))
                return Unauthorized("Invalid credentials.");

            var token = _authService.GenerateJwtToken(user);

            return Ok(new { token = token });
        }

    }
}
