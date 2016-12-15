using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PeopleSearch.Services;

namespace PeopleSearch.Controllers
{
    public class HomeController : Controller
    {
        private IPeopleData _peopleData;

        public HomeController(IPeopleData peopleData)
        {
            _peopleData = peopleData;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Search()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
