<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<Infraestrutura.Repositorios.Entidades.Usuario>" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device-width" />
</head>
<body>
    <div>
        <% if (@Html.ValueFor(model => model.Personagem) != null)%>
        <% {%>
        <img src="<%: @Html.ValueFor(model => model.Personagem.Imagem) %>" class="imgPerfil" />
        <br />
        <h6><%: @Html.ValueFor(model => model.Personagem.Desc_person)  %> </h6>
        <% }
           else
           {%>
        <img src="~/Images/usu.png" class="imgPerfil" />
        <%} %>
    </div>
</body>
</html>
