using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Totem.Util
{
    public class UtilNumero
    {
        public static double parseDouble(string value)
        {
            double intValue = 0;
            double intAux = 0;

            if (double.TryParse(value, out intAux))
                intValue = intAux;

            return intValue;
        }

        public static int parseInt(string value)
        {
            int intValue = 0;
            int intAux = 0;

            if (int.TryParse(value, out intAux))
                intValue = intAux;

            return intValue;
        }
    }
}
