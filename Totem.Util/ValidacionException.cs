using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Totem.Util
{
    public class ValidacionException : Exception
    {
        public ValidacionException(string msg)
            : base(msg)
        {

        }
    }
}
