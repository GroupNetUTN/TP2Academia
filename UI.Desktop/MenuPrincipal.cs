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
            Especialidades esp = new Especialidades();
            esp.ShowDialog();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            Usuarios user = new Usuarios();
            user.ShowDialog();
        }

        private void btnPlanes_Click(object sender, EventArgs e)
        {
            Planes planes = new Planes();
            planes.ShowDialog();
        }

        private void btnPersonas_Click(object sender, EventArgs e)
        {
            Personas per = new Personas();
            per.ShowDialog();
        }

        private void btnComisiones_Click(object sender, EventArgs e)
        {
            Comisiones comi = new Comisiones();
            comi.ShowDialog();
        }

        private void btnMaterias_Click(object sender, EventArgs e)
        {
            Materias mat = new Materias();
            mat.ShowDialog();
        }

        private void btnCursos_Click(object sender, EventArgs e)
        {
            Cursos cur = new Cursos();
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
    }
}
