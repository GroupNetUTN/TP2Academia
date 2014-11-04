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
    public partial class InscripcionDesktop : ApplicationForm
    {
        public InscripcionDesktop(Usuario u)
        {
            InitializeComponent();
            this._UsuarioActual = u;
            this._InscripcionActual = new AlumnoInscripcion();
            this._InscripcionActual.State = BusinessEntity.States.New;
        }

        private void InscripcionCurso_Load(object sender, EventArgs e)
        {
            this.dgvComisiones.AutoGenerateColumns = false;
            this.dgvMaterias.AutoGenerateColumns = false;
            this.ListarMaterias();
        }

        private Usuario _UsuarioActual;

        private AlumnoInscripcion _InscripcionActual;

        private void ListarMaterias()
        {
            MateriaLogic matlog = new MateriaLogic();
            this.dgvMaterias.DataSource = matlog.GetMateriasParaInscripcion(_UsuarioActual.Persona.Plan.ID, _UsuarioActual.Persona.ID);
            this.dgvMaterias.ClearSelection();
        }
        
        public override void MapearADatos()
        {
            _InscripcionActual.Alumno = _UsuarioActual.Persona;
            _InscripcionActual.Condicion = "Inscripto";
            CursoLogic curlog = new CursoLogic();
            int IDMateria = ((Business.Entities.Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID;
            int IDComision = ((Business.Entities.Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).ID;
            foreach (Curso c in curlog.GetAll())
            {
                if(c.Comision.ID == IDComision && c.Materia.ID == IDMateria)
                {
                    c.Cupo--;
                    _InscripcionActual.Curso = c;
                    _InscripcionActual.Curso.State = BusinessEntity.States.Modified;
                }
            }
        }

        private void dgvMaterias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int IDMateria = ((Business.Entities.Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID;
            ComisionLogic comlog = new ComisionLogic();
            this.dgvComisiones.DataSource =  comlog.GetComisionesDisponibles(IDMateria);
        }

        public override void GuardarCambios()
        {
            this.MapearADatos();
            AlumnoInscripcionLogic inslogic = new AlumnoInscripcionLogic();
            inslogic.Save(_InscripcionActual);
            CursoLogic curlog = new CursoLogic();
            curlog.Save(_InscripcionActual.Curso);     
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dgvComisiones.SelectedRows.Count > 0)
            {
                var rta = MessageBox.Show("Se esta inscribiendo a la Materia: " + ((Business.Entities.Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).Descripcion +
                    " en la Comision: " + ((Business.Entities.Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).Descripcion, "Atencion", MessageBoxButtons.YesNo);
                if (rta == DialogResult.Yes)
                {
                    this.GuardarCambios();
                    this.Close();
                }
            }
            else
                this.Notificar("Seleccione una comision a la cual inscribirse", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }



    }
}
