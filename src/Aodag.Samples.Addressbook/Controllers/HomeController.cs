using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Aodag.Samples.Addressbook.Controllers
{
    public class HomeController : Controller
    {
        public Data.ApplicationDbContext DbContext
        {
            get;
            set;
        }

        public HomeController([FromServices]Data.ApplicationDbContext dbContext)
            :base()
        {
            DbContext = dbContext;
        }

        [HttpGet]
        // GET: /<controller>/
        public IActionResult Index()
        {
            var people = DbContext.People.ToArray();
            return View(people);
        }

        [HttpGet]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm]Models.Person person)
        {
            if (!ModelState.IsValid)
            {
                return View("New", person);
            }
            DbContext.Add(person);
            DbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var person = DbContext.People.FirstOrDefault(p => p.Id == id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        [HttpPost]
        public IActionResult Update(int id, [FromForm]Models.Person data)
        {
            if (!ModelState.IsValid)
            {
                data.Id = id;
                return View("Edit", data);
            }
            var person = DbContext.People.FirstOrDefault(p => p.Id == id);
            if (person == null)
            {
                return NotFound();
            }
            person.FirstName = data.FirstName;
            person.LastName = data.LastName;
            person.Email = data.Email;
            DbContext.SaveChanges();
            return RedirectToAction("Index");            
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var person = DbContext.People.FirstOrDefault(p => p.Id == id);
            if (person == null)
            {
                return NotFound();
            }
            DbContext.Remove(person);
            DbContext.SaveChanges();
            return RedirectToAction("Index");                        
        }
    }
}
