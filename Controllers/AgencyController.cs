using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAgency.Models;

namespace CoreAgency.Controllers
{
    public class AgencyController : Controller
    {
        Context db = new Context();
        public IActionResult Index()
        {
            var agencies = db.Agencies.ToList();
            return View(agencies);
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
            return View("GetAgency",agency);
        }

        public IActionResult UpdateAgency(Agency agency)
        {
            var willupdate = db.Agencies.Find(agency.Id);
            willupdate.Name = agency.Name;
            db.SaveChanges();
            return RedirectToAction("Index");

            
        }


    }
}
