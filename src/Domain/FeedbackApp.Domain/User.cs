using Microsoft.AspNetCore.Identity;

namespace FeedbackApp.Domain;

public class User : IdentityUser<int>, IEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool Status { get; set; } = true;
}

