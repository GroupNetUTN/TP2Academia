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
    public partial class SeleccionarDocentes : ApplicationForm
    {
        private Curso _CursoActual;
        private Persona _Docente;

        public SeleccionarDocentes(Curso c)
        {
            InitializeComponent();
            _CursoActual = c;
            dgvDocentes.AutoGenerateColumns = false;
        }

        public Persona Docente
        {
            get { return _Docente; }
        }

        private void Listar()
        {
            try
            {
                PersonaLogic pl = new PersonaLogic();
                dgvDocentes.DataSource = pl.GetDocentesPorPlan(_CursoActual.Materia.Plan.ID);
                dgvDocentes.ClearSelection();
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            _Docente = (Business.Entities.Persona)this.dgvDocentes.SelectedRows[0].DataBoundItem;
            this.Close();
        }

        private void SeleccionarDocentes_Load(object sender, EventArgs e)
        {
            this.Listar();
        }
    }
}
