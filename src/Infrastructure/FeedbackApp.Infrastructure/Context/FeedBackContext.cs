using FeedbackApp.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackApp.Infrastructure.Context
{
    public class FeedBackContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
    {
        public FeedBackContext(DbContextOptions<FeedBackContext> options) : base(options)
        {
        }

        public DbSet<FeedBack> FeedBacks { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
