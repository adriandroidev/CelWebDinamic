
//INSERTAR
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL;
using BL;
using System.Globalization;

namespace Text
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Roles roles = new Roles();



            roles.Rol = "Administrador Facturas";
            roles.IdUsuarioRegistro = 1;

            Console.WriteLine(BL_Roles.InsertRoles(roles).IdRol);
            Console.ReadLine();
        }

    }
}

