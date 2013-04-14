<%@ Import Namespace="MVC.Controls.Grid" %>
<%@ Import Namespace="MVC.Controls" %>
<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Sub-Grid</h2>
     <p>
        <span style="font-weight:bold; text-decoration:underline;">Concept: Grid Control as Sub-Grid</span><br />
        A simple demonstration of how to configure a standard grid with (and as) a subgrid.
    </p>

<%= Html.Grid(new GridControl()
        .SetName("grid")
        .SetPageSize(10)
        .SetIsAutoSize(true)
        .SetHttpVerb(HttpVerbs.Get)
        .SetListUrl("Home/List")
        .SetHeight("200")
        .SetColumns<MVC.Controls.Examples.Models.Product>(cs=>
            {
                cs.Add(x => x.ProductId).SetAsPrimaryKey();
                cs.Add(x => x.Name);
                cs.Add(x => x.CompanyName);
                cs.Add(x => x.Price);
            })
        .CreateSubGrid(new GridControl()
            .SetPageSize(10)
            .SetListUrl("Home/ChildList?productId=")
            .SetIsAutoSize(true)
            .SetColumns<MVC.Controls.Examples.Models.Store>(cs=>
                {
                    cs.Add(x => x.StoreId).SetAsPrimaryKey();
                    cs.Add(x => x.Name);
                    cs.Add(x => x.Address);
                })))
    %> 
      
</asp:Content>
