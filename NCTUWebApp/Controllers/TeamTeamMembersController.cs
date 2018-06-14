using NCTUWebApp.ViewModels;
using NCTUShared.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NCTUShared.Data;

namespace NCTUWebApp.Controllers
{
    /// <summary>
    /// Controller for adding/deleting team members.
    /// </summary>
    public class TeamTeamMembersController : BaseController
    {
        private TeamsRepository _teamsRepository = null;
        private TeamTeamMemberRepository _teamTeamMemberRepository = null;

        public TeamTeamMembersController()
        {
            _teamsRepository = new TeamsRepository(Context);
            _teamTeamMemberRepository = new TeamTeamMemberRepository(Context);
        }

        public ActionResult Add(int teamId)
        {
           
            var team = _teamsRepository.Get(teamId);

            if (team == null)
            {
                return HttpNotFound();
            }

            var viewModel = new TeamTeamMembersAddViewModel()
            {
                Team = team
            };

            viewModel.Init(Repository);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(TeamTeamMembersAddViewModel viewModel)
        {
            ValidateTeamTeamMember(viewModel);

            if (ModelState.IsValid)
            {
                var ttm = new TeamTeamMember()
                {
                    TeamId = viewModel.TeamId,
                    TeamMemberId = viewModel.TeamMemberId,
                    RoleId = viewModel.RoleId
                };
                _teamTeamMemberRepository.Add(ttm);

                TempData["Message"] = "Your team member was successfully added!";

                return RedirectToAction("Detail", "Teams", new { id = viewModel.TeamId });
            }
            
            viewModel.Team = _teamsRepository.Get(viewModel.TeamId);
            viewModel.Init(Repository);

            return View(viewModel);
        }

        public ActionResult Delete(int teamId, int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            // Include the "Team.Event", "TeamMember", and "Role" navigation properties.
            var ttm = _teamTeamMemberRepository.Get((int)id);

            if (ttm == null)
            {
                return HttpNotFound();
            }

            return View(ttm);
        }

        [HttpPost]
        public ActionResult Delete(int teamId, int id)
        {
            _teamTeamMemberRepository.Delete(id);

            TempData["Message"] = "Your team member was successfully deleted!";

            return RedirectToAction("Detail", "Teams", new { id = teamId });
        }

        /// <summary>
        /// Validates a team team member on the server
        /// before adding a new record.
        /// </summary>
        /// <param name="viewModel">The view model containing the values to validate.</param>
        private void ValidateTeamTeamMember(TeamTeamMembersAddViewModel viewModel)
        {
            // If there aren't any "TeamMemberId" and "RoleId" field validation errors...
            if (ModelState.IsValidField("TeamMemberId") &&
                ModelState.IsValidField("RoleId"))
            {
                // Then make sure that this team member and role combination 
                // doesn't already exist for this team.
                if (_teamsRepository.TeamHasTeamMemberRoleCombination(viewModel.TeamId, viewModel.TeamMemberId, viewModel.RoleId))
                {
                    ModelState.AddModelError("TeamMemberId",
                        "This team member and role combination already exists for this team.");
                }
            }
        }

    }
}