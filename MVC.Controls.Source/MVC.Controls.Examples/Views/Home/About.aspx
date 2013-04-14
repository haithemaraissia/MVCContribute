<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="aboutTitle" ContentPlaceHolderID="TitleContent" runat="server">
    About Us
</asp:Content>

<asp:Content ID="aboutContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>About</h2>
    <p>
        The current release still holds only the Grid control,<br />
        But the upcoming major relese will have a wrapper controls for more jquery extenders.<br />
        So stay tuned and give us some feedback, thanks!
    </p>
</asp:Content>
