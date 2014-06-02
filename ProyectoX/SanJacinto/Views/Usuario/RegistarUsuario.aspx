<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SanJacinto.Models.UsuarioModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	RegistarUsuario
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% using (Html.BeginForm("RegistarUsuarioWeb", "Usuario"))
       { %>
    <div class="form-horizontal">
        <div class="panel panel-default" style="width: 750px;">
            <div class="panel-heading">
                <h3 class="panel-title">
                    Registro de usuario <small>San Jaciento S.A.C.</small></h3>
            </div>
                    
            <div class="panel-body">
                <div class="form-group">
                    <label class="col-sm-2 control-label" for="textinput">
                        Correo:
                    </label>
                    <div class="col-sm-4">
                        <%: Html.TextBoxFor(m => m.Correo, new { placeholder = "Ejemplo: prueba@sanjacinto.com", @class = "form-control input-sm" })%>
                    </div>
                    <label class="col-sm-2 control-label" for="textinput">
                        Contraseña:
                    </label>
                    <div class="col-sm-4">
                        <%: Html.TextBoxFor(m => m.Clave, new { placeholder = "Ingrese su contraseña", @class = "form-control input-sm" })%>
                    </div>
                </div>

                <div class="form-group">
                    <label class="col-sm-2 control-label" for="textinput">
                        Nombres:
                    </label>
                    <div class="col-sm-4">
                        <%: Html.TextBoxFor(m => m.Nombres, new { placeholder = "Ingrese sus nombres", @class = "form-control input-sm" })%>
                    </div>
                    <label class="col-sm-2 control-label" for="textinput">
                        Apellidos:
                    </label>
                    <div class="col-sm-4">
                        <%: Html.TextBoxFor(m => m.Apellidos, new { placeholder = "Ingrese sus apellidos", @class = "form-control input-sm" })%>
                    </div>
                </div>
                 
                <div class="form-group">
                    <label class="col-sm-2 control-label" for="textinput">
                        Teléfono:
                    </label>
                    <div class="col-sm-4">
                        <%: Html.TextBoxFor(m => m.Telefono, new { placeholder = "Ingrese su teléfono celular o casa", @class = "form-control input-sm" })%>
                    </div>
                    <label class="col-sm-2 control-label" for="textinput">
                        DNI:
                    </label>
                    <div class="col-sm-4">
                        <%: Html.TextBoxFor(m => m.Dni, new { placeholder = "Ingrese su DNI", @class = "form-control input-sm" })%>
                    </div>
                </div>
                        
                <div class="form-group">
                    <label class="col-sm-2 control-label" for="textinput">
                        Licencia de conducir:
                    </label>
                    <div class="col-sm-4">
                        <%: Html.TextBoxFor(m => m.Licencia, new { placeholder = "Ingrese sus número de licencia", @class = "form-control input-sm" })%>
                    </div>
                </div>

                <div style="width: 200px; margin: auto;">
                    <input type="submit" value="Registrarse" class="btn btn-info btn-block"/>
                </div>
               
            </div>
        </div>
    </div>
    <% } %>
</asp:Content>