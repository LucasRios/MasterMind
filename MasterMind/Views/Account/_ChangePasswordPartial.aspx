<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<Infraestrutura.Repositorios.Entidades.Manage>" %>

<h3>Editar Cadastro</h3>
<% using (Html.BeginForm("Manage", "Account", FormMethod.Post, new { enctype = "multipart/form-data" }))
   { %>
<%: Html.AntiForgeryToken() %>
<%: Html.ValidationSummary() %>

<form method="post" enctype="multipart/form-data">
    <fieldset runat="server">
        <legend>Change Password Form</legend>
        <div class="editor-field">
            <%:@Html.HiddenFor(model => model.Id_user)%>
            <%: @Html.ValidationMessageFor(model => model.Id_user)%>
        </div>

        <table>
            <tr>
                <td>
                    <% if (!string.IsNullOrEmpty(Model.imagem))%>
                    <% {%>
                    <img src="<%: Model.imagem %>" class="imgPerfil"/>
                    <% }
                       else
                       {%>
                    <img src="~/Images/usu.png" class="imgPerfil" />
                    <% }%>
                </td>
                <td>
                    <table>
                        <tr>
                            <td>
                                <input type="file" name="photo" id="photo">
                            </td>
                        </tr>
                    </table>

                </td>
            </tr>
        </table>


        <table>
            <tr>
                <td>
                    <%: Html.LabelFor(m => m.OldPassword) %>
                    <%: Html.PasswordFor(m => m.OldPassword,new { @class = "txtMedium", tabindex=1}) %>
                </td>
                <td>
                    <%: Html.LabelFor(m => m.Senha) %>
                    <%: Html.PasswordFor(m => m.Senha,new { @class = "txtMedium", tabindex=2}) %>
                </td>

            </tr>
            <tr>
                <td>
                    <%: Html.LabelFor(m => m.ConfirmPassword) %>
                    <%: Html.PasswordFor(m => m.ConfirmPassword,new {@class = "txtMedium", tabindex=3}) %>
                </td>
            </tr>
            <tr>
                <td>
                    <div class="editor-label">
                        <%:  Html.LabelFor(model => model.Nome)%>
                    </div>
                    <div class="editor-field">
                        <%:  Html.TextBoxFor(model => model.Nome, new {@class = "txtMedium", tabindex=4})%>
                        <%:  Html.ValidationMessageFor(model => model.Nome)%>
                    </div>
                </td>
                <td>
                    <div class="editor-label">
                        <%: Html.LabelFor(model => model.Sobrenome)%>
                    </div>
                    <div class="editor-field">
                        <%: Html.TextBoxFor(model => model.Sobrenome, new {@class = "txtMedium", tabindex=5})%>
                        <%: Html.ValidationMessageFor(model => model.Sobrenome)%>
                    </div>

                </td>

            </tr>
            <tr>
                <td>
                    <div class="editor-label">
                        <%:  Html.LabelFor(model => model.Email)%>
                    </div>
                    <div class="editor-field">
                        <%: Html.TextBoxFor(model => model.Email, new {@class = "txtMedium", tabindex=6, @readonly = "readonly" })%>
                        <%: Html.ValidationMessageFor(model => model.Email)%>
                    </div>

                </td>
                <td>
                    <div class="editor-label">
                        <%:  Html.Label("Sexo")%>
                        <div class="divSelect" style="margin-left:15px; height:30px; width:194px;">
                        <%:  Html.DropDownListFor(u => u.Sexo, new SelectList(ViewBag.ListaSexo, "Sigla", "Sexo"), new { @class = "dropdownlist", tabindex=7 })%>
                        </div>
                        <%:  Html.ValidationMessageFor(model => model.Sexo)%>
                    </div>
                </td>
            </tr>
            <tr>
                <td>

                    <div class="editor-label">
                        <%: Html.LabelFor(model => model.Dt_nasc)%>
                    </div>
                    <div class="editor-field">
                        <%:  Html.TextBoxFor(model => model.Dt_nasc, new {@class = "txtMedium", tabindex=8})%>
                        <%: Html.ValidationMessageFor(model => model.Dt_nasc)%>
                    </div>
                </td>
                <td>
                    <div class="editor-label">
                        <%:  Html.LabelFor(model => model.Cidade)%>
                    </div>
                    <div class="editor-field">
                        <%:  Html.TextBoxFor(model => model.Cidade, new { @class = "txtMedium", tabindex=9})%>
                        <%: Html.ValidationMessageFor(model => model.Cidade)%>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div class="editor-label">
                        <%: Html.LabelFor(model => model.Estado)%>
                    </div>
                    <div class="editor-field">
                        <%: Html.TextBoxFor(model => model.Estado, new {@class = "txtMedium", tabindex=10})%>
                        <%: Html.ValidationMessageFor(model => model.Estado)%>
                    </div>
                </td>
                <td>
                    <div class="editor-label">
                        <%:  Html.LabelFor(model => model.Pais)%>
                    </div>
                    <div class="editor-field">
                        <%:  Html.TextBoxFor(model => model.Pais, new {@class = "txtMedium", tabindex=11})%>
                        <%:  Html.ValidationMessageFor(model => model.Pais)%>
                    </div>


                </td>

            </tr>
        </table>

        <input type="submit" class="btn btn-info"  value="Submeter" />
    </fieldset>
</form>
<% } %>
   
