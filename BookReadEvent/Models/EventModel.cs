using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookReadEvent.Models
{
    public class EventModel
    {
        public string userId { get; set; }
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Display(Name = "Event Date")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime date { get; set; }
        [Required]
        public string location { get; set; }
        [Display(Name = "Start Time")]
        [Required(ErrorMessage = "Please Enter the start time")]
        [DataType(DataType.Time)]
        public DateTime startTime { get; set; }
        [Display(Name = "Type of Event")]
        [Required]
        public string eventType { get; set; }
        [Range(1, 4, ErrorMessage = " Duration should be 1-4 hours only")]
        [Display(Name ="Duration")]
        public int duration { get; set; }
        [StringLength(50)]
        [Display(Name ="Description")]
        public string description { get; set; }
        [StringLength(500)]
        [Display(Name ="Other Details")]
        public string otherdetails { get; set; }
       [Display(Name ="Invite People")]
        public string invite { get; set; }
        [Display(Name ="Comment")]
        public IEnumerable<Comment> comments { get; set; }

    }
}
