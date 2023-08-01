using System;
using FeedbackApp.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace FeedbackApp.Services.Services.AppUser;

public class UserService:IUserService
{
    private readonly UserManager<User> _userManager;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IConfiguration _configuration;

    public UserService(UserManager<User> userManager, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
    {
        _userManager = userManager;
        _httpContextAccessor = httpContextAccessor;
        _configuration = configuration;
    }

    public string GetSender()
    {
        return _configuration.GetSection("EmailConfiguration:Username").Value;
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        return await _userManager.FindByIdAsync(id.ToString());
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _userManager.FindByEmailAsync(email);
    }

    public async Task<bool> CreateAsync(User user, string password)
    {
        user.UserName = user.Email;
        user.SecurityStamp = Guid.NewGuid().ToString();
        var createResult = await _userManager.CreateAsync(user, password);
        return createResult.Succeeded;
    }
 
    public async Task<User?> GetCurrentUser()
    {
        var currentUser =await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User);
        return await GetByEmailAsync(currentUser.Email);
    }

}


