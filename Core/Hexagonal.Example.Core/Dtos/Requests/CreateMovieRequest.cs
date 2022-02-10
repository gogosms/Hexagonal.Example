using MediatR;

namespace Hexagonal.Example.Core.Dtos.Requests
{
	public class CreateMovieRequest : IRequest<BaseResponseDto<bool>>
	{
		public string Name { get; set; }
		
		public double Rating { get; set; }
	}
}