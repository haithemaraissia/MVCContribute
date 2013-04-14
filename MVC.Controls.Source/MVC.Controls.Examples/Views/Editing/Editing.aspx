<%@ Import Namespace="MVC.Controls" %>
<%@ Import Namespace="MVC.Controls.Grid" %>

<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Editing
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Editing</h2>
    <p>
        <span style="font-weight: bold; text-decoration: underline;">Concept: Bulk Edit</span><br />
        While the original jqGrid supports row editing, it lacks the feature to allow multiple
        row update at once.<br />
        By using the new gridAddRow, and gridSaveRows jscript methods it's a no brainer.
    </p>
    <%= Html.Grid(new GridControl()
        .SetName("grid")
        .SetPageSize(15)
        .SetIsAutoSize(true)
        .SetListUrl("/Editing/List")
        .SetHeight("200")        
        .SetColumns<MVC.Controls.Examples.Models.Store>(cs=>
            {
                cs.Add(x => x.StoreId); // Implicit key and not editable through DataAnnotations
                cs.Add(x => x.Name);
                cs.Add(x => x.Address);
            }))
    %>
    <br />
    <script language="javascript" type="text/javascript">
        /* Adds an empty new row to the grid */
        function doInsertEmpty() {
            gridAddRow("grid");
        }

        /* Adds a new row to the grid with a custom default value */
        function doInsertNonEmpty() {
            var newObj = new Object();
            newObj.Name = "Default Name";
            newObj.Address = "NY";
            gridAddRow("grid", newObj);
        }

        /* Tells the grid to send the inserted rows to the server */
        function doUpdateServer() {
            gridSaveRows("grid", "Insert", "newStores", clientCallBack);
        }

        /* A callback triggered after the server has been called,
        If returns false, cancel's the update */
        function clientCallBack(serverArgs) {
            if (serverArgs == "success")
                return true
            else
                return false;
        }
    </script>
    <span style="font-weight: bold; text-decoration: underline;">Operations:</span><br />
    <input type="button" value="Insert Empty Row" onclick="doInsertEmpty();" />
    <input type="button" value="Insert Default Row" onclick="doInsertNonEmpty();" />
    <input type="button" value="Update Sever" onclick="doUpdateServer();" />
</asp:Content>
