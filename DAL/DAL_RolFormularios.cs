using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_RolFormulario
    {
        public static RolFormularios Insert(RolFormularios Entidad)
        {
            using (BDCelWeb bd = new BDCelWeb())
            {
                Entidad.Activo = true;
                Entidad.FechaRegistro = DateTime.Now;
                bd.RolFormularios.Add(Entidad);
                bd.SaveChanges();
                return Entidad;
            }
        }
        public static bool Update(RolFormularios Entidad)
        {
            using (BDCelWeb bd = new BDCelWeb())
            {
                var RegistroBD = bd.RolFormularios.Find(Entidad.IdRolFormulario);
                RegistroBD.IdRol = Entidad.IdRol;
                RegistroBD.IdFormulario = Entidad.IdFormulario;
                RegistroBD.IdUsuarioActualizado = Entidad.IdUsuarioActualizado;
                RegistroBD.FechaActualizado = DateTime.Now;
                return bd.SaveChanges() > 0;
            }
        }
        public static bool Delete(RolFormularios Entidad)
        {
            using (BDCelWeb bd = new BDCelWeb())
            {
                var RegistroBD = bd.RolFormularios.Find(Entidad.IdRolFormulario);
                RegistroBD.Activo = false;
                RegistroBD.IdUsuarioActualizado = Entidad.IdUsuarioActualizado;
                RegistroBD.FechaActualizado = DateTime.Now;
                return bd.SaveChanges() > 0;
            }
        }
        public static List<RolFormularios> List(int IdRol, bool Activo = true)
        {
            using (BDCelWeb bd = new BDCelWeb())
            {
                return bd.RolFormularios.Where(a => a.IdRol == IdRol && a.Activo == Activo).ToList();
            }
        }
        public static RolFormularios Registro(int IdRegistro)
        {
            using (BDCelWeb bd = new BDCelWeb())
            {
                return bd.RolFormularios.Find(IdRegistro);
            }
        }

    }
}
