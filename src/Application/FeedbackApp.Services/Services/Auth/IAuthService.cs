using System;
using FeedbackApp.DataTransferObjects.Requests;

namespace FeedbackApp.Services.Services.Auth;
public interface IAuthService
{
    Task<bool> Register(UserRegisterRequest userRegisterRequest);
    Task<bool> Login(UserLoginRequest userLoginRequest);
    Task Logout();
}


