using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;
using SportApp.Application.Base;


namespace SportApp.Application.QueryHandlers.Weight
{
    public class GetUserWeightDetailQueryHandler : IRequestHandler<GetUserWeightQuery, Result<UserWeightDetail>>
    {
        public Task<Result<UserWeightDetail>> Handle(GetUserWeightQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

    public record GetUserWeightQuery(int id) : IRequest<Result<UserWeightDetail>>;

    public record UserWeightDetail();
}
