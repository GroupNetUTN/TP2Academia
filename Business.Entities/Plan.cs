using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class Plan: BusinessEntity
    {
        private string _Descripcion;
        private Especialidad _Especialidad;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        public Especialidad Especialidad
        {
            get { return _Especialidad; }
            set { _Especialidad = value; }
        }

        public string DescEspecialidad
        {
            get { return this.Especialidad.Descripcion; }
        }
    }
}
