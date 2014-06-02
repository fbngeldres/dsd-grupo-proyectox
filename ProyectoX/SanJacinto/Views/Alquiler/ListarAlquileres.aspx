<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<SanJacinto.Models.AlquilerModel>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	ListarAlquileres
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="col-md-12">
        <h2>Listados de Alquileres</h2>

        <div class="table-responsive">
            <table class="table table-bordred table-striped">
                <thead>
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
                </thead>
                <tbody>

            <% foreach (var item in Model) { %>
    
                <tr>
                    <td>
                       <p>
                            <button class="btn btn-primary btn-xs" data-title="Edit" data-toggle="modal" data-target="#edit"
                                data-placement="top" rel="tooltip">
                                <span class="glyphicon glyphicon-pencil"></span>
                            </button>
                       </p>
                    </td>
                    <td>
                        <%: item.Auto.MarcaDesc %>
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
                </tbody>
            </table>
            <div class="clearfix">
            </div>
            <ul class="pagination pull-right">
                <li class="disabled"><a href="#"><span class="glyphicon glyphicon-chevron-left"></span>
                </a></li>
                <li class="active"><a href="#">1</a></li>
                <li><a href="#">2</a></li>
                <li><a href="#">3</a></li>
                <li><a href="#">4</a></li>
                <li><a href="#">5</a></li>
                <li><a href="#"><span class="glyphicon glyphicon-chevron-right"></span></a></li>
            </ul>
         </div>
    </div>
</asp:Content>

