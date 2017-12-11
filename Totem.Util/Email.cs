using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;


namespace Totem.Util
{
    public class Email
    {

        /// <summary>
        /// Desarrollado por @Danilo Caro Aparicio, 
        /// Año: 2017
        /// Email: danilocaro21@gmail.com
        /// </summary>
        ///



        //Configuración smtp
        SmtpClient server = new SmtpClient("smtp.gmail.com", 587);

		
        public Email()
        {
			//Credenciales de la cuenta que enviará los correos
            server.Credentials = new System.Net.NetworkCredential("pruebaregistro016@gmail.com", "pruebacorreos");
            server.EnableSsl = true;
        }

        public void sendEmailServer(MailMessage msg)
        {
            try
            {
                server.Send(msg);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
