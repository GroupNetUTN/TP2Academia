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
        public Usuarios()
        {
            InitializeComponent();
            dgvUsuarios.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            UsuarioLogic ul = new UsuarioLogic();
            this.dgvUsuarios.DataSource = ul.GetAll();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
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
                int ID = ((Business.Entities.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
                UsuarioLogic user = new UsuarioLogic();
                user.Delete(ID);
                this.Listar();
            }
        }

        private void tsbPermisos_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
            EditorDePermisos ep = new EditorDePermisos(ID);
            ep.ShowDialog();
        }

        private void tsbAsignarPermisos_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
            PermisosUsuarios pu = new PermisosUsuarios(ID);
            pu.ShowDialog();
            PermisosPersonas pp = new PermisosPersonas(ID);
            pp.ShowDialog();
            PermisosPlanes pplanes = new PermisosPlanes(ID);
            pplanes.ShowDialog();
            PermisosMaterias pm = new PermisosMaterias(ID);
            pm.ShowDialog();
            PermisosEspecialidades pe = new PermisosEspecialidades(ID);
            pe.ShowDialog();
            PermisosCursos pc = new PermisosCursos(ID);
            pc.ShowDialog();
            PermisosComisiones pcomi = new PermisosComisiones(ID);
            pcomi.ShowDialog();
            PermisosInscripciones pi = new PermisosInscripciones(ID);
            pi.ShowDialog();
        }
    }
}