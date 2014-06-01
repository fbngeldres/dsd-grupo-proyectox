<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SanJacinto.Models.AlquilerModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	CrearAlquiler
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <script type="text/javascript">
        //.heading-desc
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
        <% using (Html.BeginForm("RegistrarAlquiler", "Alquiler"))
            { %>
        <div class="row">
            <div class="col-sm-12 col-md-10 col-md-offset-1">
                <table class="table table-hover">
                    <thead>
                        <tr>
                            <th>
                            </th>
                            <th>
                                Fecha Inicio
                            </th>
                            <th>
                               Accesorios
                            </th>
                            <th>
                                
                            </th>
                            <th>
                                
                            </th>
                            <th>
                               
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td class="col-sm-1 col-md-1">
                            </td>
                            <td class="col-sm-8 col-md-6">
                                <input type="text" name="txtFechaInicio" id="txtFechaInicio" class="form-control" style="width: 150px !important;"/>
                            </td>
                            <td class="col-sm-1 col-md-1">
                                <label style="font-weight:normal"><input type="checkbox" name="radio1" id="radio1" class="form-control"/>Silla de beb&eacute;</label>
                            </td>
                            <td class="col-sm-1 col-md-1">
                                <label style="font-weight:normal"><input type="checkbox" name="radio2" id="Checkbox1" class="form-control"/>Radio</label>
                            </td>
                            <td class="col-sm-1 col-md-1">
                                <label style="font-weight:normal"><input type="checkbox" name="radio2" id="Checkbox2" class="form-control"/>Parlantes</label>
                            </td>
                            <td class="col-sm-1 col-md-1">
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>        
        </div>
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
                                            <a href="#"><strong id="stMarcaDesc" style="font-weight: normal"><%: Model.Auto.MarcaDesc %></strong> - <strong id="stModeloDesc" style="font-weight: normal"><%: Model.Auto.ModeloDesc %></strong></a></h4>
                                        <span>Estado: </span><span class="text-success"><strong><%: Model.Auto.EstadoDesc %></strong></span>
                                    </div>
                                </div>
                            </td>
                            <td class="col-sm-1 col-md-1" style="text-align: center">
                                <%: Html.TextBoxFor(model => model.CantidadDias,
                                    new { @class = "form-control", @onblur = "onBlurDias();", @onkeypress = "return isNumberKey(event);" })%>
                            </td>
                            <td class="col-sm-1 col-md-1 text-center">
                                <strong>$</strong><strong id="strPrecio"><%: Model.Auto.PrecioMinimo %></strong>
                                <input id="strPrecioAuto" name="strPrecioAuto" type="hidden" value="<%: Model.Auto.PrecioMinimo %>" />
                                <input id="intCodigoAuto" name="intCodigoAuto" type="hidden" value="<%: Model.Auto.Codigo %>" />
                                <input id="intCodigoUsuario" name="intCodigoUsuario" type="hidden" value="<%: Model.Usuario.Codigo %>" />
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
                                <input id="btnSubmit" type="submit" value="Alquilar" class="hide"/>
                                <button id="btnAlquilar" type="button" class="btn btn-primary">
                                    Alquiler
                                </button>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
        <% } %>
        <!--fin detalle-->
    </div>

    <div id="confirmAlquilar" style="display: none;" class="modal">
        <div class="modal-dialog">
            <div class="form-signin mg-btm">
                <h4 class="heading-desc" style="font-size: 16px !important;font-weight: normal !important;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        ×</button>
                    ¿Est&aacute; seguro de registrar el alquiler?</h4>
                <div class="main">
                    <p>
                        <label>Marca: </label> <strong id="stMarca" style="font-weight:normal">$</strong>
                    </p>
                    <p>
                        <label>Modelo: </label> <strong id="stModelo" style="font-weight:normal">$</strong>
                    </p>
                    <p>
                        <label>Placa: </label> <strong id="stPlaca" style="font-weight:normal">$</strong>
                    </p>
                    <p>
                        <label>Accesorios: </label> <strong id="stAccesorios" style="font-weight:normal">$</strong>
                    </p>
                    <p>
                        <label>Fecha de Inicio: </label> <strong id="stFechaInicio" style="font-weight:normal">$</strong>
                    </p>
                    <p>
                        <label>Monto Total: </label> <strong id="stMonto" style="font-weight:normal">$</strong>
                    </p>
                </div>
                <div class="login-footer">
                    <div class="row">
                        <div class="col-xs-6 col-md-6 pull-left">
                            <button id="btnCancelar" type="button" class="btn btn-large btn-danger pull-right">
                                Cancelar
                            </button>
                        </div>
                        <div class="col-xs-6 col-md-6 pull-right">
                            <button id="btnAlquilarEnd" type="button" class="btn btn-large btn-danger pull-right">
                                Registrar Alquiler
                            </button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">

        $(document).ready(function () {
            $("#txtFechaInicio").datepicker({
                dateFormat: 'dd/mm/yy'
            });
        });

        $("#btnAlquilar").click(function () {
            var marca = $("#stMarcaDesc").text();
            var modelo = $("#stModeloDesc").text();
            //var placa = $("#stPlaca").val();
            //var accesorios = $("#stAccesorios").val();
            //var fechaInicio = $("#stFecInicio").val();
            var total = $("#strTotal").text();

            $("#stMarca").text(marca);
            $("#stModelo").text(modelo);
            $("#stMonto").text(total);

            $("#confirmAlquilar").modal();
        });

        $("#btnCancelar").click(function () {
            $("#confirmAlquilar").modal("hide");
        });

        $("#btnAlquilarEnd").click(function () {
            $("#btnSubmit").click();
        });

    </script>    
</asp:Content>
