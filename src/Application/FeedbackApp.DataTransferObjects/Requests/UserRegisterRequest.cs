using System;
namespace FeedbackApp.DataTransferObjects.Requests
{
	public class UserRegisterRequest
	{
        public string UserName { get; set; }    
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}

