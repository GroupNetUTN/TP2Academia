using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class DocenteCurso : BusinessEntity
    {
        private string _Cargo;
        private Persona _Docente;
        private Curso _Curso;

        public DocenteCurso()
        {
            this._Docente = new Persona();
            this._Curso = new Curso();
        }

        public string Cargo
        {
            get
            {
                return _Cargo;
            }
            set
            {
                _Cargo = value;
            }
        }

        public Persona Docente
        {
            get
            {
                return _Docente;
            }
            set
            {
                _Docente = value;
            }
        }

        public Curso Curso
        {
            get
            {
                return _Curso;
            }
            set
            {
                _Curso = value;
            }
        }

        public string ApellidoDocente
        {
            get { return this.Docente.Apellido; }
        }

        public string NombreDocente
        {
            get { return this.Docente.Nombre; }
        }
    }
}
