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
    public partial class ComisionDesktop : ApplicationForm
    {
        public ComisionDesktop()
        {
            InitializeComponent();
        }

        private void ComisionDesktop_Load(object sender, EventArgs e)
        {
            PlanLogic PlanNegocio = new PlanLogic();
            cbxPlan.DataSource = PlanNegocio.GetAll();
            cbxPlan.DisplayMember = "Descripcion";
            cbxPlan.ValueMember = "ID";
        }

        Comision _ComisionActual;

        public Comision ComisionActual
        {
            get { return _ComisionActual; }
            set { _ComisionActual = value; }
        }

        public ComisionDesktop(ModoForm modo) : this()    
        {
            this._Modo = modo;
        }

        public ComisionDesktop(int ID, ModoForm modo) : this()
        {
            this._Modo = modo;
            ComisionLogic ComisionNegocio = new ComisionLogic();
            _ComisionActual = ComisionNegocio.GetOne(ID);
            this.MapearDeDatos();
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = ComisionActual.ID.ToString();
            this.txtDescripcion.Text = ComisionActual.Descripcion;
            this.txtAniosEspecialidad.Text = ComisionActual.AnioEspecialidad.ToString();

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
                    ComisionActual.State = Comision.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    ComisionActual.State = Comision.States.Unmodified;
                    break;
                case ModoForm.Alta:
                    ComisionActual = new Comision();
                    ComisionActual.State = Comision.States.New;
                    break;
                case ModoForm.Modificacion:
                    ComisionActual.State = Comision.States.Modified;
                    break;
            }
            if (_Modo == ModoForm.Alta || _Modo == ModoForm.Modificacion)
            {
                if (_Modo == ModoForm.Modificacion)
                    ComisionActual.ID = Convert.ToInt32(this.txtID.Text);
                ComisionActual.Descripcion = this.txtDescripcion.Text;
                ComisionActual.AnioEspecialidad = Convert.ToInt32(this.txtAniosEspecialidad.Text);
                ComisionActual.IDPlan = Convert.ToInt32(this.cbxPlan.SelectedValue);
            }
        }

        public override void GuardarCambios()
        {
            this.MapearADatos();
            ComisionLogic comisionLogic = new ComisionLogic();
            comisionLogic.Save(ComisionActual);
        }

        public override bool Validar()
        {
            Boolean EsValido = true;
            //foreach (Control oControls in this.Controls)
            //{
            //    if (oControls is TextBox) /*& oControls.Text == String.Empty*/
            //    {
            //        MessageBox.Show("ERROR");
            //        EsValido = false;
            //        this.Notificar("Todos los campos son obligatorios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}

            if (txtDescripcion.Text == String.Empty||txtAniosEspecialidad.Text==String.Empty)
            {
                EsValido = false;
                this.Notificar("Complete todos los campos por favor.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
