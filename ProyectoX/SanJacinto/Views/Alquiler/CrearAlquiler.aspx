<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	CrearAlquiler
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel-body">
        <!---PAGO-->
        <form class="form-horizontal" role="form">
        <fieldset>
            <legend>Pago</legend>
            <div class="form-group">
                <label class="col-sm-3 control-label" for="card-holder-name">
                    Name on Card</label>
                <div class="col-sm-9">
                    <input type="text" class="form-control" name="card-holder-name" id="card-holder-name"
                        placeholder="Card Holder's Name">
                </div>
            </div>
            <div class="form-group">
                <label class="col-sm-3 control-label" for="card-number">
                    Card Number</label>
                <div class="col-sm-9">
                    <input type="text" class="form-control" name="card-number" id="card-number" placeholder="Debit/Credit Card Number"/>
                </div>
            </div>
            <div class="form-group">
                <label class="col-sm-3 control-label" for="expiry-month">
                    Expiration Date</label>
                <div class="col-sm-9">
                    <div class="row">
                        <div class="col-xs-3">
                            <select class="form-control col-sm-2" name="expiry-month" id="expiry-month">
                                <option>Mes</option>
                                <option value="01">Jan (01)</option>
                                <option value="02">Feb (02)</option>
                                <option value="03">Mar (03)</option>
                                <option value="04">Apr (04)</option>
                                <option value="05">May (05)</option>
                                <option value="06">June (06)</option>
                                <option value="07">July (07)</option>
                                <option value="08">Aug (08)</option>
                                <option value="09">Sep (09)</option>
                                <option value="10">Oct (10)</option>
                                <option value="11">Nov (11)</option>
                                <option value="12">Dec (12)</option>
                            </select>
                        </div>
                        <div class="col-xs-3">
                            <select class="form-control" name="expiry-year">
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
                    Card CVV</label>
                <div class="col-sm-3">
                    <input type="text" class="form-control" name="cvv" id="cvv" placeholder="Security Code"/>
                </div>
            </div>
        </fieldset>
        </form>
        <!--PAGO FIN-->
        <!---dettale-->
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
                                Price
                            </th>
                            <th class="text-center">
                                Total
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
                                            <a href="#">Audi R8</a></h4>
                                        <span>Status: </span><span class="text-success"><strong>en cochera</strong></span>
                                    </div>
                                </div>
                            </td>
                            <td class="col-sm-1 col-md-1" style="text-align: center">
                                <input type="email" class="form-control" id="exampleInputEmail1" value="7">
                            </td>
                            <td class="col-sm-1 col-md-1 text-center">
                                <strong>$100</strong>
                            </td>
                            <td class="col-sm-1 col-md-1 text-center">
                                <strong>$700</strong>
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
                                    <strong>$700</strong></h5>
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
                                    <strong>$126</strong></h5>
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
                                    <strong>$826</strong></h3>
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
                                <button type="button" class="btn btn-success">
                                    <%: Html.ActionLink("Alquilar", "RegistrarAlquiler", "Alquiler", new { @class = "glyphicon glyphicon-play" })%>
                                </button>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
        <!--fin detalle-->
    </div>
</asp:Content>
