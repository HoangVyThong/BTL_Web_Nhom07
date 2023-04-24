using BTL_Web_Nhom7.Models;
using BTL_Web_Nhom7.Models.Login;
using BTL_Web_Nhom7.Models.PhanQuyen;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BTL_Web_Nhom7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        BtlApiContext db = new BtlApiContext();
        private readonly AppSetting _appSettings;

        public UserController(IOptionsMonitor<AppSetting> optionsMonitor)
        {
            _appSettings = optionsMonitor.CurrentValue;
        }
        [HttpPost("Login")]
        public IActionResult Validate(LoginModel login)
        {
            var user = db.TaiKhoans.SingleOrDefault(p => p.TenTaiKhoan == login.UserName && p.Password == login.Password);
            if(user == null)
            {
                return Ok(new APIResponse
                {
                    Success = false,
                    Message = "Chưa đúng tài khoản mật khẩu"
                });
            }
            else
            {
                HttpContext.Session.SetString("token", GenerateToken(user));
                return Ok(new APIResponse
                {
                    Success = true,
                    Message = "Authenticate",
                    Data = GenerateToken(user)
                
                });
            }
        }

        private string GenerateToken(TaiKhoan tk)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var secretKeyBytes = Encoding.UTF8.GetBytes(_appSettings.SecretKey);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim("UserName", tk.TenTaiKhoan),
                    //roles

                    new Claim("TokenId", Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(100),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha512Signature)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescription);

            return jwtTokenHandler.WriteToken(token);
        }
    
    }
}
