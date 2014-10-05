using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class Curso : BusinessEntity
    {
        private int _AnioCalendario;
        private int _Cupo;
        private string _Descripcion;
        private Materia _Materia;
        private Comision _Comision;

        public Curso()
        {
            this._Materia = new Materia();
            this._Comision = new Comision();
        }

        public int AnioCalendario
        {
            get
            {
                return _AnioCalendario;
            }
            set
            {
                _AnioCalendario = value;
            }
        }

        public int Cupo
        {
            get
            {
                return _Cupo;
            }
            set
            {
                _Cupo = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return _Descripcion;
            }
            set
            {
                _Descripcion = value;
            }
        }

        public Comision Comision
        {
            get
            {
                return _Comision;
            }
            set
            {
                _Comision = value;
            }
        }

        public Materia Materia
        {
            get
            {
                return _Materia;
            }
            set
            {
                _Materia = value;
            }
        }

        public string DescMateria
        {
            get { return _Materia.Descripcion; }
        }

        public string DescComision
        {
            get { return _Comision.Descripcion; }
        }

    }
}
