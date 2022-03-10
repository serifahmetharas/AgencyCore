using CoreAgency.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAgency.Controllers
{
    public class CustomerController : Controller
    {
        Context db = new Context();
        public IActionResult Index()
        {
            var costumers = db.Customers.ToList();
            return View(costumers);
        }
    }
}
