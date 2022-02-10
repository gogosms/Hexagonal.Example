using System.Collections.Generic;
using MediatR;

namespace Hexagonal.Example.Core.Dtos.Requests
{
	public class GetBestMoviesForKidsRequest : IRequest<BaseResponseDto<List<MovieDto>>>
	{
	}
}
