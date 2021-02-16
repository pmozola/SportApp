using System.Threading;
using System.Threading.Tasks;

using MediatR;
using SportApp.Application.Base;
using SportApp.Domain;
using SportApp.Domain.Athlete.WeightAggregate;

namespace SportApp.Application.CommandHandlers
{
    public class AddWeightCommandHandler : IRequestHandler<AddWeightCommand, Result>
    {
        private readonly IWeightRepository repository;
        private readonly IUserContext userContext;
        private readonly IUnitOfWork unitOfWork;

        public AddWeightCommandHandler(IWeightRepository repository, IUserContext userContext, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.userContext = userContext;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(AddWeightCommand request, CancellationToken cancellationToken)
        {
            var entity = new Weight(
                userId: userContext.GetUserId(),
                value: request.Value);

            await repository.Add(entity);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }

    public record AddWeightCommand(double Value) : IRequest<Result>;
}
