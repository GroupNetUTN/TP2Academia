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
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal(Usuario u)
        {
            InitializeComponent();
            this._UsuarioActual = u;
        }

        private Usuario _UsuarioActual;

        public Usuario UsuarioActual
        {
            get { return _UsuarioActual; }
        }

        private void btnEspecialidades_Click(object sender, EventArgs e)
        {
            Especialidades esp = new Especialidades(UsuarioActual);
            esp.ShowDialog();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            Usuarios user = new Usuarios(UsuarioActual);
            user.ShowDialog();
        }

        private void btnPlanes_Click(object sender, EventArgs e)
        {
            Planes planes = new Planes(UsuarioActual);
            planes.ShowDialog();
        }

        private void btnPersonas_Click(object sender, EventArgs e)
        {
            Personas per = new Personas(UsuarioActual);
            per.ShowDialog();
        }

        private void btnComisiones_Click(object sender, EventArgs e)
        {
            Comisiones comi = new Comisiones(UsuarioActual);
            comi.ShowDialog();
        }

        private void btnMaterias_Click(object sender, EventArgs e)
        {
            Materias mat = new Materias(UsuarioActual);
            mat.ShowDialog();
        }

        private void btnCursos_Click(object sender, EventArgs e)
        {
            Cursos cur = new Cursos(UsuarioActual);
            cur.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInscripcion_Click(object sender, EventArgs e)
        {
            Inscripciones ins = new Inscripciones(_UsuarioActual);
            ins.ShowDialog();
        }

        private void btnRegistroNotas_Click(object sender, EventArgs e)
        {
            RegistroNotas reg = new RegistroNotas(_UsuarioActual);
            reg.ShowDialog();
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Login login = new Login();
            if (login.ShowDialog() == DialogResult.OK)
            {
                this._UsuarioActual = login.UsuarioActual;
                this.Visible = true;
            }
            else
            {
                this.Close();
            }
            
           
        }
    }
}
