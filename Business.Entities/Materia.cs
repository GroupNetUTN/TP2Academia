﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class Materia : BusinessEntity
    {
        private string _Descripcion;
        private int _HSSemanales;
        private int _HSTotales;
        private Plan _Plan;

        public Materia()
        {
            this._Plan = new Plan();
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

        public int HSSemanales
        {
            get
            {
                return _HSSemanales;
            }
            set
            {
                _HSSemanales = value;
            }
        }

        public int HSTotales
        {
            get
            {
                return _HSTotales;
            }
            set
            {
                _HSTotales = value;
            }
        }

        public Plan Plan
        {
            get { return _Plan; }
            set { _Plan = value; }
        }

        public string DescPlan
        {
            get { return this.Plan.Descripcion; }
        }

        public string DescEspecialidad
        {
            get { return this.Plan.Especialidad.Descripcion; }
        }
    }
}
