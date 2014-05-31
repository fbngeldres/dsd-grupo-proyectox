<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SanJacinto.Models.AlquilerModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	CrearAlquiler
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function onBlurDias() {
            var dias = document.getElementById("CantidadDias").value;
            var precio = document.getElementById("strPrecio").innerHTML + "";

            var montoTotal = 0;
            limpiaMontos();
            console.info(precio);
            if (precio.length != 0 && precio != '') {
                montoTotal = parseInt(dias) * parseInt(precio);

                document.getElementById("strMontoTotal").innerHTML = montoTotal + "";
                document.getElementById("strSubTotal").innerHTML = montoTotal + "";

                var igv = 0.18 * montoTotal;
                document.getElementById("strIGV").innerHTML = igv + "";

                document.getElementById("strTotal").innerHTML = (montoTotal + igv) + "";
            }
        }

        function limpiaMontos(){
            document.getElementById("strMontoTotal").innerHTML = 0 + "";
            document.getElementById("strSubTotal").innerHTML = 0 + "";
            document.getElementById("strIGV").innerHTML = 0 + "";
            document.getElementById("strTotal").innerHTML = 0 + "";
        }

        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }


    </script>    
    <br />
    <br />
    <br />
    <br />
    <div class="stepwizard">
        <div class="stepwizard-row">
            <div class="stepwizard-step">
                <button type="button" class="btn btn-default btn-circle" disabled="disabled">
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
                <button type="button" class="btn btn-primary btn-circle">
                    3</button>
                <p>
                    Forma de Pago</p>
            </div>
        </div>
    </div>
    <br />
    <br />
    <div class="panel-body">
        <!---PAGO-->
        <div class="form-horizontal" role="form">
        <fieldset>
            <legend>Pago</legend>
            <div class="form-group">
                <label class="col-sm-3 control-label" for="card-holder-name">
                    Nombre del Titular de la tarjeta</label>
                <div class="col-sm-9">
                    <input type="text" class="form-control" name="card-holder-name" id="txtTitular"
                        placeholder="Titular de la tarjeta"/>
                </div>
            </div>
            <div class="form-group">
                <label class="col-sm-3 control-label" for="card-number">
                    Número de tarjeta</label>
                <div class="col-sm-9">
                    <input type="text" class="form-control" name="card-number" id="txtNumeroTarjeta" placeholder="Número de tarjeta"/>
                </div>
            </div>
            <div class="form-group">
                <label class="col-sm-3 control-label" for="expiry-month">
                    Fecha de expiraci&oacute;n</label>
                <div class="col-sm-9">
                    <div class="row">
                        <div class="col-xs-3">
                            <select class="form-control col-sm-2" name="expiry-month" id="cboFechaExpiracion">
                                <option>Mes</option>
                                <option value="01">Ene (01)</option>
                                <option value="02">Feb (02)</option>
                                <option value="03">Mar (03)</option>
                                <option value="04">Abr (04)</option>
                                <option value="05">May (05)</option>
                                <option value="06">Jun (06)</option>
                                <option value="07">Jul (07)</option>
                                <option value="08">Ago (08)</option>
                                <option value="09">Sep (09)</option>
                                <option value="10">Oct (10)</option>
                                <option value="11">Nov (11)</option>
                                <option value="12">Dic (12)</option>
                            </select>
                        </div>
                        <div class="col-xs-3">
                            <select class="form-control" name="expiry-year" id="cboAnio">
                                <option value="13">2013</option>
                                <option value="14">2014</option>
                                <option value="15">2015</option>
                                <option value="16">2016</option>
                                <option value="17">2017</option>
                                <option value="18">2018</option>
                                <option value="19">2019</option>
                                <option value="20">2020</option>
                                <option value="21">2021</option>
                                <option value="22">2022</option>
                                <option value="23">2023</option>
                            </select>
                        </div>
                    </div>
                </div>
            </div>
            <div class="form-group">
                <label class="col-sm-3 control-label" for="cvv">
                    Código de Seguridad</label>
                <div class="col-sm-3">
                    <input type="text" class="form-control" name="cvv" id="txtCodigoSeguridad" placeholder="Código de seguridad"/>
                </div>
            </div>
        </fieldset>
        </div>
        <!--PAGO FIN-->
        <!---dettale-->
        <form id="form1" runat="server">
        <div class="row">
            <div class="col-sm-12 col-md-10 col-md-offset-1">
                <table class="table table-hover">
                    <thead>
                        <tr>
                            <th>
                            </th>
                            <th>
                                Auto
                            </th>
                            <th>
                                D&iacute;as
                            </th>
                            <th class="text-center">
                                Precio
                            </th>
                            <th class="text-center">
                                Monto Total
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td class="col-sm-1 col-md-1">
                            </td>
                            <td class="col-sm-8 col-md-6">
                                <div class="media">
                                    <a class="thumbnail pull-left" href="#">
                                        <img class="media-object" src="http://icons.iconarchive.com/icons/custom-icon-design/flatastic-2/72/product-icon.png"
                                            style="width: 72px; height: 72px;">
                                    </a>
                                    <div class="media-body">
                                        <h4 class="media-heading">
                                            <a href="#"><%: Model.Auto.Marca.Descripcion %> - <%: Model.Auto.Modelo.Descripcion %></a></h4>
                                        <span>Estado: </span><span class="text-success"><strong><%: Model.Auto.Estado.Descripcion %></strong></span>
                                    </div>
                                </div>
                            </td>
                            <td class="col-sm-1 col-md-1" style="text-align: center">
                                <%: Html.TextBoxFor(model => model.CantidadDias,
                                    new { @class = "form-control", @onblur = "onBlurDias();", @onkeypress = "return isNumberKey(event);" })%>
                            </td>
                            <td class="col-sm-1 col-md-1 text-center">
                                <strong>$</strong><strong id="strPrecio"><%: Model.Auto.PrecioMinimo %></strong>
                            </td>
                            <td class="col-sm-1 col-md-1 text-center">
                                <strong>$</strong><strong id="strMontoTotal"></strong>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                                <h5>
                                    Subtotal</h5>
                            </td>
                            <td class="text-right">
                                <h5>
                                    <strong>$</strong><strong id="strSubTotal"></strong></h5>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                                <h5>
                                    IGV (18%)</h5>
                            </td>
                            <td class="text-right">
                                <h5>
                                    <strong>$</strong><strong id="strIGV"></strong></h5>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                                <h3>
                                    Total</h3>
                            </td>
                            <td class="text-right">
                                <h3>
                                    <strong>$</strong><strong id="strTotal"></strong></h3>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                                <!--   <button type="button" class="btn btn-default">
                            <span class="glyphicon glyphicon-shopping-cart"></span> Continue Shopping
                        </button>-->
                            </td>
                            <td>
                                <button type="button" class="btn btn-default">
                                    <%: Html.ActionLink("Alquilar", "RegistrarAlquiler", "Alquiler", new { intCantidadDias = Model.CantidadDias }, new { @class = "glyphicon glyphicon-shopping-cart" })%>
                                </button>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
        </form>
        <!--fin detalle-->
    </div>
</asp:Content>
