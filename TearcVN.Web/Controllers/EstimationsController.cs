using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TearcVN.DataAccess;

namespace TearcVN.Web.Controllers
{
    public class EstimationsController : Controller
    {
        private Entities db = new Entities();

        // GET: Estimations
        public ActionResult Index()
        {
            var estimations = db.Estimations.Include(e => e.Floor).Include(e => e.Product).Include(e => e.Project).Include(e => e.User).Include(e => e.User1);
            return View(estimations.ToList());
        }

        // GET: Estimations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estimation estimation = db.Estimations.Find(id);
            if (estimation == null)
            {
                return HttpNotFound();
            }
            return View(estimation);
        }

        // GET: Estimations/Create
        public ActionResult Create()
        {
            ViewBag.FloorId = new SelectList(db.Floors, "Id", "Name");
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name");
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name");
            ViewBag.CreatedByUserID = new SelectList(db.Users, "Id", "Name");
            ViewBag.LastUpdatedByUserID = new SelectList(db.Users, "Id", "Name");
            return View();
        }

        // POST: Estimations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ProjectId,FloorId,ProductId,Number,Active,CreatedTime,LastUpdatedTime,CreatedByUserID,LastUpdatedByUserID")] Estimation estimation)
        {
            if (ModelState.IsValid)
            {
                db.Estimations.Add(estimation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FloorId = new SelectList(db.Floors, "Id", "Name", estimation.FloorId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", estimation.ProductId);
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name", estimation.ProjectId);
            ViewBag.CreatedByUserID = new SelectList(db.Users, "Id", "Name", estimation.CreatedByUserID);
            ViewBag.LastUpdatedByUserID = new SelectList(db.Users, "Id", "Name", estimation.LastUpdatedByUserID);
            return View(estimation);
        }

        // GET: Estimations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estimation estimation = db.Estimations.Find(id);
            if (estimation == null)
            {
                return HttpNotFound();
            }
            ViewBag.FloorId = new SelectList(db.Floors, "Id", "Name", estimation.FloorId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", estimation.ProductId);
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name", estimation.ProjectId);
            ViewBag.CreatedByUserID = new SelectList(db.Users, "Id", "Name", estimation.CreatedByUserID);
            ViewBag.LastUpdatedByUserID = new SelectList(db.Users, "Id", "Name", estimation.LastUpdatedByUserID);
            return View(estimation);
        }

        // POST: Estimations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ProjectId,FloorId,ProductId,Number,Active,CreatedTime,LastUpdatedTime,CreatedByUserID,LastUpdatedByUserID")] Estimation estimation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estimation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FloorId = new SelectList(db.Floors, "Id", "Name", estimation.FloorId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", estimation.ProductId);
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name", estimation.ProjectId);
            ViewBag.CreatedByUserID = new SelectList(db.Users, "Id", "Name", estimation.CreatedByUserID);
            ViewBag.LastUpdatedByUserID = new SelectList(db.Users, "Id", "Name", estimation.LastUpdatedByUserID);
            return View(estimation);
        }

        // GET: Estimations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estimation estimation = db.Estimations.Find(id);
            if (estimation == null)
            {
                return HttpNotFound();
            }
            return View(estimation);
        }

        // POST: Estimations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estimation estimation = db.Estimations.Find(id);
            db.Estimations.Remove(estimation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
