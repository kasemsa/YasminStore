using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using YasminStore.ApplicationContract.DTOs.Auth;
using YasminStore.ApplicationContract.Identity;
using YasminStore.Domain.Entities;
using YasminStore.Persistence;
using Microsoft.EntityFrameworkCore;

namespace YasminStore.Infrastructure.Repositories
{
    public class AuthService : IAuthService
    {
        private readonly YasminStoreDbContext _context;
        private readonly IConfiguration _config;

        public AuthService(YasminStoreDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public async Task<AuthResponseDto> RegisterAsync(RegisterUserDto dto)
        {
            // التحقق من رقم الهاتف
            if (await _context.Users.AnyAsync(u => u.PhoneNumber == dto.PhoneNumber))
                throw new Exception("هذا الرقم مسجل مسبقاً.");

            var user = new User
            {
                FullName = dto.FullName,
                PhoneNumber = dto.PhoneNumber,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                userRoles = new List<UserRole>()
            };

            // إضافة الأدوار
            if (dto.RoleIds != null && dto.RoleIds.Any())
            {
                foreach (var roleId in dto.RoleIds)
                {
                    // جلب الـ Role من قاعدة البيانات للتأكد من وجوده
                    var role = await _context.Roles.FindAsync(roleId);
                    if (role == null) throw new Exception($"Role بالمعرف {roleId} غير موجود.");

                    user.userRoles.Add(new UserRole
                    {
                        RoleId = roleId,
                        Role = role,
                        User = user
                    });
                }
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return GenerateAuthResponse(user);
        }

        public async Task<AuthResponseDto> LoginAsync(LoginUserDto dto)
        {
            var user = await _context.Users
                .Include(u => u.userRoles)
                    .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(u => u.PhoneNumber == dto.PhoneNumber);

            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
                throw new Exception("بيانات الدخول غير صحيحة.");

            return GenerateAuthResponse(user);
        }

        private AuthResponseDto GenerateAuthResponse(User user)
        {
            var roles = user.userRoles
                .Where(ur => ur.Role != null)  // ✅ تفادي null
                .Select(ur => ur.Role.RoleName)
                .ToList();

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.FullName),
                new Claim(ClaimTypes.MobilePhone, user.PhoneNumber)
            };

            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(_config["Jwt:ExpireMinutes"])),
                signingCredentials: creds
            );

            return new AuthResponseDto
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                FullName = user.FullName,
                Roles = roles
            };
        }
    }
}
