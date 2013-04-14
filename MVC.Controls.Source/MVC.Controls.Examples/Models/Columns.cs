using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC.Controls.Grid;

namespace MVC.Controls.Examples.Models
{
    public static class Columns
    {
        private static GridColumnModelList<Person> _personColumns = CreatePersonColumns();

        public static GridColumnModelList<Person> PersonColumns { get { return _personColumns; } }

        private static GridColumnModelList<Person> CreatePersonColumns()
        {
            GridColumnModelList<Person> cn = new GridColumnModelList<Person>();
            cn.Add(p => p.PersonId).SetAsPrimaryKey();
            cn.Add(p => p.FirstName).AddEvent("change", "doCascade");
            cn.Add(p => p.LastName).AddEvent("change", "doCascade");
            cn.Add(p => p.City != null ? p.City.Id : Guid.Empty).SetName("City.Id").SetCaption("CityId").SetColumnRenderer(new ComboColumnRenderer("/Renderers/GetCities"));
            cn.Add(p => p.FirstName + "_computed_" + p.LastName).SetName("Computed").SetCaption("Computed example").SetEditable(false);
            return cn;
        }
    }
}