<%@ Import Namespace="MVC.Controls.Grid" %>

<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h3>
        Master</h3>
    <%= Html.Grid(new MVC.Controls.Grid.GridControl()
        .SetName("MasterGrid")
        .SetPageSize(15)
        .SetIsAutoSize(true)
        .UseController<MVC.Controls.Examples.Controllers.MasterDetail.StoreController>()
        .UpdateDefaultPager(pager =>
                pager
                    .ShowAdd(true)
                    .ShowEdit(true)
                    .ShowDel(true)
                    .SetAddEditWidth(500))
        .SetHeight("175")
        .SetOnSelectedRowEvent("updateDetail")) %>
    <h3>
        Details</h3>
    <div id="detailEditor">
        Click on a row to show details</div>
    <script language="javascript" type="text/javascript">
        // See StoreController GetColumns
        function boldMe(cellvalue, options, rowObject) {
            return "<strong>" + cellvalue + "</strong>";
        }

        // See StoreController GetColumns
        function boldMe(cellvalue, options, rowObject) {
            return "<strong>" + cellvalue + "</strong>";
        }

        function unformatMe(cellvalue, options) {
            return cellvalue;
        }

        $("#MasterGrid").setSelection(1, true);
        function showEditor(data) {
            $("#detailEditor").html(data);
        }

        function updateDetail(row) {
            $.get('/Product?StoreId=' + row.StoreId, showEditor);
        }

    </script>
</asp:Content>
