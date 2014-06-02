<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SanJacinto.Models.AlquilerModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	RegistrarAlquiler
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <h3>Se registr&oacute; el alquiler correctamente</h3>

    <table class="table table-hover" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <label class="col-sm-3 control-label" for="">
                    Marca:</label>
            </td>
            <td>
                <%: Model.Auto.MarcaDesc %>
            </td>
        </tr>
        <tr>
            <td>
                <label class="col-sm-3 control-label" for="">
                    Modelo:</label>
            </td>
            <td>
                <%: Model.Auto.ModeloDesc %>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <img alt="300x200" src="http://sd.gintelligence.net/imagenesAutos/<%: Model.Auto.Imagen %>" height="130" width="130" />
            </td>
        </tr>
        <tr>
            <td>
                <label class="col-sm-3 control-label" for="">
                    Fecha Devoluci&oacute;n:</label>
            </td>
            <td>
                <%: Model.FechaFin %>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <%: Html.ActionLink("Regresar al buscador", "BuscarAutoAlquilar", "Auto", new object { } , new { @class = "btn btn-primary" })%>
            </td>
        </tr>
    </table>
</asp:Content>

