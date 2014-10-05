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
    public partial class InscripcionCurso : Form
    {
        public InscripcionCurso(Usuario u)
        {
            InitializeComponent();
            this._UsuarioActual = u;
            
        }

        private void InscripcionCurso_Load(object sender, EventArgs e)
        {
            this.dgvComisiones.AutoGenerateColumns = false;
            this.dgvMaterias.AutoGenerateColumns = false;
            this.ListarMaterias();
        }

        private Usuario _UsuarioActual;

        private void ListarMaterias()
        {
            List<Materia> materias = new List<Materia>();
            MateriaLogic matlog = new MateriaLogic();
            foreach (Materia m in matlog.GetAll())
            {
                if (m.Plan.ID == this._UsuarioActual.Persona.IDPlan)
                    materias.Add(m);
            }
            this.dgvMaterias.DataSource = materias;
            this.dgvMaterias.ClearSelection();
        }

        private void dgvMaterias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int ID = ((Business.Entities.Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID;
            List<Comision> comisiones = new List<Comision>();
            CursoLogic curlog = new CursoLogic();
            foreach (Curso c in curlog.GetAll())
            {
                if (c.Materia.ID == ID)
                    comisiones.Add(c.Comision);
            }
            this.dgvComisiones.DataSource = comisiones;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }



    }
}
