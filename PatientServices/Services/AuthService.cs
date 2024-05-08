using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using PatientServices.Models.Authentication;
using PatientServices.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PatientServices.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        public AuthService(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }



        public async Task<bool> RegisterUser(LoginUser loginUser)
        {
            var identityUser = new IdentityUser
            {
                UserName = loginUser.UserName,
                Email = loginUser.UserName
            };
            var result = await _userManager.CreateAsync(identityUser, loginUser.Password);
            return result.Succeeded;
        }
        public async Task<bool> LoginUser(LoginUser loginUser)
        {
            var user = await _userManager.FindByEmailAsync(loginUser.UserName);
            if (user is null)
            {
                return false;
            }

            return await _userManager.CheckPasswordAsync(user, loginUser.Password);

        }

        public string GenerateTokenString(LoginUser user)
        {
            IEnumerable<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email,user.UserName),
                new Claim(ClaimTypes.Role,"Admin")
            };
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Key").Value));

            SigningCredentials signingCred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                audience: _configuration.GetSection("Jwt:Audience").Value,
                issuer: _configuration.GetSection("Jwt:Issuer").Value,
                signingCredentials: signingCred
                );
            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenString;
        }
    }
}
