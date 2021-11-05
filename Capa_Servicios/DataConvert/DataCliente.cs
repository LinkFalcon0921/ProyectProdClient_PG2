using Capa_Datos;
using Capa_Servicios.CreateV;
using Capa_Servicios.Calculos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Servicios.DataConvert
{
    public class DataCliente
    {

            private static DataCliente boss;

            private DataCliente()
            {
                
            }

            public static DataCliente ObtenerBoss()
            {
                if (boss == null) { boss = new DataCliente(); }

                return boss;
            }

            public ClienteV ObtenerCliente(int id)
            {
                var prov = new ClienteV();

                try
                {
                    using (BASEDBEntities DB = new BASEDBEntities())
                    {
                        var oClient = DB.cliente.Find(id);

                        prov.Nombre = oClient.nombre;
                        prov.RNC = oClient.rnc;
                        prov.Tel = oClient.telefono;
                        prov.Mail = oClient.mail;
                        prov.Id = oClient.id_cliente;
                        prov.types = new TypeV(oClient.id_type);

                    }
                    return prov;
                }
                catch
                {
                    return null;
                }
            }

            public List<ClienteV> ObtenerClientes()
            {
                List<ClienteV> list = new List<ClienteV>();

                using (BASEDBEntities DB = new BASEDBEntities())
                {
                    foreach (var h in DB.cliente)
                    {
                        var ad = new ClienteV()
                        {
                            Id = h.id_cliente,
                            RNC = h.rnc,
                            Nombre = h.nombre,
                            Tel = h.telefono,
                            Mail = h.mail,
                            types = new TypeV(h.id_type)
                        };

                        list.Add(ad);
                    }
                }
                return list;
            }

            public bool ExistCliente(int id)
            {
                using (BASEDBEntities DB = new BASEDBEntities())
                {
                    if (DB.cliente.Find(id) != null)
                    {
                        return true;
                    }
                }

                return !true;//False
            }



            public bool EditarCliente(ClienteV ad,string c)
            {
                try
                {
                    using (BASEDBEntities DB = new BASEDBEntities())
                    {
                        var prov = DB.cliente.Find(ad.Id);

                        prov.nombre = ad.Nombre;
                        prov.telefono = ad.Tel;
                        prov.mail = ad.Mail;
                        prov.id_cliente = ad.Id;
                        prov.id_type = (c.Equals("Premium")) ? 2 : 1;
                        

                        DB.Entry(prov).State = System.Data.Entity.EntityState.Modified;
                        DB.SaveChanges();

                        return true;

                    }
                }
                catch(Exception)
                {
                    return false;
                }
            }

            public ClienteV EditarCliente(int id)
            {
                ClienteV person = null;

                using (BASEDBEntities DB = new BASEDBEntities())
                {
                    foreach (var h in DB.cliente)
                    {
                        if (ExistCliente(h.id_cliente))
                        {
                            person = new ClienteV()
                            {
                                Id = h.id_cliente,
                                Nombre = h.nombre,
                                Tel = h.telefono,
                                Mail = h.mail,
                                types = new TypeV(h.id_cliente)
                            };

                            return person;
                        }
                    }
                }

                return person;
            }

            public bool GuardarCliente(ClienteV ad,string cliente)
            {
                try
                {
                    using (BASEDBEntities DB = new BASEDBEntities())
                    {
                        var pers = new cliente();

                        pers.id_cliente = ContId.obtenerCont().GetIdClient();
                        pers.rnc = ad.RNC;
                        pers.nombre = ad.Nombre + ((string.IsNullOrEmpty(ad.Apellido)) ? string.Empty : " " + ad.Apellido);
                        pers.telefono = ad.Tel;
                        pers.mail = ad.Mail;
                        pers.id_type = (cliente.Equals("Premium")) ? 2 : 1;

                        DB.cliente.Add(pers);
                        DB.SaveChanges();
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            public bool RemoverCliente(int id)
            {
                try
                {
                    using (BASEDBEntities DB = new BASEDBEntities())
                    {
                        DB.cliente.Remove(DB.cliente.Find(id));
                        DB.SaveChanges();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }

            }
        }
}
