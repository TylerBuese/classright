using cr_auth.Models;

namespace cr_auth.Abstractions
{
	public interface IJwtProvider
	{
		string Generate(User user);
	}
}
