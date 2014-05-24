<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SanJacinto.Models.AlquilerModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	RegistrarAlquiler
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <h2>Se registro el alquiler correctamente</h2>

    <div class="col-sm-offset-2 col-sm-10">
        <div class="pull-left">
            <%: Html.ActionLink("Regresar", "BuscarAutoAlquilar", "Auto", new object { } , new { @class = "btn btn-primary" })%>
        </div>
    </div>
</asp:Content>

