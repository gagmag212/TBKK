using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HelpDesk.Pages
{
    public class ProcessRequestModel : PageModel
    {
        public void OnGet()
        {
            MailMessage myMail = new MailMessage("thanakritinw@gmail.com","thanakritinw@gmail.com");


            myMail.Subject = "My Subject";

         
        
            myMail.Body = "My Body & Description";

            

            var smtpClient = new SmtpClient("smtp.gmail.com",465);

            smtpClient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "thanainw@gmail.com",
                Password = "thanakrit2540"
            };

           
            smtpClient.EnableSsl = true;

            smtpClient.Send(myMail);

            smtpClient.Dispose();
            myMail.Dispose();


        }
    }
}