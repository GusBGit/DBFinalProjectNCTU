using NCTUShared.Models;
using System;
using System.Data.Entity;

namespace NCTUShared.Data
{
    /// <summary>
    /// Custom database initializer class used to populate
    /// the database with seed data.
    /// </summary>
    internal class DatabaseInitializer : DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context context)
        {
            // This is our database's seed data...
            // 3 events, 6 team members, 2 roles, and 9 teams.

            var annc1 = new Announcement()
            {
                Title = "Game-winning shot",
                Description = "Game winning shot omg omg, ame winning shot omg omg, ame winning shot omg omg, ame winning shot omg omg,ame winning shot omg omg,ame winning shot omg omg,ame winning shot omg omg",
                PostedTime = DateTime.Now
            };

            var annc2 = new Announcement()
            {
                Title = "Game-winning shot 2",
                Description = "Game winning shot omg omg, ame winning shot omg omg, ame winning shot omg omg, ame winning shot omg omg,ame winning shot omg omg,ame winning shot omg omg,ame winning shot omg omg",
                PostedTime = DateTime.Now
            };

            var annc3 = new Announcement()
            {
                Title = "Game-winning shot 3",
                Description = "Game winning shot omg omg, ame winning shot omg omg, ame winning shot omg omg, ame winning shot omg omg,ame winning shot omg omg,ame winning shot omg omg,ame winning shot omg omg",
                PostedTime = DateTime.Now
            };

            var annc4 = new Announcement()
            {
                Title = "Game-winning shot 4",
                Description = "Game winning shot omg omg, ame winning shot omg omg, ame winning shot omg omg, ame winning shot omg omg,ame winning shot omg omg,ame winning shot omg omg,ame winning shot omg omg",
                PostedTime = DateTime.Now
            };

            var eventSpiderMan = new Event()
            {
                Title = "The Amazing Spider-Man",
                Description = "The Amazing Spider-Man (abbreviated as ASM) is an American team event published by Marvel teams, featuring the adventures of the fictional superhero Spider-Man. Being the mainstream continuity of the franchise, it began publication in 1963 as a monthly periodical and was published continuously, with a brief interruption in 1995, until its relaunch with a new numbering order in 1999. In 2003 the series reverted to the numbering order of the first volume. The title has occasionally been published biweekly, and was published three times a month from 2008 to 2010. A film named after the was released July 3, 2012.",
                Date = new DateTime(2018, 6, 23)
            };
            var eventIronMan = new Event()
            {
                Title = "The Invincible Iron Man",
                Description = "Iron Man (Tony Stark) is a fictional superhero appearing in American team published by Marvel teams, as well as its associated media. The character was created by writer and editor Stan Lee, developed by scripter Larry Lieber, and designed by Don Heck and Jack Kirby. He made his first appearance in Tales of Suspense #39 (cover dated March 1963).",
                Date = new DateTime(2018, 7, 25)
            };
            var eventBone = new Event()
            {
                Title = "Bone",
                Description = "Bone is an independently published team event, written and illustrated by Jeff Smith, originally serialized in 55 irregularly released issues from 1991 to 2004.",
                Date = new DateTime(2018, 9, 3)
            };

            var tmStanLee = new TeamMember()
            {
                Name = "Stan Lee"
            };
            var tmSteveDitko = new TeamMember()
            {
                Name = "Steve Ditko"
            };
            var tmArchieGoodwin = new TeamMember()
            {
                Name = "Archie Goodwin"
            };
            var tmGeneColan = new TeamMember()
            {
                Name = "Gene Colan"
            };
            var tmJohnnyCraig = new TeamMember()
            {
                Name = "Johnny Craig"
            };
            var tmJeffSmith = new TeamMember()
            {
                Name = "Jeff Smith"
            };

            var roleCoach = new Role()
            {
                Name = "Coach"
            };
            var rolePlayer = new Role()
            {
                Name = "Player"
            };

            var team1 = new Team()
            {
                Event = eventSpiderMan,
                TeamName = "Cleveland Cavaliers"
            };
            team1.AddTeamMember(tmStanLee, roleCoach);
            team1.AddTeamMember(tmSteveDitko, rolePlayer);
            context.Teams.Add(team1);

            var team2 = new Team()
            {
                Event = eventSpiderMan,
                TeamName = "Houston Rockets"
            };
            team2.AddTeamMember(tmStanLee, roleCoach);
            team2.AddTeamMember(tmSteveDitko, rolePlayer);
            context.Teams.Add(team2);

            var team3 = new Team()
            {
                Event = eventSpiderMan,
                TeamName = "Toronto Rapotors"
            };
            team3.AddTeamMember(tmStanLee, roleCoach);
            team3.AddTeamMember(tmSteveDitko, rolePlayer);
            context.Teams.Add(team3);

            var team4 = new Team()
            {
                Event = eventIronMan,
                TeamName = "Golden State Warriors"
            };
            team4.AddTeamMember(tmArchieGoodwin, roleCoach);
            team4.AddTeamMember(tmGeneColan, rolePlayer);
            context.Teams.Add(team4);

            var team5 = new Team()
            {
                Event = eventIronMan,
                TeamName = "New York Jets"
            };
            team5.AddTeamMember(tmArchieGoodwin, roleCoach);
            team5.AddTeamMember(tmJohnnyCraig, rolePlayer);
            context.Teams.Add(team5);

            var team6 = new Team()
            {
                Event = eventIronMan,
                TeamName = "Los Angeles Lakers"
            };
            team6.AddTeamMember(tmArchieGoodwin, roleCoach);
            team6.AddTeamMember(tmJohnnyCraig, rolePlayer);
            context.Teams.Add(team6);

            var team7 = new Team()
            {
                Event = eventBone,
                TeamName = "Boston Celtics"
            };
            team7.AddTeamMember(tmJeffSmith, roleCoach);
            team7.AddTeamMember(tmJeffSmith, rolePlayer);
            context.Teams.Add(team7);

            var team8 = new Team()
            {
                Event = eventBone,
                TeamName = "Philadelphia 76ers"
            };
            team8.AddTeamMember(tmJeffSmith, roleCoach);
            team8.AddTeamMember(tmJeffSmith, rolePlayer);
            context.Teams.Add(team8);

            var team9 = new Team()
            {
                Event = eventBone,
                TeamName = "Chicago Bulls"
            };
            team9.AddTeamMember(tmJeffSmith, roleCoach);
            team9.AddTeamMember(tmJeffSmith, rolePlayer);
            context.Teams.Add(team9);

            context.SaveChanges();
        }
    }
}
