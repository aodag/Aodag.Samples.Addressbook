using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Aodag.Samples.Addressbook.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            var people = Enumerable.Range(0, 10)
                .Select(i => new Models.Person() {
                    FirstName = string.Format("Person{0}", i),
                    LastName = "Last",
                    Email = string.Format("person{0}@example.com", i)
                })
                .ToArray();
            return View(people);
        }

        public IActionResult New()
        {
            return View();
        }
    }
}
