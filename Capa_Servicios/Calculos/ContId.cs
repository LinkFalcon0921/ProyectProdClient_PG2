using System;
using Capa_Datos;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Servicios.Calculos
{
    public class ContId
    {
        private static ContId cont;

        private ContId()
        {
            
        }

        public static ContId obtenerCont()
        {
            if(cont == null) { cont = new ContId(); }

            return cont;
        }

        public int GetIdClient()
        {
            int r = 1;
            using (BASEDBEntities DB = new BASEDBEntities())
            {
                foreach (var h in DB.cliente)
                {
                    if (h.id_cliente != r++)
                    {
                        return r;
                    }
                }
            }
            return r;
        }

        public int GetIdAdmin()
        {
            int r = 1;
            using (BASEDBEntities DB = new BASEDBEntities())
            {
                foreach (var h in DB.Admins)
                {
                    if (h.id_admin != r++)
                    {
                        return r;
                    }
                    
                }
            }
            return r;
        }

        public int GetIdProduct()
        {
            int r = 1;
            using (BASEDBEntities DB = new BASEDBEntities())
            {
                foreach (var h in DB.product)
                {
                    if (h.id_prod != r++)
                    {
                        return r;
                    }
                }
            }
            return r;
        }



    }
}
