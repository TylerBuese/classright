using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace cr_quiz.Controllers
{
	[ApiController]
	[Route("")]
	[EnableCors("Cors")]
	public class TemplateController : ControllerBase
	{
		[Authorize(Roles = "put,case,sensitive,roles,here")]
		[HttpGet()]
		public async Task<ActionResult<Object>> Get()
		{
			return Ok(new { result = "Ok!" });
		}
	}
}