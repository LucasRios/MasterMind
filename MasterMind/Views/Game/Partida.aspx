<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <hgroup class="title">        
    </hgroup>

           <form id="form1" runat="server" style="height: 506px; width: 1316px; margin-top: 0px">          

    <section id="Info" style="height: 71px">
       <fieldset style="height: 66px; border: solid; width : 100%">
           <legend style= "display: block;">Informações da Partida</legend>
    
                       <asp:Label ID="Label4" runat="server" Font-Bold="True"                         
                           Text="Perguntas Respondidas" style="z-index: 1; left: 237px; top: 118px; position: absolute"></asp:Label>
                   <asp:Label ID="Label5" runat="server" Font-Bold="True" 
                       Text="5" style="z-index: 1; left: 309px; top: 143px; position: absolute; width: 18px; right: 1010px;"></asp:Label>

                   <asp:Label ID="Label7" runat="server" Font-Bold="True" 
                       Text="3" style="z-index: 1; left: 484px; top: 143px; position: absolute; width: 14px; height: 19px;"></asp:Label>

                   <asp:Label ID="Label9" runat="server" Font-Bold="True"  
                       Text="2" style="z-index: 1; left: 628px; top: 143px; position: absolute; width: 37px"></asp:Label>
    
                   <asp:Label ID="Label6" runat="server" Font-Bold="True"  
                       Text="Respostas Certas" style="z-index: 1; left: 423px; top: 118px; position: absolute"></asp:Label>

                   <asp:Label ID="Label8" runat="server" Font-Bold="True" 
                       Text="Respostas Erradas" style="z-index: 1; left: 567px; top: 118px; position: absolute"></asp:Label>

                    <asp:Label ID="Label1" runat="server" Font-Bold="True"  
                       Text="Geografia" style="z-index: 1; left: 746px; top: 143px; position: absolute; "></asp:Label>
    
                   <asp:Label ID="Label2" runat="server" Font-Bold="True"  
                       Text="Tema Principal" style="z-index: 1; left: 727px; top: 118px; position: absolute"></asp:Label>

                   <asp:Label ID="Label10" runat="server" Font-Bold="True"  
                       Text="9" style="z-index: 1; left: 913px; top: 143px; position: absolute; width: 19px;"></asp:Label>
    
                   <asp:Label ID="Label11" runat="server" Font-Bold="True"  
                       Text="Qtde. Jogadores" style="z-index: 1; left: 867px; top: 118px; position: absolute"></asp:Label>
    
                           <asp:Button ID="Button1" runat="server" Text="Abandonar Jogo" BorderStyle="None" 
                        BackColor="#CCCCCC" ForeColor="Black" style="z-index: 1; left: 1157px; top: 118px; position: absolute; height: 35px; width: 155px;"/>
           </fieldset>
    
    </section>

               <asp:Panel ID="Panel1" runat="server"                    
                   style="position: absolute; z-index: 1; left: 12px; top: 176px; height: 475px; width: 280px" 
                   BackColor="White" BorderStyle="Groove" BorderWidth="4px" 
                   HorizontalAlign="left">


                  <table style="margin-top:0">
                        <tr>
                           <td colspan="2" style="border:solid;text-align:center">
                                <asp:Label ID="Label22" runat="server" Font-Bold="True"  Width="100%">Geografia</asp:Label>
                           </td>
                       </tr>
                       <tr>
                           <td>
                                <asp:Image ID="Image12" runat="server" ImageUrl="~/Images/cartoon.jpg" Height="82px" Width="70px" />
                           </td>
                           <td style="text-align:center">
                                <asp:Label ID="Label3" runat="server" Font-Bold="True"  Width="100%">Qual a capital do Acre?</asp:Label> 
                               
                           </td>
                       </tr>
                       <tr>
                           <td colspan="2" style="padding:0">
                                   <input type="radio" name="beds" value="0" style="margin-right: 0; width:30px" /><asp:Label ID="Label23" runat="server" Font-Bold="True"  Width="80%">Rondônia</asp:Label>
                                   <br /><input type="radio" name="beds" value="1" style="margin-right: 0; width:30px" /><asp:Label ID="Label24" runat="server" Font-Bold="True"  Width="80%">Amazônia</asp:Label>
                                   <br /><input type="radio" name="beds" value="2" style="margin-right: 0; width:30px" /><asp:Label ID="Label25" runat="server" Font-Bold="True"  Width="80%">Acre</asp:Label>
                                   <br /><input type="radio" name="beds" value="3" style="margin-right: 0; width:30px" /><asp:Label ID="Label26" runat="server" Font-Bold="True"  Width="80%">Rio Branco</asp:Label>                               
                           </td>
                       </tr>
                  </table>
                               
                  <asp:Image ID="Image1" runat="server" Height="114px" 
                       ImageUrl="~/Images/cartas2.png" 
                       style="z-index: 1; left: 69px; top: 357px; position: absolute" 
                       Width="140px" />
               </asp:Panel>

                                  
               <asp:Panel ID="Panel3" runat="server" BorderStyle="Groove" BorderWidth="4px" 
                   style="z-index: 1; left: 1045px; top: 176px; position: absolute; height: 475px; width: 280px;">
                   <table style="width:100%;margin-top:0">
                        <tr>
                           <td colspan="2" style="border:solid; text-align:center">
                                <asp:Label ID="Label21" runat="server" Font-Bold="True" Width="100%">Participantes</asp:Label>
                           </td>
                       </tr>
                       <tr>
                           <td style="width:20%">
                                <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/usu.png" Height="40px" Width="40px" />
                           </td>
                           <td>
                                <asp:Label ID="Label12" runat="server" Font-Bold="True"  Text="Jogador 1" ></asp:Label>
                        </td>

                       </tr>
                       <tr>
                           <td style="width:20%">
                                <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/usu.png" Height="40px" Width="40px" />
                           </td>
                           <td>
                                <asp:Label ID="Label13" runat="server" Font-Bold="True"  Text="Jogador 2" ></asp:Label>
                        </td>
                           </tr>
                       <tr>
                           <td style="width:20%">
                                <asp:Image ID="Image4" runat="server" ImageUrl="~/Images/usu.png" Height="40px" Width="40px" />
                           </td>
                           <td>
                                <asp:Label ID="Label14" runat="server" Font-Bold="True"  Text="Jogador 3" ></asp:Label>
                        </td>
                           </tr>
                       <tr>
                           <td style="width:20%">
                                <asp:Image ID="Image6" runat="server" ImageUrl="~/Images/usu.png" Height="40px" Width="40px" />
                           </td>
                           <td>
                                <asp:Label ID="Label15" runat="server" Font-Bold="True"  Text="Jogador 4" ></asp:Label>
                        </td>
                           </tr>
                       <tr>
                           <td style="width:20%">
                                <asp:Image ID="Image7" runat="server" ImageUrl="~/Images/usu.png" Height="40px" Width="40px" />
                           </td>
                           <td>
                                <asp:Label ID="Label16" runat="server" Font-Bold="True"  Text="Jogador 5" ></asp:Label>
                        </td>
                           </tr>
                       <tr>
                           <td style="width:20%">
                                <asp:Image ID="Image8" runat="server" ImageUrl="~/Images/usu.png" Height="40px" Width="40px" />
                           </td>
                           <td>
                                <asp:Label ID="Label17" runat="server" Font-Bold="True"  Text="Jogador 6" ></asp:Label>
                        </td>
                           </tr>
                       <tr>
                           <td style="width:20%">
                                <asp:Image ID="Image9" runat="server" ImageUrl="~/Images/usu.png" Height="40px" Width="40px" />
                           </td>
                           <td>
                                <asp:Label ID="Label18" runat="server" Font-Bold="True"  Text="Jogador 7" ></asp:Label>
                        </td>
                           </tr>
                       <tr>
                           <td style="width:20%">
                                <asp:Image ID="Image10" runat="server" ImageUrl="~/Images/usu.png" Height="40px" Width="40px" />
                           </td>
                           <td>
                                <asp:Label ID="Label19" runat="server" Font-Bold="True"  Text="Jogador 8" ></asp:Label>
                        </td>
                           </tr>
                       <tr>
                           <td style="width:20%">
                                <asp:Image ID="Image11" runat="server" ImageUrl="~/Images/usu.png" Height="40px" Width="40px" />
                           </td>
                           <td>
                                <asp:Label ID="Label20" runat="server" Font-Bold="True"  Text="Jogador 9" ></asp:Label>
                        </td>
                           </tr>
                   </table>
               </asp:Panel>

               <asp:Image ID="Image5" runat="server" ImageUrl="~/Images/tabuleiro.png" style="z-index: 1; left: 374px; top: 199px; position: absolute; height: 484px; width: 592px"  />

           </form>

</asp:Content>
