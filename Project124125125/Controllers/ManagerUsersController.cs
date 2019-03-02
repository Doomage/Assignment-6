using Project124125125.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Project124125125.Controllers
{
    public class ManagerUsersController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: ManagerUsers
        [Authorize(Roles = "Manager")]
        public ActionResult Index()
        {
            return View(db.ManagerUsers.ToList());
        }

        // GET: ManagerUsers/Details/5
        [Authorize(Roles = "Manager")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ManagerUser managerUser = db.ManagerUsers.Find(id);
            if (managerUser == null)
            {
                return HttpNotFound();
            }
            return View(managerUser);
        }

        // GET: ManagerUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManagerUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Username,Password,Role")] ManagerUser managerUser)
        {
            if (ModelState.IsValid)
            {
                db.ManagerUsers.Add(managerUser);
                db.SaveChanges();
                return RedirectToAction("Wait","Login");
            }

            return View(managerUser);
        }
        // GET: ManagerUsers/Delete/5
        [Authorize(Roles = "Manager")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ManagerUser managerUser = db.ManagerUsers.Find(id);
            if (managerUser == null)
            {
                return HttpNotFound();
            }
            return View(managerUser);
        }

        // POST: ManagerUsers/Delete/5
        [Authorize(Roles = "Manager")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ManagerUser managerUser = db.ManagerUsers.Find(id);
            db.ManagerUsers.Remove(managerUser);
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

        [Authorize(Roles = "Manager")]
        public ActionResult Complete(int? id)
        {

            var user = db.ManagerUsers.Where(x => x.Id == id).FirstOrDefault();
            var addeduser = new User();
            addeduser.Id = user.Id;
            addeduser.Password = user.Password;
            addeduser.Role = user.Role;
            addeduser.Username = user.Username;
            db.Users.Add(addeduser);
            db.ManagerUsers.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

    }

}
