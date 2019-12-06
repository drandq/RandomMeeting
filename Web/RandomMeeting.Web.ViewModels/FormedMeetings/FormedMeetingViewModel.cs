using RandomMeeting.Data.Models.Meeting;
using RandomMeeting.Services.Mapping;

namespace RandomMeeting.Web.ViewModels.FormedMeetings
{
    public class FormedMeetingViewModel : IMapFrom<FormedMeeting>
    {
        public string Id { get; set; }

        public string FirstUserNumber { get; set; }

        public string SecondUserNumber { get; set; }
    }
}
