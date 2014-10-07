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
    public partial class Inscripciones : Form
    {
        public Inscripciones(Usuario u)
        {
            InitializeComponent();
            this._UsuarioActual = u;
        }

        private Usuario _UsuarioActual;

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            InscripcionDesktop insdesktop = new InscripcionDesktop(_UsuarioActual);
            insdesktop.ShowDialog();
            /*this.Listar();*/
        }
    }
}
