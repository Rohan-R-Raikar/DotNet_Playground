using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System.Security.Cryptography;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Ocelot Configuration
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

// JWT Key for AES Decryption
var aesKey = builder.Configuration["Jwt:AesKey"];
var aesIV = builder.Configuration["Jwt:AesIV"];

// JWT Bearer
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer("JwtBearer", options =>
{
    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (!string.IsNullOrEmpty(token))
            {
                context.Token = DecryptJwt(token, aesKey, aesIV);
            }
            return Task.CompletedTask;
        }
    };
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

builder.Services.AddOcelot();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

await app.UseOcelot();

app.Run();

string DecryptJwt(string token, string key, string iv)
{
    byte[] keyBytes = Encoding.UTF8.GetBytes(key);
    byte[] ivBytes = Encoding.UTF8.GetBytes(iv);

    token = token.Replace("-", "+").Replace("_", "/"); // URL-safe reverse
    var tokenBytes = Convert.FromBase64String(token);

    using var aes = Aes.Create();
    aes.Key = keyBytes;
    aes.IV = ivBytes;

    var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
    using var ms = new MemoryStream(tokenBytes);
    using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
    using var reader = new StreamReader(cs);
    return reader.ReadToEnd();
}
