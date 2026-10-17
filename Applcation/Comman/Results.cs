using Domain.Enums;

namespace Applcation.Comman
{
    public class Result
    {
        public bool IsSuccess { get;  }
        public string Message { get;  }
        public IReadOnlyList<string> Errors { get; } 

        public ErrorType ErrorType { get; set; }

        protected Result(bool succes, string Message, ErrorType errorsType, IEnumerable<string>? errors = null)
        {
           IsSuccess = succes;
           Message = Message;
           Errors = (errors ?? Enumerable.Empty<string>()).ToArray();
           ErrorType = errorsType;
        }

        public static Result Success(string massege = "Success")
        {
            return new Result
                (
              true,
              massege,
             ErrorType.None
                );

        }

        public static  Result      Failure( ErrorType errorType,string Massage = "fauiler",IEnumerable<string>? error = null  )
        {
            if (errorType == ErrorType.None)
            {
                throw new ArgumentException("ErrorType cannot be None for a failure result.", nameof(errorType));
            }
            return new Result
            (
                false,
                 Massage,
                errorType,
                error
                   

            );
        }
    }
}
