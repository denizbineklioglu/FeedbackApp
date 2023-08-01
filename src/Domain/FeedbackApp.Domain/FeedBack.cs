using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackApp.Domain
{
    public class FeedBack : IEntity
    {
        public int FeedBackID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string ReceiverMail { get; set; }

        /*
            Alıcı gönderen maili görmeyecek ama 
            gönderen kişinin gönderdiği feedbackleri görmesi için
            bir ekran yaparsak diye bu prop'u tanımladım
         */
        public string SenderMail { get; set; }
    }
}
