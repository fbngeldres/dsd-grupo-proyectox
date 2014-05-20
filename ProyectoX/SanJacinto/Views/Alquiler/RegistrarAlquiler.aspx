<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SanJacinto.Models.AlquilerModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	RegistrarAlquiler
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <h2>Se registro el alquiler correctamente</h2>

    <fieldset>
        <legend>Detalle de la Reserva</legend>
        <table>
            <tr>
                <td>Costo Total: </td>
                <td><%: Model.Costo %></td>
            </tr>
            <tr>
                <td>Nombre Solicitante: </td>
                <td><%: Model.Usuario.Nombres %> <%: Model.Usuario.Apellidos %></td>
            </tr>
            <tr>
                <td>Placa Carro: </td>
                <td><%: Model.Auto.Placa %></td>
            </tr>
        </table>
    </fieldset>
    <div class="col-sm-offset-2 col-sm-10">
        <div class="pull-left">
            <%: Html.ActionLink("Regresar", "BuscarAutoAlquilar", "Auto", new object { } , new { @class = "btn btn-primary" })%>
        </div>
    </div>
</asp:Content>

