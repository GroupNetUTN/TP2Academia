using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class MateriaLogic : BusinessLogic
    {
        private MateriaAdapter _MateriaData;

        public MateriaLogic()
        {
            _MateriaData = new MateriaAdapter();
        }

        public MateriaAdapter MateriaData
        {
            get
            {
                return _MateriaData;
            }
        }

        public Materia GetOne(int ID)
        {
            return MateriaData.GetOne(ID);
        }

        public List<Materia> GetAll()
        {
            return MateriaData.GetAll();
        }

        public void Save(Materia mat)
        {
            MateriaData.Save(mat);
        }

        public void Delete(int ID)
        {
            MateriaData.Delete(ID);
        }

        public List<Materia> GetMateriasParaInscripcion(int IDPlan, int IDAlumno)
        {
            return MateriaData.GetMateriasParaInscripcion(IDPlan, IDAlumno);
        }
    }
}
