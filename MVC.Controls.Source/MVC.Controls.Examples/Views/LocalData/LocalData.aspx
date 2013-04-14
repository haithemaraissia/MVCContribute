<%@ Import Namespace="MVC.Controls.Grid" %>
<%@ Import Namespace="MVC.Controls" %>
<%@ Import Namespace="MVC.Controls.Tab" %>

<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	LocalData
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>LocalData</h2>
    <p>
        <span style="font-weight:bold; text-decoration:underline;">Concept: LocalData</span><br />
        Instead of supplying a differenet controller action to get the grid,
        if the amount of data to be used by the grid is minimal,<br />
        It is possible to use the ViewData as a DataSource for the grid with no additional requests.<br />
        <span style="font-weight:bold;">A Note:</span> In the current release, using this feature will render
        The entire datasource to json even though some properties might not be in use by the grid.
    </p>
     <%= Html.Grid(new GridControl()
        .SetName("grid")
        .SetPageSize(15)
        .SetIsAutoSize(true)
        .SetDataSource(ViewData["GridDataSource"])
        .SetHeight("200")
        .SetHttpVerb(HttpVerbs.Get)
        .SetColumns<MVC.Controls.Examples.Models.Store>(cs =>
         {
             cs.Add(x => x.StoreId).SetAsPrimaryKey();
             cs.Add(x => x.Name);
             cs.Add(x => x.Address);
         }
        ))
    %> 


    <br />


   

</asp:Content>
