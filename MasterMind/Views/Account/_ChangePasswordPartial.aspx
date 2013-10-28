<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<Infraestrutura.Repositorios.Entidades.Cadastro>" %>

<h3>Change password</h3>

<% using (Html.BeginForm("Manage", "Account")) { %>
    <%: Html.AntiForgeryToken() %>
    <%: Html.ValidationSummary() %>

    <fieldset>
        <legend>Change Password Form</legend>
        <ol>
            <li>
                <%: Html.LabelFor(m => m.OldPassword) %>
                <%: Html.PasswordFor(m => m.OldPassword) %>
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
        <input type="submit" value="Submeter" />
    </fieldset>
<% } %>
