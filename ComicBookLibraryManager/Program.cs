using ComicBookLibraryManager.Data;
using ComicBookLibraryManager.Helpers;
using NCTUShared.Models;
using System;
using System.Collections.Generic;

namespace ComicBookLibraryManager
{
    class Program
    {
        // These are the various commands that can be performed 
        // in the app. Each command must have a unique string value.
        const string CommandListTeams = "l";
        const string CommandListTeam = "i";
        const string CommandListTeamProperties = "p";
        const string CommandAddTeam = "a";
        const string CommandUpdateTeam = "u";
        const string CommandDeleteTeam = "d";
        const string CommandSave = "s";
        const string CommandCancel = "c";
        const string CommandQuit = "q";

        //        // A collection of the team editable properties.
        //        // This collection of property names needs to match the list 
        //        // of the properties listed on the Team Detail screen.
        //        readonly static List<string> EditableProperties = new List<string>()
        //        {
        //            "EventId",
        //            "IssueNumber",
        //            "Description",
        //            "PublishedOn",
        //            "AverageRating"
        //        };

        static void Main(string[] args)
        {
            //            string command = CommandListTeams;
            //            IList<int> teamIds = null;

            //            // If the current command doesn't equal the "Quit" command 
            //            // then evaluate and process the command.
            //            while (command != CommandQuit)
            //            {
            //                switch (command)
            //                {
            //                    case CommandListTeams:
            //                        teamIds = ListTeams();
            //                        break;
            //                    case CommandAddTeam:
            //                        AddTeam();
            //                        command = CommandListTeams;
            //                        continue;
            //                    default:
            //                        if (AttemptDisplayTeam(command, teamIds))
            //                        {
            //                            command = CommandListTeams;
            //                            continue;
            //                        }
            //                        else
            //                        {
            //                            ConsoleHelper.OutputLine("Sorry, but I didn't understand that command.");
            //                        }
            //                        break;
            //                }

            //                // List the available commands.
            //                ConsoleHelper.OutputBlankLine();
            //                ConsoleHelper.Output("Commands: ");
            //                int teamCount = Repository.GetTeamCount();
            //                if (teamCount > 0)
            //                {
            //                    ConsoleHelper.Output("Enter a Number 1-{0}, ", teamCount);
            //                }
            //                ConsoleHelper.OutputLine("A - Add, Q - Quit", false);

            //                // Get the next command from the user.
            //                command = ConsoleHelper.ReadInput("Enter a Command: ", true);
            //            }
            //        }

            //        /// <summary>
            //        /// Attempts to parse the provided command as a line number
            //        /// and if successful, displays the Team Detail screen
            //        /// for the referenced team.
            //        /// </summary>
            //        /// <param name="command">The line number command.</param>
            //        /// <param name="teamIds">The collection of team IDs for the displayed team list.</param>
            //        /// <returns>Returns "true" if the team was successfully displayed, otherwise "false".</returns>
            //        private static bool AttemptDisplayTeam(
            //            string command, IList<int> teamIds)
            //        {
            //            var successful = false;
            //            int? teamId = null;

            //            // Only attempt to parse the command to a line number 
            //            // if we have a collection of team IDs available.
            //            if (teamIds != null)
            //            {
            //                // Attempt to parse the command to a line number.
            //                int lineNumber = 0;
            //                int.TryParse(command, out lineNumber);

            //                // If the number is within range then get that team ID.
            //                if (lineNumber > 0 && lineNumber <= teamIds.Count)
            //                {
            //                    teamId = teamIds[lineNumber - 1];
            //                    successful = true;
            //                }
            //            }

            //            // If we have a team ID, then display the team.
            //            if (teamId != null)
            //            {
            //                DisplayTeam(teamId.Value);
            //            }

            //            return successful;
            //        }

            //        /// <summary>
            //        /// Prompts the user for the team values to add 
            //        /// and adds the team to the database.
            //        /// </summary>
            //        private static void AddTeam()
            //        {
            //            ConsoleHelper.ClearOutput();
            //            ConsoleHelper.OutputLine("ADD TEAM");

            //            // Get the team values from the user.

            //            var team = new Team();
            //            team.EventId = GetEventId();
            //            team.IssueNumber = GetIssueNumber();
            //            team.Description = GetDescription();
            //            team.PublishedOn = GetPublishedOnDate();
            //            team.AverageRating = GetAverageRating();

            //            var tmm = new TeamTeamMember();
            //            tmm.TeamMemberId = GetTeamMemberId();
            //            tmm.RoleId = GetRoleId();
            //            team.TeamMembers.Add(tmm);

            //            // Add the team to the database.
            //            Repository.AddTeam(team);
            //        }

            //        /// <summary>
            //        /// Gets the event ID from the user.
            //        /// </summary>
            //        /// <returns>Returns an integer for the selected event ID.</returns>
            //        private static int GetEventId()
            //        {
            //            int? eventId = null;
            //            IList<Event> events = Repository.GetEvents();

            //            // While the event ID is null, prompt the user to select a event ID 
            //            // from the provided list.
            //            while (eventId == null)
            //            {
            //                ConsoleHelper.OutputBlankLine();

            //                foreach (Event s in events)
            //                {
            //                    ConsoleHelper.OutputLine("{0}) {1}", events.IndexOf(s) + 1, s.Title);
            //                }

            //                // Get the line number for the selected event.
            //                string lineNumberInput = ConsoleHelper.ReadInput(
            //                    "Enter the line number of the event that you want to add a team to: ");

            //                // Attempt to parse the user's input to a line number.
            //                int lineNumber = 0;
            //                if (int.TryParse(lineNumberInput, out lineNumber))
            //                {
            //                    if (lineNumber > 0 && lineNumber <= events.Count)
            //                    {
            //                        eventId = events[lineNumber - 1].Id;
            //                    }
            //                }

            //                // If we weren't able to parse the provided line number 
            //                // to an event ID then display an error message.
            //                if (eventId == null)
            //                {
            //                    ConsoleHelper.OutputLine("Sorry, but that wasn't a valid line number.");
            //                }
            //            }

            //            return eventId.Value;
            //        }

            //        /// <summary>
            //        /// Gets the team member ID from the user.
            //        /// </summary>
            //        /// <returns>Returns an integer for the selected team member ID.</returns>
            //        private static int GetTeamMemberId()
            //        {
            //            int? teamMemberId = null;
            //            IList<TeamMember> teamMembers = Repository.GetTeamMembers();

            //            // While the team member ID is null, prompt the user to select a team member ID 
            //            // from the provided list.
            //            while (teamMemberId == null)
            //            {
            //                ConsoleHelper.OutputBlankLine();

            //                foreach (TeamMember a in teamMembers)
            //                {
            //                    ConsoleHelper.OutputLine("{0}) {1}", teamMembers.IndexOf(a) + 1, a.Name);
            //                }

            //                // Get the line number for the selected team member.
            //                string lineNumberInput = ConsoleHelper.ReadInput(
            //                    "Enter the line number of the team member that you want to add to this team: ");

            //                // Attempt to parse the user's input to a line number.
            //                int lineNumber = 0;
            //                if (int.TryParse(lineNumberInput, out lineNumber))
            //                {
            //                    if (lineNumber > 0 && lineNumber <= teamMembers.Count)
            //                    {
            //                        teamMemberId = teamMembers[lineNumber - 1].Id;
            //                    }
            //                }

            //                // If we weren't able to parse the provided line number 
            //                // to a team member ID then display an error message.
            //                if (teamMemberId == null)
            //                {
            //                    ConsoleHelper.OutputLine("Sorry, but that wasn't a valid line number.");
            //                }
            //            }

            //            return teamMemberId.Value;
            //        }

            //        /// <summary>
            //        /// Gets the role ID from the user.
            //        /// </summary>
            //        /// <returns>Returns an integer for the selected role ID.</returns>
            //        private static int GetRoleId()
            //        {
            //            int? roleId = null;
            //            IList<Role> roles = Repository.GetRoles();

            //            // While the role ID is null, prompt the user to select a role ID 
            //            // from the provided list.
            //            while (roleId == null)
            //            {
            //                ConsoleHelper.OutputBlankLine();

            //                foreach (Role r in roles)
            //                {
            //                    ConsoleHelper.OutputLine("{0}) {1}", roles.IndexOf(r) + 1, r.Name);
            //                }

            //                // Get the line number for the selected role.
            //                string lineNumberInput = ConsoleHelper.ReadInput(
            //                    "Enter the line number of the role that the team member had on this team: ");

            //                // Attempt to parse the user's input to a line number.
            //                int lineNumber = 0;
            //                if (int.TryParse(lineNumberInput, out lineNumber))
            //                {
            //                    if (lineNumber > 0 && lineNumber <= roles.Count)
            //                    {
            //                        roleId = roles[lineNumber - 1].Id;
            //                    }
            //                }

            //                // If we weren't able to parse the provided line number 
            //                // to an role ID then display an error message.
            //                if (roleId == null)
            //                {
            //                    ConsoleHelper.OutputLine("Sorry, but that wasn't a valid line number.");
            //                }
            //            }

            //            return roleId.Value;
            //        }

            //        /// <summary>
            //        /// Gets the issue number from the user.
            //        /// </summary>
            //        /// <returns>Returns an integer for the provided issue number.</returns>
            //        private static int GetIssueNumber()
            //        {
            //            int issueNumber = 0;

            //            // While the issue number is less than or equal to "0", 
            //            // prompt the user to provide an issue number.
            //            while (issueNumber <= 0)
            //            {
            //                // Get the issue number from the user.
            //                string issueNumberInput = ConsoleHelper.ReadInput(
            //                    "Enter an issue number: ");

            //                // Attempt to parse the user's input to an integer.
            //                int.TryParse(issueNumberInput, out issueNumber);

            //                // If we weren't able to parse the provided issue number 
            //                // to an integer then display an error message.
            //                if (issueNumber <= 0)
            //                {
            //                    ConsoleHelper.OutputLine("Sorry, but that wasn't a valid issue number.");
            //                }
            //            }

            //            return issueNumber;
            //        }

            //        /// <summary>
            //        /// Gets the description from the user.
            //        /// </summary>
            //        /// <returns>Returns a string for the provided description.</returns>
            //        private static string GetDescription()
            //        {
            //            return ConsoleHelper.ReadInput(
            //                "Enter the description: ");
            //        }

            //        /// <summary>
            //        /// Gets the published on date from the user.
            //        /// </summary>
            //        /// <returns>Returns a date/time for the provided published on date.</returns>
            //        private static DateTime GetPublishedOnDate()
            //        {
            //            DateTime publishedOnDate = DateTime.MinValue;

            //            // While the published on date equals the minimum date/time value, 
            //            // prompt the user to provide a published on date.
            //            while (publishedOnDate == DateTime.MinValue)
            //            {
            //                // Get the published on date from the user.
            //                string publishedOnDateInput = ConsoleHelper.ReadInput(
            //                    "Enter the date this team was published on: ");

            //                // Attempt to parse the user's input to a date/time.
            //                DateTime.TryParse(publishedOnDateInput, out publishedOnDate);

            //                // If we weren't able to parse the provided published on date 
            //                // to a date/time then display an error message.
            //                if (publishedOnDate == DateTime.MinValue)
            //                {
            //                    ConsoleHelper.OutputLine("Sorry, but that wasn't a valid date.");
            //                }
            //            }

            //            return publishedOnDate;
            //        }

            //        /// <summary>
            //        /// Gets the average rating from the user.
            //        /// </summary>
            //        /// <returns>Returns a decimal for the provided average rating.</returns>
            //        private static decimal? GetAverageRating()
            //        {
            //            decimal? averageRating = null;
            //            var promptUser = true;

            //            // Continue to prompt the user for an average rating 
            //            // until we get a valid value or an empty value (the 
            //            // average rating is not a required value).
            //            while (promptUser)
            //            {
            //                // Get the average rating from the user.
            //                string averageRatingInput = ConsoleHelper.ReadInput(
            //                    "Enter the average rating for this team: ");

            //                // Did we get a value from the user?
            //                if (!string.IsNullOrWhiteSpace(averageRatingInput))
            //                {
            //                    // Attempt to parse the user's input to a decimal.
            //                    decimal averageRatingValue;
            //                    if (decimal.TryParse(averageRatingInput, out averageRatingValue))
            //                    {
            //                        averageRating = averageRatingValue;

            //                        // If we were able to parse the provided average rating 
            //                        // then set the prompt user flag to "false" so we 
            //                        // break out of the while loop.
            //                        promptUser = false;
            //                    }
            //                    else
            //                    {
            //                        // If we weren't able to parse the provided average rating 
            //                        // to a decimal then display an error message.
            //                        ConsoleHelper.OutputLine("Sorry, but that wasn't a valid number.");
            //                    }
            //                }
            //                else
            //                {
            //                    // If we didn't get a value from the user 
            //                    // then set the prompt user flag to "false" 
            //                    // so we break out of the while loop.
            //                    promptUser = false;
            //                }
            //            }

            //            return averageRating;
            //        }

            //        /// <summary>
            //        /// Retrieves the teams from the database and lists
            //        /// them to the screen.
            //        /// </summary>
            //        /// <returns>A collection of the team IDs in the same order 
            //        /// as the teams were listed to facilitate selecting a team 
            //        /// by its line number.</returns>
            //        private static IList<int> ListTeams()
            //        {
            //            var teamIds = new List<int>();
            //            IList<Team> teams = Repository.GetTeams();

            //            ConsoleHelper.ClearOutput();
            //            ConsoleHelper.OutputLine("TEAMS");

            //            ConsoleHelper.OutputBlankLine();

            //            foreach (Team team in teams)
            //            {
            //                teamIds.Add(team.Id);

            //                ConsoleHelper.OutputLine("{0}) {1}",
            //                    teams.IndexOf(team) + 1,
            //                    team.DisplayText);
            //            }

            //            return teamIds;
            //        }

            //        /// <summary>
            //        /// Displays the team detail for the provided team ID.
            //        /// </summary>
            //        /// <param name="teamId">The team ID to display detail for.</param>
            //        private static void DisplayTeam(int teamId)
            //        {
            //            string command = CommandListTeam;

            //            // If the current command doesn't equal the "Cancel" command 
            //            // then evaluate and process the command.
            //            while (command != CommandCancel)
            //            {
            //                switch (command)
            //                {
            //                    case CommandListTeam:
            //                        ListTeam(teamId);
            //                        break;
            //                    case CommandUpdateTeam:
            //                        UpdateTeam(teamId);
            //                        command = CommandListTeam;
            //                        continue;
            //                    case CommandDeleteTeam:
            //                        if (DeleteTeam(teamId))
            //                        {
            //                            command = CommandCancel;
            //                        }
            //                        else
            //                        {
            //                            command = CommandListTeam;
            //                        }
            //                        continue;
            //                    default:
            //                        ConsoleHelper.OutputLine("Sorry, but I didn't understand that command.");
            //                        break;
            //                }

            //                // List the available commands.
            //                ConsoleHelper.OutputBlankLine();
            //                ConsoleHelper.Output("Commands: ");
            //                ConsoleHelper.OutputLine("U - Update, D - Delete, C - Cancel", false);

            //                // Get the next command from the user.
            //                command = ConsoleHelper.ReadInput("Enter a Command: ", true);
            //            }
            //        }

            //        /// <summary>
            //        /// Confirms that the user wants to delete the team
            //        /// for the provided team ID and if so, deletes the 
            //        /// team from the database.
            //        /// </summary>
            //        /// <param name="teamId">The team ID to delete.</param>
            //        /// <returns>Returns "true" if the team was deleted, otherwise "false".</returns>
            //        private static bool DeleteTeam(int teamId)
            //        {
            //            var successful = false;

            //            // Prompt the user if they want to continue with deleting this team.
            //            string input = ConsoleHelper.ReadInput(
            //                "Are you sure you want to delete this team (Y/N)? ", true);

            //            // If the user entered "y", then delete the team.
            //            if (input == "y")
            //            {
            //                Repository.DeleteTeam(teamId);
            //                successful = true;
            //            }

            //            return successful;
            //        }

            //        /// <summary>
            //        /// Lists the detail for the provided team ID.
            //        /// </summary>
            //        /// <param name="teamId">The team ID to list detail for.</param>
            //        private static void ListTeam(int teamId)
            //        {
            //            Team team = Repository.GetTeam(teamId);

            //            ConsoleHelper.ClearOutput();
            //            ConsoleHelper.OutputLine("TEAM DETAIL");

            //            ConsoleHelper.OutputLine(team.DisplayText);

            //            if (!string.IsNullOrWhiteSpace(team.Description))
            //            {
            //                ConsoleHelper.OutputLine(team.Description);
            //            }

            //            ConsoleHelper.OutputBlankLine();
            //            ConsoleHelper.OutputLine("Published On: {0}", team.PublishedOn.ToShortDateString());
            //            ConsoleHelper.OutputLine("Average Rating: {0}",
            //                team.AverageRating != null ?
            //                team.AverageRating.Value.ToString("n2") : "N/A");

            //            ConsoleHelper.OutputLine("Team Members");

            //            foreach (TeamTeamMember tmm in team.TeamMembers)
            //            {
            //                ConsoleHelper.OutputLine("{0} - {1}", tmm.TeamMember.Name, tmm.Role.Name);
            //            }
            //        }

            //        /// <summary>
            //        /// Lists the editable properties for the provided team ID 
            //        /// and prompts the user to select a property to edit.
            //        /// </summary>
            //        /// <param name="teamId">The team ID to update.</param>
            //        private static void UpdateTeam(int teamId)
            //        {
            //            Team team = Repository.GetTeam(teamId);

            //            string command = CommandListTeamProperties;

            //            // If the current command doesn't equal the "Cancel" command 
            //            // then evaluate and process the command.
            //            while (command != CommandCancel)
            //            {
            //                switch (command)
            //                {
            //                    case CommandListTeamProperties:
            //                        ListTeamProperties(team);
            //                        break;
            //                    case CommandSave:
            //                        Repository.UpdateTeam(team);
            //                        command = CommandCancel;
            //                        continue;
            //                    default:
            //                        if (AttemptUpdateTeamProperty(command, team))
            //                        {
            //                            command = CommandListTeamProperties;
            //                            continue;
            //                        }
            //                        else
            //                        {
            //                            ConsoleHelper.OutputLine("Sorry, but I didn't understand that command.");
            //                        }
            //                        break;
            //                }

            //                // List the available commands.
            //                ConsoleHelper.OutputBlankLine();
            //                ConsoleHelper.Output("Commands: ");
            //                if (EditableProperties.Count > 0)
            //                {
            //                    ConsoleHelper.Output("Enter a Number 1-{0}, ", EditableProperties.Count);
            //                }
            //                ConsoleHelper.OutputLine("S - Save, C - Cancel", false);

            //                // Get the next command from the user.
            //                command = ConsoleHelper.ReadInput("Enter a Command: ", true);
            //            }

            //            ConsoleHelper.ClearOutput();
            //        }

            //        /// <summary>
            //        /// Attempts to parse the provided command as a line number 
            //        /// and if successful, calls the appropriate user input method 
            //        /// for the selected team property.
            //        /// </summary>
            //        /// <param name="command">The line number command.</param>
            //        /// <param name="team">The team to update.</param>
            //        /// <returns>Returns "true" if the team property was successfully updated, otherwise "false".</returns>
            //        private static bool AttemptUpdateTeamProperty(
            //            string command, Team team)
            //        {
            //            var successful = false;

            //            // Attempt to parse the command to a line number.
            //            int lineNumber = 0;
            //            int.TryParse(command, out lineNumber);

            //            // If the number is within range then get that team ID.
            //            if (lineNumber > 0 && lineNumber <= EditableProperties.Count)
            //            {
            //                // Retrieve the property name for the provided line number.
            //                string propertyName = EditableProperties[lineNumber - 1];

            //                // Switch on the provided property name and call the 
            //                // associated user input method for that property name.
            //                switch (propertyName)
            //                {
            //                    case "EventId":
            //                        team.EventId = GetEventId();
            //                        team.Event = Repository.GetEvent(team.EventId);
            //                        break;
            //                    case "IssueNumber":
            //                        team.IssueNumber = GetIssueNumber();
            //                        break;
            //                    case "Description":
            //                        team.Description = GetDescription();
            //                        break;
            //                    case "PublishedOn":
            //                        team.PublishedOn = GetPublishedOnDate();
            //                        break;
            //                    case "AverageRating":
            //                        team.AverageRating = GetAverageRating();
            //                        break;
            //                    default:
            //                        break;
            //                }

            //                successful = true;
            //            }

            //            return successful;
            //        }

            //        /// <summary>
            //        /// Lists the editable team properties to the screen.
            //        /// </summary>
            //        /// <param name="team">The team property values to list.</param>
            //        private static void ListTeamProperties(Team team)
            //        {
            //            ConsoleHelper.ClearOutput();
            //            ConsoleHelper.OutputLine("UPDATE TEAM");

            //            // NOTE: This list of team property values 
            //            // needs to match the collection of editable properties 
            //            // declared at the top of this file.
            //            ConsoleHelper.OutputBlankLine();
            //            ConsoleHelper.OutputLine("1) Event: {0}", team.Event.Title);
            //            ConsoleHelper.OutputLine("2) Issue Number: {0}", team.IssueNumber);
            //            ConsoleHelper.OutputLine("3) Description: {0}", team.Description);
            //            ConsoleHelper.OutputLine("4) Published On: {0}", team.PublishedOn.ToShortDateString());
            //            ConsoleHelper.OutputLine("5) Average Rating: {0}", team.AverageRating);
        }
    }
}
