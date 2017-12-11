using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Web.Services;
using Totem.BLL;
using Totem.Util;
using Totem.VO;

namespace Totem.UI.Pages
{
    public partial class PanelAlumno : System.Web.UI.Page
    {
        private UsuarioAlumno alumno = null;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["usuarioAlumno"] == null)
            {
                Response.Redirect("../Pages/Login.aspx");
            }


            alumno = new UsuarioAlumno();
            alumno = (UsuarioAlumno)(Session["usuarioAlumno"]);
            lblRun.Text = UtilString.formatRun(alumno.run);
            loadReportInit();
        }

        private void loadReportInit()
        {
            List<ReporteFinanciero> reporte = null;
            double deudaGlobal = 0;

            try
            {
                reporte = ReporteFinancieroBLL.getInstance.getReporteByRut(lblRun.Text);

                foreach (ReporteFinanciero item in reporte)
                {
                    deudaGlobal += item.montoCuota + item.montoInteres + item.gastoCobranza;
                }

                gridReporte.DataSource = reporte;
                gridReporte.DataBind();
                lblDeudaTotal.Text = "$" + deudaGlobal.ToString("N0");

            }
            catch (Exception ex)
            {
                lblDeudaTotal.Text = ex.Message;
            }
        }

        /// <summary>
        /// Envia un email a un usuario
        /// </summary>
        /// <param name="email"></param>
        /// <param name="run"></param>
        /// <returns></returns>
        [WebMethod]
        public static string enviarEmail(string email, string run)
        {
            JObject jsonObject = null;

            try
            {
                ReporteFinancieroBLL.getInstance.processEmail(email, run);
                jsonObject = new JObject();
                jsonObject.Add("status", "OK");
                jsonObject.Add("mensaje", "Reporte enviado correctamente");

            }
            catch (Exception ex)
            {
                jsonObject = new JObject();
                jsonObject.Add("status", "error");
                jsonObject.Add("mensaje", ex.Message);
            }

            return JsonConvert.SerializeObject(jsonObject);
        }

        protected void linkLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("../Paginas/Login.aspx");
        }
    }
}