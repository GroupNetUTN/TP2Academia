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
    public partial class SeleccionarPersona : Form
    {
        public SeleccionarPersona(Usuario u)
        {
            InitializeComponent();
            _UsuarioActual = u;
            dgvSeleccionarPersona.AutoGenerateColumns = false;
        }

        Usuario _UsuarioActual;

        public Usuario UsuarioActual
        {
            get { return _UsuarioActual; }
            set { _UsuarioActual = value; }
        }

        private void SeleccionarPersona_Load(object sender, EventArgs e)
        {
            this.Listar("Todos");
        }

        public void Listar(string tipo)
        {
            PersonaLogic pl = new PersonaLogic();
            if (tipo == "Todos")
                this.dgvSeleccionarPersona.DataSource = pl.GetAll();
            else if (tipo == "Alumnos")
                this.dgvSeleccionarPersona.DataSource = pl.GetAlumnos();
            else if (tipo == "Docentes")
                this.dgvSeleccionarPersona.DataSource = pl.GetDocentes();
            else if (tipo == "No docentes")
                this.dgvSeleccionarPersona.DataSource = pl.GetNoDocentes();
        }

        private void cbxTipoPersona_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Listar(cbxTipoPersona.SelectedItem.ToString());
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
           _UsuarioActual.Persona.ID = ((Business.Entities.Persona)this.dgvSeleccionarPersona.SelectedRows[0].DataBoundItem).ID;
           this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
