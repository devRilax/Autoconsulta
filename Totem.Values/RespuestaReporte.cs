using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Totem.Values
{
    public class RespuestaReporte
    {
        public string status { get; set; }
        public string mensaje { get; set; }
        public List<ReporteFinanciero> reporteList { get; set; }

        public RespuestaReporte()
        {
            reporteList = new List<ReporteFinanciero>();
        }
    }
}
