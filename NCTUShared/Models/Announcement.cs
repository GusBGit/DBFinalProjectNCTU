using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCTUShared.Models
{
    public class Announcement
    {
        public Announcement()
        {
            PostedTime = DateTime.Now;
        }
        /// <summary>
        /// Represents an announcement.
        /// </summary>
        public int Id { get; set; }
        [Required, StringLength(200)]
        public string Title { get; set; }
        public DateTime PostedTime { get; set; }
        public string Description { get; set; }
            
    }
}
