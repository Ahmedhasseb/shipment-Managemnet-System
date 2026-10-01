namespace Applcation.Interface.Iservice
{
    public interface IEmailService
    {
        public Task SendEmailAsync(string TO, string Subject, string body);
    }
}
