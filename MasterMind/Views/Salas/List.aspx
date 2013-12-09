<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Principal.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Infraestrutura.Repositorios.Entidades.Salas>>" %>

<asp:Content ID="aboutContent" ContentPlaceHolderID="PrincipalMiddle" runat="server">
  <% using (Html.BeginForm(new { ReturnUrl = ViewBag.ReturnUrl }))
       { %>
        <%: Html.AntiForgeryToken() %>
        <%: Html.ValidationSummary(true)  %>

 <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">


    <script src="../../Scripts/js/jquery.dropdown.js"></script>
    <style type="text/css">
        .tdSala {
            width: 50px;
        }

        .tdDesc {
            width: 220px;
        }

        .tdOwner {
            width: 160px;
        }

        .tdJogadores {
            width: 50px;
        }

        .tdPerfil {
            width: 50px;
        }

        .tdNivel {
            width: 50px;
        }

        .tdAcesso {
            width: 70px;
        }
    </style>

  <div class="container" style="width: 830px; height: 120px; float: inherit; margin: 10px;">
      
            <h1>Procurar Salas</h1>
            <div class="divSelect" >
                <%:   @Html.DropDownList("Id_nivel", new SelectList(ViewBag.ListaNivel, "Id_nivel", "descricao")) %>
                
            </div>
            <div class="divSelect" >
                <%:  @Html.DropDownList("Id_perfil", new SelectList(ViewBag.ListaTPSala, "Id_TPSala", "descricao")) %>
            </div>




            <div style="width: 120px; height: 52px; padding-top: 5px; float: left; margin-left: 10px; margin-right: 10px;">
                <input type="submit" value="Consultar" class="btn btn-info"/>
            </div>




    </div>
    <div style="margin: 10px;" id="divLista">
        <fieldset>
            <h1>Salas</h1>
            <table id="tbSalas">
                <tr class="main">
                    <td class="tdSala">ID
                    </td>
                    <td class="tdDesc">Sala
                    </td>
                    <td class="tdOwner">Criador
                    </td>
                    <td class="tdJogadores">Qtde/Usuarios
                    </td>
                    <td class="tdPerfil">Perfil
                    </td>
                    <td class="tdNivel">Nível
                    </td>
                    <td class="tdAcesso"></td>
                </tr>

                <% foreach (var item in Model)
                   {%>
                <tr class="items">
                    <td class="tdSala">
                        <%:  @Html.DisplayFor(modelItem => item.Id_Sala)%>
                    </td>
                    <td class="tdDesc">
                        <%:  @Html.DisplayFor(modelItem => item.Sala)%>
                    </td>
                    <td class="tdOwner">
                        <%:  @Html.DisplayFor(modelItem => item.Usuario.Nome)%>
                    </td>
                    <td class="tdJogadores"><%:  @Html.DisplayFor(modelItem => item.qtde_usu)%> /12
                    </td>
                    <td class="tdPerfil">
                        <%:  @Html.DisplayFor(modelItem => item.Desc_perfil)%>
                    </td>
                    <td class="tdNivel">
                        <%:  @Html.DisplayFor(modelItem => item.Niveis.descricao)%>
                    </td>
                    <td class="tdAcesso">
                         <input type="button" value="Acessar" class="btn btn-info" onclick="window.location.href='<%: @Url.Action("Acesso", "Jogos", new { Id = item.Id_Sala, senha = "" })%>    '" />
                    </td>
                </tr>
                <% } %>
            </table>
        </fieldset>
    </div>
   

     <% } %>
</asp:Content>