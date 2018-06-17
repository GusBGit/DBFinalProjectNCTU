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
    [Authorize(Roles = "Manager,Admin")]
    public class AnnouncementsController : BaseController
    {
        private AnnouncementsRepository _announcementsRepository = null;

        public AnnouncementsController()
        {
            _announcementsRepository = new AnnouncementsRepository(Context);
        }

        // GET: Announcements
        [AllowAnonymous]
        public ActionResult Index()
        {
            // TODO Get the announcement list.
            var anncs = _announcementsRepository.GetList();

            return View(anncs);
        }
        [AllowAnonymous]
        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var ann = _announcementsRepository.Get((int)id);

            if (ann == null)
            {
                return HttpNotFound();
            }

            return View(ann);
        }

        public ActionResult Add()
        {
            var ann = new Announcement();

            return View(ann);
        }

        [HttpPost]
        public ActionResult Add(Announcement ann)
        {
            ValidateAnnouncement(ann);

            if (ModelState.IsValid)
            {
                _announcementsRepository.Add(ann);

                TempData["Message"] = "Your announcement was successfully added!";

                return RedirectToAction("Detail", new { id = ann.Id });
            }

            return View(ann);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var ann = _announcementsRepository.Get((int)id,
                includeRelatedEntities: false);

            if (ann == null)
            {
                return HttpNotFound();
            }

            return View(ann);
        }

        [HttpPost]
        public ActionResult Edit(Announcement ann)
        {
            ValidateAnnouncement(ann);

            if (ModelState.IsValid)
            {
                _announcementsRepository.Update(ann);

                TempData["Message"] = "Your announcement was successfully updated!";

                return RedirectToAction("Detail", new { id = ann.Id });
            }

            return View(ann);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var ann = _announcementsRepository.Get((int)id);

            if (ann == null)
            {
                return HttpNotFound();
            }

            return View(ann);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            _announcementsRepository.Delete(id);

            TempData["Message"] = "Your announcement was successfully deleted!";

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Validates an announcement on the server
        /// before adding a new record or updating an existing record.
        /// </summary>
        /// <param name="ev">The announcement to validate.</param>
        private void ValidateAnnouncement(Announcement ann)
        {
            // If there aren't any "Title" field validation errors...
            if (ModelState.IsValidField("Title"))
            {
                // Then make sure that the provided title is unique.
                // TODO Call method to check if the title is available.
                if (_announcementsRepository.AnnouncementHasTitle(
                        ann.Id, ann.Title))
                {
                    ModelState.AddModelError("Title",
                        "The provided Title is in use by another announcement.");
                }
            }
        }
    }
}