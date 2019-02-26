using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project124125125.Models;

namespace Project124125125.Controllers
{
    public class DocumentsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Documents
        [Authorize(Roles = "Manager,Analyst,Programmer,Architect,Tester")]
        public ActionResult Index()
        {
            User loggedinUSer = Session["User"] as User;
            IEnumerable<Document> documents = db.Documents.Where(x => x.Role == loggedinUSer.Role).Include(d=>d.User);
            if(documents == null)
            {
                documents = new List<Document>();
            }

            return View(documents.ToList());
        }
        [Authorize(Roles = "Manager,Analyst,Programmer,Architect,Tester")]
        public ActionResult Complete(int id)
        {
            Document document = db.Documents.Where(x=> x.Id == id).FirstOrDefault();           
            if(document.Role == Roles.Tester)
            {
                return RedirectToAction("Index","Home");
            }
            document.Role += 1;
            db.Entry(document).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        // GET: Documents/Details/5
        [Authorize(Roles = "Manager,Analyst,Programmer,Architect,Tester")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Document document = db.Documents.Find(id);
            if (document == null)
            {
                return HttpNotFound();
            }
            return View(document);
        }

        // GET: Documents/Create
        [Authorize(Roles="Analyst")]
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.Users, "Id", "Username");
            return View();
        }

        // POST: Documents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles="Analyst")]
        public ActionResult Create([Bind(Include = "Id,Name,Text,Role,UserID")] Document document)
        {
            if (ModelState.IsValid)
            {
                User loggedinUSer = Session["User"] as User;
                document.UserID = loggedinUSer.Id;
                document.Role = loggedinUSer.Role;
                db.Documents.Add(document);               
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.Users, "Id", "Username", document.UserID);
            return View(document);
        }

        // GET: Documents/Edit/5
        [Authorize(Roles = "Manager,Analyst,Programmer,Architect,Tester")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Document document = db.Documents.Find(id);
            if (document == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.Users, "Id", "Username", document.UserID);
            return View(document);
        }

        // POST: Documents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager,Analyst,Programmer,Architect,Tester")]
        public ActionResult Edit([Bind(Include = "Id,Name,Text,Role,UserID")] Document document)
        {
            if (ModelState.IsValid)
            {
                User loggedinUSer = Session["User"] as User;
                document.UserID = loggedinUSer.Id;
                document.Role = loggedinUSer.Role;
                db.Entry(document).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.Users, "Id", "Username", document.UserID);
            return View(document);
        }

        // GET: Documents/Delete/5
        [Authorize(Roles = "Manager")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Document document = db.Documents.Find(id);
            if (document == null)
            {
                return HttpNotFound();
            }
            return View(document);
        }

        // POST: Documents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles ="Manager")]
        public ActionResult DeleteConfirmed(int id)
        {
            Document document = db.Documents.Find(id);
            db.Documents.Remove(document);
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
