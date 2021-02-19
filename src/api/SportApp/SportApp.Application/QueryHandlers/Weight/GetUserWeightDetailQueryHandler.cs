using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using MediatR;
using Microsoft.EntityFrameworkCore;
using SportApp.Application.Base;
using SportApp.Domain.Services;
using SportApp.Infrastructure;

namespace SportApp.Application.QueryHandlers.Weight
{
    public class GetUserWeightDetailQueryHandler : IRequestHandler<GetUserWeightQuery, Result<UserWeightDetail>>
    {
        private readonly SportAppDbContext dbContext;
        private readonly IBMIConverter bmiConverter;
        private readonly IUserContext userContext;

        public GetUserWeightDetailQueryHandler(SportAppDbContext dbContext, IBMIConverter bmiConverter, IUserContext userContext)
        {
            this.dbContext = dbContext;
            this.bmiConverter = bmiConverter;
            this.userContext = userContext;
        }
        public async Task<Result<UserWeightDetail>> Handle(GetUserWeightQuery request, CancellationToken cancellationToken)
        {
            var weights = await dbContext.AthleteWeights
                .Where(x => x.UserId == userContext.GetUserId())
                .OrderByDescending(x => x.Date)
                .Take(2)
                .ToArrayAsync();

            if (!weights.Any())
            {
                return Result<UserWeightDetail>.Success(null);
            }

            var userWeightDetail = new UserWeightDetail(
                weights.First().Value,
                weights.ElementAtOrDefault(1).Value,
                bmiConverter.Convert(weights.First().Value, 180));


            return Result<UserWeightDetail>.Success(userWeightDetail);
        }
    }

    public record GetUserWeightQuery(int id) : IRequest<Result<UserWeightDetail>>;

    public record UserWeightDetail(double CurrentWeight, double LastWeight, double BMI);
}
