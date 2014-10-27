using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class ModuloUsuarioLogic : BusinessLogic
    {
        private ModuloUsuarioAdapter _ModuloUsuarioData;

        public ModuloUsuarioLogic()
        {
            _ModuloUsuarioData = new ModuloUsuarioAdapter();
        }

        public ModuloUsuarioAdapter ModuloUsuarioData
        {
            get { return _ModuloUsuarioData; }
        }

        public List<ModuloUsuario> GetAll()
        {
            return ModuloUsuarioData.GetAll();
        }

        public void Save(ModuloUsuario mu)
        {
            ModuloUsuarioData.Save(mu);
        }
    }
}
