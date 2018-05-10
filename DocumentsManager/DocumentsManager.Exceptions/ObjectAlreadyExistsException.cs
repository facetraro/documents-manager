﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsManager.Exceptions
{
    public class ObjectAlreadyExistsException:Exception
    {
        private static string message1 = "No se pudo registrar. Ese ";
        private static string message2 = " ya está registrado ";
        public ObjectAlreadyExistsException(string typeError) : base(message1 + typeError + message2)
        {
        }
    }
}