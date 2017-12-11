using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Totem.Util
{
    public class UtilScript
    {
        //Ejecuta una funcion javascript desde el servidor
        public static void executeJS(string command, Page web, int time)
        {
            ScriptManager.RegisterStartupScript(web, web.GetType(), "msg", command, true);
        }
    }
}
