namespace EmailSender.Database.Models
{
    public class EmailModel
    {
        public int Id { get; set; }
        public string EmailTo {get; set;}
        public List<NotificationModel> Notification { get; set; }

    }
}
