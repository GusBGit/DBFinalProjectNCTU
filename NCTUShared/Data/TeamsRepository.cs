using NCTUShared.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCTUShared.Data
{
    public class TeamsRepository : BaseRepository<Team>
    {
        public TeamsRepository(Context context)
            : base(context)
        {
        }


        public override IList<Team> GetList()
        {
            return Context.Teams
                .Include(cb => cb.Event)
                .OrderBy(cb => cb.Event.Title)
                .ThenBy(cb => cb.TeamName)
                .ToList();
        }

        public override Team Get(int id, bool includeRelatedEntities = true)
        {
            var teams = Context.Teams.AsQueryable();

            if (includeRelatedEntities)
            {
                teams = teams
                    .Include(cb => cb.Event)
                    .Include(cb => cb.TeamMembers.Select(a => a.TeamMember))
                    .Include(cb => cb.TeamMembers.Select(a => a.Role));
            }

            return teams
                .Where(t => t.Id == id)
                .SingleOrDefault();

        }

        public bool TeamEventHasName(int teamId, int eventId, string name)
        {
            return Context.Teams
                    .Any(t => t.Id != teamId &&
                    t.EventId == eventId &&
                    t.TeamName == name);
        }

        public bool TeamHasTeamMemberRoleCombination(int teamId, int teamMemberId, int roleId)
        {
            return Context.TeamTeamMembers
                        .Any(ttm => ttm.TeamId == teamId &&
                                    ttm.TeamMemberId == teamMemberId &&
                                    ttm.RoleId == roleId);
        }
    }
}
