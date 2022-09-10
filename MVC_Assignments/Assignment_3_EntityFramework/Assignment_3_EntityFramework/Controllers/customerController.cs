using BusinessLayerCustomer;
using DataAccessLayerCustomer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Assignment_3_EntityFramework.Controllers
{
    public class customerController : Controller
    {
        private CustomerContext db = new CustomerContext();
        public ActionResult HomePage()
        {
            return View();
        }

        // GET: Customers
        public ActionResult Allcustomers()
        {
            return View(db.customers.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult DetailsByID(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult CreateNewCustomer()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNewCustomer([Bind(Include = "CustomerID,CustomerName,City,Age,Phone,Pincode")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.customers.Add(customer);
                db.SaveChanges();
                ViewBag.Message = "Customer details Added Successfully";
                return RedirectToAction("Allcustomers");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID,CustomerName,City,Age,Phone,Pincode")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Allcustomers");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.customers.Find(id);
            db.customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Allcustomers");
        }
        public ActionResult Search(string Searchby, string search)
        {
            try
            {
                List<Customer> customers = db.customers.ToList();

                if (Searchby == "CustomerName")
                {


                    List<Customer> model = customers.Where(c => c.CustomerName.StartsWith(search) || search == null).ToList();
                    ModelState.Clear();
                    return View(model);
                }
                else
                {

                    List<Customer> model = customers.Where(c => c.CustomerID == Convert.ToInt32(search) || search == null).ToList();

                    ModelState.Clear();
                    return View(model);
                }
            }
            catch
            {
                return View(search);
            }

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