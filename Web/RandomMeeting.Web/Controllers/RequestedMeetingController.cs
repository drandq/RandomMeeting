using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RandomMeeting.Data.Models;
using RandomMeeting.Services.Data.RequestedMeetings;
using RandomMeeting.Web.ViewModels.RequestedMeetings;

namespace RandomMeeting.Web.Controllers
{
    public class RequestedMeetingController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IRequestedMeetingService requestedMeetingService;

        public RequestedMeetingController(UserManager<ApplicationUser> userManager, IRequestedMeetingService requestedMeetingService)
        {
            this.userManager = userManager;
            this.requestedMeetingService = requestedMeetingService;
        }

        [Authorize]
        public IActionResult Request()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Request(RequestMeetingInputModel input)
        {
            if (!ModelState.IsValid)
            {
                return this.View(input);
            }

            var userId = this.userManager.GetUserId(HttpContext.User);

            this.requestedMeetingService.CreateRequestedMeeting(input.DesiredGender, input.DesiredAgeGroup, userId);

            return this.RedirectToAction("MyRequestedMeetings");
        }

        [Authorize]
        public IActionResult MyRequestedMeetings()
        {
            var userId = this.userManager.GetUserId(HttpContext.User);

            var requestedMeetings = this.requestedMeetingService.GetRequestedMeetingsForUser<RequestedMeetingViewModel>(userId);

            return this.View(requestedMeetings);
        }
    }
}