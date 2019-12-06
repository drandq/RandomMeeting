using RandomMeeting.Data;
using RandomMeeting.Data.Models;
using RandomMeeting.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RandomMeeting.Services.Data
{
    public class EventService : IEventService
    {
        private readonly ApplicationDbContext db;

        public EventService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void CreateEvent(string name, string description, DateTime start, DateTime end, string address, string imageUrl, string userId)
        {
            var eventToBeCreated = new Event
            {
                Name = name,
                Description = description,
                Start = start,
                End = end,
                Address = address,
                ImageUrl = imageUrl,
                CreatedOn = DateTime.UtcNow,
                NoOfLikes = 0
            };

            var user = this.db.Users.FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return;
            }

            var userEvents = new ApplicationUserEvent
            {
                Event = eventToBeCreated,
                User = user
            };

            this.db.Events.Add(eventToBeCreated);
            this.db.UserEvents.Add(userEvents);
            this.db.SaveChanges();
        }

        public IEnumerable<TViewModel> GetAllEvents<TViewModel>()
        {
            var events = this.db.Events
                .To<TViewModel>()
                .ToList();

            return events;
        }

        public IEnumerable<TViewModel> GetEventsForUser<TViewModel>(string userId)
        {
            var eventsForUser = this.db.UserEvents
                .Where(ue => ue.UserId == userId)
                .Select(ue => ue.Event)
                .To<TViewModel>()
                .ToList();

            return eventsForUser;
        }

        public Event GetEvent(string eventId)
        {
            var requestedEvent = this.db.Events
                .FirstOrDefault(e => e.Id == eventId);

            return requestedEvent;
        }

        public void LikeEvent(string eventId)
        {
            var requestedEvent = this.db.Events
                .FirstOrDefault(e => e.Id == eventId);

            requestedEvent.NoOfLikes++;

            this.db.SaveChanges();
        }

        public void EditEvent(string description, string address, string imageUrl, string eventId)
        {
            var eventToBeEdited = this.db.Events
                .FirstOrDefault(e => e.Id == eventId);

            eventToBeEdited.Description = description;
            eventToBeEdited.Address = address;
            eventToBeEdited.ImageUrl = imageUrl;

            this.db.SaveChanges();
        }

        public void DeleteEvent(string eventId)
        {
            var eventToBeDeleted = this.db.Events
                .FirstOrDefault(e => e.Id == eventId);

            var userEventsForThisEvent = this.db.UserEvents
                .Where(ue => ue.EventId == eventId);

            this.db.UserEvents.RemoveRange(userEventsForThisEvent);
            this.db.Events.Remove(eventToBeDeleted);

            this.db.SaveChanges();
        }

        public IEnumerable<TViewModel> GetUsersForEvent<TViewModel>(string eventId)
        {
            var users = this.db.UserEvents
                .Where(ue => ue.EventId == eventId)
                .Select(ue => ue.User)
                .To<TViewModel>()
                .ToList();

            return users;
        }
    }
}
