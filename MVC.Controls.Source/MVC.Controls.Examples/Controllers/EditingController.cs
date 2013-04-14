using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Controls.Examples.Models;
using MVC.Controls.Examples.Repositories;
using MVC.Controls.Grid;

namespace MVC.Controls.Examples.Controllers
{
    public class EditingController : Controller
    {
        private static List<Store> _stores = new StoreRepository().ListAll();

        public ActionResult Editing()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";

            return View();
        }

        /* Creates the grid data */
        public ActionResult List(SearchParameter searchP, SearchModel searchModel)
        {            
            var model = _stores.AsQueryable();

            GridData data = model.ToGridData(searchModel, new[] { "Id", "Name", "Address" });
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        /* Called by the grid to insert the new rows to the Repository */
        public ActionResult Insert(List<Store> newStores)
        {
            if (newStores != null)
            {
                foreach (Store store in newStores)
                {
                    Store other = _stores.FirstOrDefault(str => str.StoreId == store.StoreId);
                    if (other != null)
                    {
                        other.Name = store.Name;
                        other.Address = store.Address;
                    }
                    else
                    {
                        _stores.Add(store);
                    }
                }
            }

            return Json("success", JsonRequestBehavior.AllowGet);
        }
    }
}
