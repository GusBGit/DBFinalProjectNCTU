using NCTUShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace NCTUShared.Data
{
    public class EventsRepository : BaseRepository<Event>
    {
        public EventsRepository(Context context)
            : base(context)
        {
        }

        public override Event Get(int id, bool includeRelatedEntities = true)
        {
            var ev = Context.Events.AsQueryable();

            if (includeRelatedEntities)
            {
                ev = ev
                    .Include(e => e.Teams);
            }

            return ev
                .Where(e => e.Id == id)
                .SingleOrDefault();
        }

        public override IList<Event> GetList()
        {
            return Context.Events
                .OrderBy(e => e.Title)
                .ToList();
        }

        public bool EventHasTitle(int eventId, string title)
        {
            return Context.Events
                .Any(e => e.Id != eventId && e.Title == title);
        }
    }
}
