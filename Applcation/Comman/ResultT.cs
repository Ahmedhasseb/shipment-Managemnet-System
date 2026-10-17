using Domain.Enums;

namespace Applcation.Comman
{
    public class Result<T> : Result
    {
        public T? Data { get; private set; }

        private Result(bool IsSuccess, string Massage, ErrorType errorType,T? Dataa = default, IEnumerable<string>? Errors = null) : base(IsSuccess, Massage, errorType, Errors)
        {
            Data = Dataa;
        }

        public static Result<T> Success(T data, string Message = "Success")
        {
            return new Result<T>
                (
                true,
                Message,
                ErrorType.None,
                data
                );
        }

        public new   static Result<T> Failure(string Message, ErrorType errorType, IEnumerable<string>? errors = null)
        {
            if (errorType == ErrorType.None)
            {
                throw new ArgumentException("ErrorType cannot be None for a failure result.");
            }   
            return new Result<T>
                (
                false,
                Message,
                errorType,
                default,
                errors
                );
        }
    }
}
