using RandomMeeting.Data.Models.Enums;
using RandomMeeting.Data.Models.Meeting;
using RandomMeeting.Services.Mapping;

namespace RandomMeeting.Web.ViewModels.RequestedMeetings
{
    public class RequestedMeetingViewModel : IMapFrom<RequestedMeeting>
    {
        public string Id { get; set; }

        public Gender DesiredGender { get; set; }

        public AgeGroup DesiredAgeGroup { get; set; }
    }
}