using System.Threading;
using System.Threading.Tasks;

using MediatR;
using SportApp.Application.Base;

namespace SportApp.Application.CommandHandlers
{
    public class AddWeightCommandHandler : IRequestHandler<AddWeightCommand, Result<int>>
    {
        public Task<Result<int>> Handle(AddWeightCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(Result<int>.Success(1));
        }
    }

    public class AddWeightCommand : IRequest<Result<int>>
    {
    }
}
