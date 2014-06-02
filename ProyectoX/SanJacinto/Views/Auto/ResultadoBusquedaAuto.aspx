<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<SanJacinto.wsAutoService.Auto>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	ResultadoBusquedaAuto
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <br />
    <div class="stepwizard">
        <div class="stepwizard-row">
            <div class="stepwizard-step">
                <button type="button" class="btn btn-default btn-circle" disabled="disabled">
                    1</button>
                <p>
                    Busqueda</p>
            </div>
            <div class="stepwizard-step">
                <button type="button" class="btn btn-primary btn-circle">
                    2</button>
                <p>
                    Seleccionar</p>
            </div>
            <div class="stepwizard-step">
                <button type="button" class="btn btn-default btn-circle" disabled="disabled">
                    3</button>
                <p>
                    Forma de Pago</p>
            </div>
        </div>
    </div>
    <br />
    <br />
    <div class="panel panel-default">
        <div class="panel-body">
            <div class="col-md-12 column">
                <div class="row">
                    <% foreach (var item in Model)
                       { %>
                    <div class="col-md-3">
                        <div class="thumbnail">
                            <img alt="300x200" src="http://sd.gintelligence.net/imagenesAutos/<%: item.Imagen %>" height="130" width="130" />
                            <div class="caption">
                                <h4><%: item.Modelo.Descripcion %></h4>
                                <h5>
                                    Informacion del Vehículo</h5>
                                <ul>
                                    <li><font style="font-weight:bold;">Estado:</font> <%: item.Estado.Descripcion %></li>
                                    <li><font style="font-weight:bold;">Marca:</font> <%: item.Marca.Descripcion %></li>
                                    <li><font style="font-weight:bold;">Placa:</font> <%: item.Placa %></li>
                                    <li><font style="font-weight:bold;">Categoría:</font> <%: item.Categoria.Descripcion %></li>
                                </ul>
                                <p>
                                    <%
                                        if (Request.IsAuthenticated) {
                                    %>
                                        <%: Html.ActionLink("Revervar", "CrearAlquiler", "Alquiler", 
                                        new { dcPrecio = item.Precio,intCodAuto = item.Codigo,intCodEstado = item.Estado.Codigo, 
                                            strEstado = item.Estado.Descripcion,intCodModelo = item.Modelo.Codigo, strModelo = item.Modelo.Descripcion,
                                            intCodMarca = item.Marca.Codigo, strMarca = item.Marca.Descripcion}, new { @class = "btn btn-primary" })%>
                                    <%
                                        }
                                        else {
                                    %> 
                                        <a id="modal-469447" href="#modal-container-469447" data-toggle="modal" class="btn btn-primary">Reservar</a>

                                    <%
                                        }
                                    %>
                                    <a class="btn" href="#"><%: item.Precio %></a>
                                </p>
                            </div>
                        </div>
                    </div>
                    <% } %>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

