<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Infraestrutura.Repositorios.Entidades.Manage>" %>

<asp:Content ID="manageContent" ContentPlaceHolderID="MainContent" runat="server">
    <section id="loginForm">
        <hgroup class="title">
        <h1>Gerenciar Conta</h1>
    </hgroup>
    <form id="form1" runat="server" >
    <p class="message-success"><%: (string)ViewBag.StatusMessage %></p>

    <p>Você está logado como <strong><%: User.Identity.Name %></strong>.</p>

        <div id="Div1" class="editor-field" runat="server">
    <img id="Img1" runat="server" src="../../Images/usu.png" />
    <br /><asp:fileupload ID="Fileupload1" runat="server" Width="295px"></asp:fileupload>
    </div>
    <% Html.RenderPartial("_ChangePasswordPartial"); %>
    </form>
        </section>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ScriptsSection" runat="server">
    <%: Scripts.Render("~/bundles/jqueryval") %>
</asp:Content>