<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SanJacinto.Models.AutoModel>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	BuscarAutoAlquilar
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <br />
    
    <% using (Html.BeginForm("AgregarAuto", "Auto"))  { %>
    <div class="container">
        <div class="row">
            <div class="col-md-6 col-md-offset-4">
              
       <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    
                    <h4 class="modal-title custom_align" id="Heading">
                       Modificar Auto</h4>
                </div>
                <div class="modal-body">
                <%= Html.TextBoxFor(m => m.Codigo , new { style = "display: none;" }) %>
                    <div class="form-group">
                         <%: Html.DropDownListFor(m => m.Marca, Model.lstMarcas, new { @class = "form-control" })%>
                    
                    </div>
                    <div class="form-group">
                         <%: Html.DropDownListFor(m => m.Modelo, Model.lstModelos, new { @class = "form-control" })%>
                        
                    </div>
                     <div class="form-group">
                             <%: Html.DropDownListFor(m => m.Categoria, Model.lstCategorias , new { @class = "form-control" })%>
                             
                    </div>
                    <div class="form-group">
                           
                            <%: Html.TextBoxFor(m => m.PrecioMinimo, new { placeholder = "Precio Minimo del Auto", @class = "form-control" })%>
                    </div>
                    <div class="form-group">
                           
                            <%: Html.TextBoxFor(m => m.Placa, new { placeholder = "Placa del Auto", @class = "form-control" })%>
                    </div>
                    <div class="form-group">
                           
                           <%: Html.TextBoxFor(m => m.Imagen, new { placeholder = "Ruta Imagen del Auto", @class = "form-control" })%>
                    </div>
                </div>
                <div class="modal-footer ">
                    <button type="submit" class="btn btn-warning btn-lg" style="width: 100%;" >
                        <span class="glyphicon glyphicon-ok-sign"></span>Modificar</button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
            </div>
        </div>
    </div>
    <% } %>
</asp:Content>
