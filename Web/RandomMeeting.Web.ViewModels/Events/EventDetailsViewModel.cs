using RandomMeeting.Web.ViewModels.Users;
using System;
using System.Collections.Generic;

namespace RandomMeeting.Web.ViewModels.Events
{
    public class EventDetailsViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public string Address { get; set; }

        public int NoOfLikes { get; set; }

        public string ImageUrl { get; set; }

        public IEnumerable<ApplicationUserViewModel> Users { get; set; }
    }
}
