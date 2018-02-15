using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GroupCapstone.Models;
using Microsoft.AspNet.Identity;
using System.Xml.Linq;
using System.Threading.Tasks;

using System.Configuration;
using System.Threading;
using GroupCapstone.HelperClasses;


namespace GroupCapstone.Controllers
{
    public class ApplicationUsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ApplicationUsers
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: ApplicationUsers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // GET: ApplicationUsers/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: ApplicationUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Address,FirstName,LastName,Rating,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,Latitude,Longitude")] ApplicationUser applicationUser)
        {

            if (ModelState.IsValid)
            {
                db.Users.Add(applicationUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(applicationUser);
        }

        // GET: ApplicationUsers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // POST: ApplicationUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Address,FirstName,LastName,Rating,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,Description,Price,Shovelee,Latitude,Longitude,PricePoint,Distance")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicationUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(applicationUser);
        }

        // GET: ApplicationUsers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // POST: ApplicationUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ApplicationUser applicationUser = db.Users.Find(id);
            db.Users.Remove(applicationUser);
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
        public ActionResult Customer(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Customer([Bind(Include = "Id,Address,FirstName,LastName,Rating,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,Description,Price,Shovelee,Latitude,Longitude")] ApplicationUser applicationuser)
        {
            //find pickup pass in to view
            string sameUser = User.Identity.GetUserId();
            var result = from row in db.Users where row.Id == sameUser select row;

            if (ModelState.IsValid)
            {
                db.Entry(applicationuser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var stripePublishKey = ConfigurationManager.AppSettings[HelperClasses.APIKeys.StripePublishableKey];
            ViewBag.StripePublishKey = HelperClasses.APIKeys.StripePublishableKey;
            return View();
        }

        public ActionResult Worker(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Worker([Bind(Include = "Id,Address,FirstName,LastName,Rating,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,Description,Price,Shovelee,Latitude,Longitude,PricePoint,Distance")] ApplicationUser applicationuser)
        {
            //find pickup pass in to view
            string sameUser = User.Identity.GetUserId();
            var result = from row in db.Users where row.Id == sameUser select row;
            //var changeBool = result.FirstOrDefault();
            //changeBool.Shovelee = true;
            ////lbl_PostContent.Text = lbl_PostContent.Text.Replace(vbCrLf, "<br />");
            //db.Entry(result.FirstOrDefault()).State = EntityState.Modified;
            //db.SaveChanges();
            if (ModelState.IsValid)
            {
                db.Entry(applicationuser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("WorkIndex", "ApplicationUsers");
            }
            return RedirectToAction("WorkIndex", "ApplicationUsers");
        }
        public ActionResult UserHome()
        {
            string sameUser = User.Identity.GetUserId();
            var result = from row in db.Users where row.Id == sameUser select row;
            return View(result.FirstOrDefault());
        }

        public ActionResult WorkIndex()
        {
            string sameUser = User.Identity.GetUserId();
            var result = from row in db.Users where row.Id == sameUser select row;
            var resultToUser = result.FirstOrDefault();
            List<ApplicationUser> list = new List<ApplicationUser>();
            list = db.Users.ToList();
            GoogleDistanceMatrix theMatrix = new GoogleDistanceMatrix();
            foreach (ApplicationUser user in list)
            {
                if (resultToUser.Id == user.Id)
                {
                    list.Remove(user);
                }
                if (theMatrix.GetDistance(user.Latitude, user.Longitude, resultToUser.Latitude, resultToUser.Longitude) < resultToUser.Distance)
                {
                    list.Remove(user);
                }
            }
            return View(list);
        }


        //public ActionResult GetZipMap()
        //{
        //    foreach (ApplicationUser a in db.Users)
        //    {
        //        if (a.Shovelee == true)
        //        {
        //            string address = a.Address;
        //            string requestUri = string.Format("http://maps.googleapis.com/maps/api/geocode/xml?address={0}&sensor=false", Uri.EscapeDataString(address));

        //            WebRequest request = WebRequest.Create(requestUri);
        //            WebResponse response = request.GetResponse();
        //            XDocument xdoc = XDocument.Load(response.GetResponseStream());

        //            XElement result = xdoc.Element("GeocodeResponse").Element("result");
        //            XElement locationElement = result.Element("geometry").Element("location");
        //            XElement lat = locationElement.Element("lat");
        //            XElement lng = locationElement.Element("lng");

        //        }
        //    }
        //    return View("Index", "ApplicationUsers");
        //}




    }
}
