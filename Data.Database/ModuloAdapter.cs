using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;

namespace Data.Database
{
    class ModuloAdapter : Adapter
    {
        #region DatosEnMemoria

        private static List<Modulo> _Modulos;

        private static List<Modulo> Modulos
        {
            get
            {
                if (_Modulos == null)
                {
                    _Modulos = new List<Modulo>();
                    Modulo m;

                    m = new Modulo();
                    m.Descripcion = "Modulo1";
                    _Modulos.Add(m);

                    m = new Modulo();
                    m.Descripcion = "Modulo2";
                    _Modulos.Add(m);

                    m = new Modulo();
                    m.Descripcion = "Modulo3";
                    _Modulos.Add(m);

                    m = new Modulo();
                    m.Descripcion = "Modulo4";
                    _Modulos.Add(m);   
                }
                return _Modulos;
            }
        }

        #endregion

        public List<Modulo> GetAll()
        {
            return new List<Modulo>(Modulos);
        }

        public Modulo GetOne(string desc)
        {
            return Modulos.Find(delegate(Modulo m) {return m.Descripcion == desc;} );

        }

        public void Delete(string desc)
        {
            Modulos.Remove(this.GetOne(desc));
        }

        public void Save(Modulo mod)
        {
            if (mod.State == BusinessEntity.States.New)
            {
                Modulos.Add(mod);
            }
            else if (mod.State == BusinessEntity.States.Deleted)
            {
                this.Delete(mod.Descripcion);
            }
            else if (mod.State == BusinessEntity.States.Modified)
            {
                Modulos[Modulos.FindIndex(delegate(Modulo m) { return m.Descripcion == mod.Descripcion; })] = mod;
            }
        }
    }
}
