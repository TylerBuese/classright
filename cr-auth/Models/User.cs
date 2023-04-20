using cr_auth.Services;

namespace cr_auth.Models
{
	public class User : Times
	{
		public String Id { get; set;}
		public String Email { get; set;}
		public String Username { get; set;}
		public String Password { get; set;}
		public virtual List<UserService.UserRoles> Roles { get; set;}
		
	}
}
