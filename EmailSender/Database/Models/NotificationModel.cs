namespace EmailSender.Database.Models
{
    public class NotificationModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string From { get; set; }
        
        public EmailModel EmailModel { get; set; }






    }
}
