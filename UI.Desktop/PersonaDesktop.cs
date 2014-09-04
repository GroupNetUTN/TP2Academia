﻿using System;
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
    public partial class PersonaDesktop : ApplicationForm
    {
        public PersonaDesktop()
        {
            InitializeComponent();
        }

        //public enum TipoPers
        //{
        //    Administrador,
        //    Alumno,
        //    Docente
        //}

        private void PersonaDesktop_Load(object sender, EventArgs e)
        {

        }

        Persona _PersonaActual;

        public Persona PersonaActual
        {
            get { return _PersonaActual; }
            set { _PersonaActual = value; }
        }

        public PersonaDesktop(ModoForm modo) : this()    
        {
            this._Modo = modo;
            this.llenarCombo();
        }

        public PersonaDesktop(int ID, ModoForm modo) : this()
        {
            this._Modo = modo;
            PersonaLogic PersonaNegocio = new PersonaLogic();
            _PersonaActual = PersonaNegocio.GetOne(ID);
            this.llenarCombo();
            this.MapearDeDatos();
        }

        private void llenarCombo()
        {
            PlanLogic PlanNegocio = new PlanLogic();
            cbxPlan.DataSource = PlanNegocio.GetAll();
            cbxPlan.DisplayMember = "Descripcion";
            cbxPlan.ValueMember = "ID";
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = PersonaActual.ID.ToString();
            this.txtLegajo.Text = PersonaActual.Legajo.ToString();
            this.txtApellido.Text = PersonaActual.Apellido;
            this.txtNombre.Text = PersonaActual.Nombre;
            this.txtDia.Text = PersonaActual.FechaNacimiento.Day.ToString();
            this.txtMes.Text = PersonaActual.FechaNacimiento.Month.ToString();
            this.txtAnio.Text = PersonaActual.FechaNacimiento.Year.ToString();
            this.txtDireccion.Text = PersonaActual.Direccion;
            this.txtTelefono.Text = PersonaActual.Telefono;
            this.txtEmail.Text = PersonaActual.Email;
            this.cbxPlan.SelectedValue = PersonaActual.IDPlan;
            this.cbxTipoPersona.SelectedText = PersonaActual.TipoPersona;

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
                    PersonaActual.State = Persona.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    PersonaActual.State = Persona.States.Unmodified;
                    break;
                case ModoForm.Alta:
                    PersonaActual = new Persona();
                    PersonaActual.State = Persona.States.New;
                    break;
                case ModoForm.Modificacion:
                    PersonaActual.State = Persona.States.Modified;
                    break;
            }
            if (_Modo == ModoForm.Alta || _Modo == ModoForm.Modificacion)
            {
                if (_Modo == ModoForm.Modificacion)
                    PersonaActual.ID = Convert.ToInt32(this.txtID.Text);
                PersonaActual.Legajo = Convert.ToInt32(this.txtLegajo.Text);
                PersonaActual.Apellido = this.txtApellido.Text;
                PersonaActual.Nombre = this.txtNombre.Text;
                PersonaActual.FechaNacimiento = new DateTime(Convert.ToInt32(txtAnio.Text), Convert.ToInt32(txtMes.Text), Convert.ToInt32(txtDia.Text));
                PersonaActual.Direccion = this.txtDireccion.Text;
                PersonaActual.Telefono = this.txtTelefono.Text;
                PersonaActual.Email = this.txtEmail.Text;
                PersonaActual.IDPlan = Convert.ToInt32(this.cbxPlan.SelectedValue);
                PersonaActual.TipoPersona = this.cbxTipoPersona.SelectedText;
            }
        }

        public override void GuardarCambios()
        {
            this.MapearADatos();
            PersonaLogic PersonaLogic = new PersonaLogic();
            PersonaLogic.Save(PersonaActual);
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

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
