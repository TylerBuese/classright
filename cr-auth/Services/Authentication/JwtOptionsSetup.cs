using Microsoft.Extensions.Options;

namespace cr_auth.Services.Authentication
{
	public class JwtOptionsSetup : IConfigureOptions<JwtOptions>
	{
		private const String SectionName = "Jwt";
		private readonly IConfiguration _configuration;

        public JwtOptionsSetup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void Configure(JwtOptions options)
		{
			_configuration.GetSection(SectionName).Bind(options);
		}
	}

}
