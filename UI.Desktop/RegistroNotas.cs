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
    public partial class RegistroNotas : ApplicationForm
    {
        public RegistroNotas(Usuario u)
        {
            InitializeComponent();
            this._Modo = ModoForm.Modificacion;
            this.dgvCursos.AutoGenerateColumns = false;
            this.dgvAlumnos.AutoGenerateColumns = false;
            this._UsuarioActual = u;
        }

        private Usuario _UsuarioActual;
        private AlumnoInscripcion _InscripcionActual;

        private void RegistroNotas_Load(object sender, EventArgs e)
        {
            this.ListarCursos();
            dgvCursos.ClearSelection();
        }

        private void ListarCursos()
        {
            CursoLogic curlog = new CursoLogic();
            dgvCursos.DataSource = curlog.GetCursosDocente(this._UsuarioActual.Persona.ID);   
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

        public override void MapearADatos()
        {
            _InscripcionActual.State = AlumnoInscripcion.States.Modified;
            _InscripcionActual = ((Business.Entities.AlumnoInscripcion)this.dgvAlumnos.SelectedRows[0].DataBoundItem);
            _InscripcionActual.Nota = Convert.ToInt32(this.txtNota.Text);
            _InscripcionActual.Condicion = this.cbxCondicion.SelectedItem.ToString();
        }

        public override void GuardarCambios()
        {
            this.MapearADatos();
            AlumnoInscripcionLogic AILogic = new AlumnoInscripcionLogic();
            AILogic.Save(_InscripcionActual);
        }

        public override bool Validar()
        {
            bool EsValido = true;
            if (this.txtNota.Text.Equals(""))
                {
                    EsValido = false;
                    this.Notificar("Todos los campos son obligatorios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            return EsValido;
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvCursos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.ListarAlumnos();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                this.GuardarCambios();
                this.ListarAlumnos();
            }
        }

        private void btnBorrarNota_Click(object sender, EventArgs e)
        {
            _InscripcionActual.State = AlumnoInscripcion.States.Modified;
            _InscripcionActual = ((Business.Entities.AlumnoInscripcion)this.dgvAlumnos.SelectedRows[0].DataBoundItem);
            _InscripcionActual.Nota = 0;
            _InscripcionActual.Condicion = "Inscripto";
        }
    }
}
