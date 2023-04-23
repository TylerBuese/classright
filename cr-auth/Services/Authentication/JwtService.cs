using cr_auth.Abstractions;
using cr_auth.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace cr_auth.Services.Authentication
{
	public class JwtService : IJwtService
	{
		private readonly IConfiguration _configuration;
		public JwtService(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public String GenerateToken(User user)
		{
			var issuer = _configuration["Jwt:Issuer"];
			var audience = _configuration["Jwt:Audience"];
			var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
			
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new[]
				{
				new Claim("Id", Guid.NewGuid().ToString()),
				new Claim(JwtRegisteredClaimNames.Sub, user.Username),
				new Claim(JwtRegisteredClaimNames.Email, user.Email),
				new Claim(JwtRegisteredClaimNames.NameId, user.Id),
				new Claim(JwtRegisteredClaimNames.Jti,
				Guid.NewGuid().ToString()),
				
				}),
				Expires = DateTime.UtcNow.AddMinutes(30),
				Issuer = issuer,
				Audience = audience,
				SigningCredentials = new SigningCredentials
				(new SymmetricSecurityKey(key),
				SecurityAlgorithms.HmacSha256),
			};
			
			foreach (var role in user.Roles)
			{
				tokenDescriptor.Subject.AddClaim(new Claim(ClaimTypes.Role, role.ToString().ToLower()));
			}
			
			var tokenHandler = new JwtSecurityTokenHandler();
			var token = tokenHandler.CreateToken(tokenDescriptor);
			var stringToken = tokenHandler.WriteToken(token);
			return stringToken;
		}
	}
}
