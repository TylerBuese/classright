using cr_auth.Abstractions;
using cr_auth.Data;
using cr_auth.Models;
using cr_auth.Models.ModelIngest;
using cr_auth.Services;
using cr_auth.Services.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace cr_auth.Controllers
{
	
	[ApiController]
	[Route("")]
	[EnableCors("Cors")]
	public class AuthController : ControllerBase
	{
		private readonly DataContext _context;
		private readonly IConfiguration _configuration;
		private readonly IWebHostEnvironment _env;
		private readonly IUserService _userService;
		private readonly IJwtService _jwtService;

		public AuthController(DataContext context, IWebHostEnvironment env, IConfiguration configuration, IUserService userService, IJwtService jwtService)
		{
			_env = env;
			_context = context;
			_configuration = configuration;
			_userService = userService;
			_jwtService = jwtService;
		}

		//[HttpGet()]
		//public async Task<ActionResult<Object>> Get()
		//{
		//	return Ok(new { result = "Ok!" });
		//}
		[Authorize(Roles = "superuser,admin")]
		[HttpPost("create-user")]
		public async Task<ActionResult<Object>> CreateUser(UserCreateIngest user)
		{
			_userService.CreateUser(_context, user);
			return Ok();
		}
		[AllowAnonymous]
		[HttpPost]
		public async Task<ActionResult<object>> Login([FromBody]LoginIngest login)
		{

			var user = await _userService.ValidateUserInfo(_context, login);
			var stringToken = _jwtService.GenerateToken(user);
			var opts = new CookieOptions
			{
				SameSite = SameSiteMode.None,
				Secure = true
			};
			
			Response.Cookies.Append("oauth", stringToken, opts);
				
			
			return Ok();
		}
	}
}