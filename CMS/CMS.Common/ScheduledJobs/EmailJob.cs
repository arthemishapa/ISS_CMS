using CMS.CMS.Common.ViewModels;
using CMS.CMS.DAL.Entities;
using CMS.CMS.DAL.Repository;
using Quartz;
using System;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CMS.CMS.Common.ScheduledJobs
{
    public class EmailJob : IJob
    {
        #region Variables
        
        private IConferenceRepository ConferenceRepository
        {
            get
            {
                return DependencyResolver.Current.GetService<IConferenceRepository>();
            }
        }
        

        private ISubmissionRepository SubmissionRepository
        {
            get
            {
                return DependencyResolver.Current.GetService<ISubmissionRepository>();
            }
        }
        

        #endregion Variables

        Task IJob.Execute(IJobExecutionContext context)
        {
            foreach (var conference in ConferenceRepository.GetAll())
            {
                DateTime today = DateTime.Now;
                if (conference.BiddingDeadline < today && conference.EndDate > today)
                {
                    SendSessionNotification(conference);
                    SendPaperApprovalNotification(conference);
                }
            }

            return Task.CompletedTask;
        }

        #region Helper methods
        
        private void SendSessionNotification(Conference conference)
        {
            var chair = conference.Chair;

            string mailTo = chair.Email;
            string subject = "Session configuration";
            dynamic model = new ExpandoObject();
            model.EmailNotification = new EmailNotificationViewModel()
            { Title = "Reminder to set the conference sessions",
              Content = "Your coneference " + conference.Name + "has passed the review time, sessions must be added!" +
              "Please ignore this email if you already have.",
              CallBack = "",
              User = chair.Name };

            var body = EmailTemplateRenderer.RenderEmailTemplate("EmailNotification", model);
            EmailHelper.SendEmail(mailTo, subject, body);
        }

        private void SendPaperApprovalNotification(Conference conference)
        {
            foreach (var submission in SubmissionRepository.GetAll().Where(s => s.ConferenceId == conference.Id))
            {
                var author = submission.Author;
                string mailTo = author.Email;
                string subject = "Paper review results";
                dynamic model = new ExpandoObject();
                model.EmailNotification = new EmailNotificationViewModel()
                { Title = "Results for " + submission.Title,
                  Content = submission.Mark >= 3 ? "Congratulations, your paper has been accepted" :
                  "We are sorry to inform you but your paper didn't meet our requirements, see you next time!",
                  CallBack = "",
                  User = author.Name };

                var body = EmailTemplateRenderer.RenderEmailTemplate("EmailNotification", model);
                EmailHelper.SendEmail(mailTo, subject, body);
            }
        }

        #endregion Helper methods
    }
}