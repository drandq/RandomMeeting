using RandomMeeting.Data.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace RandomMeeting.Data.Models.Meeting
{
    public class FormedMeeting
    {
        public FormedMeeting()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        public DateTime? Time { get; set; }

        [MaxLength(100)]
        public string Location { get; set; }

        public MeetingStatus Status { get; set; }

        [MaxLength(1000)]
        public string PictureUrl { get; set; }

        public string FirstUserId { get; set; }

        public virtual ApplicationUser FirstUser { get; set; }

        public string SecondUserId { get; set; }

        public virtual ApplicationUser SecondUser { get; set; }
    }
}
