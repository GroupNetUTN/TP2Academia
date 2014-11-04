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
    public partial class Cursos : ApplicationForm
    {
        private Usuario _UsuarioActual;

        public Usuario UsuarioActual
        {
            get { return _UsuarioActual; }
            set { _UsuarioActual = value; }
        }

        public Cursos(Usuario us)
        {
            InitializeComponent();
            UsuarioActual = us;
            dgvCursos.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            try
            {
                CursoLogic cl = new CursoLogic();
                this.dgvCursos.DataSource = cl.GetAll();
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Cursos_Load(object sender, EventArgs e)
        {
            foreach (ModuloUsuario mu in UsuarioActual.ModulosUsuarios)
            {
                if (mu.Modulo.Descripcion == "Cursos")
                {
                    this.dgvCursos.Visible = mu.PermiteConsulta;
                    this.tsbNuevo.Visible = mu.PermiteAlta;
                    this.tsbEliminar.Visible = mu.PermiteBaja;
                    this.tsbEditar.Visible = mu.PermiteModificacion;
                    this.tsbDocentes.Visible = mu.PermiteModificacion || mu.PermiteAlta;   //revisar!!!!
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
                try
                {
                    int ID = ((Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).ID;
                    CursoLogic curso = new CursoLogic();
                    curso.Delete(ID);
                    this.Listar();
                }
                catch (Exception ex)
                {
                    this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tsbDocentes_Click(object sender, EventArgs e)
        {
            DocentesCursos dc = new DocentesCursos((Curso)this.dgvCursos.SelectedRows[0].DataBoundItem);
            dc.ShowDialog();
        }

    }
}
