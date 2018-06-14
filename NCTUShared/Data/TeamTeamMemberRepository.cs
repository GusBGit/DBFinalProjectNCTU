using NCTUShared.Models;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCTUShared.Data
{
    public class TeamTeamMemberRepository : BaseRepository<TeamTeamMember>
    {

        public TeamTeamMemberRepository(Context context)
            :base(context)
        {
        }

        public override TeamTeamMember Get(int id, bool includeRelatedEntities = true)
        {
            var ttms = Context.TeamTeamMembers.AsQueryable();

            if (includeRelatedEntities)
            {
                ttms = ttms
                    .Include(tt => tt.TeamMember)
                    .Include(tt => tt.Role)
                    .Include(tt => tt.Team.Event);
            }

            return ttms
                .Where(tt => tt.Id == (int)id)
                .SingleOrDefault();
        }

        public override IList<TeamTeamMember> GetList()
        {

            throw new NotImplementedException();
        }
    }
}
