using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    class CursoLogic : BusinessLogic
    {
        private CursoAdapter _CursoData;

        public CursoLogic()
        {
            _CursoData = new CursoAdapter();
        }

        public CursoAdapter CursoData
        {
            get { return _CursoData; }
        }

        public List<Curso> GetAll()
        {
            return CursoData.GetAll();
        }

        public Curso GetOne(int ID)
        {
            return CursoData.GetOne(ID);
        }

        public void Delete(int ID)
        {
            CursoData.Delete(ID);
        }

        public void Save(Curso cur)
        {
            CursoData.Save(cur);
        }
    }
}
