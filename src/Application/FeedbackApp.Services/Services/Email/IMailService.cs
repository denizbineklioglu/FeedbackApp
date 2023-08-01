using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackApp.Services.Services.Email
{
    public interface IMailService
    {
        Task SendFeedBackEmail(string nickname, string email);
    }
}
