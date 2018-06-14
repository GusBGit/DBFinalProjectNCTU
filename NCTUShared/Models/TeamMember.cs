using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCTUShared.Models
{
    /// <summary>
    /// Represents a team member.
    /// </summary>
    public class TeamMember
    {
        public TeamMember()
        {
            Teams = new List<TeamTeamMember>();
        }

        public int Id { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; }
        
        public ICollection<TeamTeamMember> Teams { get; set; }
    }
}
