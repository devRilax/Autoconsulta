using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Totem.Util
{
    public class MensajeEmail
    {
        public static string createBodyChangePassword(string username, string password)
        {
            string strHtml = "";

            strHtml += "<h2>Estimado Alumno(a) </h2><br>";
            strHtml += "<p>Su cambio de contraseña fue realizada con éxito,</p>";
            strHtml += "<p>Sus credenciales para acceder al sistema de Autoconsulta financiera son las siguientes: </p>";
            strHtml += "<p>Nombre de usuario: " + username + "</p>";
            strHtml += "<p>Clave: " + password + "</p><br>";
            strHtml += "<p>Atte: Departamento de administración Duoc UC</p>";

            return strHtml;
        }
    }
}
