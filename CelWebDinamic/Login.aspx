<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CelWebDinamic.Login" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>CelWeb</title>
    <link href="asset/bootstrap-5.2.0/css/bootstrap.min.css" rel="stylesheet" />
    <link href="asset/Fontawesome/css/all.min.css" rel="stylesheet" />
    <link href="asset/SweeAlert/sweetalert.min.css" rel="stylesheet" />
    <link href="asset/CSS/Login.css" rel="stylesheet" />



</head>
<body>
    <form id="frmLogin" runat="server">

        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>





                <div class="Contenedor">



                    <div class="card" style="background-color: #f2f2f2; border-radius: 15px">

                        <div class="card-body">

                            <div class="ImagenTop">
                                <img src="asset/image/aple.png" width="300" />
                            </div>

                            <div class="titleLogin">

                                <h1>CelWeb</h1>

                            </div>

                            <div class="form-floating mb-3">
                                <asp:TextBox runat="server"  class="form-control" ID="txtUsuario" placeholder="Usuario"></asp:TextBox>
                                <label for="floatingInput">Usuario</label>
                            </div>
                            <div class="form-floating">
                                <asp:TextBox runat="server" TextMode="password" class="form-control" ID="txtPassword" placeholder="Contraseña"></asp:TextBox>
                                <label for="floatingPassword">Contraseña</label>
                            </div>

                            <div class="row col-12 btnLogin">

       
                                <asp:Button runat="server" ID="btnIngresar" Text ="Iniciar Sesion" CssClass ="btn btn-primary" OnClick="BtnIngresar_Click" />
                            </div>

                            

                        </div>

                    </div>


                </div>





            </ContentTemplate>

        </asp:UpdatePanel>




    </form>




    <script src="asset/JQuery/jquery.min.js"></script>
    <script src="asset/bootstrap-5.2.0/js/bootstrap.min.js"></script>
    <script src="asset/SweeAlert/sweetalert.all.min.js"></script>
    <script src="asset/SweeAlert/sweetAlertStyle.js"></script>
</body>
</html>
