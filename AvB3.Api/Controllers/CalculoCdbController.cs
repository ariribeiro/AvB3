using AvB3.Service.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AvB3.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class CalculoCdbController : ControllerBase
	{
		[HttpPost]
		public async Task<IActionResult> Post(
				[FromServices] IMediator mediator,
				[FromBody] CalculoCdbCommand command
			)
		{
			var result = await mediator.Send(command);
			return Ok(result);
		}
	}
}
