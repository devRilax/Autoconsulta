<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CambioPassword.aspx.cs" Inherits="Totem.UI.Pages.CambioPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
      <title>Cambio de clave</title>

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

        <div class="page-header">
            <div class="row">
                <div class="form-group col-md-6">
                    <img src="../Fw/imagenes/logoPAO.png" />
                </div>
                <div class="form-group col-md-6">
                     <h3 class="text-primary"><i class="fa fa-lock" aria-hidden="true"></i>Cambio de clave, será enviada como respaldo a su correo</h3><br />
                </div>
            </div>
          <%--  <div class="form-inline">
                <div class="form-group col-md-offset-1">
                    <img src="../Fw/imagenes/logoPAO.png" />
                </div>
                <div class="form-group col-md-offset-1">
                    <h3 class="text-primary"><i class="fa fa-lock" aria-hidden="true"></i>Cambio de clave, esta será enviada a su correo a modo de respaldo</h3><br />
                </div>

            </div>--%>
        </div>

 


        <div class="panel panel-default">
            <div class="panel-body">
                <div class="container">
                    <div class="col-md-offset-4">
                        <div class="form-group row">
                            <label class="col-sm-2 col-form-label">Rut</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtRun" class="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-sm-2 col-form-label">Email</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtEmail" TextMode="Email" class="form-control" runat="server" placeholder="@Mail"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-sm-2 col-form-label">Clave nueva</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtClave" class="form-control" runat="server" TextMode="Password" placeholder="Clave"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-sm-2 col-form-label">Confirmar clave</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtClaveConfirmar" class="form-control" runat="server" TextMode="Password" placeholder="Confirmar clave"></asp:TextBox>
                            </div>
                        </div>


                        <div class="form-group row">
                            <div class="col-md-offset-3">

                                <asp:Button ID="btnCambiarPassword" runat="server" Text="Confirmar" CssClass="btn btn-warning" OnClick="btnCambiarPassword_Click" />
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>



        <script src="js/comun.js"></script>
        <!--#include file="Footer.html"-->
    </form>
</body>
</html>
