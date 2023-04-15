using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class Enum
    {
        public enum eMessage
        {
            Exito = 1,
            Alerta = 2,
            Error = 3,
            Info = 4
        }

        public enum eFormulario
        {
            AdministracionUsuarios = 1,
            Clientes = 2,
            Factura = 3,
            Envios = 4
        }
        public enum eRoles
        {
            AdministradorGeneral = 1,
            AdministradorCelulares = 2,
            AdministradorEnvios = 3,
            AdministradorFacturas = 4,
           
        }
        public enum ePermisos
        {
            Escritura = 1,
            Anular = 2,
            Bloqueo = 4
        }
    }
}
