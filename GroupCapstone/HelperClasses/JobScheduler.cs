using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz;
using Quartz.Impl;
using System.Threading.Tasks;
namespace GroupCapstone.HelperClasses
{
    public class JobScheduler
    {
        public static void Start()
        {
            IJobDetail weatherConnectionJob = JobBuilder.Create<WeatherConnectionJob>()
                .WithIdentity("job1")
                .Build();
            ITrigger trigger = TriggerBuilder.Create()
                .WithDailyTimeIntervalSchedule
                (s =>
                    s.WithIntervalInSeconds(30)
                    .OnEveryDay()
                    )
                    .ForJob(weatherConnectionJob)
                    .WithIdentity("trigger1")
                    .StartNow()
                    .WithCronSchedule("0 0/1 * * * ?")
                    .Build();
            ISchedulerFactory sf = new StdSchedulerFactory();
            IScheduler sc = sf.GetScheduler();
            sc.ScheduleJob(weatherConnectionJob, trigger);
            sc.Start();
        }
    }
}