<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<SanJacinto.Models.AlquilerModel>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	ListarAlquileres
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Listador de Alquileres</h2>

    <table>
        <tr>
            <th></th>
            <th>
                Marca
            </th>
            <th>
                Costo
            </th>
            <th>
                CostoAdicional
            </th>
            <th>
                FechaInicio
            </th>
            <th>
                CantidadDias
            </th>
            <th>
                Accesorios
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Modificar Reserva", "Delete", new { /* id=item.PrimaryKey */ })%>
            </td>
            <td>
                <%: item.Auto.Marca %>
            </td>
            <td>
                <%: String.Format("{0:F}", item.Costo) %>
            </td>
            <td>
                <%: String.Format("{0:F}", item.CostoAdicional) %>
            </td>
            <td>
                <%: String.Format("{0:g}", item.FechaInicio) %>
            </td>
            <td>
                <%: item.CantidadDias %>
            </td>
            <td>
                <%: item.Accesorios %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

