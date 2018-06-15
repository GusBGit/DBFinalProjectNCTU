using NCTUShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace NCTUShared.Data
{
    public class AnnouncementsRepository : BaseRepository<Announcement>
    {
        public AnnouncementsRepository(Context context)
            : base(context)
        {
        }

        public override Announcement Get(int id, bool includeRelatedEntities = true)
        {
            var ann = Context.Announcements.AsQueryable();
            
            if (includeRelatedEntities)
            {
            }

            return ann
                .Where(a => a.Id == id)
                .SingleOrDefault();
        }

        public override IList<Announcement> GetList()
        {
            return Context.Announcements
                .OrderBy(a => a.PostedTime)
                .ToList();
        }

        public bool AnnouncementHasTitle(int annId, string title)
        {
            return Context.Announcements
                .Any(a => a.Id != annId && a.Title == title);
        }
    }
}
