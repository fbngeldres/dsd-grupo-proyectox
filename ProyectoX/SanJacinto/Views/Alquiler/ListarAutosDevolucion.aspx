<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<SanJacinto.Models.AutoModel>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	listaAlquilerModel
</asp:Content>




<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script language="javascript" type="text/javascript" >
        function setearCodigo(obj) {

            $("#idAuto").val(obj);
            
            
        }


</script>
<form runat="server" action="/Alquiler/DevolverVehiculo" method="post">
    <div class="col-md-12">
        <asp:HiddenField ID="HiddenField2" runat="server"  />
        <h2>Listados de Alquileres</h2>
        <input type="hidden" id="idAuto" name="idAuto"  />
        <div class="table-responsive">
            <table class="table table-bordred table-striped">
                <thead>
                    <th></th>
                    <th>
                        Codigo
                    </th>
                    <th>
                        Marca
                    </th>
                    <th>
                        Modelo
                    </th>
                    <th>
                        Placa
                    </th>
                    <th>
                        Imagen
                    </th>
                    <th>
                        Estado
                    </th>
                    
                </thead>
                <tbody>

            <% foreach (var item in Model) { %>
    
                <tr>
                    <td>
                       <p>
                            <button class="btn btn-primary btn-xs" data-title="Devolucion" data-toggle="modal" data-target="#devolver" onclick="setearCodigo('<%: item.Codigo  %>');"; 
                                data-placement="top" rel="tooltip">
                                <span class="glyphicon glyphicon-pencil"></span>
                            </button>
                       </p>
                    </td>
                    <td>
                        <%: item.Codigo  %>
                    </td>
                    <td>
                        <%: item.MarcaDesc    %>
                    </td>
                  <td>
                        <%: item.ModeloDesc    %>
                    </td>
                      
                      <td>
                        <%: item.Placa  %>
                    </td>
                      <td>
                        <%: item.Imagen  %>
                    </td>
                      <td>
                        <%: item.EstadoDesc    %>
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
               
                <li><a href="#"><span class="glyphicon glyphicon-chevron-right"></span></a></li>
            </ul>
         </div>

           <div style="color:Green">
<%= Html.DisplayText("MensajeExito")%>
                </div>

                <div style="color:Red">
<%= Html.DisplayText("MensajeError")%>
                </div>
                
    </div>
   
    <div class="modal fade" id="devolver" tabindex="-1" role="dialog" aria-labelledby="devolver"
        aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        ×</button>
                    <h4 class="modal-title custom_align" id="H2">
                        Devolver Auto</h4>
                </div>
                <div class="modal-body">
                    <div class="alert alert-warning">
                        <span class="glyphicon glyphicon-warning-sign"></span> Esta Seguro que desea devolver este Auto?</div>
                </div>
                <div class="modal-footer ">
                    <button type="submit" class="btn btn-warning">
                        <span class="glyphicon glyphicon-ok-sign">Si
                        </button>
                      
                    <button type="button" class="btn btn-warning" aria-hidden="true" data-dismiss="modal" >
                        <span class="glyphicon glyphicon-remove"></span>No</button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    </form>
</asp:Content>

