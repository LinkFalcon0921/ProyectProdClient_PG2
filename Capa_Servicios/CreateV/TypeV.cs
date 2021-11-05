using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Servicios.CreateV
{
    public class TypeV
    {
        public TypeV(int n)
        {
            Nombre = ((n == 2) ? "Premium" : "Basic");
        }
        public string Nombre {
            set;get;
        }


    }
}
