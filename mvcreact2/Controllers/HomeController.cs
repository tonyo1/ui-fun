using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace mvcreact2.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }

    [Route("/App/{*url}")]
    public class App : Controller
    {
     
     /*
        public IActionResult Index()
        {
            return View("Index");
        }
*/
      [HttpGet]
        public ImUseful openGate()
        {
            return new ImUseful("well", "hello");
        }
    }

    public class ImUseful
    {
        public string Name { get; set; }
        public string Value { get; set; } 
        public Cashew[] Cashews { get; set; }
        public ImUseful(string name, string value)
        {
            Name = name;
            Value = value;
            Cashews = new Cashew[] { };
        }
    }
    public class Cashew
    {
        public string Variable { get; set; } = string.Empty;
    }
}