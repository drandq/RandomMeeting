using Microsoft.AspNetCore.Identity;
using RandomMeeting.Data.Models.Enums;
using RandomMeeting.Data.Models.Meeting;
using System;
using System.Collections.Generic;

namespace RandomMeeting.Data.Models
{
    public class ApplicationUser : IdentityUser<string>
    {
        public ApplicationUser()
        {
            this.Number = Guid.NewGuid().ToString();
            this.UserEvents = new List<ApplicationUserEvent>();
            this.RequestedMeetings = new List<RequestedMeeting>();
        }

        public string Number { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public AgeGroup AgeGroup { get; set; }

        public Gender Gender { get; set; }

        public virtual ICollection<ApplicationUserEvent> UserEvents { get; set; }

        public virtual ICollection<RequestedMeeting> RequestedMeetings { get; set; }
    }
}
