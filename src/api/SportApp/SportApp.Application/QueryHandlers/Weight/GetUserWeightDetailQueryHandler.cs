using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using MediatR;
using Microsoft.EntityFrameworkCore;
using SportApp.Application.Base;
using SportApp.Domain.BaseObjects;
using SportApp.Infrastructure;

namespace SportApp.Application.QueryHandlers.Weight
{
    public class GetUserWeightDetailQueryHandler : IRequestHandler<GetUserWeightQuery, Result<UserWeightDetail>>
    {
        private readonly SportAppDbContext dbContext;
        private readonly IUserContext userContext;

        public GetUserWeightDetailQueryHandler(SportAppDbContext dbContext, IUserContext userContext)
        {
            this.dbContext = dbContext;
            this.userContext = userContext;
        }
        public async Task<Result<UserWeightDetail>> Handle(GetUserWeightQuery request, CancellationToken cancellationToken)
        {
            var weight = await dbContext.AthleteWeights
                .Where(x => x.UserId == userContext.GetUserId())
                .OrderByDescending(x => x.Date)
                .FirstOrDefaultAsync(cancellationToken);

            return weight == null ? 
                Result<UserWeightDetail>.Error(new NotFoundException()) :
                Result<UserWeightDetail>.Success(new UserWeightDetail(weight.Value));
        }
    }

    public record GetUserWeightQuery() : IRequest<Result<UserWeightDetail>>;

    public record UserWeightDetail(double CurrentWeight);
}
