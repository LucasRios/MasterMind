<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
                            <div>
                        <ul>
                            <li><%: Html.ActionLink("Salas", "List", "Salas")%> </li>
                            <li><%: Html.ActionLink("Criar Salas", "Create","Salas")%> </li>
                            <li><%: Html.ActionLink("Ranking", "Ranking", "Game")%></li>
                        </ul>
                    </div>
        <% Html.RenderAction("Ranking_top", "Game"); %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsSection" runat="server">

</asp:Content>
