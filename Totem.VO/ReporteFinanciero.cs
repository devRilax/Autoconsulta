using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Totem.VO
{
    public class ReporteFinanciero
    {
        public UsuarioAlumno alumno { get; set; }
        public double montoCuota { get; set; }
        public DateTime fechaDocumento { get; set; }
        public DateTime fechaVencimiento { get; set; }

        public int nroCuota { get; set; }
        public double montoInteres { get; set; }
        public double gastoCobranza { get; set; }
        public double totalCuota { get; set; }

        public string glosaCuota { get; set; }


        public ReporteFinanciero()
        {
            alumno = new UsuarioAlumno();
        }
    }
}
