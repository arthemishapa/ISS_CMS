using CMS.CMS.Common.ViewModels;
using Quartz;
using System.Dynamic;
using System.Threading.Tasks;

namespace CMS.CMS.Common.ScheduledJobs
{
    public class EmailJob : IJob
    {
        // TODO implement the notification scenarios
        Task IJob.Execute(IJobExecutionContext context)
        {
            string mailTo = "some@mail.com";
            string subject = "This is a test";
            dynamic model = new ExpandoObject();
            model.EmailNotification = new EmailNotificationViewModel() { Title = "Test email", Content = "test", CallBack = "", User="Test" };

            var body = EmailTemplateRenderer.RenderEmailTemplate("EmailNotification", model);
            return EmailHelper.SendEmail(mailTo, subject, body);
        }
    }
}