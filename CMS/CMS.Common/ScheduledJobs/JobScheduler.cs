using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.CMS.Common.ScheduledJobs
{
    public class JobScheduler
    {
        public static async void StartAsync()
        {
            ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
            IScheduler scheduler = await schedulerFactory.GetScheduler();
            await scheduler.Start();

            IJobDetail job = JobBuilder.Create<EmailJob>().Build();

            ITrigger trigger = TriggerBuilder.Create()
                .StartNow()
                .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(18, 13))
                .Build();

            await scheduler.ScheduleJob(job, trigger);
        }
    }
}