using FeedbackApp.Domain;
using FeedbackApp.Infrastructure.Context;
using FeedbackApp.Infrastructure.Repositories;
using FeedbackApp.Infrastructure.Repositories.EntityFramework;
using FeedbackApp.Services.Mapping;
using FeedbackApp.Services.Services.AppUser;
using FeedbackApp.Services.Services.Auth;
using FeedbackApp.Services.Services.Feedback;
using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
});

builder.Services.AddIdentity<User, IdentityRole<int>>(opt =>
{
    opt.Password.RequiredLength = 8;
    opt.Password.RequireDigit = false;
    opt.Password.RequireUppercase = true;
    opt.Password.RequireLowercase = true;
    opt.Password.RequireNonAlphanumeric = false;
})
    .AddRoles<IdentityRole<int>>()
    .AddEntityFrameworkStores<FeedBackContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Auth/Login";
                    options.AccessDeniedPath = "/Auth/AccessDenied"; //Üye ama yetkisi yok
                    options.ReturnUrlParameter = "returnUrl";
                });

builder.Services.AddScoped<IFeedBackService, FeedBackService>();
builder.Services.AddScoped<IFeedBackRepository, EFFeedBackRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthService, AuthService>();

/*
var connectionString = builder.Configuration.GetConnectionString("FeedBack");
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<FeedBackContext>(opt =>
        opt.UseNpgsql(connectionString));

var hangfireCS = builder.Configuration.GetConnectionString("Hangfire");
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<HangfireContext>(opt =>
        opt.UseNpgsql(hangfireCS));
*/

var connectionString = builder.Configuration.GetConnectionString("FeedBack");
builder.Services.AddDbContext<FeedBackContext>(opt =>
        opt.UseSqlServer(connectionString));

var hangfireCS = builder.Configuration.GetConnectionString("Hangfire");
builder.Services.AddDbContext<HangfireContext>(opt =>
        opt.UseSqlServer(hangfireCS));



builder.Services.AddHangfire(configuration =>
        configuration.UseSqlServerStorage(builder.Configuration.GetConnectionString("Hangfire")));
builder.Services.AddHangfireServer();

/*
builder.Services.AddHangfire(configuration =>
        configuration.UsePostgreSqlStorage(builder.Configuration.GetConnectionString("Hangfire")));
builder.Services.AddHangfireServer();
*/

var app = builder.Build();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

var feedBackContext = services.GetRequiredService<FeedBackContext>();
feedBackContext.Database.EnsureCreated();

var hangfireContext = services.GetRequiredService<HangfireContext>();
hangfireContext.Database.EnsureCreated();

await SeedData.SeedDatabase(feedBackContext, scope.ServiceProvider);
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();
app.UseRouting();

app.UseAuthorization();
app.UseHangfireDashboard();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

