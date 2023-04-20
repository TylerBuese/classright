using Microsoft.AspNetCore.Mvc;

namespace cr_quizer.Controllers
{
	[ApiController]
	[Route("")]
	public class QuizController : ControllerBase
	{

		[HttpGet()]
		public async Task<ActionResult<Object>> Get()
		{
			return new {result = "Ok"};
		}
	}
}