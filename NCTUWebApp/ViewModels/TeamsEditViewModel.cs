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
    /// View model for the "Edit Team" view.
    /// </summary>
    public class TeamsEditViewModel 
        : TeamsBaseViewModel
    {
        /// <summary>
        /// This property enables model binding to be able to bind the "id"
        /// route parameter value to the "Team.Id" model property.
        /// </summary>
        public int Id
        {
            get { return Team.Id; }
            set { Team.Id = value; }
        }
    }
}