<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<MasterMind.Models.RegisterExternalLoginModel>" %>

<asp:Content ID="externalLoginConfirmationContent" ContentPlaceHolderID="MainContent" runat="server">
    <hgroup class="title">
        <h1>Registro</h1>
        <h2>Associar sua conta <%: ViewBag.ProviderDisplayName %> </h2>
    </hgroup>

    <% using (Html.BeginForm("ExternalLoginConfirmation", "Account", new { ReturnUrl = ViewBag.ReturnUrl })) { %>
        <%: Html.AntiForgeryToken() %>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Associação</legend>
            <p>
                <strong><%: ViewBag.ProviderDisplayName %></strong>.
                Por favor entre com o usuário e senha deste site e em seguida clique no botão de confirmação.
            </p>
            <ol>
                <li class="name">
                    <%: Html.LabelFor(m => m.UserName) %>
                    <%: Html.TextBoxFor(m => m.UserName) %>
                    <%: Html.ValidationMessageFor(m => m.UserName) %>
                </li>
            </ol>
            <%: Html.HiddenFor(m => m.ExternalLoginData) %>
            <input type="submit" value="Registrar" />
        </fieldset>
    <% } %>
</asp:Content>

<asp:Content ID="scriptsContent" ContentPlaceHolderID="ScriptsSection" runat="server">
    <%: Scripts.Render("~/bundles/jqueryval") %>
</asp:Content>
