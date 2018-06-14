using NCTUShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace NCTUShared.Data
{
    public class Repository
    {
        private Context _context = null;

        public Repository(Context context)
        {
            _context = context;
        }

        public IList<TeamMember> GetTeamMembers()
        {
            return _context.TeamMembers.OrderBy(tm => tm.Name).ToList();
        }

        public IList<Role> GetRoles()
        {
            return _context.TeamRoles.OrderBy(r => r.Name).ToList();
        }

        public IList<Event> GetEventsList()
        {
            return _context.Events.OrderBy(ev => ev.Title).ToList();
        }

       
    }
}
