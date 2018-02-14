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
<<<<<<< HEAD

            //foreach (ApplicationUser model in db.Users)
            //{
            //    string address = model.Address;
            //    string requestUri = "https://maps.googleapis.com/maps/api/geocode/xml?key=AIzaSyC4ALH2fGv4h1UC3bN0y8QgmOJCEhop7K8&address=" + Uri.EscapeDataString(address);

            //    WebRequest request = WebRequest.Create(requestUri);
            //    WebResponse response = request.GetResponse();
            //    XDocument xdoc = XDocument.Load(response.GetResponseStream());

            //    XElement result = xdoc.Element("GeocodeResponse").Element("result");
            //    XElement locationElement = result.Element("geometry").Element("location");
            //    XElement lat = locationElement.Element("lat");
            //    XElement lng = locationElement.Element("lng");
            //    string newLat = lat.Value.ToString();
            //    string newLng = lng.Value.ToString();
            //    model.Latitude = newLat;
            //    model.Longitude = newLng;

            //}
            //db.SaveChanges();
=======
            
            foreach (ApplicationUser model in db.Users)
            {
                //if (a.Shovelee == true)
                //{
                    string address = model.Address;
                    string requestUri = string.Format("http://maps.googleapis.com/maps/api/geocode/xml?address={0}&sensor=false", Uri.EscapeDataString(address));

                    WebRequest request = WebRequest.Create(requestUri);
                    WebResponse response = request.GetResponse();
                    XDocument xdoc = XDocument.Load(response.GetResponseStream());

                    XElement result = xdoc.Element("GeocodeResponse").Element("result");
                try
                {
                    XElement locationElement = result.Element("geometry").Element("location");
                    XElement lat = locationElement.Element("lat");
                    XElement lng = locationElement.Element("lng");
                    string newLat = lat.Value.ToString();
                    string newLng = lng.Value.ToString();

                    model.Latitude = newLat;
                    model.Longitude = newLng;
                }
                catch
                {
                    return RedirectToAction("UserHome", "ApplicationUsers");
                }
                    //a.location.Add(a.Latitude);
                    //a.location.Add(a.Longitude);


                // }
            }
            db.SaveChanges();
>>>>>>> 27a7ba2e518cbb5c497c406209df36834b1b7d0b
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
        public ActionResult Edit([Bind(Include = "Id,Address,FirstName,LastName,Rating,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] ApplicationUser applicationUser)
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

        public ActionResult Customer()
        {
            //find pickup pass in to view
            string sameUser = User.Identity.GetUserId();
            var result = from row in db.Users where row.Id == sameUser select row;
            return View(result.FirstOrDefault());
        }

        public ActionResult Worker()
        {
            return View();
        }

        public ActionResult UserHome()
        {
            return View();
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
