using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    public partial class Cursos : Form
    {
        public Cursos()
        {
            InitializeComponent();
            dgvCursos.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            CursoLogic cl = new CursoLogic();
            this.dgvCursos.DataSource = cl.GetAll();
        }

        private void Cursos_Load(object sender, EventArgs e)
        {
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
            CursoDesktop curDesktop = new CursoDesktop(ApplicationForm.ModoForm.Alta);
            curDesktop.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).ID;
            CursoDesktop CursoDesktop = new CursoDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            CursoDesktop.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            var rta = MessageBox.Show("¿Esta seguro que desea eliminar el Curso seleccionado?", "Atencion", MessageBoxButtons.YesNo);
            if (rta == DialogResult.Yes)
            {
                int ID = ((Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).ID;
                CursoLogic curso = new CursoLogic();
                curso.Delete(ID);
                this.Listar();
            }
        }

        private void tsbDocentes_Click(object sender, EventArgs e)
        {
            DocentesCursos dc = new DocentesCursos((Curso)this.dgvCursos.SelectedRows[0].DataBoundItem);
            dc.ShowDialog();
        }

    }
}
