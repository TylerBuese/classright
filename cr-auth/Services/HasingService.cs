using System.Security.Cryptography;
using System.Text;

namespace cr_auth.Services
{
	public class HashingService
	{
		/// <summary>
		/// Creates a SHA256 hash of a string
		/// </summary>
		/// <returns>String</returns>
		///
		public static string CreateHash(string unhashedString)
		{
			StringBuilder sb = new();

			using (SHA256 sha256 = SHA256.Create())
			{
				Encoding e = Encoding.UTF8;
				Byte[] result = sha256.ComputeHash(e.GetBytes(unhashedString));
				foreach (Byte b in result)
				{
					sb.Append(b.ToString("x2"));
				}

				return sb.ToString();
			}
		}
	}
}
