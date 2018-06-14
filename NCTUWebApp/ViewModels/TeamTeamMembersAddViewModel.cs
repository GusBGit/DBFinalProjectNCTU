using NCTUShared.Data;
using NCTUShared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NCTUWebApp.ViewModels
{
    /// <summary>
    /// The view model for the "Add Team Team Member" view.
    /// </summary>
    public class TeamTeamMembersAddViewModel
    {
        /// <summary>
        /// This property enables model binding to be able to bind the "teamid"
        /// route parameter value to the "Team.Id" model property.
        /// </summary>
        public int TeamId
        {
            get { return Team.Id; }
            set { Team.Id = value; }
        }
        public Team Team { get; set; } = new Team();
        [Display(Name = "Team Member")]
        public int TeamMemberId { get; set; }
        [Display(Name = "Role")]
        public int RoleId { get; set; }

        public SelectList TeamMemberSelectListItems { get; set; }
        public SelectList RoleSelectListItems { get; set; }

        /// <summary>
        /// Initializes the view model.
        /// </summary>
        public void Init(Repository repository, TeamMembersRepository tmr)
        {
            TeamMemberSelectListItems = new SelectList(
                tmr.GetList(),
                "Id", "Name");
            RoleSelectListItems = new SelectList(
                repository.GetRoles(),
                "Id", "Name");
        }
    }
}