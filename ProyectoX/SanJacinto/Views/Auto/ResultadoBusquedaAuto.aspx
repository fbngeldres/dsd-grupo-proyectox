<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
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
                    <% for (int i = 1; i < 11; i++)
                       { %>
                    <div class="col-md-3">
                        <div class="thumbnail">
                            <img alt="300x200" src="http://lorempixel.com/130/130/transport	" />
                            <div class="caption">
                                <h4>
                                    Audi R8 / Deportivo
                                </h4>
                                <h5>
                                    Informacion del Vehículo</h5>
                                <ul>
                                    <li>Transmicion Manual</li>
                                    <li>4.0 CC</li>
                                    <li>2 Asientos</li>
                                    <li>Aire Acondicionado</li>
                                </ul>
                                <p>
                                    <%: Html.ActionLink("Revervar", "CrearAlquiler", "Alquiler", new object { }, new { @class = "btn btn-primary" })%>
                                    <a class="btn" href="#">250 USD / Week</a>
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
