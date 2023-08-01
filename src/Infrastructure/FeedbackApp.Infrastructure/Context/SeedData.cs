using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FeedbackApp.Domain;

namespace FeedbackApp.Infrastructure.Context
{
    public class SeedData
    {
        public static async Task SeedDatabase(FeedBackContext context, IServiceProvider serviceProvider)
        {

            seedFeedBackIfNotExists(context);
        }

        private static void seedFeedBackIfNotExists(FeedBackContext context)
        {
            if (!context.FeedBacks.Any())
            {
                var feedBacks = new List<FeedBack>()
                {
                    new(){ Title="İşlerin yavaş yürütülmesi",
                           Description="İşler bazı sebeplerden dolayı yavaş ilerliyor",
                           Date= DateTime.Now,
                            ReceiverMail="deneme@gmail.com",
                              SenderMail="göndericideneme@gmail.com"
                    },
                      new(){ Title="İşlerin yavaş yürütülmesi 2",
                           Description="İşler bazı sebeplerden dolayı yavaş ilerliyor",
                           Date= DateTime.Now,
                            ReceiverMail="deneme@gmail.com",
                              SenderMail="göndericideneme@gmail.com"
                    },
                        new(){ Title="İşlerin yavaş yürütülmesi 3",
                           Description="İşler bazı sebeplerden dolayı yavaş ilerliyor",
                           Date= DateTime.Now,
                            ReceiverMail="deneme@gmail.com",
                              SenderMail="göndericideneme@gmail.com"
                    },
                        new(){ Title="İşlerin yavaş yürütülmesi 4",
                           Description="İşler bazı sebeplerden dolayı yavaş ilerliyor",
                           Date= DateTime.Now,
                            ReceiverMail="deneme@gmail.com",
                              SenderMail="göndericideneme@gmail.com"
                    }


                };
                context.FeedBacks.AddRange(feedBacks);
                context.SaveChanges();
            }
        }
    }
}
