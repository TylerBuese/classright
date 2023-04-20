namespace cr_template.Models
{
	public class GenericError : Exception
	{
		public String ErrorMessage { get; set; }
		public int? HttpStatusCode { get; set; }
		public String? ErrorTitle { get; set; }
		public String? ErrorType { get; set; }
	}
}
