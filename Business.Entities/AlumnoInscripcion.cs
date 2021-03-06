﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Entities
{
    public class AlumnoInscripcion : BusinessEntity
    {
        private string _Condicion;
        private int _Nota;
        private Persona _Alumno;
        private Curso _Curso;

        public AlumnoInscripcion()
        {
            this._Alumno = new Persona();
            this._Curso = new Curso();
        }
    
        public string Condicion
        {
            get
            {
                return _Condicion;
            }
            set
            {
                _Condicion = value;
            }
        }

        public Persona Alumno
        {
            get
            {
                return _Alumno;
            }
            set
            {
                _Alumno = value;
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

        public int Nota
        {
            get
            {
                return _Nota;
            }
            set
            {
                _Nota = value;
            }
        }

        public string DescComision
        {
            get { return Curso.Comision.Descripcion; }
        }

        public string DescMateria
        {
            get { return Curso.Materia.Descripcion; }
        }

        public int AnioCurso
        {
            get { return Curso.AnioCalendario; }
        }

        public string Apellido
        {
            get { return this.Alumno.Apellido; }
        }

        public string Nombre
        {
            get { return this.Alumno.Nombre; }
        }
    }
}
