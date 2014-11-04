using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    public partial class PlanDesktop : ApplicationForm
    {
        public PlanDesktop()
        {
            InitializeComponent();
        }

        private void PlanDesktop_Load(object sender, EventArgs e)
        {
          
        }

        Plan _PlanActual;

        public Plan PlanActual
        {
            get { return _PlanActual; }
            set { _PlanActual = value; }
        }

        public PlanDesktop(ModoForm modo) : this()    
        {
            this._Modo = modo;
            this.llenarCombo();
        }

        public PlanDesktop(int ID, ModoForm modo) : this()
        {
            this._Modo = modo;
            PlanLogic PlanNegocio = new PlanLogic();
            try
            {
                _PlanActual = PlanNegocio.GetOne(ID);
                this.llenarCombo();
                this.MapearDeDatos();
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void llenarCombo()
        {
            try
            {
                EspecialidadLogic EspecialidadNegocio = new EspecialidadLogic();
                cbxEspecialidad.DataSource = EspecialidadNegocio.GetAll();
                cbxEspecialidad.DisplayMember = "Descripcion";
                cbxEspecialidad.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = PlanActual.ID.ToString();
            this.txtDescripcion.Text = PlanActual.Descripcion;
            this.cbxEspecialidad.SelectedValue = _PlanActual.Especialidad.ID;

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
                    _PlanActual.State = Plan.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    _PlanActual.State = Plan.States.Unmodified;
                    break;
                case ModoForm.Alta:
                    _PlanActual = new Plan();
                    _PlanActual.State = Plan.States.New;
                    break;
                case ModoForm.Modificacion:
                    _PlanActual.State = Plan.States.Modified;
                    break;
            }
            if (_Modo == ModoForm.Alta || _Modo == ModoForm.Modificacion)
            {
                if (_Modo == ModoForm.Modificacion)
                    _PlanActual.ID = Convert.ToInt32(this.txtID.Text);
                _PlanActual.Descripcion = this.txtDescripcion.Text;
                _PlanActual.Especialidad.ID = Convert.ToInt32(this.cbxEspecialidad.SelectedValue);
            }
        }

        public override void GuardarCambios()
        {
            try
            {
                this.MapearADatos();
                PlanLogic planLogic = new PlanLogic();
                planLogic.Save(_PlanActual);
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                this.GuardarCambios();
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
