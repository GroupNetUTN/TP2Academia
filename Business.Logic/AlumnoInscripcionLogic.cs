using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Database;
using Business.Entities;

namespace Business.Logic
{
    public class AlumnoInscripcionLogic : BusinessLogic
    {
        private AlumnoInscripcionAdapter _InscripcionData;

        public AlumnoInscripcionLogic()
        {
            _InscripcionData = new AlumnoInscripcionAdapter();
        }

        public AlumnoInscripcionAdapter InscripcionData
        {
            get
            {
                return _InscripcionData;
            }
        }

        public AlumnoInscripcion GetOne(int ID)
        {
            return _InscripcionData.GetOne(ID);
        }

        public List<AlumnoInscripcion> GetAll(int IDAlumno)
        {
            return _InscripcionData.GetAll(IDAlumno);
        }

        public List<AlumnoInscripcion> GetAll()
        {
            return _InscripcionData.GetAll();
        }

        public void Save(AlumnoInscripcion ins)
        {
            _InscripcionData.Save(ins);
        }

        public void Delete(int ID)
        {
            _InscripcionData.Delete(ID);
        }
    }
}
