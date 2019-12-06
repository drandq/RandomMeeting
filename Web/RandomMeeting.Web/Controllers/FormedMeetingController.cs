using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RandomMeeting.Data.Models;
using RandomMeeting.Services.Data.FormedMeetings;
using RandomMeeting.Services.Data.RequestedMeetings;
using RandomMeeting.Web.ViewModels.FormedMeetings;

namespace RandomMeeting.Web.Controllers
{
    public class FormedMeetingController : Controller
    {
        private readonly IFormedMeetingService formedMeetingService;
        private readonly IRequestedMeetingService requestedMeetingService;
        private readonly UserManager<ApplicationUser> userManager;

        public FormedMeetingController(IFormedMeetingService formedMeetingService, 
                                        IRequestedMeetingService requestedMeetingService,
                                        UserManager<ApplicationUser> userManager)
        {
            this.formedMeetingService = formedMeetingService;
            this.requestedMeetingService = requestedMeetingService;
            this.userManager = userManager;
        }

        [Authorize]
        public IActionResult Generate(string id)
        {
            var userId = this.userManager.GetUserId(HttpContext.User);
            var requestedMeetingId = id;

            var hasAppropriatePartner = this.formedMeetingService.HasAppropriatePartner(userId, requestedMeetingId);

            if (hasAppropriatePartner == null)
            {
                return this.RedirectToAction("NoPartners");
            }
            else
            {
                var passiveUserId = hasAppropriatePartner;

                this.formedMeetingService.CreateFormedMeeting(userId, passiveUserId);

                var requestedMeetingIdOfPassiveUser = this.requestedMeetingService.GetFirstMatchingRequestedMeetingIdForActiveUser(userId, requestedMeetingId);
                this.requestedMeetingService.DeleteRequestedMeeting(requestedMeetingId);
                this.requestedMeetingService.DeleteRequestedMeeting(requestedMeetingIdOfPassiveUser);

                return this.RedirectToAction("MyFormedMeetings");
            }
        }

        [Authorize]
        public IActionResult NoPartners()
        {
            return this.View();
        }

        [Authorize]
        public IActionResult MyFormedMeetings()
        {
            var userId = this.userManager.GetUserId(HttpContext.User);

            var formedMeetings = this.formedMeetingService.GetFormedMeetingsForUser<FormedMeetingViewModel>(userId);

            return this.View(formedMeetings);
        }

        [Authorize]
        public IActionResult Set()
        {
            return null;
        }
    }
}