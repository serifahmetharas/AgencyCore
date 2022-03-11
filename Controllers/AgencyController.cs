using AgencyCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgencyCore.Controllers
{
    public class AgencyController : Controller
    {
        Context db = new Context();
        public IActionResult Index()
        {
            var values = db.Agencies.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult NewAgency()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NewAgency(Agency agency)
        {
            db.Agencies.Add(agency);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult DeleteAgency(int id)
        {
            var agency = db.Agencies.Find(id);
            db.Agencies.Remove(agency);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult GetAgency(int id) // Guncelleme içi gelmesini sağladım.
        {
            var agency = db.Agencies.Find(id);
            return View("GetAgency", agency);
        }

        public IActionResult UpdateAgency(Agency ag)
        {
            var willupdate = db.Agencies.Find(ag.AgencyId);
            willupdate.AgencyName = ag.AgencyName;
            db.SaveChanges();
            return RedirectToAction("Index");


        }

        public IActionResult AgencyDetail(int id)
        {
            var values = db.Customers.Where(x => x.AgencyId == id).ToList();
            var agencyname = db.Agencies.Where(x => x.AgencyId == id).Select(y => y.AgencyName).FirstOrDefault();
            ViewBag.nameag = agencyname;
            return View(values);
        }
    }
}
