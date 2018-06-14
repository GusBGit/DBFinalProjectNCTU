using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCTUShared.Models
{
    /// <summary>
    /// Represents a member of a team.
    /// </summary>
    public class TeamTeamMember
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public int TeamMemberId { get; set; }
        public int RoleId { get; set; }

        public Team Team { get; set; }
        public TeamMember TeamMember { get; set; }
        public Role Role { get; set; }
    }
}
