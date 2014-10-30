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
    public partial class Planes : ApplicationForm
    {
        private Usuario _UsuarioActual;

        public Usuario UsuarioActual
        {
            get { return _UsuarioActual; }
            set { _UsuarioActual = value; }
        }

        public Planes(Usuario us)
        {
            InitializeComponent();
            UsuarioActual = us;
            dgvPlanes.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            PlanLogic pl = new PlanLogic();
            this.dgvPlanes.DataSource = pl.GetAll();
        }

        private void Planes_Load(object sender, EventArgs e)
        {
            foreach (ModuloUsuario mu in UsuarioActual.ModulosUsuarios)
            {
                if (mu.Modulo.Descripcion == "Planes")
                {
                    this.dgvPlanes.Visible = mu.PermiteConsulta;
                    this.tsbNuevo.Visible = mu.PermiteAlta;
                    this.tsbEliminar.Visible = mu.PermiteBaja;
                    this.tsbEditar.Visible = mu.PermiteModificacion;
                }
            }
            this.Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            PlanDesktop PlanDesktop = new PlanDesktop(ApplicationForm.ModoForm.Alta);
            PlanDesktop.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).ID;
            PlanDesktop PlanDesktop = new PlanDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            PlanDesktop.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            var rta = MessageBox.Show("¿Esta seguro que desea eliminar el Plan seleccionado?", "Atencion", MessageBoxButtons.YesNo);
            if (rta == DialogResult.Yes)
            {
                int ID = ((Business.Entities.Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).ID;
                PlanLogic plan = new PlanLogic();
                plan.Delete(ID);
                this.Listar();
            }
        }
    }
}
