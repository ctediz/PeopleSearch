using Microsoft.AspNetCore.Mvc;
using PeopleSearch.Entities;
using PeopleSearch.Services;
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
        
        [HttpGet]
        public IActionResult Search()
        {
            var model = new SearchViewModel();
            model.People = _peopleData.GetAll();

            return View(model);
        }

        
        [HttpPost]
        public IActionResult Search(string nameFragment)
        {
            var model = new SearchViewModel();
            model.People = _peopleData.Get(nameFragment);

            return PartialView(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PersonEditViewModel model)
        {
            if(ModelState.IsValid)
            {
                string[] split = model.Name.Split(new char[0]);

                var newPerson = new Person();
                newPerson.FirstName = split[0];
                newPerson.LastName = split[1];
                newPerson.Interests = model.Interests;
                newPerson.Birth = model.Birth;

                newPerson = _peopleData.Add(newPerson);
                _peopleData.Commit();

                return RedirectToAction("Search");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _peopleData.Get(id);
            if(model == null)
            {
                return RedirectToAction("Search");
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(int id, Person model)
        {
            var person = _peopleData.Get(id);
            if(ModelState.IsValid)
            {
                person.FirstName = model.FirstName;
                person.LastName = model.LastName;
                person.Interests = model.Interests;
                person.Birth = model.Birth;
                
                _peopleData.Commit();

                return RedirectToAction("Search");
            }

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
