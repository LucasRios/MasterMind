<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Infraestrutura.Repositorios.Entidades.Jogos>" %>

<asp:Content ID="aboutContent" ContentPlaceHolderID="MainContent" runat="server">
    <% using (Html.BeginForm(new { ReturnUrl = ViewBag.ReturnUrl })) { %>
        <%: Html.AntiForgeryToken() %>
        <%: Html.ValidationSummary(true) %>
<fieldset>
    <div>
        <h1>Acesso à sala <%: @Html.DisplayTextFor(model => model.Sala.Sala)%> </h1>
        <%: Html.HiddenFor(model => model.Id_sala)%>
    </div>
    <table>
        <tr>
            <td><div class="editor-label">Temas Disponíveis</div>
            </td>
            <td>
                <%:  @Html.DropDownListFor(u => u.Id_tema, new SelectList(ViewBag.ListaTemas, "Id_tema", "Desc_tema"), new { @class = "dropdownlist"})%>
            </td>
        </tr>
        <tr>
            <td><div class="editor-label">Nível de Dificuldade</div>
            </td>
            <td>
                <%:  @Html.DropDownListFor(u => u.Id_nivel, new SelectList(ViewBag.ListaNiveis, "Id_nivel", "descricao"), new { @class = "dropdownlist"})%>
            </td>
        </tr>
        <tr>
            <td>
               <div class="editor-label"> Senha de Acesso </div>
            </td>
            <td>
                <div class="editor-field">
                    <%:  @Html.TextBoxFor(model => model.Senha, new  { @class="txtMedium" })%>
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
</asp:Content>
