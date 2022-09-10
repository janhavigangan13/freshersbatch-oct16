using System.Collections.Generic;
using System.Linq;
using Assignment2_Database1stApproachMVC.Models;
using System.Web.Mvc;

namespace Assignment2_Database1stApproachMVC.Controllers
{
    public class BusInfoController : Controller
    {
        BusinfoContext businfoContext = new BusinfoContext();

        public ActionResult AllBusDetails()
        {
            ModelState.Clear();
            return View(businfoContext.BusInfoes.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(BusInfo db)
        {
            if(ModelState.IsValid)
            {
                businfoContext.BusInfoes.Add(db);
                int a =businfoContext.SaveChanges();
                if(a>0)
                {
                    TempData["insertmessage"] = "<script>alert('Record inserted successfully!')</script>";
                    return RedirectToAction("AllBusDetails");
                }
                else
                {
                    TempData["insertmessage"] = "<script>alert('Record not inserted!')</script>";
                }
            }
            return View(db);
           
        }

        public ActionResult detailOfBusMum()
        {
            IEnumerable <BusInfo> query = businfoContext.BusInfoes.ToList().Where(res => res.BoardingPoint == "MUM");
            return View(query);
        }
    }
}