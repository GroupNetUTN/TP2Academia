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
        private Persona _Persona;
        private List<ModuloUsuario> _ModulosUsuarios;

        public Usuario()
        {
            this._Persona = new Persona();
            this._ModulosUsuarios = new List<ModuloUsuario>();
        }
        
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

        public Persona Persona
        {
            get { return _Persona; }
            set { _Persona = value; }
        }

        public List<ModuloUsuario> ModulosUsuarios
        {
            get { return this._ModulosUsuarios; }
            set { this._ModulosUsuarios = value; }
        }

        public string Nombre
        {
            get { return this.Persona.Nombre; }
        }

        public string Apellido
        {
            get { return this.Persona.Apellido; }
        }

        public string Email
        {
            get { return this.Persona.Email; }
        }

        public string TipoPersona
        {
            get { return this.Persona.TipoPersona; }
        }
    }
}
