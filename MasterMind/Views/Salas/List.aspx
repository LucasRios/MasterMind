<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Principal.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Infraestrutura.Repositorios.Entidades.Salas>>" %>

<asp:Content ID="aboutContent" ContentPlaceHolderID="PrincipalMiddle" runat="server">

    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">


    <script src="../../Scripts/js/jquery.dropdown.js"></script>
    <style type="text/css">
        .tdSala 
        {width: 50px;        }
               
               .tdDesc
                {width: 220px;        }
               .tdOwner
                {width: 160px;        }
               .tdJogadores
                {width: 50px;        }
               .tdPerfil
                {width: 50px;        }
               .tdNivel
                {width: 50px;        }
               .tdAcesso
                {width: 70px;        }
    </style>

    <div class="container" style="width: 830px; height: 120px; float: inherit; margin: 10px;">
        <section class="main clearfix" style="float: left;">
            <h1>Procurar Salas</h1>
            <div class="fleft" style="width: 80px; float: left; margin-left: 10px; margin-right: 10px;">
                <select id="Niveis.Id_Nivel" name="cd-dropdown" class="cd-select">
                    <% foreach (var item in ViewBag.ListaNivel)
                       { %>
                    <option
                        <% if (item.Id_Nivel == 0)
                           {%>
                        value="-1"
                        selected
                        <%}
                           else
                           {%>
                        value="<%:  item.Id_Nivel %>"
                        <%} %>>
                        <%:  item.descricao %>
                    </option>
                    <%  }  %>
                </select>
            </div>

            <div class="fleft" style="width: 120px; float: left; margin-left: 10px; margin-right: 10px;">
                <select id="tpSala" name="cd-dropdown" class="cd-select">
                    <% foreach (var item in ViewBag.ListaTPSala)
                       { %>
                    <option
                        <% if (item.Id_TPSala == 0)
                           {%>
                        value="-1"
                        selected
                        <%}
                           else
                           {%>
                        value="<%:  item.Id_TPSala %>"
                        <%} %>>
                        <%:  item.descricao %>
                    </option>
                    <%  }  %>
                </select>
            </div>
            <div style="width: 120px; height: 52px; padding-top: 5px; float: left; margin-left: 10px; margin-right: 10px;">
                <input type="button" id="btnFiltrar" value="Consultar" class="btn btn-info" />
            </div>

        </section>



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
    <!-- /container -->


    <script type="text/javascript">
        $(document).ready(function () {

            $(function () {

                $('#Niveis.Id_Nivel').dropdown({
                    gutter: 5
                });

            });

            $(function () {

                $('#tpSala').dropdown({
                    gutter: 5
                });

            });
            $("#btnFiltrar").click(function(e){
                var dropvalue = document.getElementsByName("cd-dropdown");
                $.ajax({
                    type: "POST",
                    url: "ListarSalas",
                    success     : function(retorno){
                        $("#tbSalas .items").remove();
                        $.each(retorno,function(e){
                            console.log(this);
                            var html="";
                            html+=          "<tr class='items' >";
                            html+="<td class='tdSala'>";
                            html+=this.Id_Sala;
                            html+="</td>";
                            html+="<td class='tdDesc'>";
                            html+=this.Sala;
                            html+="</td>";
                            html+="<td class='tdOwner'>";
                            html+=this.Usuario.Nome;
                            html+="</td>";
                            html+="<td class='tdJogadores'>"+ this.qtde_usu +" /12";
                            html+="</td>";
                            html+="<td class='tdPerfil'>";
                            html+=this.Desc_perfil;
                            html+="</td>";
                            html+="<td class='tdNivel'>";
                            html+=this.Niveis.descricao;
                            html+="</td>";
                            html+="<td class='tdAcesso'>";
                            html+="<input type='button' value='Acessar' class='btn btn-info' onclick=\"window.location.href='\/Jogos\/Acesso\/" + this .Id_Sala +"'\" />";
                            html+="</td>";
                            html+="</tr>";

                            $("#tbSalas").append(html);
                        });
                    },
                    data: {Id_nivel:dropvalue[0].value,Id_perfil:dropvalue[1].value},
                    dataType: "json"
                });
            });
        });
    </script>
</asp:Content>
