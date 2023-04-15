using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static EL.Enum;
using BL;
using EL;
using Utilidades;
using static System.Collections.Specialized.BitVector32;


namespace CelWebDinamic
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AbandonarSesion();
            }
        }


        private void AbandonarSesion(bool MostrarMensaje = true)
        {
            Session.Abandon();
            Session.RemoveAll();
            HttpCookie CookieSesion = new HttpCookie("ASP.NET_SessionId", "");
            Response.Cookies.Add(CookieSesion);
        }
        private void Mensaje(string Message, eMessage tipoMensaje, string Encabezado = "", bool Html = false, bool Fondo = false, bool returnLogin = false, string UrlReturn = "", bool CerrarClick = true)
        {
            //icon -->      success,warning, error,  info
            //btnColor -->  #32A525,#E38618,#F27474,#3FC3EE

            //Parametros que recibe el metodo
            //function Mensaje(title, mensaje, icon = 'success', btnConfirmText = 'Aceptar', btnConfirmColor = '#32A525', html = false, fondo = false, ReturnLogin = false, UrlReturn)

            switch (tipoMensaje)
            {
                case eMessage.Exito:
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SweetAlert Exito", "Mensaje('" + Encabezado + "', '" + Message + "','success','Aceptar','#32A525'," + Html.ToString().ToLower() + "," + Fondo.ToString().ToLower() + "," + returnLogin.ToString().ToLower() + ",'" + UrlReturn.ToString().ToLower() + "'," + CerrarClick.ToString().ToLower() + ");", true);
                    break;
                case eMessage.Alerta:
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SweetAlert Alerta", "Mensaje('" + Encabezado + "', '" + Message + "','warning','Aceptar','#E38618'," + Html.ToString().ToLower() + "," + Fondo.ToString().ToLower() + "," + returnLogin.ToString().ToLower() + ",'" + UrlReturn.ToString().ToLower() + "'," + CerrarClick.ToString().ToLower() + ");", true);
                    break;
                case eMessage.Error:
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SweetAlert Error", "Mensaje('" + Encabezado + "', '" + Message + "','error','Aceptar','#F27474'," + Html.ToString().ToLower() + "," + Fondo.ToString().ToLower() + "," + returnLogin.ToString().ToLower() + ",'" + UrlReturn.ToString().ToLower() + "'," + CerrarClick.ToString().ToLower() + ");", true);
                    break;
                case eMessage.Info:
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SweetAlert Info", "Mensaje('" + Encabezado + "', '" + Message + "','info','Aceptar','#3FC3EE'," + Html.ToString().ToLower() + "," + Fondo.ToString().ToLower() + "," + returnLogin.ToString().ToLower() + ",'" + UrlReturn.ToString().ToLower() + "'," + CerrarClick.ToString().ToLower() + ");", true);
                    break;
            }
        }
        private string Justify(string msj)
        {
            string Html = "<div style = text-align:justify> " + msj + " </div>";
            return Html;
        }

        



         private bool ValidarAcceso()
        {
            if (string.IsNullOrEmpty(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                Mensaje("Ingrese su usuario", eMessage.Alerta);
                return false;
            }
            if (string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                Mensaje("Ingrese su contraseña", eMessage.Alerta);
                return false;
            }

            if (!BL_Usuarios.ExisteUserName(txtUsuario.Text))
            {
                Mensaje("Credenciales Incorrectas", eMessage.Alerta);
                return false;
            }

            if(BL_Usuarios.VerificarCuentaBloqueada(txtUsuario.Text))
            {
                Mensaje("Su cuenta ha sido bloqueada por multiples intentos fallidos de iniciar sesion", eMessage.Error);
                return false;
            }

            byte [] Password = BL_Usuarios.Encrypt(txtPassword.Text);
            if (!BL_Usuarios.ValidarCredenciales(txtUsuario.Text,Password)) 
            {

                Usuarios User = BL_Usuarios.ExisteUsuario_x_UserName(txtUsuario.Text);
                if (BL_Usuarios.CantidadIntentosFallidos(txtUsuario.Text) >= 2)
                {
                    
                    BL_Usuarios.BloquearCuentaUsuario(User.IdUsuario, true, User.IdUsuario);
                    Mensaje(Justify("La cuenta ha sido bloqueada por multiples intentos de iniciar sesion. Comuniquese con un administrador"), eMessage.Error, "", true);
                }

                if (User != null)
                {
                    BL_Usuarios.SumarIntentosFallido(User.IdUsuario);
                    
                }

                Mensaje(Justify("Credenciales incorrectas. Supera 3 intentos fallidos y su cuenta estara bloqueada"), eMessage.Alerta, "", true);
                return false;
            }


            Usuarios UsuarioAutenticado = BL_Usuarios.ExisteUsuario_x_UserName(txtUsuario.Text);
            if(UsuarioAutenticado != null) 
            { 
            
                if (UsuarioAutenticado.IntentosFallidos > 0)
                {
                    BL_Usuarios.RestablecerIntentosFallido(UsuarioAutenticado.IdUsuario,UsuarioAutenticado.IdUsuario);

                }

                if (!(UsuarioAutenticado.IdRol > 0))
                {

                    Mensaje("Lo sentimos, usted no tiene un Rol asignado en el sistema. Comuniquese con un administrador", eMessage.Alerta);
                    return false;
                }

                Session["IdUsuarioGl"] = UsuarioAutenticado.IdUsuario;
                Session["IdRolGl"] = UsuarioAutenticado.IdRol;
                //Redireccionar a la pagina principal
                Response.Redirect("~/Principal.aspx");

            }
            return true;
        }
        protected void BtnIngresar_Click(object sender, EventArgs e)
        {
            ValidarAcceso();

        }
    }
}