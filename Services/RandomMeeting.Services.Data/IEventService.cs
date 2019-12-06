using RandomMeeting.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RandomMeeting.Services.Data
{
    public interface IEventService
    {
        void CreateEvent(string name, string description, DateTime start, DateTime end, string address, string imageUrl, string userId);

        IEnumerable<TViewModel> GetAllEvents<TViewModel>();

        IEnumerable<TViewModel> GetEventsForUser<TViewModel>(string userId);

        Event GetEvent(string eventId);

        void LikeEvent(string eventId);

        void EditEvent(string description, string address, string imageUrl, string eventId);

        void DeleteEvent(string eventId);

        IEnumerable<TViewModel> GetUsersForEvent<TViewModel>(string eventId);
    }
}
