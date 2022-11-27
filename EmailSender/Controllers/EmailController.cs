using EmailSender.Database.Contexts;
using EmailSender.Services;
using EmailSender.Services.Abstract;
using EmailSender.ViewModels;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

namespace EmailSender.Controllers
{
    public class EmailController : Controller
    {
        private readonly IEmailSender _emailSender;
        private readonly DataContext _dataContext;

        public EmailController(IEmailSender emailSender, DataContext dataContext)
        {
            _emailSender = emailSender;
            _dataContext = dataContext;
        }



        [HttpGet]
        public IActionResult List()
        {
            var model = _dataContext.DBNotification
                .Select(e => new ListEmailViewModel($"{e.EmailModel.EmailTo}", e.From, e.Title, e.Content))
                .ToList();

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add([FromForm] AddEmailViewModel model)
        {
          
            var email = new Database.Models.NotificationModel()
            {
                From = model.From,
                Title = model.Title,
                Content = model.Content,
                EmailModel = model.To

            };

            List<string> emailTo = new List<string>();
            if (model.Status == false)
            {
                var emails = email.EmailModel.EmailTo.Trim().Split(",");
                foreach (var mail in emails)
                {
                    emailTo.Add(mail);

                }

            }
            else if(model.Status == true)
            {
                emailTo.Add(email.EmailModel.EmailTo);
            }

            var message = new Message(emailTo, email.Title, email.Content);
            _emailSender.SendEmail(message);
            _dataContext.DBNotification.Add(email);
            _dataContext.DBEmail.Add(email.EmailModel);
            _dataContext.SaveChanges();
            return RedirectToAction(nameof(List));
        }


       
    }
}
