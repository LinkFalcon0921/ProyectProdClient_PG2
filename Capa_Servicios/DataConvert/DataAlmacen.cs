using Capa_Servicios.CreateV;
using Capa_Servicios.Calculos;
using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Servicios.DataConvert
{
    public class DataAlmacen
    {
        private static DataAlmacen boss;

         private DataAlmacen()
        {

        }

        public static DataAlmacen ObtenerBoss()
        {
            if(boss == null) { boss = new DataAlmacen(); }

            return boss;
        }

        public bool GuardarAlmacen(AlmacenV alm,string nameAd)
        {
            try {
                using (BASEDBEntities DB = new BASEDBEntities())
                {
                    var g = new product();

                    g.id_prod = ContId.obtenerCont().GetIdProduct();
                    g.nombre = alm.Nombre;
                    g.precio = alm.Precio;
                    g.id_admin = DataAdmins.ObtenerBoss().ObtenerIdAdmin(nameAd);

                    DB.product.Add(g);
                    DB.SaveChanges();

                }
                return true;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            
        }

        public bool EditarAlmacen(AlmacenV alm)
        {

            try
            {
                using (BASEDBEntities DB = new BASEDBEntities())
                {
                    var g = DB.product.Find(alm.Id);

                    g.nombre = alm.Nombre;
                    g.precio = alm.Precio;

                    DB.Entry(g).State = System.Data.Entity.EntityState.Modified;
                    DB.SaveChanges();
                }
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            }

        public AlmacenV EditarAlmacen(int id)
        {

            try
            {
                var alm = new AlmacenV();

                using (BASEDBEntities DB = new BASEDBEntities())
                {
                    var g = DB.product.Find(id);

                    alm.Id = g.id_prod;
                    alm.Nombre = g.nombre;
                    alm.Precio = ((float)g.precio);
                    alm.admins = DataAdmins.ObtenerBoss().ObtenerAdmin(g.id_admin);
                }
                return alm;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

            public List<AlmacenV> ObtenerAlmacen()
        {
            try
            {
                using(BASEDBEntities DB = new BASEDBEntities())
                {
                    List<AlmacenV> list = (from t in DB.product
                                           select new AlmacenV() {
                                               Id = t.id_prod,
                                               admins = DataAdmins.ObtenerBoss().ObtenerAdmin(t.id_admin),
                                               Precio = ((float)t.precio)
                                           }
                                           ).ToList();
                    return list;
                }
            }
            catch
            {
                return null;
            }
        }

        public bool deleteAlmacen(int id)
        {

            try
            {
                using(BASEDBEntities DB = new BASEDBEntities())
                {
                    DB.product.Remove(DB.product.Find(id));
                }

                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
