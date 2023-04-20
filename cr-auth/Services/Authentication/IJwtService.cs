using cr_auth.Models;

namespace cr_auth.Services.Authentication
{
	public interface IJwtService
	{
		string GenerateToken(User user);
	}
}