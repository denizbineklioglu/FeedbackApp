using AutoMapper;
using FeedbackApp.DataTransferObjects.Requests;
using FeedbackApp.Domain;
using Microsoft.AspNetCore.Identity;

namespace FeedbackApp.Services.Services.Auth;

public class AuthService: IAuthService
{
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly SignInManager<User> _signInManager;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;


    public AuthService(IPasswordHasher<User> passwordHasher, SignInManager<User> signInManager,
       IMapper mapper, UserManager<User> userManager)
    {
        _passwordHasher = passwordHasher;
        _signInManager = signInManager;
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<bool> Register(UserRegisterRequest userRegisterRequest)
    {
        var checkUserByEmail = await checkUserExistsByEmail(userRegisterRequest.Email);
        if (checkUserByEmail) return false;
        var user = _mapper.Map<User>(userRegisterRequest);
        user.UserName = userRegisterRequest.Email;
        await _userManager.CreateAsync(user, userRegisterRequest.Password);
        await _signInManager.PasswordSignInAsync(user, userRegisterRequest.Password, true, false);
        return true;
    }

    public async Task<bool> Login(UserLoginRequest userLoginRequest)
    {
        var userToFind = await _userManager.FindByEmailAsync(userLoginRequest.Email);
        if (userToFind == null) return false;

        var checkPassword = verifyUserPassword(userToFind, userToFind.PasswordHash, userLoginRequest.Password);
        if (!checkPassword) return false;

        await _signInManager.PasswordSignInAsync(userToFind, userLoginRequest.Password, true, false);
        return true;
    }

    public async Task Logout()
    {
        await _signInManager.SignOutAsync();
    }

    private async Task<bool> checkUserExistsByEmail(string email)
    {
        var checkUserByEmail = await _userManager.FindByEmailAsync(email);
        return checkUserByEmail == null ? false : true;
    }

    private bool verifyUserPassword(User user, string hashedPassword, string providedPassword)
    {
        var verifyPassword = _passwordHasher.VerifyHashedPassword(user, hashedPassword, providedPassword);
        return verifyPassword == PasswordVerificationResult.Failed ? false : true;
    }

}


