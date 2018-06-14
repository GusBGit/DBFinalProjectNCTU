using NCTUShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace NCTUWebApp.Controllers
{
    public class AnnouncementsController : Controller
    {
        // GET: Announcements
        public ActionResult Index()
        {
            // TODO Get the announcement list.
            var anncs = new List<Announcement>();

            return View(anncs);
        }
        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // TODO Get the announcement.
            var ann = new Announcement();

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
                // TODO Add the announcement.

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

            // TODO Get the announcement.
            var ann = new Announcement();

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
                // TODO Update the announcement.

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

            // TODO Get the announcement.
            var ann = new Announcement();

            if (ann == null)
            {
                return HttpNotFound();
            }

            return View(ann);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            // TODO Delete the announcement.

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
            //// If there aren't any "Title" field validation errors...
            //if (ModelState.IsValidField("Title"))
            //{
            //    // Then make sure that the provided title is unique.
            //    // TODO Call method to check if the title is available.
            //    if (false)
            //    {
            //        ModelState.AddModelError("Title",
            //            "The provided Title is in use by another announcement.");
            //    }
            //}
        }
    }
}