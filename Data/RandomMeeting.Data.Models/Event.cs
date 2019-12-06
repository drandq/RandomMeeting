using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RandomMeeting.Data.Models
{
    public class Event
    {
        public Event()
        {
            this.Id = Guid.NewGuid().ToString();
            this.UserEvents = new List<ApplicationUserEvent>();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        [Required]
        [MaxLength(70)]
        public string Address { get; set; }

        public DateTime CreatedOn { get; set; }

        public int NoOfLikes { get; set; }

        [Required]
        [MaxLength(1000)]
        public string ImageUrl { get; set; }

        public bool HasFinished => (DateTime.Compare(DateTime.Now, this.End) <= 0) ? false : true;

        public virtual ICollection<ApplicationUserEvent> UserEvents { get; set; }
    }
}
