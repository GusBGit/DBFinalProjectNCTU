using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCTUShared.Models
{
    /// <summary>
    /// Represents an event.
    /// </summary>
    public class Event
    {
        public Event()
        {
            Teams = new List<Team>();
        }

        public int Id { get; set; }
        [Required, StringLength(200)]
        public string Title { get; set; }
        public DateTime Date { get; set; }
        [Display(Name = "Team Limit")]
        public int TeamLimit { get; set; }
        [Display(Name = "Team Size Limit")]
        public int TeamSizeLimit { get; set; }
        public string Description { get; set; }

        public ICollection<Team> Teams { get; set; }
    }
}
