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
    public partial class formLogin : ApplicationForm
    {
        public formLogin()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bool Existe = false;
            bool Habilitado = false;
            UsuarioLogic user = new UsuarioLogic();
            foreach (Usuario u in user.GetAll())
                if (u.NombreUsuario == this.txtUsuario.Text && u.Clave == this.txtContraseña.Text)
                {
                    Existe = true;
                    Habilitado = u.Habilitado;
                }
            if (Existe)
            {
                if(Habilitado)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    this.Notificar("El Usuario no está habilitado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                this.Notificar("Usuario o contraseña incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
