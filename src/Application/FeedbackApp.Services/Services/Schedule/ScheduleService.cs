using FeedbackApp.Services.Services.Email;
using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackApp.Services.Services.Schedule
{
    public class ScheduleService
    {
        public static void ScheduleSendFeedBackEmail(string email, string name)
        {
            BackgroundJob.Schedule<IMailService>(x => x.SendFeedBackEmail(name, email), TimeSpan.FromMinutes(1));
        }
    }
}
