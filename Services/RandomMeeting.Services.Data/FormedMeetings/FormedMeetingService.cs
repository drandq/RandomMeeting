using System.Collections.Generic;
using System.Linq;
using RandomMeeting.Data;
using RandomMeeting.Data.Models.Meeting;
using RandomMeeting.Services.Data.Users;
using RandomMeeting.Services.Mapping;

namespace RandomMeeting.Services.Data.FormedMeetings
{
    public class FormedMeetingService : IFormedMeetingService
    {
        private readonly ApplicationDbContext db;
        private readonly IUserService userService;

        public FormedMeetingService(ApplicationDbContext db, IUserService userService)
        {
            this.db = db;
            this.userService = userService;
        }
        
        public string HasAppropriatePartner(string userId, string requestedMeetingId)
        {
            var activeUser = this.db.Users.FirstOrDefault(u => u.Id == userId);
            var requestedMeeting = this.db.RequestedMeetings.FirstOrDefault(rm => rm.Id == requestedMeetingId);

            // Check if someone wants active user
            var passiveRequestedMeetingMatchingActiveUser = db.RequestedMeetings
                .FirstOrDefault(rq => rq.DesiredGender == activeUser.Gender && rq.DesiredAgeGroup == activeUser.AgeGroup);
            
            if (passiveRequestedMeetingMatchingActiveUser == null)
            {
                return null;
            }

            var passiveUserId = passiveRequestedMeetingMatchingActiveUser.UserId;
            var passiveUser = this.userService.GetUserById(passiveUserId);

            // Check if this passive user is good enough for active user
            if (passiveUser.Gender != requestedMeeting.DesiredGender || passiveUser.AgeGroup != requestedMeeting.DesiredAgeGroup)
            {
                return null;
            }

            return passiveUser.Id;
        }

        public void CreateFormedMeeting(string activeUserId, string passiveUserId)
        {
            var formedMeeting = new FormedMeeting
            {
                FirstUserId = activeUserId,
                SecondUserId = passiveUserId
            };

            this.db.FormedMeetings.Add(formedMeeting);
            this.db.SaveChanges();
        }

        public IEnumerable<TViewModel> GetFormedMeetingsForUser<TViewModel>(string userId)
        {
            var formedMeetings = this.db.FormedMeetings
                .Where(fm => fm.FirstUserId == userId || fm.SecondUserId == userId)
                .To<TViewModel>()
                .ToList();

            return formedMeetings;
        }
    }
}
