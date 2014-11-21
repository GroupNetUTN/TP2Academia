using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class PlanLogic : BusinessLogic
    {
        private PlanAdapter _PlanData;

        public PlanLogic()
        {
            _PlanData = new PlanAdapter();
        }
        
        public PlanAdapter PlanData
        {
            get
            {
                return _PlanData;
            } 
        }

        public Plan GetOne(int ID)
        {
            return PlanData.GetOne(ID);
        }

        public List<Plan> GetAll()
        {
            return PlanData.GetAll();
        }

        public bool Existe(string desc, int esp)
        {
            return PlanData.Existe(desc, esp);
        }

        public void Save(Plan plan)
        {
            PlanData.Save(plan);
        }

        public void Delete(int ID)
        {
            PlanData.Delete(ID);
        }
    }
}
