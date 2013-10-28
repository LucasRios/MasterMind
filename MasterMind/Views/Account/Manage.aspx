<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<System.Web.Mvc.Models.LocalPasswordModel>" %>

<asp:Content ID="manageContent" ContentPlaceHolderID="MainContent" runat="server">
    <section id="loginForm">
        <hgroup class="title">
        <h1>Gerenciar Conta</h1>
    </hgroup>
    <form id="form1" runat="server" >
    <p class="message-success"><%: (string)ViewBag.StatusMessage %></p>

    <p>Você está logado como <strong><%: User.Identity.Name %></strong>.</p>

    <asp:image ID="Image1" runat="server" ImageUrl="~/Images/usu.png" Height="208px" Width="208px" ></asp:image>
    <br /><asp:fileupload ID="Fileupload1" runat="server" Width="295px"></asp:fileupload>

    <% Html.RenderPartial("_ChangePasswordPartial"); %>
    </form>
        </section>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ScriptsSection" runat="server">
    <%: Scripts.Render("~/bundles/jqueryval") %>
</asp:Content>