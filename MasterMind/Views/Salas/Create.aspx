<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Principal.Master" Inherits="System.Web.Mvc.ViewPage<Infraestrutura.Repositorios.Entidades.Salas>" %>

<asp:Content ID="aboutContent" ContentPlaceHolderID="PrincipalMiddle" runat="server">
    <% using (Html.BeginForm(new { ReturnUrl = ViewBag.ReturnUrl })) { %>
    <%: Html.AntiForgeryToken() %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Create</legend>
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
                <td style="text-align: left;">
                    <div>
                        <input type="radio" name="beds" value="1" checked="checked" style="margin-right: 0; width: 30px" /><asp:Label ID="Label23" runat="server" Font-Bold="True" Width="80%" Style="text-align: left;">Privado</asp:Label>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div class="editor-label"><%:  @Html.LabelFor(model => model.Niveis.descricao)%></div>
                </td>
                <td>
                    <%:  @Html.DropDownListFor(u => u.Niveis.Id_Nivel, new SelectList(ViewBag.ListaNiveis, "Id_nivel", "descricao"), new { @class = "dropdownlist"})%>
                     <%:  @Html.ValidationMessageFor(model => model.Niveis.Id_Nivel)%>
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
                        <input type="submit" class="btn btn-info" value="Acessar" />
                    </div>
                </td>
            </tr>
        </table>
    </fieldset>
    <% } %>
</asp:Content>



