using MimeKit;
using System.Linq;

namespace EmailSender.Services
{
    public class Message
    {
        public List<MailboxAddress> To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        public Message(List<string> to,string subject,string content)
        {
            To=new List<MailboxAddress>();
            To.AddRange(to.Select(x => new MailboxAddress(string.Empty,x.ToString())));
            Subject=subject;
            Content=content;
        }

    }
}
