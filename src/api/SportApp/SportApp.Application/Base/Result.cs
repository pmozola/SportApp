using System;

namespace SportApp.Application.Base
{
    public class Result : IFailedResult
    {
        public bool IsSuccessful { get; }
        public Exception Exception { get; }

        private protected Result()
        {
            IsSuccessful = true;
        }

        private protected Result(Exception error)
        {
            IsSuccessful = false;
            Exception = error;
        }

        public TResult Match<TResult>(Func<TResult> success, Func<Exception, TResult> error)
            => IsSuccessful ? success() : error(Exception);

        public void Match(Action success, Action error)
        {
            if (IsSuccessful) success();
            else error();
        }

        public static Result Success() => new();
        public static Result Error(Exception error) => new(error);
    }

    public interface IFailedResult
    {
    }
}
