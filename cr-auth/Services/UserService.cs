using cr_auth.Abstractions;
using cr_auth.Data;
using cr_auth.Errors;
using cr_auth.Models;
using cr_auth.Models.ModelIngest;
using cr_auth.Services.Authentication;
using System.Text.RegularExpressions;

namespace cr_auth.Services
{
	public class UserService : IUserService
	{
		public enum UserRoles { STUDENT, INSTRUCTOR, GUEST, ADMINISTRATOR, SUPERUSER }

		private readonly IJwtService _jwtService;

        public async Task<User> CreateUser(DataContext c, UserCreateIngest user)
		{
			if (
				user.Username != null &&
				user.Password != null &&
				user.Email != null
				)
			{
				validateUserCreate(user);
			}
			else
			{
				throw new GenericError()
				{
					ErrorMessage = "The user object provided is invalid.",
					ErrorTitle = "Invalid User Object",
					ErrorType = "Validation Error",
					HttpStatusCode = 400
				};
			}

			var listOfTypes = new List<UserRoles>();
			foreach (var type in user.Types)
			{
				Enum.TryParse(typeof(UserRoles), type.ToUpper(), out var result);
				if (result != null)
				{
					listOfTypes.Add((UserRoles)result);
				}
			}

			var u = new User()
			{
				Email = user.Email,
				Username = user.Username,
				Password = HashingService.CreateHash(user.Password),
				Id = Guid.NewGuid().ToString(),
				Roles = listOfTypes,
				CreatedDate = DateTime.Now.ToUniversalTime(),

			};
			c.Users.Add(u);
			c.SaveChanges();

			return u;
		}

		public async Task<User> ValidateUserInfo(DataContext context, LoginIngest info)
		{
			var user = context.Users.Where(u => u.Email == info.Email && HashingService.CreateHash(info.Password) == u.Password).FirstOrDefault();
			if (user == null)
			{
				throw new GenericError()
				{
					ErrorMessage = "Email or password incorrect.",
					ErrorTitle = "Email of password incorrect",
					ErrorType = "Validation Error",
					HttpStatusCode = 400
				};
			}

			return user;

		}
		private bool validateUserCreate(UserCreateIngest user)
		{
			if (user.Username.Length < 4 || user.Username.Length > 50)
				throw new GenericError()
				{
					ErrorMessage = "Username must be between 4 and 50 characters in length.",
					ErrorTitle = "Username length is invalid",
					ErrorType = "Validation Error",
					HttpStatusCode = 400
				};

			var regex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");
			if (regex.Match(user.Password) == null)
				throw new GenericError()
				{
					ErrorMessage = "The password provided is invalid. The password should have at least 8 characters, one letter and one number.",
					ErrorTitle = "Password is invalid",
					ErrorType = "Validation Error",
					HttpStatusCode = 400
				};

			if (!user.Email.Contains("@"))
				throw new GenericError()
				{
					ErrorMessage = "The email provided is invalid. The email should contain an '@'",
					ErrorTitle = "Email is invalid",
					ErrorType = "Validation Error",
					HttpStatusCode = 400
				};

			return true;
		}
	}

}
