namespace EmailSender.Services.Abstract
{
    public interface  IEmailSender
    {
        void SendEmail(Message message);
    }
}
