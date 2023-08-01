﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FeedbackApp.DataTransferObjects.Requests
{
    public class UpdateFeedBackRequest
    {
        public int FeedBackID { get; set; }

        [Display(Name = "Başlık")]
        public string Title { get; set; }

        [Display(Name = "İleti")]
        public string Description { get; set; }

        [Display(Name = "Alıcı Mail")]
        public string ReceiverMail { get; set; }

        public string SenderMail { get; set; }
    }
}
