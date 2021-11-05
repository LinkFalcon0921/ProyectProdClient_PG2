using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using Capa_Servicios.Calculos;
using Capa_Servicios.CreateV;

namespace Capa_Servicios.DataConvert
{
    public class DataAdmins
    {
        private static DataAdmins boss;

        private DataAdmins()
        {
           
        }

        public static DataAdmins ObtenerBoss()
        {
            if(boss== null) { boss = new DataAdmins(); }

            return boss;
        }

        public AdminsC ObtenerAdmin(int id)
        {
            AdminsC prov = new AdminsC();

            try {
                using (BASEDBEntities DB = new BASEDBEntities())
                {
                    var oAdmin = DB.Admins.Find(id);

                    prov.Nombre = oAdmin.nombre;
                    prov.RNC = oAdmin.rnc;
                    prov.Tel = oAdmin.telefono;
                    prov.Mail = oAdmin.mail;
                    prov.Id = oAdmin.id_admin;

                }

                return prov;
            }
            catch
            {
                return null;
            }
        }

        public int ObtenerIdAdmin(string nom)
        {
            AdminsC prov = new AdminsC();

            try
            {
                using (BASEDBEntities DB = new BASEDBEntities())
                {
                    foreach (var t in DB.Admins)
                    {
                        if(t.nombre.Equals(nom))
                        {
                            return t.id_admin;
                        }
                    }
                    return 0;
                }
            }
            catch
            {
                return 0;
            }
        }

        public List<AdminsC> ObtenerAdmins()
        {
            List<AdminsC> list = new List<AdminsC>();

            using (BASEDBEntities DB = new BASEDBEntities())
            {
                foreach(var h in DB.Admins)
                {
                    var ad = new AdminsC()
                    {
                        Id = h.id_admin,
                        RNC = h.rnc,
                        Nombre = h.nombre,
                        Tel = h.telefono,
                        Mail = h.mail
                    };
                    list.Add(ad);
                }
            }

            return list;
        }

        public bool ExistAdmin(int id)
        {
            using (BASEDBEntities DB = new BASEDBEntities())
            {
                if(DB.Admins.Find(id)!= null)
                {
                    return true;
                }
            }

            return !true;//False
        }



        public bool EditarAdmin(AdminsC ad)
        {
            try
            {
                using (BASEDBEntities DB = new BASEDBEntities())
                {
                    var prov = DB.Admins.Find(ad.Id);

                    prov.nombre = ad.Nombre;
                    prov.telefono = ad.Tel;
                    prov.mail = ad.Mail;
                    prov.id_admin = ad.Id;

                    DB.Entry(prov).State = System.Data.Entity.EntityState.Modified;
                    DB.SaveChanges();

                    return true;

                }
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                return false;
            }
            }

        public AdminsC EditarAdmin(int id)
        {
            AdminsC person = null;

            using(BASEDBEntities DB = new BASEDBEntities())
            {
                foreach (var h in DB.Admins)
                {
                    if(h.id_admin == id)
                    {
                        person = new AdminsC()
                        {
                            Id = h.id_admin,
                            Nombre = h.nombre,
                            Tel = h.telefono,
                            Mail = h.mail
                        };

                        return person;
                    }
                }
            }

            return person;  
        }

            public bool GuardarAdmin(AdminsC ad)
        {
            try
            {
                    using (BASEDBEntities DB = new  BASEDBEntities())
                    {
                        var pers = new Admins();

                        pers.id_admin = ContId.obtenerCont().GetIdAdmin();
                        pers.rnc = ad.RNC;
                    pers.nombre = ad.Nombre;
                        pers.telefono = ad.Tel;
                        pers.mail = ad.Mail;

                        DB.Admins.Add(pers);
                        DB.SaveChanges();
                    }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool RemoverAdmin(int id)
        {
            try
            {
                using (BASEDBEntities DB = new BASEDBEntities())
                {
                    DB.Admins.Remove(DB.Admins.Find(id));
                    DB.SaveChanges();
                    return true;
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            }

    }
}
