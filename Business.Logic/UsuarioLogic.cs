using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class UsuarioLogic : BusinessLogic
    {
        private UsuarioAdapter _UsuarioData;

        public UsuarioLogic()
        {
            _UsuarioData = new UsuarioAdapter();
        }
        
        public UsuarioAdapter UsuarioData
        {
            get
            {
                return _UsuarioData;
            } 
        }

        public Usuario GetOne(int ID)
        {
            return UsuarioData.GetOne(ID);
        }

        public List<Usuario> GetAll()
        {
            return UsuarioData.GetAll();
        }

        public void Save(Usuario user)
        {
            UsuarioData.Save(user);
        }

        public void Delete(int ID)
        {
            UsuarioData.Delete(ID);
        }
    }
}
