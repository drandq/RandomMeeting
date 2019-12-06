using RandomMeeting.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace RandomMeeting.Web.ViewModels.RequestedMeetings
{
    public class RequestMeetingInputModel
    {
        [Required]
        [EnumDataType(typeof(Gender))]
        [Display(Name = "Desired gender")]
        public Gender DesiredGender { get; set; }

        [Required]
        [EnumDataType(typeof(AgeGroup))]
        [Display(Name = "Desired age group")]
        public AgeGroup DesiredAgeGroup { get; set; }
    }
}
