<%@ Page Language="C#"  Inherits="System.Web.Mvc.ViewPage<Infraestrutura.Repositorios.Entidades.Salas>" %>





    <% using (Html.BeginForm("Principal", "Game"))
       { %>
<%: Html.AntiForgeryToken() %>
<%: Html.ValidationSummary() %>

<fieldset>
    <div class="editor-field">
        <%: Html.HiddenFor(model => model.Perfil, new { @Value = "2"})%>
        <h1>Crie sua propria Sala</h1>
    </div>
    <table>
        <tr>
            <td>
                <div class="editor-label">
                    <%: @Html.LabelFor(model => model.Sala)%>
                </div>
            </td>
            <td>
                <div class="editor-field">
                    <%:   @Html.TextBoxFor(model => model.Sala, new  { @class="txtMedium" })%>
                    <%:   @Html.ValidationMessageFor(model => model.Sala)%>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <div class="editor-label">
                    <%:    @Html.LabelFor(model => model.Perfil)%>
                </div>
            </td>
            <td>
                <div class="editor-field">
                    <input type="radio" name="beds" value="1" checked="checked" style="margin-right: 0; width: 30px" /><asp:label id="Label23" runat="server" font-bold="True" width="80%">Privado</asp:label>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <div class="editor-label">
                    <%:  @Html.LabelFor(model => model.Senha)%>
                </div>
            </td>
            <td>
                <div class="editor-field">
                    <%:  @Html.TextBoxFor(model => model.Senha, new  { @class="txtMedium" })%>
                    <%:  @Html.ValidationMessageFor(model => model.Senha)%>
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
  


