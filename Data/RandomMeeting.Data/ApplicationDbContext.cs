using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RandomMeeting.Data.Models;
using RandomMeeting.Data.Models.Meeting;
using System;
using System.Collections.Generic;
using System.Text;

namespace RandomMeeting.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public DbSet<Event> Events { get; set; }

        public DbSet<ApplicationUserEvent> UserEvents { get; set; }

        public DbSet<RequestedMeeting> RequestedMeetings { get; set; }

        public DbSet<FormedMeeting> FormedMeetings { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUserEvent>()
                .HasKey(ue => new { ue.UserId, ue.EventId });

            base.OnModelCreating(builder);
        }
    }
}
