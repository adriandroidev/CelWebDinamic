using BL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilidades;
using static EL.Enum;

namespace CelWebDinamic
{
    public partial class Principal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidarSesion();
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

        private void AbandonarSesion(bool MostrarMensaje = true)
        {
            Session.Abandon();
            Session.RemoveAll();
            HttpCookie CookieSesion = new HttpCookie("ASP.NET_SessionId", "");
            Response.Cookies.Add(CookieSesion);
            if (MostrarMensaje)
            {
                Mensaje("Inicie Sesion nuevamente", eMessage.Info, "Datos de sesion incompletos", false, true, true, "/Login.aspx", false);
            }


        }

        private void VerificarPermisosFormularios(List<RolFormularios> RolFormularios)
        {
            panelAdministracionUsuarios.Visible = false;
            panelFormulario_2.Visible = false;
            panelFormulario_3.Visible = false;
            panelFormulario_4.Visible = false;

            foreach (var RolFormulario in RolFormularios)
            {
                if (RolFormulario.IdFormulario == (int)eFormulario.AdministracionUsuarios)
                {
                    panelAdministracionUsuarios.Visible = true;
                }
                if (RolFormulario.IdFormulario == (int)eFormulario.Clientes)
                {
                    panelFormulario_2.Visible = true;
                }
                if (RolFormulario.IdFormulario == (int)eFormulario.Factura)
                {
                    panelFormulario_3.Visible = true;
                }
                if (RolFormulario.IdFormulario == (int)eFormulario.Envios)
                {
                    panelFormulario_4.Visible = true;
                }
            }

        }

        private bool ValidarSesion()
        {

            try
            {
                int IdUsuarioGl = (int)General.ValidarEnteros(Session["IdUsuarioGl"]);
                int IdRolGl = (int)General.ValidarEnteros(Session["IdRolGl"]);
                if (!(IdUsuarioGl > 0))
                {

                    AbandonarSesion();

                    return false;
                }

                if (!(IdRolGl > 0))
                {
                    AbandonarSesion();


                    return false;
                }

                Usuarios user = BL_Usuarios.Registro(IdUsuarioGl);
                if (user == null)
                {
                    AbandonarSesion();


                    return false;
                }

                if (user.IdRol != IdRolGl)
                {

                    AbandonarSesion();


                    return false;
                }


                List<RolFormularios> FormulariosUser = BL_RolFormulario.List(IdRolGl);
                if (!(FormulariosUser.Count > 0))
                {
                    AbandonarSesion(false);
                    Mensaje("Estimado usuario, no cuenta con permisos necesarios para ingresar a ningun formulario", eMessage.Info, "", false, true, true, "/Login.aspx", false);
                    return false;
                }


                VerificarPermisosFormularios(FormulariosUser);
                Session["RolFormulariosGl"] = FormulariosUser;
                return true;
            
            }
            catch
            {
                AbandonarSesion();
                return false;
            }

        }

        protected void lnkAdministracionUsuarios_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdministracionUsuarios.aspx");
        }

        protected void lnkFormulario_2_Click(object sender, EventArgs e)
        {

        }

        protected void lnkFormulario_3_Click(object sender, EventArgs e)
        {

        }

        protected void lnkFormulario_4_Click(object sender, EventArgs e)
        {

        }
    }
}