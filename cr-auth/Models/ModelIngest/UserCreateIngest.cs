namespace cr_auth.Models.ModelIngest
{
	public class UserCreateIngest
	{
		public String Username { get; set; }
		public String Password { get; set; }
		public String Email { get; set; }
		public List<String> Types { get; set; }
	}
}
