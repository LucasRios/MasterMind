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
                    <%: Html.LabelFor(m => m.usuario) %>
                    <%: Html.TextBoxFor(m => m.usuario) %>
                    <%: Html.ValidationMessageFor(m => m.usuario) %>
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
    <h3>Master Mind - O jogo do Conhecimento</h3>
    <ol class="round">
        <li class="one">
            <h5>Crie sua conta.</h5>
            Crie seu perfil em menos de 2 minutos!             
        </li>

        <li class="two">
            <h5>Salas personalizadas.</h5>
            Acesse uma sala ou crie sua própria sala para jogar com os amigos!
        </li>

        <li class="three">
            <h5>Comece a jogar!</h5>
            Mostre que você é um MasterMind! Supere seus amigos e adquira conhecimento brincando!
        </li>
    </ol>
    </section>
</asp:Content>

<asp:Content ID="scriptsContent" ContentPlaceHolderID="ScriptsSection" runat="server">
    <%: Scripts.Render("~/bundles/jqueryval") %>
</asp:Content>
