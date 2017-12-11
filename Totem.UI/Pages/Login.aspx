<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Totem.UI.Pages.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Bienvenido</title>

    <!--#include file="Header.html"-->
    <link rel="stylesheet" href="../Fw/css/style.css" />
</head>
<body style="background-color: #00263E; width:100%; height:100%;">

  
    <div class="page-header">
          <h1 class="text-center" style="font-family: 'Source Sans Pro Semibold'; color: #FFFFFF;">Sistema de Autoconsulta Financiera</h1>
      <h3 class="text-center" style="font-family: 'Source Sans Pro Semibold'; color: #FFFFFF;">Duoc UC sede Padre Alonso De Ovalle</h3>
    </div>
    

    <form id="form1" runat="server" class="form-signin">
        <div class="wrapper">


            <p class="logo" aria-autocomplete="list">
                <img class="logo" src="../Fw/imagenes/logoLogin.png" />
            </p>

            <asp:TextBox ID="txtUsermane" class="form-control" placeholder="Run" MaxLength="9" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtPassword" class="form-control" placeholder="Clave" MaxLength="15" TextMode="Password" runat="server"></asp:TextBox>


            <asp:Button ID="btnLogeo" class="btn btn-lg btn-warning btn-block" runat="server" Text="Entrar" OnClick="btnLogeo_Click" />




        </div>
        <!--#include file="Footer.html"-->
        <script src="js/comun.js"></script>



    </form>
    <br /><br /><br />

    
    <h6 class="text-center" style="color: #FFFFFF; font-family: 'Trebuchet MS', 'Lucida Sans Unicode', 'Lucida Grande', 'Lucida Sans', Arial, sans-serif;">Desarrollado por: Danilo Caro Aparicio</h6>
    <h6 class="text-center" style="color: #FFFFFF; font-family: 'Trebuchet MS', 'Lucida Sans Unicode', 'Lucida Grande', 'Lucida Sans', Arial, sans-serif;">Analista Programador Computacional 2017</h6>


</body>
</html>
