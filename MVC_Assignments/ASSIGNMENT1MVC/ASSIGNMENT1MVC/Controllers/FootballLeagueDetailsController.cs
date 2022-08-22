using ASSIGNMENT1MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASSIGNMENT1MVC.Controllers
{
    public class FootballLeagueDetailsController : Controller
    {
        public ActionResult AllMatchDetails()
        {
            footballDetails fd = new footballDetails();
            ModelState.Clear();
            return View(fd.GetMatchdetails());
        }


        public ActionResult winningmatchdetails()
        {
            footballDetails matchDB = new footballDetails();
            ModelState.Clear();
            return View(matchDB.WinningMatchDetails());
        }
        public ActionResult japanmatchdetails()
        {
            footballDetails matchDB = new footballDetails();
            ModelState.Clear();
            return View(matchDB.teamplayedbyjapan());
        }
        [HttpGet]
        public ActionResult CreateNewRecord()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateNewRecord(FootballLeague Match)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    footballDetails matchDB = new footballDetails();
                    if (matchDB.AddMatchResult(Match))
                    {
                        ViewBag.Message = "Match Details Added Successfully";
                        ModelState.Clear();
                    }

                }
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}