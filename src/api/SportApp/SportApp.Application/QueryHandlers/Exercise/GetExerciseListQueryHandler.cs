using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SportApp.Application.Base;
using SportApp.Infrastructure;

namespace SportApp.Application.QueryHandlers.Exercise
{
    public class GetExerciseListQueryHandler : IRequestHandler<GetExerciseListQuery, Result<ExerciseInfo[]>>
    {
        private readonly SportAppDbContext _dbContext;

        public GetExerciseListQueryHandler(SportAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result<ExerciseInfo[]>> Handle(GetExerciseListQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext
                .Excercises
                .Select(x => new ExerciseInfo(x.Id, x.Name, x.TumbnailUrl))
                .ToArrayAsync();

            return Result<ExerciseInfo[]>.Success(result);
        }
    }

    public record GetExerciseListQuery() : IRequest<Result<ExerciseInfo[]>>;

    public record ExerciseInfo(int Id, string Name, string thumbnail);
}
