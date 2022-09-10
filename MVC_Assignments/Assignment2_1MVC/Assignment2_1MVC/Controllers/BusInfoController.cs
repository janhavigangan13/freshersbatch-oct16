using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Assignment2_1MVC.Models;
using System.Web.Mvc;

namespace Assignment2_1MVC.Controllers
{
    public class BusInfoController : Controller
    {
        
        public ActionResult DetailByAmount()
        {
            BusInfoDetails bid = new BusInfoDetails();
            ModelState.Clear();
            return View(bid.businfosbyamount().ToList());
        }

        public ActionResult DetailByDate()
        {
            BusInfoDetails bid = new BusInfoDetails();
            ModelState.Clear();
            return View(bid.businfosbydate().ToList());
        }
    }
}