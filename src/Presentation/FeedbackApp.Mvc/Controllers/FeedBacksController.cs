using FeedbackApp.DataTransferObjects.Requests;
using FeedbackApp.Services.Services.AppUser;
using FeedbackApp.Services.Services.Feedback;
using Microsoft.AspNetCore.Mvc;

namespace FeedbackApp.Mvc.Controllers;

public class FeedBacksController : Controller
{
    private readonly IFeedBackService _feedBackService;
    private readonly IUserService _userService;

    public FeedBacksController(IFeedBackService feedBackService, IUserService userService)
    {
        _feedBackService = feedBackService;
        _userService = userService;
    }

    [HttpGet("/create-feedback")]
    public async Task<IActionResult?> CreateFeedback()
    {
        var user = await _userService.GetCurrentUser();
        ViewBag.currentUser = user.Email;
        return View();
    }

    [HttpPost("/create-feedback")]
    public async Task<IActionResult?> CreateFeedback(CreateFeedBackRequest model)
    {
        if (ModelState.IsValid)
        {
            await _feedBackService.CreateFeedBack(model);
            return RedirectToAction("Index", "Home");
        }
        return View();
    }

    [HttpGet("/get-incoming-feedback")]
    public async Task<IActionResult> GetIncomingFeedback()
    {
        var result = await _feedBackService.GetIncomingFeedback();
        ViewBag.listCount = result.Count();
        return View(result);
    }

    [HttpGet("/get-sent-feedback")]
    public async Task<IActionResult> GetSentFeedbacks()
    {
        var result = await _feedBackService.GetSentFeedbacks();
        ViewBag.listCount = result.Count();
        return View(result);
    }


}


