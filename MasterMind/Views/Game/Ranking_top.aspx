﻿<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<List<Infraestrutura.Repositorios.Entidades.Ranking>>" %>

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
        padding: 4px 15px 2px 4px ;
        font-weight: bold;      
    }
</style>

<fieldset>
    <table class="space">
        <tr class="main">
            <td colspan="2" >Ranking</td>
        </tr>
        <tr>
             <td>Pos.</td>
             <td>Usuário</td>
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
        </tr>
        <% } %>
    </table>
</fieldset>

<% } %>