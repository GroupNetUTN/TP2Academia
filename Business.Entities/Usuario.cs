using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class Usuario : BusinessEntity
    {
        private string _NombreUsuario;
        private string _Clave;
        private bool _Habilitado;
        private int _IDPersona;

        public string NombreUsuario
        {
            get { return _NombreUsuario; }
            set { _NombreUsuario = value; }
        }
        public string Clave
        {
            get { return _Clave; }
            set { _Clave = value; }
        }

        public bool Habilitado
        {
            get { return _Habilitado; }
            set { _Habilitado = value; }
        }

        public int IDPersona
        {
            get { return _IDPersona; }
            set { _IDPersona = value; }
        }
    }
}
