using System;
using FeedbackApp.Domain;

namespace FeedbackApp.Services.Services.AppUser
{
	public interface IUserService
	{
        Task<User?> GetByIdAsync(int id);
        Task<User?> GetByEmailAsync(string email);
        Task<bool> CreateAsync(User user, string password);
        Task<User?> GetCurrentUser();

    }
}

