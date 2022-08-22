using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Assignment1_3MVC.Models;

namespace Assignment1_3MVC.Controllers
{
    public class FootballController : Controller
    {
        
        public ActionResult DisplayAllDetails()
        {
           FootballContext db = new FootballContext();
            return View(db.FootBallLeagues.ToList());
        }
        public ActionResult WinningDeatils()
        {
            FootballContext db = new FootballContext();
            IEnumerable<FootBallLeague> query = db.FootBallLeagues.ToList().Where(result => result.Status1 == "Win");
            return View(query);
        }
    }
}