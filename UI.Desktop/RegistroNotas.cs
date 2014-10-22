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
    public partial class RegistroNotas : Form
    {
        public RegistroNotas(Usuario u)
        {
            InitializeComponent();
            this.dgvCursos.AutoGenerateColumns = false;
            this.dgvAlumnos.AutoGenerateColumns = false;
            this._UsuarioActual = u;
        }

        private Usuario _UsuarioActual;

        private void RegistroNotas_Load(object sender, EventArgs e)
        {
            this.ListarCursos();
        }

        private void ListarCursos()
        {
            CursoLogic curlog = new CursoLogic();
            dgvCursos.DataSource = curlog.GetCursosDocente(this._UsuarioActual.Persona.ID);
            dgvCursos.ClearSelection();
        }

        public void ListarAlumnos()
        {
            int IDCurso = ((Business.Entities.Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).ID;
            AlumnoInscripcionLogic ail = new AlumnoInscripcionLogic();
            List<AlumnoInscripcion> alumnosInscriptos = new List<AlumnoInscripcion>();
            foreach (AlumnoInscripcion ai in ail.GetAll())
            {
                if (ai.Curso.ID == IDCurso)
                    alumnosInscriptos.Add(ai);
            }
            this.dgvAlumnos.DataSource = alumnosInscriptos;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvCursos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.ListarAlumnos();
        }
    }
}
