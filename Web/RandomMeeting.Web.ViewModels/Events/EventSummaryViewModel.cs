using RandomMeeting.Services.Mapping;
using RandomMeeting.Data.Models;
using System;

namespace RandomMeeting.Web.ViewModels.Events
{
    public class EventSummaryViewModel : IMapFrom<Event>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public DateTime Start { get; set; }
    }
}
