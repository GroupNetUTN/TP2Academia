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
    public partial class EspecialidadDesktop : ApplicationForm
    {
        public EspecialidadDesktop()
        {
            InitializeComponent();
        }

        private void UsuarioDesktop_Load(object sender, EventArgs e)
        {

        }

        Especialidad _EspecialidadActual;

        public EspecialidadDesktop(ModoForm modo) : this()    
        {
            this._Modo = modo;
        }

        public EspecialidadDesktop(int ID, ModoForm modo) : this()
        {
            this._Modo = modo;
            EspecialidadLogic EspecialidadNegocio = new EspecialidadLogic();
            try
            {
                _EspecialidadActual = EspecialidadNegocio.GetOne(ID);
                this.MapearDeDatos();
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Especialidad EspecialidadActual
        {
            get { return _EspecialidadActual; }
            set { _EspecialidadActual = value; }
        }

        public override void MapearDeDatos() 
        {
            this.txtID.Text = _EspecialidadActual.ID.ToString();
            this.txtDescripcion.Text = _EspecialidadActual.Descripcion;
           
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
                    _EspecialidadActual.State = Especialidad.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    _EspecialidadActual.State = Especialidad.States.Unmodified;
                    break;
                case ModoForm.Alta:
                    _EspecialidadActual = new Especialidad();
                    _EspecialidadActual.State = Especialidad.States.New;
                    break;
                case ModoForm.Modificacion:
                    _EspecialidadActual.State = Especialidad.States.Modified;
                    break;
            }
            if (_Modo == ModoForm.Alta || _Modo == ModoForm.Modificacion)
            {
                if (_Modo == ModoForm.Modificacion)
                    _EspecialidadActual.ID = Convert.ToInt32(this.txtID.Text);
                _EspecialidadActual.Descripcion = this.txtDescripcion.Text;
            }

        }

        public override void GuardarCambios() 
        {
            try
            {
                this.MapearADatos();
                EspecialidadLogic esplogic = new EspecialidadLogic();
                if (!esplogic.Existe(_EspecialidadActual.Descripcion))
                {
                    esplogic.Save(_EspecialidadActual);
                }
                else this.Notificar("Ya existe esta Especialidad",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override bool Validar()
        {
            Boolean EsValido = true;
            if (this.txtDescripcion.Text == String.Empty)
            {
                EsValido = false;
                this.Notificar("Es campo Descripcion es obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
