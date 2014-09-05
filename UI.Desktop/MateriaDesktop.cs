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
            _MateriaActual = MateriaNegocio.GetOne(ID);
            this.LlenarComboEspecialidades();
            this.MapearDeDatos();
        }

        private void LlenarComboEspecialidades()
        {
            EspecialidadLogic EspecialidadNegocio = new EspecialidadLogic();
            cbxEspecialidades.DataSource = EspecialidadNegocio.GetAll();
            cbxEspecialidades.DisplayMember = "Descripcion";
            cbxEspecialidades.ValueMember = "ID";
        }

        private void LlenarComboPlanes()
        {
            PlanLogic pl = new PlanLogic();
            List<Plan> planes = new List<Plan>();
            foreach (Plan p in pl.GetAll())
            {
                if (p.IDEspecialidad == Convert.ToInt32(cbxEspecialidades.SelectedValue))
                {
                    planes.Add(p);
                }
            }
            cbxPlanes.DataSource = planes;
            cbxPlanes.DisplayMember = "Descripcion";
            cbxPlanes.ValueMember = "ID";
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = MateriaActual.ID.ToString();
            this.txtDescripcion.Text = MateriaActual.Descripcion;
            this.txtHsSemanales.Text = MateriaActual.HSSemanales.ToString();
            this.txtHsTotales.Text = MateriaActual.HSTotales.ToString();
            PlanLogic plan = new PlanLogic();
            this.cbxEspecialidades.SelectedValue = plan.GetOne(MateriaActual.IDPlan).IDEspecialidad;
            this.LlenarComboPlanes();
            this.cbxPlanes.SelectedValue = MateriaActual.IDPlan;

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
                _MateriaActual.IDPlan = Convert.ToInt32(this.cbxPlanes.SelectedValue);
            }
        }

        public override void GuardarCambios()
        {
            this.MapearADatos();
            MateriaLogic materialogic = new MateriaLogic();
            materialogic.Save(_MateriaActual);
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

