<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SanJacinto.Models.AutoModel>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	BuscarAutoAlquilar
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <br />
    <div class="stepwizard">
        <div class="stepwizard-row">
            <div class="stepwizard-step">
                <button type="button" class="btn btn-primary btn-circle">
                    1</button>
                <p>
                    Búsqueda</p>
            </div>
            <div class="stepwizard-step">
                <button type="button" class="btn btn-default btn-circle" disabled="disabled">
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
    <% using (Html.BeginForm("ResultadoBusquedaAuto", "Auto"))
       { %>
    <div class="container">
        <div class="row">
            <div class="col-md-6 col-md-offset-4">
                <div class="form-horizontal">
                    <fieldset>
                        <!-- Form Name -->
                        <legend>Búsqueda de Automóviles</legend>
                        <!-- Text input-->
                        <div class="form-group">
                            <label class="col-sm-2 control-label" for="textinput">
                                Placa:
                            </label>
                            <div class="col-sm-4">
                                <%: Html.TextBoxFor(m => m.Placa, new { placeholder = "Placa", @class = "form-control" })%>
                            </div>
                            <label class="col-sm-2 control-label" for="textinput">
                                Categoría:
                            </label>
                            <div class="col-sm-4">
                                <%: Html.DropDownListFor(m => m.Categoria, Model.lstCategorias, new { @class = "form-control" })%>   
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-2 control-label" for="textinput">
                                Marca:
                            </label>
                            <div class="col-sm-4">
                                <%: Html.DropDownListFor(m => m.Marca, Model.lstMarcas, new { @class = "form-control" })%>
                            </div>
                            <label class="col-sm-2 control-label" for="textinput">
                                Modelo:
                            </label>
                            <div class="col-sm-4">
                                <%: Html.DropDownListFor(m => m.Modelo, Model.lstModelos, new { @class = "form-control" })%>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-2 control-label" for="textinput">
                                Precio mínimo:
                            </label>
                            <div class="col-sm-4">
                                <%: Html.TextBoxFor(m => m.PrecioMinimo, new { placeholder = "Precio mínimo", @class = "form-control" })%>
                            </div>

                            <label class="col-sm-2 control-label" for="textinput">
                                Precio máximo:
                            </label>
                            <div class="col-sm-4">
                                <%: Html.TextBoxFor(m => m.PrecioMaximo, new { placeholder = "Precio máximo", @class = "form-control" })%>
                            </div>
                        </div>

                        <div class="form-group">
	                        <div class="col-sm-offset-2 col-sm-10">
		                        <div class="pull-right">
                                    <input id="btnSubmit" type="submit" value="Submit" class="btn btn-primary"/>
		                        </div>
	                        </div>
                        </div>

                    </fieldset>
                </div>
            </div>
        </div>
    </div>
    <% } %>
</asp:Content>
