using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;
using SportApp.Application.Base;


namespace SportApp.Application.Bahaviors
{
    public class ExceptionBehevior<TRequest, TResponse>
       : IPipelineBehavior<TRequest, Result<TResponse>>,  IPipelineBehavior<TRequest, Result>
    {
        public async Task<Result<TResponse>> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<Result<TResponse>> next)
        {

            try
            {
                return await next();
            }
            catch (Exception ex)
            {

                return Result<TResponse>.Error(ex);
            }
        }

        public async Task<Result> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<Result> next)
        {
            try
            {
                return await next();
            }
            catch (Exception ex)
            {

                return Result.Error(ex);
            }
        }
    }
}
