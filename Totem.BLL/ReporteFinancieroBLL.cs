using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Totem.Util;
using Totem.VO;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Net.Mail;
using System.Text.RegularExpressions;
using Totem.Services;

namespace Totem.BLL
{
    public class ReporteFinancieroBLL
    {


        private static ReporteFinancieroBLL instance;
        public static ReporteFinancieroBLL getInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ReporteFinancieroBLL();
                }
                return instance;
            }
            set { instance = value; }
        }

        private ReporteFinancieroBLL()
        {
        }


        /// <summary>
        /// Obtiene un listado de deudas a través de la capa de servicios
        /// según el run ingresado
        /// </summary>
        /// <param name="run"></param>
        /// <returns></returns>
        public List<ReporteFinanciero> getReporteByRut(string run)
        {
            List<ReporteFinanciero> list = AlumnoService.getReporteByRut(UtilString.quitarFormatoRun(run));

            if (list.Count() == 0 || list == null)
            {
                throw new ValidacionException("No se encontraron registros");
            }

            return list;
        }


        /// <summary>
        /// Prepara el envio de reporte a un email que ingresa un usuario en específico
        /// el reporte se va a buscar a la base de datos con el rut.
        /// En caso de una actualización de este sistema, sería ideal usar los mismos datos del gridview y así
        /// no ir a consultar a la base de datos
        /// </summary>
        /// <param name="email"></param>
        /// <param name="run"></param>
        public void processEmail(string email, string run)
        {
            if (!isValidMail(email))
            {
                throw new ValidacionException("El formato del correo es inválido");
            }

            string strRun = UtilString.quitarFormatoRun(run);

            //Obtiene el reporte, crea un reporte en memoria y lo adjunta al email
            List<ReporteFinanciero> list = ReporteFinancieroBLL.getInstance.getReporteByRut(strRun);
            MemoryStream reportePdf = createPdfReport(list);
            sendMail(reportePdf, email);
        }

        private void sendMail(MemoryStream reportePdf, string strEmail)
        {

            Email serverMail = null;
            MailMessage mailMessage = null;
            DateTime fechaArchivo = DateTime.Now;

            try
            {
                serverMail = new Email();
                mailMessage = new MailMessage();

                mailMessage.To.Add(new MailAddress(strEmail));
                mailMessage.From = new MailAddress(Constantes.EMAIL_DEPTO_ADMINISTRACION);
                mailMessage.Subject = "Reporte de Autoconsulta Financiera Duoc UC";
                mailMessage.Body = ("Estimado Alumno/a, le recordamos que esta información es solamente de carácter referencial, para más información debe acercarse al centro de pago de la institución");
                mailMessage.IsBodyHtml = true;
                mailMessage.Priority = MailPriority.Normal;
                mailMessage.Attachments.Add(new Attachment(reportePdf, "Reporte_" + fechaArchivo.ToString("dd/MM/yyyy") + ".pdf"));
                serverMail.sendEmailServer(mailMessage);
            }
            catch (Exception)
            {
                throw new ValidacionException("Error al enviar correo");
            }

        }


        /// <summary>
        /// Crea un reporte en formato pdf, agregando el contenido que trae el listado
        /// </summary>
        /// <param name="list"></param>
        /// <returns>Devuelve un memory stream para adjuntarlo a un correo</returns>
        public MemoryStream createPdfReport(List<ReporteFinanciero> list)
        {

            MemoryStream memoryStream = new MemoryStream();
            Document doc = new Document(PageSize.LETTER);
            PdfWriter writer = PdfWriter.GetInstance(doc, memoryStream);

            BaseFont bf = BaseFont.CreateFont(
                                  BaseFont.COURIER,
                                  BaseFont.CP1252,
                                  BaseFont.EMBEDDED);

            Font titleFont = new Font(bf, 16);
            Font columnFont = new Font(bf, 15);
            Font cellFont = new Font(bf, 14);



            //Titulo y autor
            doc.AddTitle("Reporte Financiero");
            doc.AddCreator("Duoc");
            doc.Open();

            // Fuente
            iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            //iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("agregar ruta de imagen");
            //img.BorderWidth = 0;
            //img.Alignment = Element.ALIGN_TOP;
            //float pr = 0.0f;
            //pr = 150 / img.Width;
            //img.ScalePercent(pr * 100);

            //Encabezado
            //doc.Add(img);
            doc.Add(new Paragraph("Departamento de administración Duoc UC, Padre Alonso de Ovalle", titleFont));
            doc.Add(Chunk.NEWLINE);

            // Crea una tabla con la cantidad de columnas
            PdfPTable tblPrueba = new PdfPTable(6);
            tblPrueba.WidthPercentage = 100;

            // Título de las columnas
            PdfPCell clGlosa = new PdfPCell(new Phrase("Glosa", columnFont));
            clGlosa.BorderWidth = 0;
            clGlosa.BorderWidthBottom = 0.75f;

            PdfPCell clNumCuota = new PdfPCell(new Phrase("Nro Cuota", columnFont));
            clNumCuota.BorderWidth = 0;
            clNumCuota.BorderWidthBottom = 0.75f;

            PdfPCell clMonto = new PdfPCell(new Phrase("Monto", columnFont));
            clMonto.BorderWidth = 0;
            clMonto.BorderWidthBottom = 0.75f;

            PdfPCell clInteres = new PdfPCell(new Phrase("Interes", columnFont));
            clInteres.BorderWidth = 0;
            clInteres.BorderWidthBottom = 0.75f;

            PdfPCell clgCobranza = new PdfPCell(new Phrase("Gasto cobranza", columnFont));
            clgCobranza.BorderWidth = 0;
            clgCobranza.BorderWidthBottom = 0.75f;

            PdfPCell clTotal = new PdfPCell(new Phrase("Gasto cobranza", columnFont));
            clTotal.BorderWidth = 0;
            clTotal.BorderWidthBottom = 0.75f;

            // Añade las columnas
            tblPrueba.AddCell(clGlosa);
            tblPrueba.AddCell(clNumCuota);
            tblPrueba.AddCell(clMonto);
            tblPrueba.AddCell(clInteres);
            tblPrueba.AddCell(clgCobranza);
            tblPrueba.AddCell(clTotal);

            // Almacena el pago total de la deuda
            double totalPago = 0;
            Font celLFont = new Font(bf, 14);



            //Carga la tabla con los valores
            foreach (ReporteFinanciero item in list)
            {
                clGlosa = new PdfPCell(new Phrase(item.glosaCuota, celLFont));
                clGlosa.BorderWidth = 0;

                clNumCuota = new PdfPCell(new Phrase(item.nroCuota.ToString(), celLFont));
                clNumCuota.BorderWidth = 0;
                clNumCuota.VerticalAlignment = Element.ALIGN_CENTER;


                clMonto = new PdfPCell(new Phrase(item.montoCuota.ToString("N0"), celLFont));
                clMonto.BorderWidth = 0;

                clInteres = new PdfPCell(new Phrase(item.montoInteres.ToString("N0"), celLFont));
                clInteres.BorderWidth = 0;

                clgCobranza = new PdfPCell(new Phrase(item.gastoCobranza.ToString("N0"), celLFont));
                clgCobranza.BorderWidth = 0;

                clTotal = new PdfPCell(new Phrase(item.totalCuota.ToString("N0"), celLFont));
                clTotal.BorderWidth = 0;

                // Añade el contenido
                tblPrueba.AddCell(clGlosa);
                tblPrueba.AddCell(clNumCuota);
                tblPrueba.AddCell(clMonto);
                tblPrueba.AddCell(clInteres);
                tblPrueba.AddCell(clgCobranza);
                tblPrueba.AddCell(clTotal);


                if (item.glosaCuota == "Vencida")
                {
                    totalPago += item.totalCuota;
                }

            }

            //agrega el contenido
            doc.Add(tblPrueba);

            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("Total a pagar: $" + totalPago.ToString("N0")));
            doc.Add(Chunk.NEWLINE);

            writer.CloseStream = false;
            doc.Close();

            memoryStream.Position = 0;

            return memoryStream;
        }

        private bool isValidMail(string email)
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
    }
}
