using System.ComponentModel.DataAnnotations;

namespace FeedbackApp.DataTransferObjects.Requests;

    public class CreateFeedBackRequest
    {
        [Display(Name = "Başlık")]
        public string Title { get; set; }

        [Display(Name = "İleti")]
        public string Description { get; set; }

        [Display(Name = "Alıcı Mail")]
        public string ReceiverMail { get; set; }

        public string SenderMail { get; set; } 
    }

