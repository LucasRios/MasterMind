<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MasterMind.Models.LoginModel>" %>

<asp:Content ID="loginContent" ContentPlaceHolderID="MainContent" runat="server">
    <hgroup class="title">
        
    </hgroup>

    <section id="loginForm">
    <h2>Use sua conta local para acessar</h2>
    <% using (Html.BeginForm(new { ReturnUrl = ViewBag.ReturnUrl })) { %>
        <%: Html.AntiForgeryToken() %>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Log in</legend>
            <ol>
                <li>
                    <%: Html.LabelFor(m => m.email) %>
                    <%: Html.TextBoxFor(m => m.email) %>
                    <%: Html.ValidationMessageFor(m => m.email) %>
                </li>
                <li>
                    <%: Html.LabelFor(m => m.Senha) %>
                    <%: Html.PasswordFor(m => m.Senha) %>
                    <%: Html.ValidationMessageFor(m => m.Senha) %>
                </li>
                <li>
                    <%: Html.CheckBoxFor(m => m.RememberMe) %>
                    <%: Html.LabelFor(m => m.RememberMe, new { @class = "checkbox" }) %>
                </li>
            </ol>
            <input type="submit" value="Acessar" />
        </fieldset>
        <p>
            <%: Html.ActionLink("Registre-se", "Register") %> se você não possui uma conta.
        </p>
    <% } %>
    </section>

    <section class="social" id="socialLoginForm">
    <h2>Master Mind - O jogo do Conhecimento</h2>
        <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <img src="../Images/logo.png" />
    </section>
</asp:Content>

<asp:Content ID="scriptsContent" ContentPlaceHolderID="ScriptsSection" runat="server">
    <%: Scripts.Render("~/bundles/jqueryval") %>
</asp:Content>
