<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<SanJacinto.Models.AutoModel>>"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	MantenimientoAuto
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<script language="javascript" type="text/javascript" >
    function setearCodigo(obj) {

        $("#codigoEliminar").val(obj);



    }

    function setearCodigoModificar(obj) {
       
        window.location = '/Auto/PlantillaModificarAuto?codigo=' + obj

    }
   
   


</script>
<form id="Form1" runat="server"  method="post">

<input type="hidden" id="codigo" name="codigo" />
    <div class="container">
        <div class="row">
            <div class="col-md-12">
               
                <h4>
                
                    Lista de Automoviles (
                    <a href="/Auto/PlantillaAgregarAuto"> Agregar Auto</a>)</h4>
                <div class="table-responsive">
                    <table id="mytable" class="table table-bordred table-striped">
                        <thead>
                            <th>
                                Marca
                            </th>
                            <th>
                                Modelo
                            </th>
                            <th>
                                Precio
                            </th>
                            <th>
                                Placa
                            </th>
                            <th>
                                Editar
                            </th>
                            <th>
                                Eliminar
                            </th>
                        </thead>
                        <tbody>

                           <% foreach (var item in Model)
                              { %>

                              <tr>
                              <td> <%: item.MarcaDesc   %> </td>
                              <td> <%: item.ModeloDesc    %> </td>
                              <td> <%: item.PrecioMinimo    %> </td>
                              <td> <%: item.Placa   %> </td>

                              <td>
                                    <p>
                                        <button class="btn btn-primary btn-xs" data-title="Edit" data-toggle="modal"  onclick="setearCodigoModificar('<%: item.Codigo   %> ');"
                                            data-placement="top" rel="tooltip">
                                            <span class="glyphicon glyphicon-pencil"></span>
                                        </button>
                                    </p>
                                </td>

                                  <td>
                                    <p>
                                        <button id="eliminar" class="btn btn-danger btn-xs" data-title="Delete" data-toggle="modal" onclick="setearCodigo('<%: item.Codigo   %> ')"  data-target="#delete" 
                                            data-placement="top" rel="tooltip">
                                            <span class="glyphicon glyphicon-trash"></span>
                                        </button>
                                    </p>
                                </td>

                              </tr>


                           <%} %>
                           
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
        </div>
    </div>
     </form>
    <!-- Pop up de registro de Auto -->
 

    <!-- Popup de edicion de auto -->
    
    <form id="Form3" action="../Auto/EliminarAuto"   method="post"> 
    <!-- Popup de eliminacion de auto -->
    
    <div class="modal fade" id="delete" tabindex="-1" role="dialog" aria-labelledby="edit"
        aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        ×</button>
                    <h4 class="modal-title custom_align" id="H2">
                        Eliminar Auto</h4>
                </div>
                <div class="modal-body">
                    <div class="alert alert-warning">
                        <span class="glyphicon glyphicon-warning-sign"></span>Estas Seguro que deseas eliminar este registro?</div>
                </div>
                <div class="modal-footer ">
                <input type="hidden" id="codigoEliminar" name="codigoEliminar" />
                    <button type="submit" class="btn btn-warning">
                        <span class="glyphicon glyphicon-ok-sign"></span>Si</button>
                    <button type="button" class="btn btn-warning">
                        <span class="glyphicon glyphicon-remove"></span>No</button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    </form> 
   
</asp:Content>
