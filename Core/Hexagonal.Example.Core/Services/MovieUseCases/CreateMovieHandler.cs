using System;
using System.Threading;
using System.Threading.Tasks;
using Hexagonal.Example.Core.Dtos;
using Hexagonal.Example.Core.Dtos.Requests;
using Hexagonal.Example.Core.Interfaces;
using Hexagonal.Example.Core.Models;
using MediatR;

namespace Hexagonal.Example.Core.Services.MovieUseCases
{
	public class CreateMovieHandler : IRequestHandler<CreateMovieRequest, BaseResponseDto<bool>>
	{
		private readonly IRepository<Movie> _repository;

		public CreateMovieHandler(IRepository<Movie> repository)
		{
			_repository = repository;
		}

		public async Task<BaseResponseDto<bool>> Handle(CreateMovieRequest request, CancellationToken cancellationToken)
		{
			var response = new BaseResponseDto<bool>();

			try
			{
				var movie = new Movie
				{
					Name = request.Name,
					Rating = request.Rating,
					IsDeleted = false,
					CreatedAt = DateTime.Now
				};

				await _repository.Add(movie);

				response.Data = true;
			}
			catch (Exception)
			{
				response.Errors.Add("An error occurred while creating the movie.");
			}

			return response;
		}
	}
}
