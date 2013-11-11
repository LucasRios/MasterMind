<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<Infraestrutura.Repositorios.Entidades.Jogos>" %>

<% using (Html.BeginForm("Principal", "Game"))
   { %>
<%: Html.AntiForgeryToken() %>
<%: Html.ValidationSummary() %>


<fieldset>
    <div style="text-align: center">
        <h1>Acesso à sala <%: @Html.LabelFor(model => model.Sala.Sala)%> </h1>
    </div>
    <table>
        <tr>
            <td>Temas Disponíveis
            </td>
            <td>
                <%   using (Html.BeginForm("Acesso", "Salas", FormMethod.Get)) { %>
                <%:  @Html.DropDownList("Id_tema", new SelectList(ViewBag.ListaTemas, "Id_tema", "Desc_tema"), new { @class = "dropdownlist" }) %>
                <%   } %>
            </td>
        </tr>
        <tr>
            <td>
                Senha de Acesso
            </td>
            <td>
                <div class="editor-field">
                    <%:  @Html.TextBoxFor(model => model.Sala.Senha, new  { @class="txtMedium" })%>
                    <%:  @Html.ValidationMessageFor(model => model.Sala.Senha)%>
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <div>
                    <input type="submit" value="Acessar" />
                </div>
            </td>
        </tr>
    </table>
</fieldset>

<% } %>
