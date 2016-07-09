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
        Data.ApplicationDbContext DbContext
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
        public IActionResult Create([FromForm]string firstName, [FromForm]string lastName, [FromForm]string email)
        {
            var person = new Models.Person() {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
            };
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
        public IActionResult Update(int id, [FromForm]string firstName, [FromForm]string lastName, [FromForm]string email)
        {
            var person = DbContext.People.FirstOrDefault(p => p.Id == id);
            if (person == null)
            {
                return NotFound();
            }
            person.FirstName = firstName;
            person.LastName = lastName;
            person.Email = email;
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
