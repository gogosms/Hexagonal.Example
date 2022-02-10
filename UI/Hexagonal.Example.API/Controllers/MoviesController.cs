using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hexagonal.Example.Core.Dtos;
using Hexagonal.Example.Core.Dtos.Requests;
using MediatR;

namespace Hexagonal.Example.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MoviesController : ControllerBase
	{
		private readonly IMediator _mediator;

		public MoviesController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		public async Task<ActionResult<string>> CreateMovieAsync([FromBody] CreateMovieRequest createMovieRequest)
		{
			
			var createResponse = await _mediator.Send(createMovieRequest);

			if (createResponse.Data)
			{
				return Created("...", null);
			}

			return BadRequest(createResponse.Errors);
		}

		[HttpGet("kids")]
		public async Task<ActionResult<List<MovieDto>>> GetBestMoviesForKidsAsync()
		{
			var createResponse = await _mediator.Send(new CreateMovieRequest(){Name = "Sueños de Libertad", Rating = 100});
			var response = await _mediator.Send(new GetBestMoviesForKidsRequest());

			if (!response.HasError)
			{
				return Ok(response.Data);
			}

			return BadRequest(response.Errors);
		}
	}
}
