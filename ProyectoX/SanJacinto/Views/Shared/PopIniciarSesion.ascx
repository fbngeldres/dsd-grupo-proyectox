<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<SanJacinto.Models.UsuarioModel>" %>
<% using (Html.BeginForm("LogOn", "Usuario"))
   { %>
<div class="modal fade" id="modal-container-469447" role="dialog" aria-labelledby="myModalLabel"
    aria-hidden="true">
    <div class="modal-dialog">
        <div class="form-signin mg-btm">
            <h3 class="heading-desc">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                    ×</button>
                Iniciar Sesión en San Jacinto</h3>
            <!--<div class="social-box">
                <div class="row mg-btm">
                    <div class="col-md-12">
                        <a href="#" class="btn btn-primary btn-block">
                            <i class="icon-facebook"></i>Logearse con Facebook
                        </a>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <a href="#" class="btn btn-info btn-block">
                            <i class="icon-twitter"></i>Logearse con Twitter
                        </a>
                    </div>
                </div>
            </div>-->
            <div class="main">
                Usuario:
                <%: Html.TextBoxFor(m => m.Correo, new { placeholder = "prueba@sanjacinto.com", @class = "form-control" })%>
                Contraseña:
                <%: Html.PasswordFor(m => m.Clave, new { placeholder = "Ingrese contraseña", @class = "form-control" })%>
                <span class="clearfix"></span>
            </div>
            <div class="login-footer">
                <div class="row">
                    <div class="col-xs-6 col-md-6">
                        <div class="left-section">
                            <%: Html.ActionLink("Registrese Ahora!", "RegistarUsuario", "Usuario")%>
                        </div>
                    </div>
                    <div class="col-xs-6 col-md-6 pull-right">
                        <input id="btnLogOn" type="submit" value="Iniciar sesión" class="btn btn-large btn-danger pull-right"/>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<% } %>