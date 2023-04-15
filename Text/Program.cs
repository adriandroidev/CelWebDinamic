using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL;
using BL;

namespace Text
{
    internal class Program
    {
        static void Main(string[] args)


        {

            RolPermisos RolPerm = new RolPermisos();
            RolPerm.IdRol = 1;
            RolPerm.IdPermiso = 4;
            RolPerm.IdUsuarioRegistro = 1;


            Console.WriteLine(BL_RolPermisos.Insert(RolPerm).IdRolPermiso);

        }
    }
}
