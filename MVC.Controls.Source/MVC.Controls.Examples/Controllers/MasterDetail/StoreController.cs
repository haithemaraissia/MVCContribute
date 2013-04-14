using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC.Controls.Examples.Models;
using MVC.Controls.Grid;
using System.Web.Mvc;

namespace MVC.Controls.Examples.Controllers.MasterDetail
{
    public class StoreController : BaseController<Store, int>
    {
        public virtual ViewResult Index()
        {
            return View();
        }

        public static GridColumnModelList<Store> _columns = null;
        public override GridColumnModelList<Store> GetColumns()
        {
            if (_columns == null)
            {
                _columns = new GridColumnModelList<Store>();
                _columns.Add(p => p.StoreId).SetHidden(true);
                _columns.Add(p => p.Name);
                _columns
                    .Add(p => p.Address)
                    .SetFormatter("boldMe")
                    .SetUnformatter("unformatMe");
            }

            return _columns;
        }

        public override IQueryable<Store> GetItems()
        {
            return DataContext.Stores.AsQueryable();
        }

        public override System.Web.Mvc.ActionResult DeleteItem(Store toDelete)
        {
            Store other = DataContext.Stores.Single(s => s.StoreId == toDelete.StoreId);
            DataContext.Stores.Remove(other);
            return null;
        }

        public override void BeforeAdd(Store added)
        {
            // This value is undefined from the client but we assign it so we can safely ignore
            // the error.
            ModelState.Remove(AttributeHelper.GetMemberName(added, item => item.StoreId));
        }

        public override System.Web.Mvc.ActionResult AddItem(Store added, out string newid)
        {
            DataContext.Stores.Add(added);
            added.StoreId = DataContext.Stores.Max(store => store.StoreId) + 1;
            newid = added.StoreId.ToString();
            return null;
        }

        public override System.Web.Mvc.ActionResult EditItem(Store edited)
        {
            Store other = DataContext.Stores.Single(s => s.StoreId == edited.StoreId);
            other.Name = edited.Name;
            other.Address = edited.Address;
            return null;
        }
    }
}