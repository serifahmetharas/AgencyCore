using AgencyCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgencyCore.Controllers
{
    public class CustomerController : Controller
    {
        Context db = new Context();
        [Authorize]
        public IActionResult Index()
        {
            var values = db.Customers.Include(x=>x.Agency).ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult NewCustomer()
        {
            List<SelectListItem> values = (from x in db.Agencies.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.AgencyName,
                                               Value = x.AgencyId.ToString()
                                           }).ToList();
            ViewBag.vls = values;

            return View();
        }
        [HttpPost]
        public IActionResult NewCustomer(Customer c)
        {
            var cust = db.Agencies.Where(x => x.AgencyId == c.Agency.AgencyId).FirstOrDefault();
            c.Agency = cust;
            db.Customers.Add(c);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult DeleteCustomer(int id)
        {
            var customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult GetCustomer(int id) // Guncelleme içi gelmesini sağladım.
        {
            var customer = db.Customers.Find(id);
            var agencyname = db.Agencies.Where(x => x.AgencyId == id).Select(y => y.AgencyName).FirstOrDefault();
            ViewBag.nameag = agencyname; // View bag ile GetCustomer da ajans ismini yollamak için.
            return View("GetCustomer", customer);
        }

        public IActionResult UpdateCustomer(Customer customer)
        {
            var willupdate = db.Customers.Find(customer.AgencyId);
            willupdate.Name = customer.Name;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
