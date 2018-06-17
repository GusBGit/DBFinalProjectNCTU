using NCTUShared.Data;
using NCTUShared.Models;
using NCTUWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace NCTUWebApp.Controllers
{
    /// <summary>
    /// Controller for the "Event" section of the website.
    /// </summary>
    [Authorize(Roles="Admin,Manager")]
    public class EventsController : BaseController
    {
        private EventsRepository _eventsRepository = null;
        private TeamsRepository _teamsRepository = null;

        public EventsController()
        {
            _eventsRepository = new EventsRepository(Context);
            _teamsRepository = new TeamsRepository(Context);
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            // TODO Get the event list.
            var events = _eventsRepository.GetList();

            return View(events);
        }

        [AllowAnonymous]
        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var viewModel = new EventsBaseViewModel();
            // TODO Get the event.

            var ev = _eventsRepository.Get((int)id);

            if (ev == null)
            {
                return HttpNotFound();
            }

            viewModel.Init(_eventsRepository, _teamsRepository, (int)id);


            // Sort the teams.
            viewModel.Teams = viewModel.Teams
                .OrderBy(cb => cb.TeamName)
                .ToList();
            
            return View(viewModel);
        }

        public ActionResult Add()
        {
            var ev = new Event();

            return View(ev);
        }

        [HttpPost]
        public ActionResult Add(Event ev)
        {
            ValidateEvent(ev);

            if (ModelState.IsValid)
            {
         
                _eventsRepository.Add(ev);

                TempData["Message"] = "Your event was successfully added!";

                return RedirectToAction("Detail", new { id = ev.Id });
            }

            return View(ev);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var ev = _eventsRepository
                .Get((int)id, includeRelatedEntities: false);

            if (ev == null)
            {
                return HttpNotFound();
            }

            return View(ev);
        }

        [HttpPost]
        public ActionResult Edit(Event ev)
        {
            ValidateEvent(ev);

            if (ModelState.IsValid)
            {
                _eventsRepository.Update(ev);

                TempData["Message"] = "Your event was successfully updated!";

                return RedirectToAction("Detail", new { id = ev.Id });
            }

            return View(ev);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var ev = _eventsRepository.Get((int)id);

            if (ev == null)
            {
                return HttpNotFound();
            }

            return View(ev);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            _eventsRepository.Delete(id);

            TempData["Message"] = "Your event was successfully deleted!";

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Validates an event on the server
        /// before adding a new record or updating an existing record.
        /// </summary>
        /// <param name="ev">The event to validate.</param>
        private void ValidateEvent(Event ev)
        {
            // If there aren't any "Title" field validation errors...
            if (ModelState.IsValidField("Title"))
            {
                // Then make sure that the provided title is unique.
                if (_eventsRepository.EventHasTitle(
                        ev.Id, ev.Title))
                {
                    ModelState.AddModelError("Title",
                        "The provided Title is in use by another event.");
                }
            }
        }
    }
}