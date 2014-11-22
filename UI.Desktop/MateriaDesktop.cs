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
    public partial class MateriaDesktop : ApplicationForm
    {
        public MateriaDesktop()
        {
            InitializeComponent();
        }

        private void MateriaDesktop_Load(object sender, EventArgs e)
        {

        }

        Materia _MateriaActual;

        public Materia MateriaActual
        {
            get { return _MateriaActual; }
            set { _MateriaActual = value; }
        }

        public MateriaDesktop(ModoForm modo)
            : this()
        {
            this._Modo = modo;
            this.LlenarComboEspecialidades();
        }

        public MateriaDesktop(int ID, ModoForm modo)
            : this()
        {
            this._Modo = modo;
            MateriaLogic MateriaNegocio = new MateriaLogic();
            try
            {
                _MateriaActual = MateriaNegocio.GetOne(ID);
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
            this.txtID.Text = MateriaActual.ID.ToString();
            this.txtDescripcion.Text = MateriaActual.Descripcion;
            this.txtHsSemanales.Text = MateriaActual.HSSemanales.ToString();
            this.txtHsTotales.Text = MateriaActual.HSTotales.ToString();
            this.cbxEspecialidades.SelectedValue = MateriaActual.Plan.Especialidad.ID;
            this.LlenarComboPlanes();
            this.cbxPlanes.SelectedValue = MateriaActual.Plan.ID;

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
                    _MateriaActual.State = Materia.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    _MateriaActual.State = Materia.States.Unmodified;
                    break;
                case ModoForm.Alta:
                    _MateriaActual = new Materia();
                    _MateriaActual.State = Materia.States.New;
                    break;
                case ModoForm.Modificacion:
                    _MateriaActual.State = Materia.States.Modified;
                    break;
            }
            if (_Modo == ModoForm.Alta || _Modo == ModoForm.Modificacion)
            {
                if (_Modo == ModoForm.Modificacion)
                    _MateriaActual.ID = Convert.ToInt32(this.txtID.Text);
                _MateriaActual.Descripcion = this.txtDescripcion.Text;
                _MateriaActual.HSSemanales = Convert.ToInt32(this.txtHsSemanales.Text);
                _MateriaActual.HSTotales = Convert.ToInt32(this.txtHsTotales.Text);
                _MateriaActual.Plan.ID = Convert.ToInt32(this.cbxPlanes.SelectedValue);
            }
        }

        public override void GuardarCambios()
        {
            try
            {
                this.MapearADatos();
                MateriaLogic materialogic = new MateriaLogic();
                if (!materialogic.Existe(_MateriaActual.Plan.ID, _MateriaActual.Descripcion))
                {
                    materialogic.Save(_MateriaActual);
                }
                else this.Notificar("Ya existe esta Materia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override bool Validar()
        {
            Boolean EsValido = true;
            if (this.cbxEspecialidades.SelectedItem == null || this.cbxPlanes.SelectedItem == null)
                EsValido = false;
            if (this.txtDescripcion.Text == String.Empty || this.txtHsSemanales.Text == String.Empty || this.txtHsTotales.Text == String.Empty)
                EsValido = false;
            if (EsValido == false)
                 this.Notificar("Todos los campos son obligatorios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return EsValido;
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                this.GuardarCambios();
                this.Close();
            }
        }

        private void cbxEspecialidades_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.LlenarComboPlanes();
        }
    }
}