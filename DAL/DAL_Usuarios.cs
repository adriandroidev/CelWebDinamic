using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilidades;

namespace DAL
{
    public static class DAL_Usuarios
    {
        private static byte[] Key = Encoding.UTF8.GetBytes("S3Gur1d4d1nf0rm4t1c42o23");//24 Caracteres
        private static byte[] IV = Encoding.UTF8.GetBytes("Pr0y3ct03J3mpl00");//16 Caracteres
        public static Usuarios Insert(Usuarios Entidad)
        {
            using (BDCelWeb bd = new BDCelWeb())
            {
                Entidad.Activo = true;
                Entidad.FechaRegistro = DateTime.Now;
                bd.Usuarios.Add(Entidad);
                bd.SaveChanges();
                return Entidad;
            }
        }
        public static bool Update(Usuarios Entidad)
        {
            using (BDCelWeb bd = new BDCelWeb())
            {
                var RegistroBD = bd.Usuarios.Find(Entidad.IdUsuario);
                RegistroBD.NombreCompleto = Entidad.NombreCompleto;
                RegistroBD.Correo = Entidad.Correo;
                RegistroBD.UserName = Entidad.UserName;
                if (Entidad.Password != null)
                {
                    RegistroBD.Password = Entidad.Password;
                }
                RegistroBD.IdRol = Entidad.IdRol;
                RegistroBD.IdUsuarioActualizado = Entidad.IdUsuarioActualizado;
                RegistroBD.FechaActualizado = DateTime.Now;
                return bd.SaveChanges() > 0;
            }
        }
        public static bool PasswordUpdate(Usuarios Entidad)
        {
            using (BDCelWeb bd = new BDCelWeb())
            {
                var Consulta = bd.Usuarios.Find(Entidad.IdUsuario);
                Consulta.Password = Entidad.Password;
                Consulta.IdUsuarioActualizado = Entidad.IdUsuarioActualizado;
                Consulta.FechaActualizado = DateTime.Now;
                return bd.SaveChanges() > 0;
            }
        }
        public static bool Delete(Usuarios Entidad)
        {
            using (BDCelWeb bd = new BDCelWeb())
            {
                var RegistroBD = bd.Usuarios.Find(Entidad.IdUsuario);
                RegistroBD.Activo = false;
                RegistroBD.IdUsuarioActualizado = Entidad.IdUsuarioActualizado;
                RegistroBD.FechaActualizado = DateTime.Now;
                return bd.SaveChanges() > 0;
            }
        }
        public static List<Usuarios> List(bool Activo = true)
        {
            using (BDCelWeb bd = new BDCelWeb())
            {
                return bd.Usuarios.Where(a => a.Activo == Activo).ToList();
            }
        }
        public static Usuarios Registro(int IdRegistro)
        {
            using (BDCelWeb bd = new BDCelWeb())
            {
                return bd.Usuarios.Find(IdRegistro);
            }
        }
        public static List<Usuarios> Buscar(string Palabra)
        {
            using (BDCelWeb bd = new BDCelWeb())
            {
                return bd.Usuarios.
                      Where(a => a.NombreCompleto.Contains(Palabra)
                              || a.Correo.Contains(Palabra)
                              || a.UserName.Contains(Palabra)
                      ).ToList();
            }
        }
        public static Usuarios ExisteCorreo(string Email)
        {
            using (BDCelWeb bd = new BDCelWeb())
            {
                return bd.Usuarios.Where(a => a.Correo.ToLower() == Email.ToLower()).SingleOrDefault();
            }
        }
        public static bool SumarIntentosFallido(int IdRegistro)
        {
            using (BDCelWeb bd = new BDCelWeb())
            {
                var Registro = bd.Usuarios.Find(IdRegistro);
                Registro.IntentosFallidos = Convert.ToInt16(Registro.IntentosFallidos + 1);
                return bd.SaveChanges() > 0;
            }
        }
        public static bool RestablecerIntentosFallido(int IdRegistro, int IdUsuarioActualizado)
        {
            using (BDCelWeb bd = new BDCelWeb())
            {
                var Registro = bd.Usuarios.Find(IdRegistro);
                Registro.IntentosFallidos = 0;
                Registro.IdUsuarioActualizado = IdUsuarioActualizado;
                Registro.FechaActualizado = DateTime.Now;
                return bd.SaveChanges() > 0;
            }
        }
        public static bool BloquearCuentaUsuario(int IdRegistro, bool Bloquear, int IdUsuarioActualizado)
        {
            using (BDCelWeb bd = new BDCelWeb())
            {
                var Registro = bd.Usuarios.Find(IdRegistro);
                Registro.Bloqueado = Bloquear;
                if (!Bloquear) { Registro.IntentosFallidos = 0; }
                Registro.IdUsuarioActualizado = IdUsuarioActualizado;
                Registro.FechaActualizado = DateTime.Now;
                return bd.SaveChanges() > 0;
            }
        }
        public static bool ExisteUserName(string UserName)
        {
            using (BDCelWeb bd = new BDCelWeb())
            {
                return bd.Usuarios.Where(a => a.UserName.ToLower() == UserName.ToLower()).Count() > 0;
            }
        }
        public static Usuarios ExisteUsuario_x_UserName(string UserName)
        {
            using (BDCelWeb bd = new BDCelWeb())
            {
                return bd.Usuarios.Where(a => a.UserName.ToLower() == UserName.ToLower()).SingleOrDefault();
            }
        }
        public static bool ValidarCredenciales(string UserName, byte[] Password)
        {
            using (BDCelWeb bd = new BDCelWeb())
            {
                return bd.Usuarios.Where(a => a.UserName.ToLower() == UserName.ToLower() && a.Password == Password).Count() > 0;
            }
        }
        public static byte[] Encrypt(string FlatString)
        {
            return Encripty.Encrypt(FlatString, Key, IV);
        }

        public static bool VerificarCuentaBloqueada(string UserName)
        {
            using (BDCelWeb bd = new BDCelWeb())
            {
                return bd.Usuarios.
                Where(a => a.UserName.ToLower() == UserName.ToLower() 
                && a.Bloqueado).Count() > 0;
            }
        }

        public static short CantidadIntentosFallidos(string UserName)
        {
            using (BDCelWeb bd = new BDCelWeb())
            {
                return bd.Usuarios.Where(a => a.UserName.ToLower() == UserName.ToLower()).SingleOrDefault().IntentosFallidos;
            }
        }

    }
}
