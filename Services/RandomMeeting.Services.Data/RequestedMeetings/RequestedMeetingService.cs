using System.Collections.Generic;
using System.Linq;
using RandomMeeting.Data;
using RandomMeeting.Data.Models.Enums;
using RandomMeeting.Data.Models.Meeting;
using RandomMeeting.Services.Mapping;

namespace RandomMeeting.Services.Data.RequestedMeetings
{
    public class RequestedMeetingService : IRequestedMeetingService
    {
        private readonly ApplicationDbContext db;

        public RequestedMeetingService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void CreateRequestedMeeting(Gender gender, AgeGroup ageGroup, string userId)
        {
            var requestedMeeting = new RequestedMeeting
            {
                DesiredGender = gender,
                DesiredAgeGroup = ageGroup,
                UserId = userId
            };

            this.db.RequestedMeetings.Add(requestedMeeting);
            this.db.SaveChanges();
        }

        public void DeleteRequestedMeeting(string requestedMeetingId)
        {
            if (requestedMeetingId == null)
            {
                return;
            }

            var requestedMeeting = this.db.RequestedMeetings.FirstOrDefault(rm => rm.Id == requestedMeetingId);

            this.db.RequestedMeetings.Remove(requestedMeeting);
            this.db.SaveChanges();
        }

        public string GetFirstMatchingRequestedMeetingIdForActiveUser(string activeUserId, string requestedMeetingId)
        {
            var activeUser = this.db.Users.FirstOrDefault(u => u.Id == activeUserId);
            var requestedMeeting = this.db.RequestedMeetings.FirstOrDefault(rm => rm.Id == requestedMeetingId);

            var passiveRequestedMeetingMatchingActiveUser = db.RequestedMeetings
                .FirstOrDefault(rq => rq.DesiredGender == activeUser.Gender && rq.DesiredAgeGroup == activeUser.AgeGroup);

            return passiveRequestedMeetingMatchingActiveUser.Id;
        }

        public IEnumerable<TViewModel> GetRequestedMeetingsForUser<TViewModel>(string userId)
        {
            var meetingsForUser = this.db.RequestedMeetings
                .Where(m => m.UserId == userId)
                .To<TViewModel>()
                .ToList();

            return meetingsForUser;
        }
    }
}