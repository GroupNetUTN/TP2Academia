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
    public partial class Especialidades : ApplicationForm
    {
        private Usuario _UsuarioActual;

        public Usuario UsuarioActual
        {
            get { return _UsuarioActual; }
            set { _UsuarioActual = value; }
        }

        public Especialidades(Usuario us)
        {
            InitializeComponent();
            UsuarioActual = us;
            dgvEspecialidades.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            try
            {
                EspecialidadLogic el = new EspecialidadLogic();
                this.dgvEspecialidades.DataSource = el.GetAll();
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Especialidades_Load(object sender, EventArgs e)
        {
            foreach (ModuloUsuario mu in UsuarioActual.ModulosUsuarios)
            {
                if (mu.Modulo.Descripcion == "Especialidades")
                {
                    this.dgvEspecialidades.Visible = mu.PermiteConsulta;
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
            EspecialidadDesktop EspDesktop = new EspecialidadDesktop(ApplicationForm.ModoForm.Alta);
            EspDesktop.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;
            EspecialidadDesktop EspeDesktop = new EspecialidadDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            EspeDesktop.ShowDialog();
            this.Listar();

        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            var rta = MessageBox.Show("¿Esta seguro que desea eliminar esta especialidad?", "Atencion", MessageBoxButtons.YesNo);
            if (rta == DialogResult.Yes)
            {
                try
                {
                    int ID = ((Business.Entities.Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;
                    EspecialidadLogic especialidad = new EspecialidadLogic();
                    especialidad.Delete(ID);
                    this.Listar();
                }
                catch (Exception ex)
                {
                    this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
