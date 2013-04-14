using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Controls.Grid;
using MVC.Controls.Examples.Models;
using MVC.Controls.Examples.Repositories;

namespace MVC.Controls.Examples.Controllers
{
    public class SearchController : Controller
    {
        public ActionResult Search()
        {
            SearchParameter sp = new SearchParameter();
            sp.UserName = "sternr";
            sp.Created = DateTime.Now;

            ViewData["SearchParams"] = sp;
            return View();
        }

        /* Notice the List methid accepts an additional
         * SearchParameter parameter - this is achieved using the -
         * Html.BuildQuery method used in the view Grid declaration */
        public ActionResult List(SearchParameter searchP, SearchModel searchModel)
        {
            StoreRepository repository = new StoreRepository();

            List<Store> stores = repository.ListAll();

            var model = stores.AsQueryable();
            return Json(model.ToGridData(searchModel, new[] { "Id", "Name", "Address" }), JsonRequestBehavior.AllowGet);
        }
    }
}
