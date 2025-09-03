namespace CognifyAPI.Interfaces
{
    public interface IEmailRepository
    {
        Task SendEmail(string toEmail, string subject, string body);
    }
}
