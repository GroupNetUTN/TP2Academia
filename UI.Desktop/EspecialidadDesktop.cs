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
            _EspecialidadActual = EspecialidadNegocio.GetOne(ID);
            this.MapearDeDatos();
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
            this.MapearADatos();
            EspecialidadLogic esplogic = new EspecialidadLogic();
            esplogic.Save(_EspecialidadActual);
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

            if (txtDescripcion.Text == String.Empty)
            {
                EsValido = false;
                this.Notificar("Complete la descripción por favor.", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
