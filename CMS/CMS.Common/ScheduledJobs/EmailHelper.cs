using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace CMS.CMS.Common.ScheduledJobs
{
    public class EmailHelper
    {
        public static async Task SendEmail(string toEmailAddress, string subject, string body)
        {
            var message = new MailMessage();
            message.To.Add(new MailAddress(toEmailAddress));
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = true;
            message.BodyEncoding = System.Text.Encoding.GetEncoding("utf-8");

            var plainView =
                    AlternateView.CreateAlternateViewFromString(Regex.Replace(body, "<(.|\n)*?>", string.Empty),
                        null, "text/plain");
            var htmlView = AlternateView.CreateAlternateViewFromString(body, null, "text/html");
            Regex.Replace(body, @"(?<!\t)((?<!\r)(?=\n)|(?=\r\n))", "\t", RegexOptions.Multiline);

            message.AlternateViews.Add(plainView);
            message.AlternateViews.Add(htmlView);
            using (var smtp = new SmtpClient())
            {
                await smtp.SendMailAsync(message);
            }
        }
    }
}