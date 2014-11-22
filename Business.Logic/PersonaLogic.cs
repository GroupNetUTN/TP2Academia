using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class PersonaLogic : BusinessLogic
    {
        private PersonaAdapter _PersonaData;

        public PersonaLogic()
        {
            _PersonaData = new PersonaAdapter();
        }
        
        public PersonaAdapter PersonaData
        {
            get
            {
                return _PersonaData;
            } 
        }

        public Persona GetOne(int ID)
        {
            return PersonaData.GetOne(ID);
        }

        public bool Existe(int leg)
        {
            return _PersonaData.Existe(leg);
        }

        public List<Persona> GetAll()
        {
            return PersonaData.GetAll(0);
        }

        public List<Persona> GetNoDocentes()
        {
            return PersonaData.GetAll(1);
        }
        
        public List<Persona> GetAlumnos()
        {
            return PersonaData.GetAll(2);
        }

        public List<Persona> GetDocentes()
        {
            return PersonaData.GetAll(3);
        }

        public void Save(Persona per)
        {
            PersonaData.Save(per);
        }

        public void Delete(int ID)
        {
            PersonaData.Delete(ID);
        }
    }
}
