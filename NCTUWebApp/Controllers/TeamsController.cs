using NCTUShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using NCTUWebApp.ViewModels;
using System.Net;
using System.Data.Entity.Infrastructure;
using NCTUShared.Data;

namespace NCTUWebApp.Controllers
{
    /// <summary>
    /// Controller for the "Teams" section of the website.
    /// </summary>
    public class TeamsController : BaseController
    {
        private TeamsRepository _teamsRepository = null;

        public TeamsController()
        {
            _teamsRepository = new TeamsRepository(Context);
        }

        public ActionResult Index()
        {
            var teams = _teamsRepository.GetList();

            return View(teams);
        }

        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var team = _teamsRepository.Get((int)id);

            if (team == null)
            {
                return HttpNotFound();
            }

            // Sort the team members.
            team.TeamMembers = team.TeamMembers.OrderBy(a => a.Role.Name).ToList();

            return View(team);
        }

        public ActionResult Add()
        {
            var viewModel = new TeamsAddViewModel();

            viewModel.Init(Repository);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(TeamsAddViewModel viewModel)
        {
            ValidateTeam(viewModel.Team);

            if (ModelState.IsValid)
            {
                var team = viewModel.Team;
                team.AddTeamMember(viewModel.TeamMemberId, viewModel.RoleId);

                _teamsRepository.Add(team);

                TempData["Message"] = "Your team was successfully added!";

                return RedirectToAction("Detail", new { id = team.Id });
            }

            viewModel.Init(Repository);

            return View(viewModel);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var team = _teamsRepository.Get((int)id, 
                includeRelatedEntities: false);

            if (team == null)
            {
                return HttpNotFound();
            }

            var viewModel = new TeamsEditViewModel()
            {
                Team = team
            };
            viewModel.Init(Repository);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(TeamsEditViewModel viewModel)
        {
            ValidateTeam(viewModel.Team);
            
            if (ModelState.IsValid)
            {
                var team = viewModel.Team;

                _teamsRepository.Update(team);

                TempData["Message"] = "Your team was successfully updated!";

                return RedirectToAction("Detail", new { id = team.Id });
            }

            viewModel.Init(Repository);

            return View(viewModel);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var team = _teamsRepository.Get((int)id);

            if (team == null)
            {
                return HttpNotFound();
            }

            return View(team);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            _teamsRepository.Delete(id);

            TempData["Message"] = "Your team was successfully deleted!";

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Validates a team on the server
        /// before adding a new record or updating an existing record.
        /// </summary>
        /// <param name="team">The team to validate.</param>
        private void ValidateTeam(Team team)
        {
            // If there aren't any "EventId" and "TeamName" field validation errors...
            if (ModelState.IsValidField("Team.EventId") &&
                ModelState.IsValidField("Team.TeamName"))
            {
                // Then make sure that the provided team name is unique for the provided event.
                // TODO Call method to check if the issue number is available for this team.
                if (_teamsRepository.TeamEventHasName(team.Id, team.EventId, team.TeamName))
                {
                    ModelState.AddModelError("Team.TeamName",
                        "The provided Issue Number has already been entered for the selected Event.");
                }
            }
        }

    }
}