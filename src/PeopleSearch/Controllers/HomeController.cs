using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PeopleSearch.Services;
using PeopleSearch.Entities;
using PeopleSearch.ViewModels;

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
            var model = new SearchViewModel();
            model.People = _peopleData.GetAll();            

            return View(model);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
