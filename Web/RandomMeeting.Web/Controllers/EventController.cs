using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RandomMeeting.Data.Models;
using RandomMeeting.Services.Data;
using RandomMeeting.Web.ViewModels.Events;
using RandomMeeting.Web.ViewModels.Users;

namespace RandomMeeting.Web.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventService eventService;
        private readonly UserManager<ApplicationUser> userManager;

        public EventController(IEventService eventService, UserManager<ApplicationUser> userManager)
        {
            this.eventService = eventService;
            this.userManager = userManager;
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [Authorize]
        [AutoValidateAntiforgeryToken]
        [HttpPost]
        public IActionResult Create(CreateEventInputModel input)
        {
            if (!ModelState.IsValid)
            {
                return this.View(input);
            }

            var userId = userManager.GetUserId(HttpContext.User);

            this.eventService.CreateEvent(input.Name, input.Description, input.Start, input.End, input.Address, input.ImageUrl, userId);

            return this.RedirectToAction("MyEvents");
        }

        [Authorize]
        public IActionResult AllEvents()
        {
            var events = this.eventService.GetAllEvents<EventSummaryViewModel>();

            return this.View(events);
        }

        [Authorize]
        public IActionResult MyEvents()
        {
            var userId = userManager.GetUserId(HttpContext.User);

            var events = this.eventService.GetEventsForUser<EventSummaryViewModel>(userId);

            return this.View(events);
        }

        [Authorize]
        public IActionResult Details(string id)
        {
            var requestedEvent = this.eventService.GetEvent(id);

            var usersForEvent = this.eventService.GetUsersForEvent<ApplicationUserViewModel>(id);

            var eventModel = new EventDetailsViewModel
            {
                Id = requestedEvent.Id,
                Name = requestedEvent.Name,
                Description = requestedEvent.Description,
                Address = requestedEvent.Address,
                ImageUrl = requestedEvent.ImageUrl,
                Start = requestedEvent.Start,
                End = requestedEvent.End,
                NoOfLikes = requestedEvent.NoOfLikes,
                Users = usersForEvent
            };

            return this.View(eventModel);
        }

        [Authorize]
        public IActionResult Like(string id)
        {
            this.eventService.LikeEvent(id);

            return this.RedirectToAction("Details", new { id = id });
        }

        [Authorize]
        public IActionResult Edit()
        {
            return this.View();
        }

        [Authorize]
        [AutoValidateAntiforgeryToken]
        [HttpPost]
        public IActionResult Edit(EditEventInputModel input, string id)
        {
            if (!ModelState.IsValid)
            {
                return this.View(input);
            }

            this.eventService.EditEvent(input.Description, input.Address, input.ImageUrl, id);

            return this.RedirectToAction("Details", new { id = id });
        }

        [Authorize]
        public IActionResult Delete(string id)
        {
            this.eventService.DeleteEvent(id);

            return this.RedirectToAction("MyEvents");
        }
    }
}
