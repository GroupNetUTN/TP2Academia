using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class PermisosMaterias : ApplicationForm
    {
        private int _IDUsuario;
        private ModuloUsuario _ModuloUsuarioActual = new ModuloUsuario();
        ModuloLogic ml = new ModuloLogic();
            
        public PermisosMaterias(int id)
        {
            InitializeComponent();
            this._IDUsuario = id;
        }

        public override void MapearADatos()
        {
            _ModuloUsuarioActual.State = BusinessEntity.States.New;
            _ModuloUsuarioActual.Modulo.ID = ml.GetOne("Materias").ID;
            _ModuloUsuarioActual.IdUsuario = _IDUsuario;
            _ModuloUsuarioActual.PermiteAlta = this.chkAlta.Checked;
            _ModuloUsuarioActual.PermiteBaja = this.chkBaja.Checked;
            _ModuloUsuarioActual.PermiteConsulta = this.chkConsulta.Checked;
            _ModuloUsuarioActual.PermiteModificacion = this.chkModificacion.Checked;
        }

        public override void GuardarCambios()
        {
            this.MapearADatos();
            ModuloUsuarioLogic mul = new ModuloUsuarioLogic();
            mul.Save(_ModuloUsuarioActual);
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.GuardarCambios();
            this.Close();
        }
    }
}
