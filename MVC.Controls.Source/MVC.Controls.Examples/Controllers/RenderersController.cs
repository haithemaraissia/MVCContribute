using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Controls.Examples.Models;
using MVC.Controls.Examples.Repositories;
using System.Text;
using MVC.Controls.Grid;
using System.Linq.Dynamic;

namespace MVC.Controls.Examples.Controllers
{
    public class RenderersController : Controller
    {
        private static List<Person> _persons = new PersonRepository().GetAllPersons();
        private static List<City> _cities = _persons.Select(person => person.City).Distinct().ToList();

        public ActionResult Renderers()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";

            return View();
        }

        /* Creates the grid data */
        public ActionResult ListPersons(SearchModel searchModel)
        {
            List<Person> stores = _persons;

            IQueryable<Person> model =
                (from Person p in stores
                select p).AsQueryable();

            GridData gridData = model.ToGridData(searchModel, Columns.PersonColumns);

            return Json(gridData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EditPersons(List<Person> persons)
        {
            /* Insert update code here */
            return Json(GridResponse.Create(true), JsonRequestBehavior.AllowGet);
        }

        public ActionResult EditPerson(Person person)
        {
            if (ModelState.IsValid == false)
            {
                return Json(GridResponse.Create(ModelState), JsonRequestBehavior.AllowGet);
            }

            Person other = _persons.SingleOrDefault(oth => oth.PersonId == person.PersonId);

            if (other == null)
            {
                other = new Person();
                other.PersonId = _persons.Max(per => per.PersonId) + 1;
                _persons.Add(other);
            }

            other.FirstName = person.FirstName;
            other.LastName = person.LastName;
            if (person.City.Id == Guid.Empty)
            {
                other.City = null;
            }
            else
            {
                other.City = _cities.Single(city => city.Id == person.City.Id);
            }

            return Json(GridResponse.Create(true), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Insert(List<Person> newPersons)
        {
            return Json("success", JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeletePerson(Person person)
        {
            if (person.PersonId == 20)
            {
                return Json(GridResponse.CreateFailure("This person can't be deleted, try another!"), JsonRequestBehavior.AllowGet);             
            }

            if (_persons.RemoveAll(oth => oth.PersonId == person.PersonId) == 1)
            {
                return Json(GridResponse.CreateSuccess(), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(GridResponse.CreateFailure("Person not found!"), JsonRequestBehavior.AllowGet);             
            }
        }

        public ActionResult GetCities()
        {
            StringBuilder sb = new StringBuilder();

            // WITHOUT THIS ROW, THE FIRST CITY FAILS IN THE COMBO FOR UNKNOWN REASONS!
            //sb.Append(Guid.Empty.ToString() + ":(none);");

            foreach (City c in _cities)
                sb.Append(c.Id.ToString() + ":" + c.Name + ";");

            return Json(sb.ToString(), JsonRequestBehavior.AllowGet);
        }
    }
}
