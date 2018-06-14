using ComicBookLibraryManager.Models;
using System;
using System.Data.Entity;

namespace ComicBookLibraryManager.Data
{
    /// <summary>
    /// Custom database initializer class used to populate
    /// the database with seed data.
    /// </summary>
    internal class DatabaseInitializer : DropCreateDatabaseIfModelChanges<Context>
    {
        protected override void Seed(Context context)
        {
            // This is our database's seed data...
            // 3 events, 6 team members, 2 roles, and 9 teams.

            var eventSpiderMan = new Event()
            {
                Title = "The Amazing Spider-Man",
                Description = "The Amazing Spider-Man (abbreviated as ASM) is an American team event published by Marvel teams, featuring the adventures of the fictional superhero Spider-Man. Being the mainstream continuity of the franchise, it began publication in 1963 as a monthly periodical and was published continuously, with a brief interruption in 1995, until its relaunch with a new numbering order in 1999. In 2003 the series reverted to the numbering order of the first volume. The title has occasionally been published biweekly, and was published three times a month from 2008 to 2010. A film named after the was released July 3, 2012."
            };
            var eventIronMan = new Event()
            {
                Title = "The Invincible Iron Man",
                Description = "Iron Man (Tony Stark) is a fictional superhero appearing in American team published by Marvel teams, as well as its associated media. The character was created by writer and editor Stan Lee, developed by scripter Larry Lieber, and designed by Don Heck and Jack Kirby. He made his first appearance in Tales of Suspense #39 (cover dated March 1963)."
            };
            var eventBone = new Event()
            {
                Title = "Bone",
                Description = "Bone is an independently published team event, written and illustrated by Jeff Smith, originally serialized in 55 irregularly released issues from 1991 to 2004."
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

            var roleScript = new Role()
            {
                Name = "Script"
            };
            var rolePencils = new Role()
            {
                Name = "Pencils"
            };

            var team1 = new Team()
            {
                Event = eventSpiderMan,
                IssueNumber = 1,
                Description = "As Peter Parker and Aunt May struggle to pay the bills after Uncle Bens death, Spider-Man must try to save a doomed John Jameson from his out of control spacecraft. / Spideys still trying to make ends meet so he decides to try and join the Fantastic Four. When that becomes public knowledge the Chameleon decides to frame Spider-Man and steals missile defense plans disguised as Spidey.",
                PublishedOn = new DateTime(1963, 3, 1),
                AverageRating = 7.1m
            };
            team1.AddTeamMember(tmStanLee, roleScript);
            team1.AddTeamMember(tmSteveDitko, rolePencils);
            context.Teams.Add(team1);

            var team2 = new Team()
            {
                Event = eventSpiderMan,
                IssueNumber = 2,
                Description = "The Vulture becomes the city's most feared thief. Spider-Man must find a way to figure out his secrets and defeat this winged menace. / Spider-Man is up against The Tinkerer and a race of aliens who are trying to invade Earth.",
                PublishedOn = new DateTime(1963, 5, 1),
                AverageRating = 6.8m
            };
            team2.AddTeamMember(tmStanLee, roleScript);
            team2.AddTeamMember(tmSteveDitko, rolePencils);
            context.Teams.Add(team2);

            var team3 = new Team()
            {
                Event = eventSpiderMan,
                IssueNumber = 3,
                Description = "Spider-Man battles Doctor Octopus and is defeated, he considers himself a failure until the Human Torch gives a speech to his class which inspires him to go in prepared and win the day, leaving Doctor Octopus under arrest. Spider-Man visits the Torch with words of thanks.",
                PublishedOn = new DateTime(1963, 7, 1),
                AverageRating = 6.9m
            };
            team3.AddTeamMember(tmStanLee, roleScript);
            team3.AddTeamMember(tmSteveDitko, rolePencils);
            context.Teams.Add(team3);

            var team4 = new Team()
            {
                Event = eventIronMan,
                IssueNumber = 1,
                Description = "A.I.M. manages to make three duplicates of the Iron Man armor.",
                PublishedOn = new DateTime(1968, 5, 1),
                AverageRating = 7.6m
            };
            team4.AddTeamMember(tmArchieGoodwin, roleScript);
            team4.AddTeamMember(tmGeneColan, rolePencils);
            context.Teams.Add(team4);

            var team5 = new Team()
            {
                Event = eventIronMan,
                IssueNumber = 2,
                Description = "Stark competitor Drexel Cord builds a robot to destroy Iron Man.",
                PublishedOn = new DateTime(1968, 6, 1),
                AverageRating = 6.7m
            };
            team5.AddTeamMember(tmArchieGoodwin, roleScript);
            team5.AddTeamMember(tmJohnnyCraig, rolePencils);
            context.Teams.Add(team5);

            var team6 = new Team()
            {
                Event = eventIronMan,
                IssueNumber = 3,
                Description = "While helping Stark, Happy once again turns into the Freak.",
                PublishedOn = new DateTime(1968, 7, 1),
                AverageRating = 6.8m
            };
            team6.AddTeamMember(tmArchieGoodwin, roleScript);
            team6.AddTeamMember(tmJohnnyCraig, rolePencils);
            context.Teams.Add(team6);

            var team7 = new Team()
            {
                Event = eventBone,
                IssueNumber = 1,
                Description = "Fone Bone, Smiley Bone and Phoney Bone are run out of Boneville and get separated in the desert. Fone Bone finds his way to the valley.",
                PublishedOn = new DateTime(1991, 7, 1),
                AverageRating = 7.1m
            };
            team7.AddTeamMember(tmJeffSmith, roleScript);
            team7.AddTeamMember(tmJeffSmith, rolePencils);
            context.Teams.Add(team7);

            var team8 = new Team()
            {
                Event = eventBone,
                IssueNumber = 2,
                Description = "While babysitting Miz Possum's children, Bone is chased by Rat Creatures, is saved by the Dragon and finally finds Thorn.",
                PublishedOn = new DateTime(1991, 9, 1),
                AverageRating = 6.9m
            };
            team8.AddTeamMember(tmJeffSmith, roleScript);
            team8.AddTeamMember(tmJeffSmith, rolePencils);
            context.Teams.Add(team8);

            var team9 = new Team()
            {
                Event = eventBone,
                IssueNumber = 3,
                Description = "Grandma Ben returns from Barrelhaven and Phoney Bone and Bone reunite.",
                PublishedOn = new DateTime(1991, 12, 1),
                AverageRating = 6.9m
            };
            team9.AddTeamMember(tmJeffSmith, roleScript);
            team9.AddTeamMember(tmJeffSmith, rolePencils);
            context.Teams.Add(team9);

            context.SaveChanges();
        }
    }
}
