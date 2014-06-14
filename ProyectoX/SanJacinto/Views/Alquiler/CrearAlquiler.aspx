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
            if (precio.length != 0 && precio != '') {

                montoTotal = parseInt(dias) * parseInt(precio);
                var total = montoTotal;

                montoTotal = number_format(montoTotal, 2, '.', ',');

                document.getElementById("strMontoTotal").innerHTML = montoTotal + "";
                document.getElementById("strSubTotal").innerHTML = montoTotal + "";

                var igv = 0.18 * total;
                var igv2 = igv;
                igv = number_format(igv, 2, '.', ',');
                document.getElementById("strIGV").innerHTML = igv + "";

                montoTotal = total + igv2;
                document.getElementById("strTotalHide").innerHTML = montoTotal + "";
                montoTotal = number_format(montoTotal, 2, '.', ',');
                document.getElementById("strTotal").innerHTML = montoTotal + "";
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
                                <label style="font-weight:normal"><input type="checkbox" value="Silla de Bebé" name="Checkbox1" id="Checkbox1" class="form-control"/>Silla de beb&eacute;</label>
                            </td>
                            <td class="col-sm-1 col-md-1">
                                <label style="font-weight:normal"><input type="checkbox" value="Radio MP3" name="Checkbox2" id="Checkbox2" class="form-control"/>Radio</label>
                            </td>
                            <td class="col-sm-1 col-md-1">
                                <label style="font-weight:normal"><input type="checkbox" value="Parlantes" name="Checkbox3" id="Checkbox3" class="form-control"/>Parlantes</label>
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
                                <input id="txtAccesorios" name="txtAccesorios" type="hidden" />
                                <input id="txtCostoAdicional" name="txtCostoAdicional" type="hidden" />
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
                                    <strong>$</strong><strong id="strTotal"></strong><strong id="strTotalHide" style="display: none;"></strong></h3>
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
          <div style="color:Red">
<%= Html.DisplayText("MensajeError")%>
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
                        <label>Precio x dia: $</label> <strong id="stPrecio" style="font-weight:normal">$</strong>
                    </p>
                    <p>
                        <label>Fecha de Inicio: </label> <strong id="stFechaInicio" style="font-weight:normal">$</strong>
                    </p>
                    <p>
                        <label>Accesorios: </label> <strong id="stAccesorios" style="font-weight:normal">$</strong>
                    </p>
                    <p>
                        <label>Costo Adicional: </label> <strong id="stCostoAdicional" style="font-weight:normal">$</strong>
                    </p>
                    <p>
                        <label>Monto Total: $</label> <strong id="stMontoTotal" style="font-weight:normal">$</strong>
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
                dateFormat: 'dd/MM/yyyy',
                onSelect: function (date) {
                    var fecha = date + "";
                    var list = fecha.split("/");

                    var dia = list[0];
                    var mes = list[1];
                    var anio = "2014";
                    $("#txtFechaInicio").val(dia + "/" + obtenerIndexMes(mes) + "/" + anio);
                }
            });
        });

        $("#btnAlquilar").click(function () {
            var marca = $("#stMarcaDesc").text();
            var modelo = $("#stModeloDesc").text();
            var precio = $("#strPrecio").text();

            var cadenaAccesorios = "";
            var costoAdicional = 0;
            var isSelectA1 = $("#Checkbox1").is(":checked");
            if (isSelectA1) {
                cadenaAccesorios += $("#Checkbox1").val();
                cadenaAccesorios += ", ";
                costoAdicional += 100;
            }
            var isSelectA2 = $("#Checkbox2").is(":checked");
            if (isSelectA2) {
                cadenaAccesorios += $("#Checkbox2").val();
                cadenaAccesorios += ", ";
                costoAdicional += 150;
            }
            var isSelectA3 = $("#Checkbox3").is(":checked");
            if (isSelectA3) {
                cadenaAccesorios += $("#Checkbox3").val();
                cadenaAccesorios += ", ";
                costoAdicional += 180;
            }

            var fechaInicio = $("#txtFechaInicio").val();
            var strTotal = $("#strTotalHide").text() + "";
            var montoTotal = parseFloat(strTotal) + costoAdicional;

            if (cadenaAccesorios.length == 0)
                cadenaAccesorios = " - ";
            else
                cadenaAccesorios = cadenaAccesorios.substr(0, cadenaAccesorios.length - 2);

            montoTotal = number_format(montoTotal, 2, '.', ',');

            $("#stMarca").text(marca);
            $("#stModelo").text(modelo);
            $("#stPrecio").text(precio);
            $("#stFechaInicio").text(fechaInicio);
            $("#stAccesorios").text(cadenaAccesorios);
            $("#stCostoAdicional").text(costoAdicional);
            $("#stMontoTotal").text(montoTotal);

            $("#txtAccesorios").val(cadenaAccesorios);
            $("#txtCostoAdicional").val(costoAdicional);

            $("#confirmAlquilar").modal();
        });

        $("#btnCancelar").click(function () {
            $("#confirmAlquilar").modal("hide");
        });

        $("#btnAlquilarEnd").click(function () {
            $("#btnSubmit").click();
        });


        function number_format(number, decimals, dec_point, thousands_sep) {
            number = (number + '').replace(/[^0-9+-Ee.]/g, '');
            var n = !isFinite(+number) ? 0 : +number,
            prec = !isFinite(+decimals) ? 0 : Math.abs(decimals),
            sep = (typeof thousands_sep === 'undefined') ? ',' : thousands_sep,
            dec = (typeof dec_point === 'undefined') ? '.' : dec_point,
            s = '',
            toFixedFix = function (n, prec) {
                var k = Math.pow(10, prec);
                return '' + Math.round(n * k) / k;
            };
            // Fix for IE parseFloat(0.55).toFixed(0) = 0;
            s = (prec ? toFixedFix(n, prec) : '' + Math.round(n)).split('.');
            if (s[0].length > 3) {
                s[0] = s[0].replace(/\B(?=(\d{3})+(?!\d))/g, sep); ///B(?=(?:d{3})+(?!d))/g
            }
            if ((s[1] || '').length < prec) {
                s[1] = s[1] || '';
                s[1] += new Array(prec - s[1].length + 1).join('0');
            }
            return s.join(dec);
        }

        function obtenerIndexMes(cadena) {
            if (cadena == "Enero")
                return "01";
            else if (cadena == "Febrero")
                return "02";
            else if (cadena == "Marzo")
                return "03";
            else if (cadena == "Abril")
                return "04";
            else if (cadena == "Mayo")
                return "05";
            else if (cadena == "Junio")
                return "06";
            else if (cadena == "Julio")
                return "07";
            else if (cadena == "Agosto")
                return "08";
            else if (cadena == "Septiembre")
                return "09";
            else if (cadena == "Octubre")
                return "10";
            else if (cadena == "Noviembre")
                return "11";
            else
                return "12";
        }

    </script>    
</asp:Content>
