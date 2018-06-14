using NCTUShared.Data;
using NCTUShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NCTUWebApp.ViewModels
{
    /// <summary>
    /// Base view model class for the "Add Team" 
    /// and "Edit Team" views.
    /// </summary>
    public abstract class TeamsBaseViewModel
    {
        public Team Team { get; set; } = new Team();

        public SelectList EventSelectListItems { get; set; }

        /// <summary>
        /// Initializes the view model.
        /// </summary>
        public virtual void Init(Repository repository)
        {
            EventSelectListItems = new SelectList(
                repository.GetEventsList(),
                "Id", "Title");
        }
    }
}