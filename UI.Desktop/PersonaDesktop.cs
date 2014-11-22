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
    public partial class PersonaDesktop : ApplicationForm
    {
        public PersonaDesktop()
        {
            InitializeComponent();
        }

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
            this.LlenarComboEspecialidades();
        }

        public PersonaDesktop(int ID, ModoForm modo) : this()
        {
            this._Modo = modo;
            PersonaLogic PersonaNegocio = new PersonaLogic();
            try
            {
                _PersonaActual = PersonaNegocio.GetOne(ID);
                this.LlenarComboEspecialidades();
                this.MapearDeDatos();
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LlenarComboEspecialidades()
        {
            try
            {
                EspecialidadLogic EspecialidadNegocio = new EspecialidadLogic();
                cbxEspecialidades.DataSource = EspecialidadNegocio.GetAll();
                cbxEspecialidades.DisplayMember = "Descripcion";
                cbxEspecialidades.ValueMember = "ID";
                this.cbxEspecialidades.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LlenarComboPlanes()
        {
            try
            {
                PlanLogic pl = new PlanLogic();
                List<Plan> planes = new List<Plan>();
                foreach (Plan p in pl.GetAll())
                {
                    if (p.Especialidad.ID == Convert.ToInt32(cbxEspecialidades.SelectedValue))
                    {
                        planes.Add(p);
                    }
                }
                cbxPlanes.DataSource = planes;
                cbxPlanes.DisplayMember = "Descripcion";
                cbxPlanes.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            this.cbxTipoPersona.SelectedItem = PersonaActual.TipoPersona;
            this.cbxEspecialidades.SelectedValue = PersonaActual.Plan.Especialidad.ID;
            this.LlenarComboPlanes();
            this.cbxPlanes.SelectedValue = PersonaActual.Plan.ID;

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
                PersonaActual.Plan.ID = Convert.ToInt32(this.cbxPlanes.SelectedValue);
                PersonaActual.TipoPersona = this.cbxTipoPersona.SelectedItem.ToString();
            }
        }

        public override void GuardarCambios()
        {
            try
            {
                this.MapearADatos();
                PersonaLogic PersonaLogic = new PersonaLogic();
                if(!PersonaLogic.Existe(_PersonaActual.Legajo))
                    PersonaLogic.Save(PersonaActual);
                else this.Notificar("Ya existe una Persona con este Legajo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override bool Validar()
        {
            Boolean EsValido = true;
            if (this.txtLegajo.Text == String.Empty || this.txtApellido.Text == String.Empty || this.txtNombre.Text == String.Empty ||
                this.txtDia.Text == "dd" || this.txtMes.Text == "mm"|| this.txtAnio.Text == "aaaa" ||
                this.cbxEspecialidades.SelectedItem == null || this.cbxPlanes.SelectedItem == null ||
                this.cbxTipoPersona.SelectedItem == null)
            {
                EsValido = false;
                this.Notificar("Falta completar algunos campos obligatorios", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void cbxEspecialidades_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.LlenarComboPlanes();
        }


    }
}
