using RandomMeeting.Data.Models;

namespace RandomMeeting.Services.Data.Users
{
    public interface IUserService
    {
        ApplicationUser GetUserById(string userId);
    }
}
