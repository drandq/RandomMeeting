using System.Collections.Generic;

namespace RandomMeeting.Services.Data.FormedMeetings
{
    public interface IFormedMeetingService
    {
        string HasAppropriatePartner(string userId, string requestedMeetingId);

        void CreateFormedMeeting(string activeUserId, string passiveUserId);

        IEnumerable<TViewModel> GetFormedMeetingsForUser<TViewModel>(string userId);
    }
}
