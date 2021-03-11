using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCongViec.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class XacThucController : ControllerBase
    {
        private readonly UserManager<NguoiSuDung> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;

        public XacThucController(UserManager<NguoiSuDung> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
        }




        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] DangNhap model)
        {
            var user = await userManager.FindByNameAsync(model.Username);
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }


        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] DangKy model)
        {
            var userExists = await userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new PhanHoi { Status = "Lỗi", Message = "User đã tồn tại!" });

            NguoiSuDung user = new NguoiSuDung()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new PhanHoi { Status = "Lỗi", Message = "Tạo User không thành công. Vui lòng kiểm tra lại cú pháp." });

            return Ok(new PhanHoi { Status = "thành công", Message = "Tạo User thành công!" });
        }


        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] DangKy model)
        {
            var userExists = await userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new PhanHoi { Status = "Lỗi", Message = "Đã tồn tại!" });

            NguoiSuDung user = new NguoiSuDung()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new PhanHoi { Status = "Lỗi", Message = "Tạo không thành công. Vui lòng kiểm tra lại cú pháp." });

            if (!await roleManager.RoleExistsAsync(RoleNguoiSuDung.Admin))
                await roleManager.CreateAsync(new IdentityRole(RoleNguoiSuDung.Admin));
            if (!await roleManager.RoleExistsAsync(RoleNguoiSuDung.User))
                await roleManager.CreateAsync(new IdentityRole(RoleNguoiSuDung.User));

            if (await roleManager.RoleExistsAsync(RoleNguoiSuDung.Admin))
            {
                await userManager.AddToRoleAsync(user, RoleNguoiSuDung.Admin);
            }

            return Ok(new PhanHoi { Status = "thành công", Message = "Tạo thành công!" });
        }

    }

}
