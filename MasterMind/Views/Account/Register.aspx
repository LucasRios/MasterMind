<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Infraestrutura.Repositorios.Entidades.Cadastro>" %>

<asp:Content ID="registerContent" ContentPlaceHolderID="MainContent" runat="server">
    <hgroup class="title" style="margin-left: 40px;">        
        <h1>Criar uma nova conta</h1>
    </hgroup>

    <% using (Html.BeginForm()) { %>
        <%: Html.AntiForgeryToken() %>
        <%: Html.ValidationSummary() %>

        <fieldset style="margin-left: 40px;">
            <legend>Registration Form</legend>
            <ol>
                <li>
                    <%: Html.LabelFor(m => m.usuario ) %>
                    <%: Html.TextBoxFor(m => m.usuario) %>
                </li>
                <li>
                    <%: Html.LabelFor(m => m.email) %>
                    <%: Html.TextBoxFor(m => m.email) %>
                </li>
                <li>
                    <%: Html.LabelFor(m => m.Nome1) %>
                    <%: Html.TextBoxFor(m => m.Nome1) %>
                </li>
                <li>
                    <%: Html.LabelFor(m => m.sobrenome) %>
                    <%: Html.TextBoxFor(m => m.sobrenome) %>
                </li>
                <li>
                    <%: Html.LabelFor(m => m.dt_nasc) %>
                    <%: Html.TextBoxFor(m => m.dt_nasc) %>
                </li>
                <li>
                    <%: Html.LabelFor(m => m.pais) %>
                    <%: Html.TextBoxFor(m => m.pais) %>
                </li>
                <li>
                    <%: Html.LabelFor(m => m.estado) %>
                    <%: Html.TextBoxFor(m => m.estado) %>
                </li>
                <li>
                    <%: Html.LabelFor(m => m.cidade) %>
                    <%: Html.TextBoxFor(m => m.cidade) %>
                </li>
                <li>
                    <%: Html.LabelFor(m => m.Senha) %>
                    <%: Html.PasswordFor(m => m.Senha) %>
                </li>
                <li>
                    <%: Html.LabelFor(m => m.ConfirmPassword) %>
                    <%: Html.PasswordFor(m => m.ConfirmPassword) %>
                </li>
            </ol>
            <input type="submit" value="Registrar" />
        </fieldset>
    <% } %>
</asp:Content>

<asp:Content ID="scriptsContent" ContentPlaceHolderID="ScriptsSection" runat="server">
    <%: Scripts.Render("~/bundles/jqueryval") %>
</asp:Content>
