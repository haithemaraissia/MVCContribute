<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MVC.Controls.Examples.Models.Store>" %>

<%@ Import Namespace="MVC.Controls.Grid" %>

Details for: <%=Model.Name %><br />
Located at: <%=Model.Address%> <br />
<br />

        <%= Html.Grid(new MVC.Controls.Grid.GridControl()
        .SetName("DetailGrid")
        .SetPageSize(15)
        .SetIsAutoSize(true)
        .UseController<MVC.Controls.Examples.Controllers.MasterDetail.ProductController>(Model)
        .UpdateDefaultPager(pager =>
                pager
                    .ShowAdd(true)
                    .ShowEdit(true)
                    .ShowDel(true))
        .SetHeight("175")) %>