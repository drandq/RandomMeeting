using System;
using System.Collections.Generic;
using System.Text;

namespace RandomMeeting.Data.Models
{
    public class ApplicationUserEvent
    {
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string EventId { get; set; }

        public virtual Event Event { get; set; }
    }
}
