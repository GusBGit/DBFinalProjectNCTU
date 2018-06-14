using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCTUShared.Models
{
    /// <summary>
    /// Represents a team.
    /// </summary>
    public class Team
    {
        public Team()
        {
            TeamMembers = new List<TeamTeamMember>();
        }

        public int Id { get; set; }
        [Display(Name = "Event")]
        public int EventId { get; set; }
        [Display(Name = "Team Name")]
        public string TeamName { get; set; }

        public Event Event { get; set; }
        public ICollection<TeamTeamMember> TeamMembers { get; set; }

        /// <summary>
        /// The display text for a team.
        /// </summary>
        public string DisplayText
        {
            get
            {
                return $"{Event?.Title} #{TeamName}";
            }
        }

        /// <summary>
        /// Adds a team member to the team.
        /// </summary>
        /// <param name="teamMember">The team member to add.</param>
        /// <param name="role">The role that the team member had on this team.</param>
        public void AddTeamMember(TeamMember teamMember, Role role)
        {
            TeamMembers.Add(new TeamTeamMember()
            {
                TeamMember = teamMember,
                Role = role
            });
        }

        /// <summary>
        /// Adds a team member to the team.
        /// </summary>
        /// <param name="teamMemberId">The team member ID to add.</param>
        /// <param name="roleId">The role ID that the team member had on this team.</param>
        public void AddTeamMember(int teamMemberId, int roleId)
        {
            TeamMembers.Add(new TeamTeamMember()
            {
                TeamMemberId = teamMemberId,
                RoleId = roleId
            });
        }
    }
}
