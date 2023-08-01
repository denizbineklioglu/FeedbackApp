using FeedbackApp.Domain;
using FeedbackApp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace FeedbackApp.Infrastructure.Repositories.EntityFramework
{
    public class EFFeedBackRepository : EFRepositoryBase<FeedBack,FeedBackContext>,IFeedBackRepository
    {
        private readonly FeedBackContext _context;
        public EFFeedBackRepository(FeedBackContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FeedBack>> GetIncomingFeedbackLists(string email)
        {
            return await _context.FeedBacks.Where(f => f.ReceiverMail == email).ToListAsync();   
        }

        public async Task<IEnumerable<FeedBack>> GetSentFeedbackLists(string email)
        {
            return await _context.FeedBacks.Where(f => f.SenderMail == email).ToListAsync();             
        }
    }
}
