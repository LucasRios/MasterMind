<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<List<Infraestrutura.Repositorios.Entidades.Salas>>" %>

<% using (Html.BeginForm("Principal", "Game"))
   { %>
<%: Html.AntiForgeryToken() %>
<%: Html.ValidationSummary() %>

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
                <%:  @Html.DisplayFor(modelItem => item.Id_usuario)%>
            </td>
            <td>0
            </td>
            <td>
                <%:  @Html.DisplayFor(modelItem => item.Perfil)%>
            </td>
            <td>
                <input type="button" value="Acessar" />
            </td>
        </tr>
        <% } %>
    </table>
</fieldset>

<% } %>
