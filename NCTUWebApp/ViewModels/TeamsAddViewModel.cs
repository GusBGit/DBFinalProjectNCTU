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
    /// View model for the "Add Team" view.
    /// </summary>
    public class TeamsAddViewModel
        : TeamsBaseViewModel
    {
        [Display(Name = "Team Member")]
        public int TeamMemberId { get; set; }
        [Display(Name = "Role")]
        public int RoleId { get; set; }

        public SelectList TeamMemberSelectListItems { get; set; }
        public SelectList RoleSelectListItems { get; set; }

        public TeamsAddViewModel()
        {
            // Set the team default values.
            Team.TeamName = "Team Name";
        }

        /// <summary>
        /// Initializes the view model.
        /// </summary>
        public override void Init(Repository repository)
        {
            base.Init(repository);

            TeamMemberSelectListItems = new SelectList(
                repository.GetTeamMembers(),
                "Id", "Name");
            RoleSelectListItems = new SelectList(
                repository.GetRoles(), 
                "Id", "Name");
        }
    }
}