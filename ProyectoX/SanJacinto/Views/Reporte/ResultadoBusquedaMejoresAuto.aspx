<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<SanJacinto.wsReporteService.AutoReporte>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	ResultadoBusquedaMejoresAuto
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
               
                <h4>Lista de Automoviles</h4>
                <div class="table-responsive">
                    <table id="mytable" class="table table-bordred table-striped">
                        <thead>
                            <th>
                                Placa
                            </th>
                            <th>
                                Categoria
                            </th>
                            <th>
                                Marca
                            </th>
                            <th>
                                Modelo
                            </th>
                            <th>
                                Veces alquilado
                            </th>
                        </thead>
                        <tbody>

                           <% foreach (var item in Model)
                              { %>

                              <tr>
                              <td> <%: item.Placa   %> </td>
                              <td> <%: item.Categoria    %> </td>
                              <td> <%: item.Marca    %> </td>
                              <td> <%: item.Modelo   %> </td>
                              <td> <%: item.veces   %> </td>

                              </tr>

                           <%} %>
                           
                        </tbody>
                    </table>
                    <div class="clearfix">
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

