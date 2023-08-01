using AutoMapper;
using FeedbackApp.DataTransferObjects.Requests;
using FeedbackApp.DataTransferObjects.Responses;
using FeedbackApp.Domain;
using FeedbackApp.Infrastructure.Repositories;
using FeedbackApp.Services.Services.AppUser;

namespace FeedbackApp.Services.Services.Feedback
{
    public class FeedBackService : IFeedBackService
    {
        private readonly IFeedBackRepository _feedBackRepo;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public FeedBackService(IFeedBackRepository feedBackRepo, IMapper mapper, IUserService userService)
        {
            _feedBackRepo = feedBackRepo;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task CreateFeedBack(CreateFeedBackRequest model)
        {
            var feedback = _mapper.Map<FeedBack>(model);
            await _feedBackRepo.AddAsync(feedback);
        }

        public async Task DeleteFeedBack(FeedBack entity)
        {
            await _feedBackRepo.DeleteAsync(entity);
        }

        public async Task<FeedBack?> GetFeedbackById(int id)
        {
            return await _feedBackRepo.GetAsync(id);
        }

        public async Task<IEnumerable<FeedBackListResponse>> GetIncomingFeedback()
        {
            var currenUser = await _userService.GetCurrentUser();
            if (currenUser == null)
            {
                return null;
            }
            var feedbacks = await _feedBackRepo.GetIncomingFeedbackLists(currenUser.Email);
            return _mapper.Map<IEnumerable<FeedBackListResponse>>(feedbacks);
        }

        public async Task<IEnumerable<FeedBackListResponse>> GetSentFeedbacks()
        {
            var currenUser = await _userService.GetCurrentUser();
            if (currenUser == null)
            {
                return null;
            }
            var feedbacks = await _feedBackRepo.GetSentFeedbackLists(currenUser.Email);

            return _mapper.Map<IEnumerable<FeedBackListResponse>>(feedbacks);
        }

        public async Task UpdateFeedBack(UpdateFeedBackRequest model)
        {
            var feedback = _mapper.Map<FeedBack>(model);
            await _feedBackRepo.UpdateAsync(feedback);
        }
    }
}
