using EmailSender.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace EmailSender.Database.Contexts
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions options)
            : base(options)
        {

        }


        public DbSet<EmailModel> DBEmail { get; set; }
        public DbSet<NotificationModel> DBNotification { get; set; }
    }
}
