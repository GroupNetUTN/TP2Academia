using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class EspecialidadLogic : BusinessLogic
    {
        private EspecialidadAdapter _EspecialidadData;

        public EspecialidadLogic()
        {
            _EspecialidadData = new EspecialidadAdapter();
        }

        public EspecialidadAdapter EspecialidadData
        {
            get
            {
                return _EspecialidadData;
            } 
        }

        public Especialidad GetOne(int ID)
        {
            return EspecialidadData.GetOne(ID);
        }

        public List<Especialidad> GetAll()
        {
            return EspecialidadData.GetAll();
        }

        public void Save(Especialidad esp)
        {
            EspecialidadData.Save(esp);
        }

        public void Delete(int ID)
        {
            EspecialidadData.Delete(ID);
        }
    }
}
