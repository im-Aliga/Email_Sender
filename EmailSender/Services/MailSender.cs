using EmailSender.Services.Abstract;
using MailKit.Net.Smtp;
using MimeKit;


namespace EmailSender.Services
{
    public class MailSender:IEmailSender
    {
        private readonly EmailConfiguration _emailconfig;
        public MailSender(EmailConfiguration emailconfig)
        {
            _emailconfig = emailconfig;
        }
        public void SendEmail(Message message)
        {
            var emailMessage = CreateEmailMessage(message);
            Send(emailMessage);
        }
        private MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_emailconfig.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject=message.Subject;
            emailMessage.Body=new TextPart(MimeKit.Text.TextFormat.Text) { Text=message.Content };
            return emailMessage;
        }
        private void Send(MimeMessage mailMessage)
        {
            using(var client=new SmtpClient())
            {
                try
                {
                    client.Connect(_emailconfig.SmtpServer, _emailconfig.Port,true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(_emailconfig.UserName,_emailconfig.Password);
                    client.Send(mailMessage);
                }
                catch 
                {

                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }
    }
}
