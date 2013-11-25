<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Infraestrutura.Repositorios.Entidades.Usuario>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <ul>
            <li><%: Html.ActionLink("Salas", "List", "Salas")%> </li>
            <li><%: Html.ActionLink("Criar Salas", "Create","Salas")%> </li>
            <li><%: Html.ActionLink("Ranking", "Ranking", "Game")%></li>
            <li><%: Html.ActionLink("Escolher Personagem", "Personagem", "Account")%></li>
            <li><%: Html.ActionLink("Manutenção da Conta", "Manage", "Account")%></li>
            <li><% using (Html.BeginForm("LogOff", "Account", FormMethod.Post, new { id = "logoutForm" }))
                   { %>
                <%: Html.AntiForgeryToken() %>
                <a href="javascript:document.getElementById('logoutForm').submit()">Log off</a>
                <% } %></li>
        </ul>
    </div>
    <% Html.RenderAction("Ranking_top", "Game"); %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsSection" runat="server">
</asp:Content>
