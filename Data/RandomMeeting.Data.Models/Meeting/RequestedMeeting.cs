using RandomMeeting.Data.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace RandomMeeting.Data.Models.Meeting
{
    public class RequestedMeeting
    {
        public RequestedMeeting()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        public Gender DesiredGender { get; set; }

        public AgeGroup DesiredAgeGroup { get; set; }

        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
