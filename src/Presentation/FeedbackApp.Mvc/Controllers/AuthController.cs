using FeedbackApp.DataTransferObjects.Requests;
using FeedbackApp.Domain;
using FeedbackApp.Services.Services.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FeedbackApp.Mvc.Controllers;

public class AuthController : Controller
{
    private readonly IAuthService _authService;
    private readonly SignInManager<User> _signInManager;

    public AuthController(IAuthService authService, SignInManager<User> signInManager)
    {
        _authService = authService;
        _signInManager = signInManager;
    }

    [HttpGet("/login")]
    public IActionResult Login(string? returnUrl)
    {
        ViewBag.ReturnUrl = returnUrl;
        return View();
    }

    [HttpPost("/login")]
    public async Task<IActionResult> Login(UserLoginRequest model, string? returnUrl)
    {
        var response = await _authService.Login(model);
        if (!response)
            return RedirectToAction("Login", "Auth");
        return RedirectToAction("Index", "Home");
    }

    [HttpGet("/register")]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost("/register")]
    public async Task<IActionResult> Register(UserRegisterRequest userRegister)
    {
        if (!ModelState.IsValid)
            return View(userRegister);

        
        var loginResult = await _authService.Register(userRegister);
        if (!loginResult)
            return RedirectToAction("Register", "Auth");

        return RedirectToAction("Index", "Home");
    }

    [HttpGet("/logout")]
    public async Task<IActionResult> Logout()
    {
        await _authService.Logout();
        return RedirectToAction("Login", "Auth");
    }
    [HttpGet("/access-denied")]
    public IActionResult AccessDenied()
    {
        return View();
    }


}


