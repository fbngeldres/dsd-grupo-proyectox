﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	BuscarAutoAlquilar
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-6 col-md-offset-4">
                <fieldset>
                    <!-- Form Name -->
                    <legend>Busquedad de Automoviles</legend>
                    <!-- Text input-->
                    <div class="form-group">
                        <label class="col-sm-2 control-label" for="textinput">
                            Ciudad</label>
                        <div class="col-sm-10">
                            <input type="text" placeholder="Ciudad o Aeropuerto" class="form-control">
                        </div>
                    </div>
                    <!-- Text input-->
                    <div class="form-group">
                        <label class="col-sm-2 control-label" for="textinput">
                            Fecha Pick-up</label>
                        <div class="col-sm-4">
                            <input type="text" class="form-control" value="" id="fechapickup" placeholder="Pick up">
                        </div>
                        <label class="col-sm-2 control-label" for="textinput">
                            Hora Pick-up</label>
                        <div class="col-sm-4">
                            <select id="subject" name="subject" class="form-control" required="required">
                                <option value="na" selected="">Elige Hora:</option>
                                <option value="service">1:00 AM</option>
                                <option value="service">2:00 AM</option>
                                <option value="service">3:00 AM</option>
                                <option value="service">4:00 AM</option>
                                <option value="service">5:00 AM</option>
                                <option value="service">6:00 AM</option>
                                <option value="service">7:00 AM</option>
                                <option value="service">8:00 AM</option>
                                <option value="service">9:00 AM</option>
                                <option value="service">10:00 AM</option>
                                <option value="service">11:00 AM</option>
                                <option value="service">12:00 PM</option>
                                <option value="service">13:00 PM</option>
                                <option value="service">14:00 PM</option>
                                <option value="service">15:00 PM</option>
                                <option value="service">16:00 PM</option>
                                <option value="service">17:00 PM</option>
                                <option value="service">18:00 PM</option>
                                <option value="service">19:00 PM</option>
                                <option value="service">20:00 PM</option>
                                <option value="service">21:00 PM</option>
                                <option value="service">22:00 PM</option>
                                <option value="service">23:00 PM</option>
                                <option value="service">00:00 PM</option>
                            </select>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-2 control-label" for="textinput">
                            Fecha Drop-off</label>
                        <div class="col-sm-4">
                            <input type="text" class="form-control" value="" id="fechadropoff" placeholder="Drop off">
                        </div>
                        <label class="col-sm-2 control-label" for="textinput">
                            Hora Drop-off</label>
                        <div class="col-sm-4">
                            <select id="subject" name="subject" class="form-control" required="required">
                                <option value="na" selected="">Elige Hora:</option>
                                <option value="service">1:00 AM</option>
                                <option value="service">2:00 AM</option>
                                <option value="service">3:00 AM</option>
                                <option value="service">4:00 AM</option>
                                <option value="service">5:00 AM</option>
                                <option value="service">6:00 AM</option>
                                <option value="service">7:00 AM</option>
                                <option value="service">8:00 AM</option>
                                <option value="service">9:00 AM</option>
                                <option value="service">10:00 AM</option>
                                <option value="service">11:00 AM</option>
                                <option value="service">12:00 PM</option>
                                <option value="service">13:00 PM</option>
                                <option value="service">14:00 PM</option>
                                <option value="service">15:00 PM</option>
                                <option value="service">16:00 PM</option>
                                <option value="service">17:00 PM</option>
                                <option value="service">18:00 PM</option>
                                <option value="service">19:00 PM</option>
                                <option value="service">20:00 PM</option>
                                <option value="service">21:00 PM</option>
                                <option value="service">22:00 PM</option>
                                <option value="service">23:00 PM</option>
                                <option value="service">00:00 PM</option>
                            </select>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-sm-offset-2 col-sm-10">
                            <div class="pull-right">
                                <%: Html.ActionLink("Buscar", "ResultadoBusquedaAuto", "Auto", new { @class = "btn btn-primary" })%>
                            </div>
                        </div>
                    </div>
                </fieldset>
            </div>
        </div>
    </div>


</asp:Content>
