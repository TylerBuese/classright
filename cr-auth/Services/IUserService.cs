using cr_auth.Data;
using cr_auth.Models;
using cr_auth.Models.ModelIngest;
using cr_auth.Services.Authentication;

namespace cr_auth.Services
{
	public interface IUserService
	{
		Task<User> CreateUser(DataContext c, UserCreateIngest user);
		Task<User> ValidateUserInfo(DataContext context, LoginIngest info);
	}
}