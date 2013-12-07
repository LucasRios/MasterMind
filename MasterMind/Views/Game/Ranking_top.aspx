<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<List<Infraestrutura.Repositorios.Entidades.Ranking>>" %>

<% using (Html.BeginForm("Principal", "Game"))
   { %>
<%: Html.AntiForgeryToken() %>
<%: Html.ValidationSummary() %>

<style type="text/css">
    table.space {
        border: solid;
        border-spacing: 10px;
    }

    tr.main {
        border: solid;
        font-weight: bold;
    }

    td {
        text-align: center;
        padding: 4px 15px 2px 4px;
        font-weight: bold;
    }
</style>

<fieldset>
  
    <div id="divRank">
       <div style="text-align:center">
          <h2>TOP 3</h2>
       </div>
        

        <% 
       int i = 0;
       foreach (var item in Model)
       {
           i = i + 1;

           int limite = Model.Count;
           if (ViewBag.achouRanking) limite = limite - 1;
           
           if (i <= limite)
           {
        %>
     <div>
                <img src="../../Images/orderedList<%:  @Html.DisplayFor(modelItem => i)%>.png" style="margin-right:5px; " />
           
                <%:  @Html.DisplayFor(modelItem => item.Id_User.Nome)%>
          </div>
        <% }
                else
                { %>
       <div>Sua Posição</div>
       <div>
           <%:  @Html.DisplayFor(modelItem => item.Id_Ranking)%>
       </div>
        <%}
            } %>
    

    </div>
</fieldset>

<% } %>
