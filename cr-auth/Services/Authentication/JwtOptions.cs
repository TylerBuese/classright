namespace cr_auth.Services.Authentication
{
	public class JwtOptions
	{
		public String Issuer { get; init;}
		public String Audience { get; init;	}
		public String SecretKey { get; init; }
	}
}
