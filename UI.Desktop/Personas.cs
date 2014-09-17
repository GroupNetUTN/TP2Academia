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
    public partial class Personas : ApplicationForm
    {
        public Personas()
        {
            InitializeComponent();
            dgvPersonas.AutoGenerateColumns = false;
        }

        public void Listar(string tipo)
        {
            PersonaLogic pl = new PersonaLogic();
            if (tipo == "Todos")
                this.dgvPersonas.DataSource = pl.GetAll();
            else if (tipo == "Alumnos")
                this.dgvPersonas.DataSource = pl.GetAlumnos();
            else if (tipo == "Docentes")
                this.dgvPersonas.DataSource = pl.GetDocentes();
        }

        private void Personas_Load(object sender, EventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar(cbxTipoPersona.SelectedItem.ToString());
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            PersonaDesktop PersDesktop = new PersonaDesktop(ApplicationForm.ModoForm.Alta);
            PersDesktop.ShowDialog();
            this.Listar(cbxTipoPersona.SelectedItem.ToString());
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.Persona)this.dgvPersonas.SelectedRows[0].DataBoundItem).ID;
            PersonaDesktop PersDesktop = new PersonaDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            PersDesktop.ShowDialog();
            this.Listar(cbxTipoPersona.SelectedItem.ToString());

        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            var rta = MessageBox.Show("¿Esta seguro que desea eliminar el usuario?", "Atencion", MessageBoxButtons.YesNo);
            if (rta == DialogResult.Yes)
            {
                int ID = ((Business.Entities.Persona)this.dgvPersonas.SelectedRows[0].DataBoundItem).ID;
                PersonaLogic per = new PersonaLogic();
                per.Delete(ID);
                this.Listar(cbxTipoPersona.SelectedItem.ToString());
            }
        }

        private void cbxTipoPersona_SelectedIndexChanged(object sender, EventArgs e)
        {
             this.Listar(cbxTipoPersona.SelectedItem.ToString());
        }
    }
}
