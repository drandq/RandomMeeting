using RandomMeeting.Data.Models.Enums;
using System.Collections.Generic;

namespace RandomMeeting.Services.Data.RequestedMeetings
{
    public interface IRequestedMeetingService
    {
        void CreateRequestedMeeting(Gender gender, AgeGroup ageGroup, string userId);

        IEnumerable<TViewModel> GetRequestedMeetingsForUser<TViewModel>(string userId);

        void DeleteRequestedMeeting(string requestedMeetingId);

        string GetFirstMatchingRequestedMeetingIdForActiveUser(string activeUserId, string requestedMeetingId);
    }
}
