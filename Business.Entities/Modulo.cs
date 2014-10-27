using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class Modulo: BusinessEntity
    {
        private string _Descripcion;
        private string _Ejecuta;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        public string Ejecuta
        {
            get { return _Ejecuta; }
            set { _Ejecuta = value; } 
        }
    }
}
