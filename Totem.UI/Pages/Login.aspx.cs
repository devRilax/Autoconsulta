using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Totem.VO;
using Totem.Util;
using Totem.BLL;


namespace Totem.UI.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["OK"] != null)
            {
                UtilScript.executeJS("msgRespuesta('Credenciales actualizadas','success');", this.Page, 500);
                Session.Clear();
                Session.Abandon();
            }
        }

        protected void btnLogeo_Click(object sender, EventArgs e)
        {
            UsuarioAlumno user = null;

            try
            {
                user = new UsuarioAlumno();
                user.run = txtUsermane.Text;
                user.clave = txtPassword.Text;

                Session["usuarioAlumno"] = user;

                if (UsuarioAlumnoBLL.getInstance.validUser(user))
                {
                    //Aqui debería validar el "estadoLogin" del usuario, si es 0
                    //deberá redireccionar a la página para cambiar su clave,
                    //de lo contrario debe redireccionar al panel alumno, por problemas
                    //de seguridad, en esta ocasión no se cambiará la clave.
                    Response.Redirect("../Pages/PanelAlumno.aspx");
                }
                else
                {
                    UtilScript.executeJS("msgLoginError('Credenciales invalidas');", this.Page, 500);
                }
            }
            catch (Exception ex)
            {
                UtilScript.executeJS("msgLoginError('" + ex.Message + "');", this.Page, 500);
            }

        }
    }
}