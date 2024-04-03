using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookReadEvent.Models
{
    public class Comment
    {
        [ForeignKey("CreateEvent")]
        public int Eventid { get; set; }
        [Key]
        public int Id { get; set; }
        public bool newcomment { get; set; }
        [Required(ErrorMessage = "Please write a comment before posting")]
        public string comment { get; set; }
        public DateTime timestamp { get; set; }
        public EventModel _event{ get;set; }
        public Comment()
        {
            timestamp = DateTime.Now;
        }
    }
}
