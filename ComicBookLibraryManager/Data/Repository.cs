using NCTUShared.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using NCTUShared.Data;

namespace ComicBookLibraryManager.Data
{
    /// <summary>
    /// Repository class that provides various database queries
    /// and CRUD operations.
    /// </summary>
    public static class Repository
    {
        /// <summary>
        /// Private method that returns a database context.
        /// </summary>
        /// <returns>An instance of the Context class.</returns>
        static Context GetContext()
        {
            var context = new Context();
            context.Database.Log = (message) => Debug.WriteLine(message);
            return context;
        }

        /// <summary>
        /// Returns a count of the teams.
        /// </summary>
        /// <returns>An integer count of the teams.</returns>
        public static int GetTeamCount()
        {
            using (Context context = GetContext())
            {
                return context.Teams.Count();
            }
        }

        /// <summary>
        /// Returns a list of teams ordered by the event title
        /// </summary>
        /// <returns>An IList collection of Team entity instances.</returns>
        public static IList<Team> GetTeams()
        {
            using (Context context = GetContext())
            {
                return context.Teams
                    .Include(cb => cb.Event)
                    .OrderBy(cb => cb.Event.Title)
                    .ThenBy(cb => cb.TeamName)
                    .ToList();
            }
        }

        /// <summary>
        /// Returns a single team.
        /// </summary>
        /// <param name="teamId">The team book ID to retrieve.</param>
        /// <returns>A fully populated Team entity instance.</returns>
        public static Team GetTeam(int teamId)
        {
            using (Context context = GetContext())
            {
                return context.Teams
                    .Include(cb => cb.Event)
                    .Include(cb => cb.TeamMembers.Select(a => a.TeamMember))
                    .Include(cb => cb.TeamMembers.Select(a => a.Role))
                    .Where(cb => cb.Id == teamId)
                    .SingleOrDefault();
            }
        }

        /// <summary>
        /// Returns a list of events ordered by title.
        /// </summary>
        /// <returns>An IList collection of events entity instances.</returns>
        public static IList<Event> GetEvents()
        {
            using (Context context = GetContext())
            {
                return context.Events
                    .OrderBy(s => s.Title)
                    .ToList();
            }
        }

        /// <summary>
        /// Returns a single event.
        /// </summary>
        /// <param name="eventId">The event's ID to retrieve.</param>
        /// <returns>An events entity instance.</returns>
        public static Event GetEvent(int eventId)
        {
            using (Context context = GetContext())
            {
                return context.Events
                    .Where(s => s.Id == eventId)
                    .SingleOrDefault();
            }
        }

        /// <summary>
        /// Returns a list of team members ordered by name.
        /// </summary>
        /// <returns>An IList collection of TeamMember entity instances.</returns>
        public static IList<TeamMember> GetTeamMembers()
        {
            using (Context context = GetContext())
            {
                return context.TeamMembers
                    .OrderBy(a => a.Name)
                    .ToList();
            }
        }

        /// <summary>
        /// Returns a list of roles ordered by name.
        /// </summary>
        /// <returns>An IList collection of Role entity instances.</returns>
        public static IList<Role> GetRoles()
        {
            using (Context context = GetContext())
            {
                return context.TeamRoles
                    .OrderBy(r => r.Name)
                    .ToList();
            }
        }

        /// <summary>
        /// Adds a team.
        /// </summary>
        /// <param name="team">The Team entity instance to add.</param>
        public static void AddTeam(Team team)
        {
            using (Context context = GetContext())
            {
                context.Teams.Add(team);

                if (team.Event != null && team.Event.Id > 0)
                {
                    context.Entry(team.Event).State = EntityState.Unchanged;
                }

                foreach (TeamTeamMember tmm in team.TeamMembers)
                {
                    if (tmm.TeamMember != null && tmm.TeamMember.Id > 0)
                    {
                        context.Entry(tmm.TeamMember).State = EntityState.Unchanged;
                    }

                    if (tmm.Role != null && tmm.Role.Id > 0)
                    {
                        context.Entry(tmm.Role).State = EntityState.Unchanged;
                    }
                }

                context.SaveChanges();
            }
        }

        /// <summary>
        /// Updates a team.
        /// </summary>
        /// <param name="team">The Team entity instance to update.</param>
        public static void UpdateTeam(Team team)
        {
            using (Context context = GetContext())
            {
                context.Teams.Attach(team);
                var teamEntry = context.Entry(team);
                teamEntry.State = EntityState.Modified;
                //teamEntry.Property("IssueNumber").IsModified = false;

                context.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes a team.
        /// </summary>
        /// <param name="teamId">The team ID to delete.</param>
        public static void DeleteTeam(int teamId)
        {
            using (Context context = GetContext())
            {
                var team = new Team() { Id = teamId };
                context.Entry(team).State = EntityState.Deleted;

                context.SaveChanges();
            }
        }
    }
}
