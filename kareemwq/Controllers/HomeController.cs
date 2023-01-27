using kareemwq.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace kareemwq.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        List<Person> people = new List<Person>() {
          new Person() { Name = "John", DateOfBirth = DateTime.Parse("2000-05-06")},
          new Person() { Name = "Linda", DateOfBirth = DateTime.Parse("2005-01-09")},
          new Person() { Name = "Susan", DateOfBirth = DateTime.Parse("2008-07-12")}
         };

        public IActionResult Index()
        {
            return View(people);
        }
        [Route("Privacy/{name}")]
        public IActionResult Privacy(string? name)
        {
            if (name == null)
            {
                return Content("name not found");

            }
            else
            {
                Person? pep = people.Where(item => item.Name == name).FirstOrDefault();
                return View(pep);
            }


        }
        [Route("viewpro")]
        public IActionResult Personwithproduct()
        {
            Person person = new Person() { Name = "kareem" , DateOfBirth = DateTime.Parse("2000-05-06") };
            Product product = new Product() { ProductId = 1122 , ProductName = "qasir" };

            PersonWithProduct personWithProduct = new PersonWithProduct() { person = person , product = product };

            return View( personWithProduct);
        
        }

            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}