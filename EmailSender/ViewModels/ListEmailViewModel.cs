namespace EmailSender.ViewModels
{
    public class ListEmailViewModel
    {
        public string To { get; set; }
        public string From { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public ListEmailViewModel(string to, string from, string title, string content)
        {
            To= to;
            From= from;
            Title= title;
            Content= content;


        }
    }
}
