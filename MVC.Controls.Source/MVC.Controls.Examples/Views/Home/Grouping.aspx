<%@ Import Namespace="MVC.Controls.Grid" %>
<%@ Import Namespace="MVC.Controls" %>

<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Grouping
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Grouping & Ordering (New from 1.2.0.1)</h2>
     <p>
        <span style="font-weight:bold; text-decoration:underline;">Concept: Grid Groups and Sorting</span><br />
        By using the <b><i>.SetAsGroup()</i></b> new API for the GridColumnModel, the grid automagically becomes grouped.<br />
        To add additional formatting and styling to the group, you can you the new <b><i>.SetGroupFormatting</i></b> API of GridControl, and specify the following arguments:<br />
        <b><u>groupColumnShow:</u></b> Whether or not to show the grouped column. Default to yes.<br />
        <b><u>groupText:</u></b> The text title of the group. e.g. <b>{0}-{1} items</b> (notice that HTML is supported).<br />
        <b><u>groupCollapse:</u></b> Whether or not the groups are collapsed by default. Default to no.<br />
        <b><u>groupOrder:</u></b> The group order. Default to asc.<br />
    </p>

<%= Html.Grid(new GridControl()
        .SetName("grid")
        .SetPageSize(10)
        .SetIsAutoSize(true)
        .SetListUrl("../Home/List")
        .SetHeight("200")
        .SetGroupFormatting(groupText:"<b>Group For: {0}, {1} item(s)") /* Optional, allows better control over the UI */
        .SetColumns<MVC.Controls.Examples.Models.Product>(cs=>
            {
                cs.Add(x => x.ProductId).SetAsPrimaryKey();
                cs.Add(x => x.Name);
                cs.Add(x => x.CompanyName).SetAsGroup(); /* This marks the column for grouping */
                cs.Add(x => x.Price).SetCellType(GridCellType.FLOAT);  
            }))
    %> 
      
</asp:Content>

