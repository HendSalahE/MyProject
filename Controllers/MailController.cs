using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Templet.BLL.Models;
using System.Net;
using System.Net.Mail;

namespace Templet.Controllers
{
    public class MailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMail(MailVM mail)
        {
            using (var smtp = new SmtpClient("smtp.gmail.com", 587))
            {
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("elgendya160@gmail.com","@@@AAA321_321");
                smtp.Send("elgendya160@gmail.com", "hendsalah1658@yahoo.com", mail.Title, mail.Message);

            }
                return RedirectToAction("Index");
        }
    }
}
