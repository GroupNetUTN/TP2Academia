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
    public partial class Usuarios : ApplicationForm
    {
        private Usuario _UsuarioActual;

        public Usuario UsuarioActual
        {
            get { return _UsuarioActual; }
            set { _UsuarioActual = value; }
        }

        public Usuarios(Usuario us)
        {
            InitializeComponent();
            UsuarioActual = us;
            dgvUsuarios.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            try
            {
                UsuarioLogic ul = new UsuarioLogic();
                this.dgvUsuarios.DataSource = ul.GetAll();
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            foreach (ModuloUsuario mu in UsuarioActual.ModulosUsuarios)
            {
                if (mu.Modulo.Descripcion == "Usuarios")
                {
                    this.dgvUsuarios.Visible = mu.PermiteConsulta;
                    this.tsbNuevo.Visible = mu.PermiteAlta;
                    this.tsbEliminar.Visible = mu.PermiteBaja;
                    this.tsbEditar.Visible = mu.PermiteModificacion;
                }
            }
            this.Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            UsuarioDesktop UserDesktop = new UsuarioDesktop(ApplicationForm.ModoForm.Alta);
            UserDesktop.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
            UsuarioDesktop UserDesktop = new UsuarioDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            UserDesktop.ShowDialog();
            this.Listar();

        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            var rta = MessageBox.Show("¿Esta seguro que desea eliminar el usuario?", "Atencion", MessageBoxButtons.YesNo);
            if (rta == DialogResult.Yes)
            {
                try
                {
                    int ID = ((Business.Entities.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
                    UsuarioLogic user = new UsuarioLogic();
                    user.Delete(ID);
                    this.Listar();
                }
                catch (Exception ex)
                {
                    this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}