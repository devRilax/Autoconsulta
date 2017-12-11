using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Totem.Util;
using Totem.VO;
using Totem.Services;
using System.Net.Mail;

namespace Totem.BLL
{
    public class UsuarioAlumnoBLL
    {
        private static UsuarioAlumnoBLL instance;
        public static UsuarioAlumnoBLL getInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UsuarioAlumnoBLL();
                }
                return instance;
            }
            set { instance = value; }
        }

        public bool validUser(UsuarioAlumno usuario)
        {
            validateLoginInput(usuario);
            return AlumnoService.validateUser(usuario);
        }

        private void validateLoginInput(UsuarioAlumno usuario)
        {
            if (usuario.run == "")
            {
                throw new Exception("Campo run es requerido");
            }

            if (usuario.clave == "")
            {
                throw new Exception("Campo clave es requerido");
            }

        }

        public bool cambiarClaveUsuario(UsuarioAlumno usuario, string claveConfirmacion)
        {
            validarCambioClave(usuario, claveConfirmacion);
            return AlumnoService.changeUserPassword(usuario);
        }

        public void enviarEmailInformativo(UsuarioAlumno usuario)
        {

            if (!UtilString.isValidMail(usuario.email))
            {
                throw new ValidacionException("La dirección de correo ingresada es inválida");
            }

            Email serverMail = null;
            MailMessage mailMsg = null;


            try
            {
                serverMail = new Email();
                mailMsg = new MailMessage();

                mailMsg.To.Add(new MailAddress(usuario.email));
                mailMsg.From = new MailAddress(Constantes.EMAIL_DEPTO_ADMINISTRACION);
                mailMsg.Subject = "Cambio de clave";
                mailMsg.Body = MensajeEmail.createBodyChangePassword(usuario.run, usuario.clave);
                mailMsg.IsBodyHtml = true;
                mailMsg.Priority = MailPriority.Normal;
                serverMail.sendEmailServer(mailMsg);
            }
            catch (Exception)
            {
                throw new Exception("Error al enviar correo");
            }
        }

        private void validarCambioClave(UsuarioAlumno usuario, string claveConfimacion)
        {

            if (usuario.email == "")
            {
                throw new Exception("Campo email es requerido");
            }

            if (usuario.clave == "")
            {
                throw new Exception("Campo clave es requerido");
            }

            if (!(usuario.clave == claveConfimacion))
            {
                throw new Exception("Las claves ingresadas no coinciden");
            }

        }
    }
}
