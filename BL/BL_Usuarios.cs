﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BL
{
    public static class BL_Usuarios
    {
        public static bool ExisteUserName(string UserName)
        {
            return DAL_Usuarios.ExisteUserName(UserName);
        }


    }
}