using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using NCTUShared.Models;

namespace NCTUShared.Data.Queries
{
    class GetTeamQuery
    {
        private Context _context = null;
        public GetTeamQuery(Context context)
        {
            _context = context;
        }

        public Team Execute(int id)
        {
            return _context.Teams
                .Include(cb => cb.Event)
                .Include(cb => cb.TeamMembers.Select(a => a.TeamMember))
                .Include(cb => cb.TeamMembers.Select(a => a.Role))
                .Where(cb => cb.Id == id)
                .SingleOrDefault();
        }
    }
}
