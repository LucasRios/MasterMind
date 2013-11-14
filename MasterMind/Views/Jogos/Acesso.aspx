<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Infraestrutura.Repositorios.Entidades.Jogos>" %>

<asp:Content ID="aboutContent" ContentPlaceHolderID="MainContent" runat="server">
    <% using (Html.BeginForm(new { ReturnUrl = ViewBag.ReturnUrl }))
       { %>
    <%: Html.AntiForgeryToken() %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <div>
            <h1>Acesso à sala <%: @Html.DisplayTextFor(model => model.Sala.Sala)%> </h1>
            <%: Html.HiddenFor(model => model.Sala.Id_Sala)%>
            <%: Html.HiddenFor(model => model.Sala.Sala)%>
            <%: Html.HiddenFor(model => model.Sala.Senha)%>
        </div>
        <table>
            <tr>
                <td>
                    <div class="editor-label"><%:  @Html.LabelFor(model => model.Tema.Desc_tema)%></div>
                </td>
                <td>
                    <%:  @Html.DropDownListFor(u => u.Tema.Id_tema, new SelectList(ViewBag.ListaTemas, "Id_tema", "Desc_tema"), new { @class = "dropdownlist"})%>
                    <%: Html.HiddenFor(u => u.Tema.Desc_tema)%>
                    <%:  @Html.ValidationMessageFor(u => u.Tema.Id_tema)%>
                </td>
            </tr>
            <tr>
                <td>
                    <div class="editor-label"><%:  @Html.LabelFor(model => model.Senha)%></div>
                </td>
                <td>
                    <div class="editor-field">
                        <%:  @Html.TextBoxFor(model => model.Senha, new  { @class="txtMedium" })%>
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
