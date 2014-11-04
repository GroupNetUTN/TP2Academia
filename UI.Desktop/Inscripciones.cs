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
    public partial class Inscripciones : ApplicationForm
    {
        public Inscripciones(Usuario u)
        {
            InitializeComponent();
            this.dgvInscripciones.AutoGenerateColumns = false;
            this._UsuarioActual = u;
        }

        private Usuario _UsuarioActual;

        public void Listar()
        {
            AlumnoInscripcionLogic ail = new AlumnoInscripcionLogic();
            this.dgvInscripciones.DataSource = ail.GetAll(_UsuarioActual.Persona.ID);
        }

        private void Inscripciones_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            InscripcionDesktop insdesktop = new InscripcionDesktop(_UsuarioActual);
            insdesktop.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            var rta = MessageBox.Show("¿Esta seguro que desea eliminar esta Inscripción?", "Atencion", MessageBoxButtons.YesNo);
            if (rta == DialogResult.Yes)
            {
                int ID = ((Business.Entities.AlumnoInscripcion)this.dgvInscripciones.SelectedRows[0].DataBoundItem).ID;
                AlumnoInscripcionLogic insc = new AlumnoInscripcionLogic();
                insc.Delete(ID);
                CursoLogic curlog = new CursoLogic();
                Curso cur = curlog.GetOne(((Business.Entities.AlumnoInscripcion)this.dgvInscripciones.SelectedRows[0].DataBoundItem).Curso.ID);
                cur.State = BusinessEntity.States.Modified;
                cur.Cupo++;
                curlog.Save(cur);
                this.Listar();
            }
        }
    }
}
