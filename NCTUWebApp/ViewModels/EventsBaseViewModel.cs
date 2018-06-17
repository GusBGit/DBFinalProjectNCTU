using NCTUShared.Data;
using NCTUShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NCTUWebApp.ViewModels
{
    /// <summary>
    /// Base view model class for the "Detail"
    /// and "Index" views.
    /// </summary>
    public class EventsBaseViewModel
    {
        public Event Event { get; set; }
        public ICollection<Team> Teams { get; set; }
        TeamsRepository Tr { get; set; }

        public void Init(EventsRepository evRep,
            TeamsRepository teamsRepository,
            int id)
        {
            Tr = teamsRepository;
            Event = evRep.Get(id);
            Teams = Event.Teams;
        }

        public int NumberOfTeamMembers(int id)
        {
            return Tr.Get(id).TeamMembers.Count();
        }
    }
}