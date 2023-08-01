using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackApp.Services.Services.Constants
{
    public static class EmailMessages
    {

        public const string Title = "Bir yeni feedback aldınız";
        public const string Subject = "Bir yeni feedback aldınız";


        public static string GetFeedBackBody(string name)
        {
            return $"<p>Merhaba {name}</p><br><p>Bir yeni feedback aldınız.</p>";
        }

    }
}
