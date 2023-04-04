using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System;
using WebApplication1.Entities;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        [HttpPost("login")]
        public IActionResult Login(int deviceId, string deviceToken, [FromServices]InnovationContext innovationContext)
        {
            var device = innovationContext.Devices.Where(dev=> dev.Id == deviceId && dev.Token == deviceToken).FirstOrDefault();
            // если пользователь не найден, отправляем статусный код 401
            if (device is null) return (IActionResult)Results.Unauthorized();

            var claims = new List<Claim> { new Claim(ClaimTypes.NameIdentifier, device.Id.ToString()) };
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(10)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            // формируем ответ
            var response = new
            {
                access_token = encodedJwt,
                devicename = device.Name
            };

            return Ok(response);
        }

    }
}
