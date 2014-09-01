using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class ComisionLogic : BusinessLogic
    {
        private ComisionAdapter _ComisionData;

        public ComisionLogic()
        {
            _ComisionData = new ComisionAdapter();
        }

        public ComisionAdapter ComisionData
        {
            get
            {
                return _ComisionData;
            }
        }

        public Comision GetOne(int ID)
        {
            return ComisionData.GetOne(ID);
        }

        public List<Comision> GetAll()
        {
            return ComisionData.GetAll();
        }

        public void Save(Comision comi)
        {
            ComisionData.Save(comi);
        }

        public void Delete(int ID)
        {
            ComisionData.Delete(ID);
        }
    }
}
