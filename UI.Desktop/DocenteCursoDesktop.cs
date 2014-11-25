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
    public partial class DocenteCursoDesktop : ApplicationForm
    {
        private Curso _CursoActual;
        private DocenteCurso _DocenteCursoActual;
        
        public DocenteCursoDesktop()
        {
            InitializeComponent();
        }

        public DocenteCursoDesktop(ModoForm modo, Curso c) : this()    
        {
            this._Modo = modo;
            _CursoActual = c;
            _DocenteCursoActual = new DocenteCurso();
        }

        public DocenteCursoDesktop(int ID, ModoForm modo, Curso c) : this()
        {
            this._Modo = modo;
            try
            {
                _CursoActual = c;
                DocenteCursoLogic DocCursNegocio = new DocenteCursoLogic();
                _DocenteCursoActual = DocCursNegocio.GetOne(ID);
                this.MapearDeDatos();
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = _DocenteCursoActual.ID.ToString();
            this.cbxCargo.SelectedItem = _DocenteCursoActual.Cargo;

            switch (this._Modo)
            {
                case ModoForm.Modificacion:
                    this.btnAceptar.Text = "Guardar";
                    this.btnSelecDocente.Visible = false;
                    break;
                case ModoForm.Consulta:
                    this.btnAceptar.Text = "Aceptar";
                    break;
            }
        }

        public override void MapearADatos()
        {
            switch (this._Modo)
            {
                case ModoForm.Baja:
                    _DocenteCursoActual.State = DocenteCurso.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    _DocenteCursoActual.State = DocenteCurso.States.Unmodified;
                    break;
                case ModoForm.Alta:
                    _DocenteCursoActual.State = Plan.States.New;
                    break;
                case ModoForm.Modificacion:
                    _DocenteCursoActual.State = DocenteCurso.States.Modified;
                    break;
            }
            if (_Modo == ModoForm.Alta || _Modo == ModoForm.Modificacion)
            {
                if (_Modo == ModoForm.Modificacion)
                    _DocenteCursoActual.ID = Convert.ToInt32(this.txtID.Text);
                _DocenteCursoActual.Curso.ID = _CursoActual.ID;
                _DocenteCursoActual.Cargo = cbxCargo.SelectedItem.ToString();
            }
        }

        public override void GuardarCambios()
        {
            try
            {
                this.MapearADatos();
                DocenteCursoLogic DCLogic = new DocenteCursoLogic();
                if (_Modo != ModoForm.Alta || !DCLogic.Existe(_DocenteCursoActual.Curso.ID, _DocenteCursoActual.Docente.ID, _DocenteCursoActual.Cargo))
                    DCLogic.Save(_DocenteCursoActual);
                else this.Notificar("Este Docente ya se encuentra asignado a este Curso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override bool Validar()
        {
            Boolean EsValido = true;
            if (this.cbxCargo.SelectedItem == null)
            {
                EsValido = false;
                this.Notificar("No se seleccionó un Cargo para el Docente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if(this._DocenteCursoActual.Docente.ID == 0)
            {
                this.Notificar("No se seleccionó un Docente para el Curso",MessageBoxButtons.OK, MessageBoxIcon.Error);
                EsValido = false;
            }
            return EsValido;
        }

        private void btnSelecDocente_Click(object sender, EventArgs e)
        {
            SeleccionarDocentes doc = new SeleccionarDocentes(_CursoActual);
            doc.ShowDialog();
            _DocenteCursoActual.Docente = doc.Docente;
            this.txtDocente.Text = _DocenteCursoActual.Docente.Apellido + " " + _DocenteCursoActual.Docente.Nombre;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                this.GuardarCambios();
                this.Close();                
            }
        }
    }
}
