using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Controls.Examples.Repositories;
using MVC.Controls.Grid;
using MVC.Controls.Examples.Models;

namespace MVC.Controls.Examples.Controllers
{
    public class LocalDataController : Controller
    {
        public ActionResult LocalData()
        {
            StoreRepository repository = new StoreRepository();

            List<Store> stores = repository.ListAll();

            ViewData["GridDataSource"] = stores;
            return View();
        }
    }
}
