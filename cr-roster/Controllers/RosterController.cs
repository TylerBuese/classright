using Microsoft.AspNetCore.Mvc;

namespace cr_roster.Controllers
{
	[ApiController]
	[Route("")]
	public class RosterController : ControllerBase
	{
		[HttpGet()]
		public async Task<ActionResult<Object>> Get()
		{
			return Ok(new { result = "Ok!" });
		}
	}
}