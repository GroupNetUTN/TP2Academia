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

        public SeleccionarDocentes(Curso c, Persona p)
        {
            InitializeComponent();
            _CursoActual = c;
            _Docente = p;
            dgvDocentes.AutoGenerateColumns = false;
        }

        public Persona Docente
        {
            get { return _Docente; }
        }

        private void Listar()
        {
            List<Persona> docentes = new List<Persona>();
            PersonaLogic pl = new PersonaLogic();
            foreach (Persona p in pl.GetAll())
            {
                if (p.TipoPersona == "Docente" && p.IDPlan == _CursoActual.Comision.Plan.ID)
                    docentes.Add(p);
            }
            dgvDocentes.DataSource = docentes;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            _Docente.ID = ((Business.Entities.Persona)this.dgvDocentes.SelectedRows[0].DataBoundItem).ID;
            this.Close();
        }

        private void SeleccionarDocentes_Load(object sender, EventArgs e)
        {
            this.Listar();
        }
    }
}
