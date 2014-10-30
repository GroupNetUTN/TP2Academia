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
    public partial class Materias : ApplicationForm
    {
        private Usuario _UsuarioActual;

        public Usuario UsuarioActual
        {
            get { return _UsuarioActual; }
            set { _UsuarioActual = value; }
        }

        public Materias(Usuario us)
        {
            InitializeComponent();
            UsuarioActual = us;
            dgvMaterias.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            MateriaLogic ml = new MateriaLogic();
            dgvMaterias.DataSource = ml.GetAll();
        }

        private void Materias_Load(object sender, EventArgs e)
        {
            foreach (ModuloUsuario mu in UsuarioActual.ModulosUsuarios)
            {
                if (mu.Modulo.Descripcion == "Materias")
                {
                    this.dgvMaterias.Visible = mu.PermiteConsulta;
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
            MateriaDesktop MateriaDesktop = new MateriaDesktop(ApplicationForm.ModoForm.Alta);
            MateriaDesktop.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID;
            MateriaDesktop MateriaDesktop = new MateriaDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            MateriaDesktop.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            var rta = MessageBox.Show("¿Esta seguro que desea eliminar la Materia seleccionada?", "Atencion", MessageBoxButtons.YesNo);
            if (rta == DialogResult.Yes)
            {
                int ID = ((Business.Entities.Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID;
                MateriaLogic materia = new MateriaLogic();
                materia.Delete(ID);
                this.Listar();
            }


        }


    }
}