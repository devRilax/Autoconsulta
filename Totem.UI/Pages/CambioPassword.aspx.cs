using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Totem.BLL;
using Totem.Util;
using Totem.VO;

namespace Totem.UI.Pages
{
    public partial class CambioPassword : System.Web.UI.Page
    {
        private UsuarioAlumno usuarioLogeado = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuarioAlumno"] == null)
            {
                Response.Redirect("../Paginas/Login.aspx");
            }
            usuarioLogeado = new UsuarioAlumno();
            usuarioLogeado = (UsuarioAlumno)(Session["usuarioAlumno"]);
            txtRun.Text = UtilString.formatRun(usuarioLogeado.run);
            txtRun.Attributes.Add("readonly", "readonly");
        }

        protected void btnCambiarPassword_Click(object sender, EventArgs e)
        {

            UsuarioAlumno usuario = null;
            string claveConfirmacion = "";

            try
            {
                usuario = new UsuarioAlumno();
                usuario.email = txtEmail.Text;
                usuario.clave = txtClave.Text;
                usuario.run = UtilString.quitarFormatoRun(txtRun.Text);
                claveConfirmacion = txtClaveConfirmar.Text;

                validLengthPw(usuario.clave);


                if (UsuarioAlumnoBLL.getInstance.cambiarClaveUsuario(usuario, claveConfirmacion))
                {
                    UsuarioAlumnoBLL.getInstance.enviarEmailInformativo(usuario);
                    Session["OK"] = "Contraseña actualizada";
                    Response.Redirect("../Paginas/Login.aspx");
                }


            }
            catch (Exception ex)
            {
                UtilScript.executeJS("msgRespuesta('" + ex.Message + "','error');", this.Page, 500);
            }
        }

        private void validLengthPw(string password)
        {
            if (password.Length <= 4)
            {
                throw new Exception("Clave insegura: Su contraseña debe tener más de 3 caracteres");
            }
        }

        protected void linkLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("../Paginas/Login.aspx");
        }
    }
}