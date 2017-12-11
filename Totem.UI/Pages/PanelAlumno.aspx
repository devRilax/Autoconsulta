<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PanelAlumno.aspx.cs" Inherits="Totem.UI.Pages.PanelAlumno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
      <title>Consulta financiera</title>

    <!--#include file="Header.html"-->
    <link href="../Fw/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Fw/bootstrap/css/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="../Fw/css/metisMenu.min.css" rel="stylesheet" />
    <link href="../Fw/css/sb-admin-2.css" rel="stylesheet" />
    <link href="../Fw/fontsAwesome/css/font-awesome.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="wrapper">
            <nav class="navbar navbar-inverse bg-primary" role="navigation" style="margin-bottom: 0">

                <div class="container-fluid">
                    <div class="navbar-header">
                        <a class="navbar-brand" href="#">Sistema Integrado de consulta financiera</a>
                    </div>
                    <ul class="nav navbar-nav">
                    </ul>
                    <ul class="nav navbar-nav navbar-right">
                        <li></li>
                        <li>

                            <asp:LinkButton ID="linkLogout" runat="server" OnClick="linkLogout_Click">
                                 <i class="fa fa-sign-out"></i>SALIR
                            </asp:LinkButton>

                        </li>
                    </ul>
                </div>
            </nav>


        </div>

        <style type="text/css">
            th {
                text-align: center !important;
            }
        </style>
        <div class="page-header">

            <div class="row">
                <div class="form-group col-md-6">
                    <div class="col-md-offset-2">
                        <img src="../Fw/imagenes/logoPAO.png" />
                    </div>
                </div>
                <div class="form-group col-md-6">
                    <div class="col-md-offset-1">
                        <h1 class="text-danger text-left"><i class="fa fa-exclamation-circle" aria-hidden="true"></i>Solo información referencial</h1>
                    </div>
                </div>
            </div>


        </div>


        <div class="container">
            <%--<div class="well">--%>
            <i class="fa fa-user" aria-hidden="true"></i>
            <label>Run Alumno</label>
            <asp:Label ID="lblRun" runat="server" Text="Label" ClientIDMode="Static"></asp:Label>

            <div class="row">
                <div class="form-group col-md-12">
                    <div class="table-responsive">
                        <asp:GridView ID="gridReporte" runat="server" CssClass="table table-hover table-striped table-bordered" AutoGenerateColumns="false"
                            GridLines="None" CellSpacing="-1" HorizontalAlign="Center"
                            Font-Names="Tahoma">
                            <Columns>
                                <asp:BoundField DataField="glosaCuota" HeaderText="ESTADO CUOTA" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Right">
                                    <HeaderStyle HorizontalAlign="Right"></HeaderStyle>

                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="nroCuota" HeaderText="N° CUOTA" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="montoCuota" HeaderText="MONTO CUOTA" DataFormatString="{0:C0}" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="montoInteres" HeaderText="INTERÉS" DataFormatString="{0:C0}" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="gastoCobranza" HeaderText="GASTOS COBRANZA" DataFormatString="{0:C0}" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="totalCuota" HeaderText="TOTAL" DataFormatString="{0:C0}" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundField>
                            </Columns>
                            <HeaderStyle BackColor="#EBEBFA" />
                        </asp:GridView>
                    </div>



                    <div class="col-md-offset-10">
                        <span class="label label-primary">Total a pagar: </span>&nbsp;
                        <asp:Label ID="lblDeudaTotal" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>&nbsp;
                    </div>

                    <div class="row">
                        <div class="col-md-6 col-md-offset-4">


                            <button type="button" id="btnEnviarEmail" data-toggle="modal" data-target="#modalEmail" class="btn btn-primary">
                                <i class="fa fa-envelope"></i>
                                Enviarme un reporte</button>
                        </div>
                    </div>


                </div>
                <br />




                <div class="modal fade" id="modalEmail">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header bg-warning">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                                <h4 class="modal-title">Envio de reporte</h4>
                            </div>
                            <div class="modal-body">

                                <p>
                                    Ingrese su correo:
                                </p>
                                <br />
                                <input type="email" id="txtEmailAjx" placeholder="@email" class="form-control" />
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-warning" data-dismiss="modal">
                                    Cerrar</button>
                                <button type="button" class="btn btn-warning" id="btnEnviarEmailAjx"
                                    data-loading-text="<i class='fa fa-circle-o-notch fa-spin'></i> Procesando">
                                    Enviar
                                </button>
                            </div>
                        </div>

                    </div>

                </div>

            </div>
            <%--    </div>--%>
        </div>

        <!--#include file="Footer.html"-->
        <script src="js/comun.js"></script>
        <script src="js/Consulta.js"></script>
    </form>
     <div class="panel-footer">
        <div class="row">
            <div class="col-md-11">
                <h3 class="text-info text-center"><i class="fa fa-clock-o" aria-hidden="true"></i>Información actualizada cada 24hrs.</h3>
            </div>
        </div>
    </div>
</body>
</html>
