<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<List<Infraestrutura.Repositorios.Entidades.Ranking>>" %>

<% using (Html.BeginForm("Principal", "Game"))
   { %>
<%: Html.AntiForgeryToken() %>
<%: Html.ValidationSummary() %>

<style type="text/css">
    table.space {
        border: solid;
        border-spacing: 10px;
        text-align:center;
    }

    tr.main {
        border: solid;
        font-weight: bold;
    }

    td {
        text-align: center;
        padding: 4px 15px 2px 4px ;
        font-weight: bold;      
    }
</style>

<fieldset>
    <div class="editor-field">
        <h1>Ranking</h1>
    </div>
    <div style="text-align:center">
    <table class="space">
        <tr class="main">
             <td>Posição</td>
             <td>Usuário</td>
             <td>Resp. Certas</td>
             <td>Resp. Erradas</td>
             <td>Respondidas</td>
        </tr>

        <% 
       int i = 0;
            foreach (var item in Model )
            {
                i = i + 1;%>
        <tr>
            <td>
                <%:  @Html.DisplayFor(modelItem => i)%>
            </td>
            <td>
                <%:  @Html.DisplayFor(modelItem => item.Id_User.Nome)%>
            </td>
            <td>
                <%:  @Html.DisplayFor(modelItem => item.qtde_certas)%>
            </td>
            <td>
                <%:  @Html.DisplayFor(modelItem => item.qtde_erradas)%>
            </td>
            <td>
                <%:  @Html.DisplayFor(modelItem => item.qtde_respostas)%>
            </td>
        </tr>
        <% } %>
    </table>
        </div>
</fieldset>

<% } %>
