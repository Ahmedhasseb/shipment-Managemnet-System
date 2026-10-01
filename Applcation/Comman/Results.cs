namespace Applcation.Comman
{
    public class Results
    {
        public bool IsSuccess { get; protected set; }
        public string Message { get; protected set; }
        public List<string> Errors { get; protected set; } = new();

        public Results(bool succes, string Message, List<string>? Errors = null)
        {
            this.IsSuccess = succes;
            this.Message = Message;
            this.Errors = Errors ?? new List<string>();

        }

        public static Results Success(string massege = "Success")
        {
            return new Results
                (
              true,
              massege
                );

        }

        public static Results Failure(string Massage = "fauiler", List<string>? Errors = null)
        {
            return new Results
            (
                false,
                 Massage,
                 Errors

            );
        }
    }
}
