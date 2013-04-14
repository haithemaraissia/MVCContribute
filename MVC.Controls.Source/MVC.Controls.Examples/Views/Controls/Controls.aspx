﻿<%@ Import Namespace="MVC.Controls" %>
<%@ Import Namespace="MVC.Controls.Tab" %>
<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Controls
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Controls (New! from 1.2.0.1)</h2>

    <script language="javascript" type="text/javascript">

        function onSelectTest(txt, inst) {
            alert(inst.id + " : " + txt);
        }

        function onBeforeAutoComplete(elem, data) {
            if (elem.val() == "test") return false;
            return true;
        }

    </script>
    <h3>Controls</h3>
    The main design guidline MVC.Controls tries to follow, is to seperate between the control's design, and it's behaviour.<br />
    This makes the integration process into existing projects smoother by allowing the developer to get better control over the bottom-line HTML

    <h3>Date Picker</h3>
    <!-- Making standard controls act as DatePicker -->
    On Text Focus: <%=Html.TextBox("txtDate").AsDatePicker(new DatePicker(onSelectCallBack:"onSelectTest"))%>
    <br />
    <!-- Binding existing elements to specific behaviour -->
    On Button Click: <input type="text" id="txtTest" /><%=new DatePicker(dateFormat:"dd/mm/yy", buttonText:"Go").Render("txtTest")%>
    <br />

    <h3>AutoComplete</h3>
    <!-- Making standard controls act as AutoComplete -->
    AutoComplete: <%=Html.TextBox("txtValue").AsAutoComplete(new AutoComplete(valueId:"txtHidden", searchUrl:"Search")) %>

    <br />
    <h3>Accordion</h3>

    <%=Html.Accordion(new MVC.Controls.Accordion.AccordionControl()
        .SetLoadingText("Wait")
        .SetCacheTabs()
        .AddAccordionItem(new MVC.Controls.Accordion.AccordionItem()
                          .SetContent(MVC.Controls.ContentType.RemoteAction, "Accordion1")
                          .SetTitle("Remote Action"))
        .AddAccordionItem(new MVC.Controls.Accordion.AccordionItem()
                          .SetTitle("Partial View")
                          .SetContent(MVC.Controls.ContentType.PartialView, "Accordion2"))
        .AddAccordionItem(new MVC.Controls.Accordion.AccordionItem()
                           .SetTitle("Static HTML")
                           .SetContent(MVC.Controls.ContentType.Static, "<b>Static html-based item</b><br /><br />This is an example for a static accordion item using ContentType.Static")
                           .SetSelected()))%>

    
    <br />
    <h3>Tabs</h3>

     <%= Html.Tab(new TabControl()
            .SetCacheTabs(true)
            .SetSpinner("<b>wait!</b>")
            .AddTabItem(new TabItem()
                .SetContent(MVC.Controls.ContentType.RemoteAction, "Tab1")
                .SetTitle("Remote Tab"))
                
            .AddTabItem(new TabItem()
                .SetContent(MVC.Controls.ContentType.PartialView, "Tab2")
                .SetTitle("PartialView Tab"))
                
            .AddTabItem(new TabItem()
                .SetContent(MVC.Controls.ContentType.Static, "<b>Tab3</b><br /><br />This is an example for a static tab using ContentType.Static")
                .SetTitle("Static Tab")))
    %>
</asp:Content>
