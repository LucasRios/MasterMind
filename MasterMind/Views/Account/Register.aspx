<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Infraestrutura.Repositorios.Entidades.Usuario>" %>

<asp:Content ID="registerContent" ContentPlaceHolderID="MainContent" runat="server">
    <hgroup class="title" style="margin-left: 40px;">
        <h1>Criar uma nova conta</h1>
    </hgroup>

    <% using (Html.BeginForm())
       { %>
    <%: Html.AntiForgeryToken() %>
    <%: Html.ValidationSummary() %>

    <fieldset style="margin-left: 40px;">
        <legend>Registration Form</legend>
        <table>
            <tr>
                <td>

                    <div class="editor-label">
                        <%:  Html.LabelFor(model => model.Nome)%>
                    </div>
                    <div class="editor-field">
                        <%:  Html.TextBoxFor(model => model.Nome, new { tabindex=1})%>
                        <%:  Html.ValidationMessageFor(model => model.Nome)%>
                    </div>
                </td>
                <td>
                    <div class="editor-label">
                        <%: Html.LabelFor(model => model.Sobrenome)%>
                    </div>
                    <div class="editor-field">
                        <%: Html.TextBoxFor(model => model.Sobrenome, new { tabindex=2})%>
                        <%: Html.ValidationMessageFor(model => model.Sobrenome)%>
                    </div>

                </td>
                <td>
                    <div class="editor-label">
                        <%:  Html.Label("Sexo")%>
                        <%:  Html.DropDownListFor(u => u.Sexo, new SelectList(ViewBag.ListaSexo, "Sigla", "Sexo"), new { @class = "dropdownlist", tabindex=6 })%>
                        <%:  Html.ValidationMessageFor(model => model.Sexo)%>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div class="editor-label">
                        <%:  Html.LabelFor(model => model.Email)%>
                    </div>
                    <div class="editor-field">
                        <%: Html.TextBoxFor(model => model.Email, new { tabindex=3 })%>
                        <%: Html.ValidationMessageFor(model => model.Email)%>
                    </div>

                </td>
                <td>

                    <div class="editor-label">
                        <%:  Html.LabelFor(model => model.Senha)%>
                    </div>
                    <div class="editor-field">
                        <%:  Html.PasswordFor(model => model.Senha, new { tabindex=4})%>
                        <%:  Html.ValidationMessageFor(model => model.Senha)%>
                    </div>
                </td>
            </tr>
            <tr>
                <td>

                    <div class="editor-label">
                        <%: Html.LabelFor(model => model.Dt_nasc)%>
                    </div>
                    <div class="editor-field">
                        <%:  Html.TextBoxFor(model => model.Dt_nasc, new { tabindex=5})%>
                        <%: Html.ValidationMessageFor(model => model.Dt_nasc)%>
                    </div>
                </td>
                <td>
                    <div class="editor-label">
                        <%: Html.LabelFor(model => model.Estado)%>
                    </div>
                    <div class="editor-field">
                        <%: Html.TextBoxFor(model => model.Estado, new { tabindex=8})%>
                        <%: Html.ValidationMessageFor(model => model.Estado)%>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div class="editor-label">
                        <%:  Html.LabelFor(model => model.Cidade)%>
                    </div>
                    <div class="editor-field">
                        <%:  Html.TextBoxFor(model => model.Cidade, new { tabindex=7})%>
                        <%: Html.ValidationMessageFor(model => model.Cidade)%>
                    </div>


                </td>
                <td>
                    <div class="editor-label">
                        <%:  Html.LabelFor(model => model.Pais)%>
                    </div>
                    <div class="editor-field">
                        <%:  Html.TextBoxFor(model => model.Pais, new { tabindex=9})%>
                        <%:  Html.ValidationMessageFor(model => model.Pais)%>
                    </div>


                </td>

            </tr>
        </table>

        <input type="submit" value="Registrar" />
    </fieldset>
    <% } %>
</asp:Content>

<asp:Content ID="scriptsContent" ContentPlaceHolderID="ScriptsSection" runat="server">
    <%: Scripts.Render("~/bundles/jqueryval") %>
</asp:Content>
