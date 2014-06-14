<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SanJacinto.Models.ReporteModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	BuscarAutoReporte
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <br />
    <% using (Html.BeginForm("ResultadoBusquedaMejoresAuto", "Reporte"))
       { %>
    <div class="container">
        <div class="row">
            <div class="col-md-6 col-md-offset-4">
                <div class="form-horizontal">
                    <fieldset>
                        <!-- Form Name -->
                        <legend>Listar los Automóviles más alquilado en un rango de fechas</legend>
                        <!-- Text input-->
                        <div class="form-group">
                            <label class="col-sm-2 control-label" for="textinput">
                                Fecha inicio:
                            </label>
                            <div class="col-sm-4">
                                <%: Html.TextBoxFor(m => m.FechaInicioCadena, new { @class = "form-control" })%>
                            </div>
                            <label class="col-sm-2 control-label" for="textinput">
                                Fecha fin:
                            </label>
                            <div class="col-sm-4">
                                <%: Html.TextBoxFor(m => m.FechaFinCadena, new { @class = "form-control" })%>
                            </div>
                        </div>

                        <div class="form-group">
	                        <div class="col-sm-offset-2 col-sm-10">
		                        <div class="pull-right">
                                    <input id="btnSubmit" type="submit" value="Buscar" class="btn btn-primary"/>
		                        </div>
	                        </div>
                        </div>

                    </fieldset>
                </div>
            </div>
        </div>
    </div>
    <% } %>
    <script type="text/javascript">

        $(document).ready(function () {
            $("#FechaFinCadena").datepicker({
                dateFormat: 'dd/MM/yyyy',
                onSelect: function (date) {
                    var fecha = date + "";
                    var list = fecha.split("/");

                    var dia = list[0];
                    var mes = list[1];
                    var anio = "2014";
                    $("#FechaFinCadena").val(dia + "/" + obtenerIndexMes(mes) + "/" + anio);
                }
            });
        });

        $(document).ready(function () {
            $("#FechaInicioCadena").datepicker({
                dateFormat: 'dd/MM/yyyy',
                onSelect: function (date) {
                    var fecha = date + "";
                    var list = fecha.split("/");

                    var dia = list[0];
                    var mes = list[1];
                    var anio = "2014";
                    $("#FechaInicioCadena").val(dia + "/" + obtenerIndexMes(mes) + "/" + anio);
                }
            });
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
