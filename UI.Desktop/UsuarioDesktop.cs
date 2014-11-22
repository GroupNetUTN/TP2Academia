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
using Util;

namespace UI.Desktop
{
    public partial class UsuarioDesktop : ApplicationForm
    {
        public UsuarioDesktop()
        {
            InitializeComponent();
        }

        private void UsuarioDesktop_Load(object sender, EventArgs e)
        {
            if (_UsuarioActual.Persona.TipoPersona == "No docente")
                this.dgvPermisos.Visible = true;
            else
                this.dgvPermisos.Visible = false;
        }

        Usuario _UsuarioActual;

        public UsuarioDesktop(ModoForm modo) : this()    
        {
            this._Modo = modo;
            _UsuarioActual = new Usuario();
            
        }

        public UsuarioDesktop(int ID, ModoForm modo) : this()
        {
            this._Modo = modo;
            UsuarioLogic UsuarioNegocio = new UsuarioLogic();
            try
            {
                _UsuarioActual = UsuarioNegocio.GetOne(ID);
                if (_UsuarioActual.Persona.TipoPersona == "No docente")
                {
                    this.dgvPermisos.AutoGenerateColumns = false;
                    ModuloUsuarioLogic logic = new ModuloUsuarioLogic();
                    dgvPermisos.DataSource = logic.GetAll(ID);
                }
                this.MapearDeDatos();
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Usuario UsuarioActual
        {
            get { return _UsuarioActual; }
            set { _UsuarioActual = value; }
        }

        public override void MapearDeDatos() 
        {
            this.txtID.Text = _UsuarioActual.ID.ToString();
            this.txtUsuario.Text = _UsuarioActual.NombreUsuario;
            this.txtClave.Text = _UsuarioActual.Clave;
            this.txtConfirmarClave.Text = _UsuarioActual.Clave;
            this.chkHabilitado.Checked = _UsuarioActual.Habilitado;
            this.txtPersona.Text = _UsuarioActual.Apellido + " " + _UsuarioActual.Nombre;

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
                    _UsuarioActual.State = Usuario.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    _UsuarioActual.State = Usuario.States.Unmodified;
                    break;
                case ModoForm.Alta:
                    _UsuarioActual.State = Usuario.States.New;
                    break;
                case ModoForm.Modificacion:
                    _UsuarioActual.State = Usuario.States.Modified;
                    break;
            }
            if (_Modo == ModoForm.Alta || _Modo == ModoForm.Modificacion)
            {
                if (_Modo == ModoForm.Modificacion)
                    _UsuarioActual.ID = Convert.ToInt32(this.txtID.Text);
                _UsuarioActual.NombreUsuario = this.txtUsuario.Text;
                _UsuarioActual.Clave = this.txtClave.Text;
                _UsuarioActual.Habilitado = this.chkHabilitado.Checked;
                foreach (DataGridViewRow row in this.dgvPermisos.Rows)
                {
                    _UsuarioActual.ModulosUsuarios.Add((ModuloUsuario)row.DataBoundItem);
                }
            }

        }

        public override void GuardarCambios() 
        {
            try
            {
                this.MapearADatos();
                UsuarioLogic userlogic = new UsuarioLogic();
                if(!userlogic.Existe(_UsuarioActual.NombreUsuario))
                    userlogic.Save(_UsuarioActual);
                else this.Notificar("Ya existe un Usuario con ese Nombre de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (this.txtClave.Text != this.txtConfirmarClave.Text)
            {
                EsValido = false;
                this.Notificar("La clave no coincide con la confirmacion de la misma", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (this.txtClave.Text.Length < 8)
            {
                EsValido = false;
                this.Notificar("La clave debe tener al menos 8 caracteres", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (this._UsuarioActual.Persona.ID == 0)
            {
                EsValido = false;
                this.Notificar("No se le asignó una Persona al Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnSeleccionarPersona_Click(object sender, EventArgs e)
        {
            SeleccionarPersona select = new SeleccionarPersona(_UsuarioActual);
            select.ShowDialog();
            this._UsuarioActual = select.UsuarioActual;
            this.txtPersona.Text = _UsuarioActual.Apellido + " " +  _UsuarioActual.Nombre;
            if (_UsuarioActual.Persona.TipoPersona == "No docente")
            {
                try
                {
                    this.dgvPermisos.AutoGenerateColumns = false;
                    ModuloUsuarioLogic logic = new ModuloUsuarioLogic();
                    dgvPermisos.DataSource = logic.GetAll(0);
                    dgvPermisos.Visible = true;
                }
                catch (Exception ex)
                {
                    this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                this.dgvPermisos.Visible = false;
        }
    }
}
