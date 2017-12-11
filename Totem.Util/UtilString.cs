using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace Totem.Util
{
    public class UtilString
    {
        public static bool isValidMail(string email)
        {
            bool isValid = false;
            string sFormato = "";

            if (email.Length == 0)
            {
                throw new ValidacionException("Debe ingresar una direccion de correo");
            }
            else
            {
                sFormato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
                if (Regex.IsMatch(email, sFormato))
                {
                    if (Regex.Replace(email, sFormato, String.Empty).Length == 0)
                    {
                        isValid = true;
                    }
                    else
                    {
                        isValid = false;
                    }
                }
                else
                {
                    isValid = false;
                }

                return isValid;
            }
        }
        public static string formatRun(string rut)
        {
            int cont = 0;
            string format;
            if (rut.Length == 0)
            {
                return "";
            }
            else
            {
                rut = rut.Replace(".", "");
                rut = rut.Replace("-", "");
                format = "-" + rut.Substring(rut.Length - 1);
                for (int i = rut.Length - 2; i >= 0; i--)
                {
                    format = rut.Substring(i, 1) + format;
                    cont++;
                    if (cont == 3 && i != 0)
                    {
                        format = "." + format;
                        cont = 0;
                    }
                }
                return format;
            }
        }

        public static string quitarFormatoRun(string rut)
        {
            string runConFormato = rut;
            string runSinFormato = runConFormato.Replace(".", "");
            runSinFormato = runSinFormato.Replace("-", "");
            return runSinFormato;
        }

        public static string getConnectionPath(FileUpload fileUp)
        {
            string path = "";
            string ruta = "";
            string strConn = "";

            try
            {

                //obtiene la ruta general
                path = System.Web.HttpContext.Current.Server.MapPath("~/");

                //guarda la ruta en el  fileUp
                fileUp.SaveAs(path + fileUp.FileName);

                //concatena la ruta obtenida como string
                ruta = path + fileUp.FileName;
            }
            catch (System.Web.HttpException)
            {
                throw new Exception("error al leer arhivo excel");
            }


            //lee la extension del archivo
            string fileName = System.IO.Path.GetExtension(fileUp.FileName);

            //valida que sea formato excel
            if (!(fileName == ".xlsx") || !(fileName == ".xls"))
            {
                throw new Exception("El archivo seleccionado no posee un formato valido");
            }

            return strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + ruta + ";Extended Properties=\"Excel 12.0 Xml;HDR=NO;\"";
        }

     
    }
}
