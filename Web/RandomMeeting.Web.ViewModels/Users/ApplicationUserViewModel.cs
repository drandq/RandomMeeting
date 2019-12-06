using RandomMeeting.Data.Models;
using RandomMeeting.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace RandomMeeting.Web.ViewModels.Users
{
    public class ApplicationUserViewModel : IMapFrom<ApplicationUser>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
