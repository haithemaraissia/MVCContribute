using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Linq.Dynamic;
using MVC.Controls.Examples.Repositories;
using MVC.Controls.Examples.Models;

using MVC.Controls.Grid;

namespace MVC.Controls.Examples.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult Grouping()
        {
            return View();
        }

        public ActionResult List(SearchModel searchModel)
        {
            ProductRepository repository = new ProductRepository();

            List<Product> products = repository.ListAll();

            return Json(products.AsQueryable().ToGridData(searchModel, new[] { "Id", "Name", "CompanyName", "Price" }), JsonRequestBehavior.AllowGet);
        }

        public ActionResult ChildList(int productId, SearchModel searchModel)
        {
            StoreRepository rep = new StoreRepository();
            List<Store> stores = rep.GetByProductId(productId);

            var model = stores.AsQueryable();
            return Json(model.ToGridData(searchModel, new[] { "Id", "Name", "Address" }), JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
