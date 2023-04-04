using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using EL;

namespace DAL
{
    public static class DAL_Roles
    {
        //Insertar forma 1
        public static Roles InsertRoles(Roles Entidad)
        {
            using (BDCelWeb bd = new BDCelWeb())
            {
                Entidad.Activo = true;
                Entidad.FechaRegistro = DateTime.Now;
                bd.Roles.Add(Entidad);
                bd.SaveChanges();
                return Entidad;
            }
        }

        //Insertar forma 2
        public static Roles InsertarRoles(Roles Entidad)
        {
            using (BDCelWeb bd = new BDCelWeb())
            {
                Roles Registro_a_Guardar = new Roles();

                Registro_a_Guardar.Rol = Entidad.Rol;
                Registro_a_Guardar.IdUsuarioRegistro = Entidad.IdUsuarioRegistro;
                Registro_a_Guardar.Activo = true;
                Registro_a_Guardar.FechaRegistro = DateTime.Now;

                bd.Roles.Add(Registro_a_Guardar);
                bd.SaveChanges();
                return Registro_a_Guardar;

            }
        }

        //Update forma 1
        public static bool Update(Roles Entidad)
        {
            using (BDCelWeb bd = new BDCelWeb())
            {
                var RegistroBD = bd.Roles.Find(Entidad.IdRol);
                RegistroBD.Rol = Entidad.Rol;
                RegistroBD.IdUsuarioActualizado = Entidad.IdUsuarioActualizado;
                RegistroBD.FechaActualizado = DateTime.Now;
                return bd.SaveChanges() > 0;
            }
        }

        //update forma 2
        public static bool Actualizar(Roles Entidad)
        {
            using (BDCelWeb bd = new BDCelWeb())
            {
                var RegistroBD = (from tabla in bd.Roles where tabla.IdRol == Entidad.IdRol select tabla).SingleOrDefault();

                if (RegistroBD != null)
                {
                    RegistroBD.Rol = Entidad.Rol;
                    RegistroBD.IdUsuarioActualizado = Entidad.IdUsuarioActualizado;
                    RegistroBD.FechaActualizado = DateTime.Now;
                    return bd.SaveChanges() > 0;
                }
                return false;
            }
        }

        //Delete forma 1
        public static bool Delete(Roles Entidad)
        {
            using (BDCelWeb bd = new BDCelWeb())
            {
                var RegistroBD = bd.Roles.Find(Entidad.IdRol);
                RegistroBD.Activo = false;
                RegistroBD.IdUsuarioActualizado = Entidad.IdUsuarioActualizado;
                RegistroBD.FechaActualizado = DateTime.Now;
                return bd.SaveChanges() > 0;
            }
        }

        //Delete forma 1
        public static bool Eliminar(Roles Entidad)
        {
            using (BDCelWeb bd = new BDCelWeb())
            {
                var RegistroBD = (from tabla in bd.Roles where tabla.IdRol == Entidad.IdRol select tabla).SingleOrDefault();

                if (RegistroBD != null)
                {
                    RegistroBD.Activo = false;
                    RegistroBD.IdUsuarioActualizado = Entidad.IdUsuarioActualizado;
                    RegistroBD.FechaActualizado = DateTime.Now;
                    return bd.SaveChanges() > 0;
                }
                return false;
            }
        }

        //Select Todos los Registros
        public static List<Roles> List(bool Activo = true)
        {
            using (BDCelWeb bd = new BDCelWeb())
            {
                return bd.Roles.Where(a => a.Activo == Activo).ToList();
            }
        }
        public static List<Roles> Lista(bool Activo = true)
        {
            using (BDCelWeb bd = new BDCelWeb())
            {
                return (from tabla in bd.Roles where tabla.Activo == Activo select tabla).ToList();
            }
        }

        //Select Un Registro
        public static Roles Registro_(int IdRegistro)
        {
            using (BDCelWeb bd = new BDCelWeb())
            {
                return bd.Roles.Where(a => a.IdRol == IdRegistro).SingleOrDefault();
            }
        }
        public static Roles Registro__(int IdRegistro)
        {
            using (BDCelWeb bd = new BDCelWeb())
            {
                return bd.Roles.Find(IdRegistro);
            }
        }
        public static Roles Registro___(int IdRegistro)
        {
            using (BDCelWeb bd = new BDCelWeb())
            {
                return (from tabla in bd.Roles where tabla.IdRol == IdRegistro select tabla).SingleOrDefault();
            }
        }


        //Select Dinamico
        public static List<Roles> Buscar(string Palabra)
        {
            using (BDCelWeb bd = new BDCelWeb())
            {
                return bd.Roles.Where(a => a.Rol.Contains(Palabra)).ToList();
            }
        }

        public static List<Roles> Buscar_(string Palabra)
        {
            using (BDCelWeb bd = new BDCelWeb())
            {
                return (from tabla in bd.Roles
                        where tabla.Rol.Contains(Palabra)
                        select tabla).ToList();
            }
        }




    }
}
