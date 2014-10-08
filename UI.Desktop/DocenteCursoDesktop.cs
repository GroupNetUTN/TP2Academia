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
            if (modo == ModoForm.Alta)
                _DocenteCursoActual = new DocenteCurso();
        }

        public DocenteCursoDesktop(int ID, ModoForm modo, Curso c) : this()
        {
            this._Modo = modo;
            DocenteCursoLogic DocCursNegocio = new DocenteCursoLogic();
            _DocenteCursoActual = DocCursNegocio.GetOne(ID);
            this.MapearDeDatos();
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = _DocenteCursoActual.ID.ToString();
            this.cbxCargo.SelectedItem = _DocenteCursoActual.Cargo;

            switch (this._Modo)
            {
                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    break;
                case ModoForm.Consulta:
                    this.btnAceptar.Text = "Aceptar";
                    break;
                default:
                    this.btnAceptar.Text = "Guardar";
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
                _DocenteCursoActual.IDCurso = _CursoActual.ID;
                _DocenteCursoActual.Cargo = cbxCargo.SelectedItem.ToString();
            }
        }

        public override void GuardarCambios()
        {
            this.MapearADatos();
            DocenteCursoLogic DCLogic = new DocenteCursoLogic();
            DCLogic.Save(_DocenteCursoActual);
        }

        public override bool Validar()
        {
            Boolean EsValido = true;
            foreach (Control oControls in this.Controls)
            {
                if (oControls is TextBox && oControls.Text == String.Empty && oControls != this.txtID)
                {
                    EsValido = false;
                    break;
                }
            }
            if (EsValido == false)
                this.Notificar("Todos los campos son obligatorios", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return EsValido;
        }

        private void btnSelecDocente_Click(object sender, EventArgs e)
        {
            SeleccionarDocentes doc = new SeleccionarDocentes(_CursoActual, _DocenteCursoActual.Docente);
            doc.ShowDialog();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                var rta = MessageBox.Show("¿Esta seguro que desea asignar este nuevo docente?", "Atencion", MessageBoxButtons.YesNo);
                if (rta == DialogResult.Yes)
                {
                    this.GuardarCambios();
                    this.Close();
                }
            }
        }
    }
}
