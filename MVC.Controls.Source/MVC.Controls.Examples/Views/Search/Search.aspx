<%@ Import Namespace="MVC.Controls" %>
<%@ Import Namespace="MVC.Controls.Grid" %>
<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Search
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Search</h2>
    <p>
        <span style="font-weight:bold; text-decoration:underline;">Concept: Query Params Serializer</span><br />
        Because the grid is filled on a different (subsequent) request from the one creating the view,<br />
        It is crucial to be able to store query information recieved as ViewData in the first request,<br /> 
        for addition (i.e paging-fetching) requests.<br />
        <br />
        To make it easier to save the query information, a utility function called Html.BuildQuery is offered.<br />
        The utility serializes the query parameter to json and thus store it as part of the grid parameters.<br />
    </p>
     <%= Html.Grid(new GridControl()
        .SetName("grid")
        .SetPageSize(15)
        .SetIsAutoSize(true)
        .SetListUrl("/Search/List" + Html.BuildQuery(ViewData["SearchParams"], "searchP"))
        .SetHeight("200")
        .SetColumns<MVC.Controls.Examples.Models.Store>(cs=>
            {
                cs.Add(x => x.StoreId).SetAsPrimaryKey();
                cs.Add(x => x.Name);
                cs.Add(x => x.Address);
            }))
    %> 

</asp:Content>
