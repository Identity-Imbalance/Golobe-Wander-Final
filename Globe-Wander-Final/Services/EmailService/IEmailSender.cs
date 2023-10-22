namespace Globe_Wander_Final.Services.EmailService
{
    public interface IEmailSender
    {
        Task SendEmail(string email ,  string subject  );
    }
}
