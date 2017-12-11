using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Totem.VO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Totem.Services
{
    public class AlumnoService
    {

        /// <summary>
        /// Valida el login
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public static bool validateUser(UsuarioAlumno usuario)
        {
            AlumnoSv.AlumnoWsClient ws = null;
            string alumnoJson = null;
            JToken token = null;
            bool exist = false;

            try
            {
                ws = new AlumnoSv.AlumnoWsClient();
                alumnoJson = ws.validaLoginAlumno(usuario.run, usuario.clave);
                token = JObject.Parse(alumnoJson);

                if ((string)token.SelectToken("status") == "ok")
                {
                    //Si existe el usuario, obtiene el estado de login
                    usuario.estadoLogin = (int)token.SelectToken("estadoLogin");
                    exist = true;
                }
            }
            catch (Exception)
            {

                throw new Exception("Error desconocido, contacte al administrador");
            }

            return exist;
        }

        /// <summary>
        /// Solicita el cambio de clave a través del servicio
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public static bool changeUserPassword(UsuarioAlumno usuario)
        {
            AlumnoSv.AlumnoWsClient ws = null;
            string alumnoJson = null;
            bool itChanged = false;
            JToken token = null;

            try
            {
                ws = new AlumnoSv.AlumnoWsClient();
                alumnoJson = ws.cambiarClaveUsuario(usuario.run, usuario.clave);
                token = JObject.Parse(alumnoJson);

                if ((string)token.SelectToken("status") == "ok")
                {
                    itChanged = true;
                }
            }
            catch (Exception)
            {

                throw new Exception("Error desconocido, contacte al administrador");
            }

            return itChanged;
        }

        /// <summary>
        /// Obtiene las deudas de un usuario segun su rut a través del servicio de la app central
        /// </summary>
        /// <param name="run"></param>
        /// <returns></returns>
        public static List<ReporteFinanciero> getReporteByRut(string run)
        {
            AlumnoSv.AlumnoWsClient ws = null;
            RespuestaReporte response = null;
            List<ReporteFinanciero> list = null;

            response = new RespuestaReporte();
            ws = new AlumnoSv.AlumnoWsClient();

            response = ws.obtenerReporteAlumnoWs(run);

            if (response.status == "error")
            {
                throw new Exception(response.mensaje);
            }
            else
            {
                list = new List<ReporteFinanciero>();
                list = response.reporteList;
            }

            return list;
        }
    }
}
