using NCTUShared.Data;
using NCTUShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace NCTUWebApp.Controllers
{
    /// <summary>
    /// Controller for the "TeamMembers" section of the website.
    /// </summary>
    public class TeamMembersController : BaseController
    {
        private TeamMembersRepository _teamMembersRepository = null;

        public TeamMembersController()
        {
            _teamMembersRepository = new TeamMembersRepository(Context);
        }

        public ActionResult Index()
        {
            var teamMembers = _teamMembersRepository.GetList();

            return View(teamMembers);
        }

        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            var teamMember = _teamMembersRepository.Get((int)id);

            if (teamMember == null)
            {
                return HttpNotFound();
            }

            // Sort the teams.
            teamMember.Teams = teamMember.Teams
                .OrderBy(t => t.Team.Event.Title)
                .OrderByDescending(t => t.Team.TeamName)
                .ToList();

            return View(teamMember);
        }

        public ActionResult Add()
        {
            var teamMember = new TeamMember();

            return View(teamMember);
        }

        [HttpPost]
        public ActionResult Add(TeamMember teamMember)
        {
            ValidateTeamMember(teamMember);

            if (ModelState.IsValid)
            {

                _teamMembersRepository.Add(teamMember);

                TempData["Message"] = "Your team member was successfully added!";

                return RedirectToAction("Detail", new { id = teamMember.Id });
            }

            return View(teamMember);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // TODO Get the team member.
            var teamMember = _teamMembersRepository.Get((int)id, 
                includeRelatedEntities: false);

            if (teamMember == null)
            {
                return HttpNotFound();
            }

            return View(teamMember);
        }

        [HttpPost]
        public ActionResult Edit(TeamMember teamMember)
        {
            ValidateTeamMember(teamMember);

            if (ModelState.IsValid)
            {
                _teamMembersRepository.Update(teamMember);

                TempData["Message"] = "Your team member was successfully updated!";

                return RedirectToAction("Detail", new { id = teamMember.Id });
            }

            return View(teamMember);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            var teamMember = _teamMembersRepository.Get((int)id);

            if (teamMember == null)
            {
                return HttpNotFound();
            }

            return View(teamMember);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            _teamMembersRepository.Delete(id);

            TempData["Message"] = "Your team member was successfully deleted!";

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Validates an team member on the server 
        /// before adding a new record or updating an existing record.
        /// </summary>
        /// <param name="teamMember">The team member to validate.</param>
        private void ValidateTeamMember(TeamMember teamMember)
        {
            // If there aren't any "Name" field validation errors...
            if (ModelState.IsValidField("Name"))
            {
                // Then make sure that the provided name is unique.
                // TODO Call method to check if the team member name is available.
                if (_teamMembersRepository.TeamMemberHasName(
                        teamMember.Id, teamMember.Name))
                {
                    ModelState.AddModelError("Name",
                        "The provided Name is in use by another team member.");
                }
            }
        }
    }
}
