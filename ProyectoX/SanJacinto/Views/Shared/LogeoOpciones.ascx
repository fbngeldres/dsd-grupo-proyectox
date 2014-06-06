<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<ul class="nav navbar-nav navbar-right">
    <%
        if (Request.IsAuthenticated) {
            FormsIdentity id = (FormsIdentity)Page.User.Identity;
            FormsAuthenticationTicket ticket = id.Ticket;
    %>
    

        <li class="dropdown"><a href="#" class="dropdown-toggle" data-toggle="dropdown">Mi cuenta
            <b class="caret"></b></a>
            <ul class="dropdown-menu">
                <li>
                    <div class="navbar-content">
                        <div class="row">
                            <div class="col-md-5">
                                <img src="http://lh5.googleusercontent.com/-b0-k99FZlyE/AAAAAAAAAAI/AAAAAAAAAAA/twDq00QDud4/s120-c/photo.jpg"
                                    alt="Alternate Text" class="img-responsive" />
                                <!--<p class="text-center small">
                                    <a href="#">Cambiar Foto</a></p>-->
                            </div>
                            <div class="col-md-7">
                                <span><%:Page.User.Identity.Name%></span>
                                <p class="text-muted small">
                                    <%:ticket.UserData %></p>
                                <div class="divider">
                                </div>
                                <a href="#" class="btn btn-primary btn-sm active">Editar Perfil</a>
                            </div>
                        </div>
                    </div>
                    <div class="navbar-footer">
                        <div class="navbar-footer-content">
                            <div class="row">
                                <div class="col-md-6">
                                    <a href="#" class="btn btn-default btn-sm">Cambiar contraseña</a>
                                </div>
                                <div class="col-md-6">
                                    <%: Html.ActionLink("Cerrar sesión", "LogOut", "Usuario", new object { }, new { @class = "btn btn-default btn-sm pull-right" })%>
                                </div>
                            </div>
                        </div>
                    </div>
                </li>
            </ul>
        </li>
    <%
        }
        else {
    %> 
        <li>
		    <a id="modal-469447" href="#modal-container-469447" data-toggle="modal">Iniciar Sesion</a>
	    </li>
    <%
        }
    %>
</ul>