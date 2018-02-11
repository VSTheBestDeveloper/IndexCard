using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IndexCard.Models;
using IndexCard.Entities;

namespace IndexCard.Controllers
{
   [Authorize]
    public class QnAsController : Controller
    {
        private IIndexCardRepo getData;
        private MVCDBEntities db = new MVCDBEntities();

        public QnAsController()
        {
            getData = new IndexCardRepo();
        }

        public QnAsController(IIndexCardRepo dbEntity)
        {
            getData = (IIndexCardRepo) dbEntity;
        }
        
        // GET: QnAs
        public ActionResult Index()
        {
            return View(db.QnAs.ToList());
        }

        // GET: QnAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QnA qnA = db.QnAs.Find(id);
            if (qnA == null)
            {
                return HttpNotFound();
            }
            return View(qnA);
        }

        // GET: IndexQuestion
        [AllowAnonymous]
        public ViewResult IndexCardDisplay(/*int id*/)
        {
            var kvp = getData.GetQuestionAnswer();
            var model = new QnA()
            {
                Question = kvp.Key,
                Answer = kvp.Value
            };

            return View(model);
        }

        // GET: QnAs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QnAs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "QnAId,Question,Answer")] QnA qnA)
        {
            if (ModelState.IsValid)
            {
                db.QnAs.Add(qnA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(qnA);
        }

        // GET: QnAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QnA qnA = db.QnAs.Find(id);
            if (qnA == null)
            {
                return HttpNotFound();
            }
            return View(qnA);
        }

        // POST: QnAs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "QnAId,Question,Answer")] QnA qnA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(qnA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(qnA);
        }

        // GET: QnAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QnA qnA = db.QnAs.Find(id);
            if (qnA == null)
            {
                return HttpNotFound();
            }
            return View(qnA);
        }

        // POST: QnAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QnA qnA = db.QnAs.Find(id);
            db.QnAs.Remove(qnA);
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
