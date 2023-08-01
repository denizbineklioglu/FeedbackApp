using FeedbackApp.DataTransferObjects.Requests;
using FeedbackApp.DataTransferObjects.Responses;
using FeedbackApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackApp.Services.Services.Feedback
{
    public interface IFeedBackService
    {
        Task CreateFeedBack(CreateFeedBackRequest model);
        Task DeleteFeedBack(FeedBack entity);
        Task UpdateFeedBack(UpdateFeedBackRequest model);
        Task<FeedBack?> GetFeedbackById(int id);

        Task<IEnumerable<FeedBackListResponse>> GetSentFeedbacks();
        Task<IEnumerable<FeedBackListResponse>> GetIncomingFeedback();
    }
}
