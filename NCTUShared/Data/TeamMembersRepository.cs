using NCTUShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

namespace NCTUShared.Data
{
    public class TeamMembersRepository : BaseRepository<TeamMember>
    {
        public TeamMembersRepository(Context context)
            : base(context)
        {
        }

        public override TeamMember Get(int id, bool includeRelatedEntities = true)
        {
            var teamMember = Context.TeamMembers.AsQueryable();

            if (includeRelatedEntities)
            {
                teamMember = teamMember
                    .Include(tm => tm.Teams.Select(t => t.Team.Event))
                    .Include(tm => tm.Teams.Select(t => t.Role));
            }

            return teamMember
                .Where(tm => tm.Id == id)
                .SingleOrDefault();
        }

        public override IList<TeamMember> GetList()
        {
            return Context.TeamMembers
                .OrderBy(tm => tm.Name)
                .ToList();
        }

        public bool TeamMemberHasName(int tmId, string name)
        {
            return Context.TeamMembers
                .Any(tm => tm.Id != tmId && tm.Name == name);
        }
    }
}
