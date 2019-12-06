using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RandomMeeting.Data;
using RandomMeeting.Data.Models;

namespace RandomMeeting.Services.Data.Users
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext db;

        public UserService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public ApplicationUser GetUserById(string userId)
        {
            return this.db.Users.FirstOrDefault(u => u.Id == userId);
        }
    }
}
