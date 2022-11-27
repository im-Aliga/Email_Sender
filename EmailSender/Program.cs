using EmailSender.Database.Contexts;
using EmailSender.Services;
using EmailSender.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using NETCore.MailKit.Core;

namespace EmailSender
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Native DI desing pattern (IoC container)

            // 1. IoC priciple => to avoid tightly coupled codes
            // 2. Autho dispose
            // 3. Performance 
            // Lifetime of object

            var emailConfig = builder.Configuration.GetSection("EmailConfiguration")
                 .Get < EmailConfiguration >();
            builder.Services.AddSingleton(emailConfig);
            builder.Services.AddScoped<IEmailSender, MailSender>();

            builder.Services
                .AddDbContext<DataContext>(o =>
                {
                    o.UseSqlServer("Server=DESKTOP-J810F6D;Database=DataEmail;Trusted_Connection=True;TrustServerCertificate=True;");
                }, ServiceLifetime.Transient)
                //.AddScoped<IEmailService, SMTP>()
                //.AddScoped<IEmployeeService, EmployeeService>()
                .AddMvc()
                .AddRazorRuntimeCompilation();


            var app = builder.Build();

            app.UseStaticFiles();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=employee}/{action=list}");

            app.Run();
        }
    }
}