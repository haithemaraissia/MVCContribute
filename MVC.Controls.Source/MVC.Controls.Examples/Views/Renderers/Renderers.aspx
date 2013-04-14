<%@ Import Namespace="MVC.Controls.Grid" %>

<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Renderers
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Renderers</h2>
    <p>
        <span style="font-weight: bold; text-decoration: underline;">Concept: Custom Column
            Renderers</span><br />
        [Still under development] It is possible to supply different renderering mechanisms
        to support different<br />
        types of column rendering for edit-mode.<br />
        In this example, we use the prebuilt ComboColumnRenderer for the Cities column.<br />
        Select a row and press the update button to see it in action<br />
    </p>
    <%= Html.Grid(new GridControl()
        .SetName("grid")
        .SetPageSize(15)
        .SetIsAutoSize(true)
        .SetListUrl("/Renderers/ListPersons")
        .SetEditUrl("/Renderers/EditPerson")
        .SetHeight("200")
        .SetWidth("200")
        .UseColumns(MVC.Controls.Examples.Models.Columns.PersonColumns)
        .UpdateDefaultPager(pager =>        
            pager
                .ShowAdd(true)
                .ShowDel(true, deleteUrl:"/Renderers/DeletePerson")                
                .ShowEdit(true)                    
                .ShowView(true)
        ))
    %>
    <br />
    <%=Html.GridAddButton(buttonText: "Add", gridName: "grid")%>
    <%=Html.GridUpdateButton(buttonText: "Update", gridName: "grid") %>
    <%=Html.GridSaveButton(buttonText: "Save", gridName: "grid")%>
    <%=Html.GridCancelButton(buttonText: "Cancel", gridName: "grid")%>
    <%=Html.GridDeleteButton(buttonText: "Delete", gridName: "grid",  actionUrl: "/Renderers/DeletePerson")%>
    |
    <%=Html.GridSaveButton(buttonText: "Save All", gridName: "grid", bulkUrl:"EditPersons", parameterName: "persons") %>
    <%=Html.GridCancelButton(buttonText: "Cancel All", gridName: "grid", allRows: true)%>


    <script language="javascript" type="text/javascript">
        function doCascade(e) {
            var currValue = e.currentTarget.value;
            var currRowId = <%=Html.GridSelectedRow() %>;
            // Dangerous to hard code a column number like that...
            if($("#grid")[0].rows[currRowId] != undefined)
            {
                var cascadedCombo = $("#grid")[0].rows[currRowId].cells[3].childNodes[0];

                if (cascadedCombo!=undefined&&cascadedCombo.options != undefined)
                {
                    /* Now we can take the combo, and update it's elements using "currValue" */
                    var opt = new Option(currValue, 100);
                    cascadedCombo.options.add(opt);
                }
            }
        }
    </script>
</asp:Content>
