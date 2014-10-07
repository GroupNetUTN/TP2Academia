using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class DocenteCurso : BusinessEntity
    {
        private string _Cargo;
        private int _IDCurso;
        private Persona _Docente;

        public DocenteCurso()
        {
            this.Docente = new Persona();
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

        public int IDCurso
        {
            get
            {
                return _IDCurso;
            }
            set
            {
                _IDCurso = value;
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
