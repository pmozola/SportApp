using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using MediatR;
using Microsoft.EntityFrameworkCore;
using SportApp.Application.Base;
using SportApp.Infrastructure;

namespace SportApp.Application.QueryHandlers.Exercise
{
    public class GetExerciseQueryHandler : IRequestHandler<GetExerciseQuery, Result<ExerciseDetail>>
    {
        private readonly SportAppDbContext _dbContext;

        public GetExerciseQueryHandler(SportAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result<ExerciseDetail>> Handle(GetExerciseQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext
                 .Excercises
                 .Where(x => x.Id == request.id)
                 .Select(x => new ExerciseDetail(x.Id, x.Name, x.Description, x.VideoUrl.Url))
                 .FirstOrDefaultAsync();

            return Result<ExerciseDetail>.Success(result); ;
        }
    }

    public record GetExerciseQuery(int id): IRequest<Result<ExerciseDetail>>;

    public record ExerciseDetail(int Id, string Name, string Description, string VideoUrl);
}
