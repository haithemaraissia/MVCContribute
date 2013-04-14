using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC.Controls.Examples.Models;
using MVC.Controls.Grid;
using System.Web.Mvc;

namespace MVC.Controls.Examples.Controllers.MasterDetail
{
    public class ProductController : BaseController<Product, int>
    {
        public ActionResult Index(int storeId)
        {
            return PartialView(DataContext.Stores.Single(store => store.StoreId == storeId));
        }

        public int GetParentStoreId()
        {
            string id = Request.Params["StoreId"];
            // Sometimes there's a comma included!!
            id = id.Replace(",", "");
            return Convert.ToInt32(id);
        }

        public static GridColumnModelList<Product> _columns = null;
        public override GridColumnModelList<Product> GetColumns()
        {
            if (_columns == null)
            {
                _columns = new GridColumnModelList<Product>();
                _columns.Add(p => p.ProductId).SetHidden(true);
                _columns.Add(p => p.Name);
                _columns.Add(p => p.CompanyName);
                _columns.Add(p => p.Price);
                _columns.ForEach(col => col.SetAlign("left"));
            }

            return _columns;
        }

        public override IQueryable<Product> GetItems()
        {
            int id = GetParentStoreId();
            return
                DataContext
                    .Stores
                    .Single(store => store.StoreId == id)
                    .Products
                    .AsQueryable();
        }

        public override System.Web.Mvc.ActionResult DeleteItem(Product toDelete)
        {
            DataContext
                .Stores
                .Single(store => store.StoreId == GetParentStoreId())
                .Products
                .RemoveAll(product => product.ProductId == toDelete.ProductId);
            return null;
        }

        public override void BeforeAdd(Product added)
        {
            // This value is undefined from the client but we assign it so we can safely ignore
            // the error.
            ModelState.Remove(AttributeHelper.GetMemberName(added, item => item.ProductId));
        }

        public override System.Web.Mvc.ActionResult AddItem(Product added, out string newid)
        {
            DataContext
                .Stores
                .Single(store => store.StoreId == GetParentStoreId())
                .Products
                .Add(added);

            added.ProductId = DataContext.Stores.Max(store => store.Products.Max(product => product.ProductId)) + 1;

            newid = added.ProductId.ToString();
            return null;
        }

        public override System.Web.Mvc.ActionResult EditItem(Product edited)
        {
            Product other =
                DataContext
                    .Stores
                    .Single(store => store.StoreId == GetParentStoreId())
                    .Products
                    .Single(product => product.ProductId == edited.ProductId);

            other.Name = edited.Name;
            other.Price = edited.Price;
            other.CompanyName = edited.CompanyName;

            return null;
        }
    }
}