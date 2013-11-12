<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<Infraestrutura.Repositorios.Entidades.Salas>>" %>

<asp:Content ID="aboutContent" ContentPlaceHolderID="MainContent" runat="server">
    <% using (Html.BeginForm(new { ReturnUrl = ViewBag.ReturnUrl })) { %>
        <%: Html.AntiForgeryToken() %>
        <%: Html.ValidationSummary(true) %>

<style type="text/css">
    table.space {
        border: solid;
        border-spacing: 10px;
    }

    tr.main {
        border: solid;
        font-weight: bold;
    }

    td {
        text-align: center;
        padding: 4px 50px 2px 4px ;
        font-weight: bold;      
    }
</style>

<fieldset>
    <h1>Acesse uma sala abaixo</h1>
    <table class="space">
        <tr class="main">
            <td>Sala
            </td>
            <td>Criador
            </td>
            <td>Qtde/Usuarios
            </td>
            <td>Perfil
            </td>
            <td></td>
        </tr>

        <% foreach (var item in Model)
           {%>
        <tr>
            <td>
                <%:  @Html.DisplayFor(modelItem => item.Sala)%>
            </td>
            <td>
                <%:  @Html.DisplayFor(modelItem => item.Id_Usuario)%>
            </td>
            <td>0
            </td>
            <td>
                <%:  @Html.DisplayFor(modelItem => item.Perfil)%>
            </td>
            <td>
                <input type="button" value="Acessar" onclick="window.location.href='<%: @Url.Action("Acesso", "Jogos", new { Id = item.Id_Sala })%>    '" />
            </td>
        </tr>
        <% } %>
    </table>
</fieldset>
    <% } %>

</asp:Content>
