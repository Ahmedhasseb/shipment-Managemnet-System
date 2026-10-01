namespace Applcation.Comman
{
    public class ResultT<T> : Results
    {
        public T? Data { get; private set; }

        private ResultT(bool IsSuccess, string Massage, T? Dataa = default, List<string>? Errors = null) : base(IsSuccess, Massage, Errors)
        {
            Data = Dataa;
        }

        public static ResultT<T> Success(T data, string Message = "Success")
        {
            return new ResultT<T>
                (
                true,
                Message,
                data
                );
        }

        public static ResultT<T> Failure(string Message, List<string>? errors = null)
        {
            return new ResultT<T>
                (
                false,
                Message,
                default,
                errors
                );
        }
    }
}
