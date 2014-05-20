<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	MantenimientoAuto
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h4>
                    Lista de Automoviles (
                    <button type="button" class="btn btn-link btn-cons" data-title="Insert" data-toggle="modal"
                        data-target="#crear" data-placement="top" rel="tooltip">
                        Agregar Auto</button>)</h4>
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
                            <tr>
                                <td>
                                    Toyota
                                </td>
                                <td>
                                    Yaris
                                </td>
                                <td>
                                    137.00
                                </td>
                                <td>
                                    ABCABC
                                </td>
                                <td>
                                    <p>
                                        <button class="btn btn-primary btn-xs" data-title="Edit" data-toggle="modal" data-target="#edit"
                                            data-placement="top" rel="tooltip">
                                            <span class="glyphicon glyphicon-pencil"></span>
                                        </button>
                                    </p>
                                </td>
                                <td>
                                    <p>
                                        <button class="btn btn-danger btn-xs" data-title="Delete" data-toggle="modal" data-target="#delete"
                                            data-placement="top" rel="tooltip">
                                            <span class="glyphicon glyphicon-trash"></span>
                                        </button>
                                    </p>
                                </td>
                            </tr>
                            <td>
                                Toyota
                            </td>
                            <td>
                                Yaris
                            </td>
                            <td>
                                137.00
                            </td>
                            <td>
                                ABCABC
                            </td>
                            <td>
                                <p>
                                    <button class="btn btn-primary btn-xs" data-title="Edit" data-toggle="modal" data-target="#edit"
                                        data-placement="top" rel="tooltip">
                                        <span class="glyphicon glyphicon-pencil"></span>
                                    </button>
                                </p>
                            </td>
                            <td>
                                <p>
                                    <button class="btn btn-danger btn-xs" data-title="Delete" data-toggle="modal" data-target="#delete"
                                        data-placement="top" rel="tooltip">
                                        <span class="glyphicon glyphicon-trash"></span>
                                    </button>
                                </p>
                            </td>
                            </tr>
                            <td>
                                Toyota
                            </td>
                            <td>
                                Yaris
                            </td>
                            <td>
                                137.00
                            </td>
                            <td>
                                ABCABC
                            </td>
                            <td>
                                <p>
                                    <button class="btn btn-primary btn-xs" data-title="Edit" data-toggle="modal" data-target="#edit"
                                        data-placement="top" rel="tooltip">
                                        <span class="glyphicon glyphicon-pencil"></span>
                                    </button>
                                </p>
                            </td>
                            <td>
                                <p>
                                    <button class="btn btn-danger btn-xs" data-title="Delete" data-toggle="modal" data-target="#delete"
                                        data-placement="top" rel="tooltip">
                                        <span class="glyphicon glyphicon-trash"></span>
                                    </button>
                                </p>
                            </td>
                            </tr>
                            <td>
                                Toyota
                            </td>
                            <td>
                                Yaris
                            </td>
                            <td>
                                137.00
                            </td>
                            <td>
                                ABCABC
                            </td>
                            <td>
                                <p>
                                    <button class="btn btn-primary btn-xs" data-title="Edit" data-toggle="modal" data-target="#edit"
                                        data-placement="top" rel="tooltip">
                                        <span class="glyphicon glyphicon-pencil"></span>
                                    </button>
                                </p>
                            </td>
                            <td>
                                <p>
                                    <button class="btn btn-danger btn-xs" data-title="Delete" data-toggle="modal" data-target="#delete"
                                        data-placement="top" rel="tooltip">
                                        <span class="glyphicon glyphicon-trash"></span>
                                    </button>
                                </p>
                            </td>
                            </tr>
                            <td>
                                Toyota
                            </td>
                            <td>
                                Yaris
                            </td>
                            <td>
                                137.00
                            </td>
                            <td>
                                ABCABC
                            </td>
                            <td>
                                <p>
                                    <button class="btn btn-primary btn-xs" data-title="Edit" data-toggle="modal" data-target="#edit"
                                        data-placement="top" rel="tooltip">
                                        <span class="glyphicon glyphicon-pencil"></span>
                                    </button>
                                </p>
                            </td>
                            <td>
                                <p>
                                    <button class="btn btn-danger btn-xs" data-title="Delete" data-toggle="modal" data-target="#delete"
                                        data-placement="top" rel="tooltip">
                                        <span class="glyphicon glyphicon-trash"></span>
                                    </button>
                                </p>
                            </td>
                            </tr>
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

    <!-- Pop up de registro de usuario -->
    <div class="modal fade" id="crear" tabindex="-1" role="dialog" aria-labelledby="crear"
        aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        ×</button>
                    <h4 class="modal-title custom_align" id="Heading">
                        Insert Your Detail</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <input class="form-control " type="text" placeholder="Mohsin">
                    </div>
                    <div class="form-group">
                        <input class="form-control " type="text" placeholder="Irshad">
                    </div>
                    <div class="form-group">
                        <textarea rows="2" class="form-control" placeholder="CB 106/107 Street # 11 Wah Cantt Islamabad Pakistan"></textarea>
                    </div>
                </div>
                <div class="modal-footer ">
                    <button type="button" class="btn btn-warning btn-lg" style="width: 100%;">
                        <span class="glyphicon glyphicon-ok-sign"></span>Update</button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>

    <!-- Popup de edicion de auto -->
    <div class="modal fade" id="edit" tabindex="-1" role="dialog" aria-labelledby="edit"
        aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        ×</button>
                    <h4 class="modal-title custom_align" id="H1">
                        Edit Your Detail</h4>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <input class="form-control " type="text" placeholder="Mohsin">
                    </div>
                    <div class="form-group">
                        <input class="form-control " type="text" placeholder="Irshad">
                    </div>
                    <div class="form-group">
                        <textarea rows="2" class="form-control" placeholder="CB 106/107 Street # 11 Wah Cantt Islamabad Pakistan"></textarea>
                    </div>
                </div>
                <div class="modal-footer ">
                    <button type="button" class="btn btn-warning btn-lg" style="width: 100%;">
                        <span class="glyphicon glyphicon-ok-sign"></span>Update</button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    
    <!-- Popup de eliminacion de auto -->
    <div class="modal fade" id="delete" tabindex="-1" role="dialog" aria-labelledby="edit"
        aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        ×</button>
                    <h4 class="modal-title custom_align" id="H2">
                        Delete this entry</h4>
                </div>
                <div class="modal-body">
                    <div class="alert alert-warning">
                        <span class="glyphicon glyphicon-warning-sign"></span>Are you sure you want to delete
                        this Record?</div>
                </div>
                <div class="modal-footer ">
                    <button type="button" class="btn btn-warning">
                        <span class="glyphicon glyphicon-ok-sign"></span>Yes</button>
                    <button type="button" class="btn btn-warning">
                        <span class="glyphicon glyphicon-remove"></span>No</button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
</asp:Content>
