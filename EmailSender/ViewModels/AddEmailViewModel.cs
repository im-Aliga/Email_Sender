using EmailSender.Database.Models;

namespace EmailSender.ViewModels
{
    public class AddEmailViewModel
    {
        public string From { get; set; }
        public EmailModel To { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public bool Status { get; set; }



    }
}
