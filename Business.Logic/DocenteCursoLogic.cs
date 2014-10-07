using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class DocenteCursoLogic : BusinessLogic
    {
        private DocenteCursoAdapter _DocenteCursoData;

        public DocenteCursoLogic()
        {
            _DocenteCursoData = new DocenteCursoAdapter();
        }

        public DocenteCursoAdapter DocenteCursoData
        {
            get
            {
                return _DocenteCursoData;
            }
        }

        public DocenteCurso GetOne(int ID)
        {
            return _DocenteCursoData.GetOne(ID);
        }

        public List<DocenteCurso> GetAll()
        {
            return _DocenteCursoData.GetAll();
        }

        public void Save(DocenteCurso dc)
        {
            _DocenteCursoData.Save(dc);
        }

        public void Delete(int ID)
        {
            _DocenteCursoData.Delete(ID);
        }
    }
}
