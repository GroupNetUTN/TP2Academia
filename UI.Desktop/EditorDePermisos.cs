using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class EditorDePermisos : ApplicationForm
    {
        private int _IDUsuario;

        public EditorDePermisos(int idUsuario)
        {
            InitializeComponent();
            _IDUsuario = idUsuario;
        }

        private void cbxModulos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.cbxModulos.SelectedItem.ToString().Equals("Usuarios"))
            {
                this.chkAlta.Text = "Crear nuevos usuarios";
                this.chkAlta.Visible = true;
                this.chkBaja.Text = "Eliminar usuarios";
                this.chkBaja.Visible = true;
                this.chkConsulta.Text = "Acceso a usuarios creados";
                this.chkConsulta.Visible = true;
                this.chkModificacion.Text = "Editar usuarios";
                this.chkModificacion.Visible = true;
            }
            else if (this.cbxModulos.SelectedItem.ToString().Equals("Personas"))
            {
                this.chkAlta.Text = "Crear nuevas personas";
                this.chkAlta.Visible = true;
                this.chkBaja.Text = "Eliminar personas";
                this.chkBaja.Visible = true;
                this.chkConsulta.Text = "Acceso a personas creadas";
                this.chkConsulta.Visible = true;
                this.chkModificacion.Text = "Editar personas";
                this.chkModificacion.Visible = true;
            }
            else if (this.cbxModulos.SelectedItem.ToString().Equals("Planes"))
            {
                this.chkAlta.Text = "Crear nuevos planes";
                this.chkAlta.Visible = true;
                this.chkBaja.Text = "Eliminar planes";
                this.chkBaja.Visible = true;
                this.chkConsulta.Text = "Acceso a planes creados";
                this.chkConsulta.Visible = true;
                this.chkModificacion.Text = "Editar planes";
                this.chkModificacion.Visible = true;
            }
            else if (this.cbxModulos.SelectedItem.ToString().Equals("Materias"))
            {
                this.chkAlta.Text = "Crear nuevas materias";
                this.chkAlta.Visible = true;
                this.chkBaja.Text = "Eliminar materias";
                this.chkBaja.Visible = true;
                this.chkConsulta.Text = "Acceso a materias creadas";
                this.chkConsulta.Visible = true;
                this.chkModificacion.Text = "Editar materias";
                this.chkModificacion.Visible = true;
            }
            else if (this.cbxModulos.SelectedItem.ToString().Equals("Especialidades"))
            {
                this.chkAlta.Text = "Crear nuevas especialidades";
                this.chkAlta.Visible = true;
                this.chkBaja.Text = "Eliminar especialidades";
                this.chkBaja.Visible = true;
                this.chkConsulta.Text = "Acceso a especialidades creadas";
                this.chkConsulta.Visible = true;
                this.chkModificacion.Text = "Editar especialidades";
                this.chkModificacion.Visible = true;
            }
            else if (this.cbxModulos.SelectedItem.ToString().Equals("Cursos"))
            {
                this.chkAlta.Text = "Crear nuevos cursos";
                this.chkAlta.Visible = true;
                this.chkBaja.Text = "Eliminar cursos";
                this.chkBaja.Visible = true;
                this.chkConsulta.Text = "Acceso a cursos creados";
                this.chkConsulta.Visible = true;
                this.chkModificacion.Text = "Editar cursos";
                this.chkModificacion.Visible = true;
            }
            else if (this.cbxModulos.SelectedItem.ToString().Equals("Comisiones"))
            {
                this.chkAlta.Text = "Crear nuevas comisiones";
                this.chkAlta.Visible = true;
                this.chkBaja.Text = "Eliminar comisiones";
                this.chkBaja.Visible = true;
                this.chkConsulta.Text = "Acceso a comisiones creadas";
                this.chkConsulta.Visible = true;
                this.chkModificacion.Text = "Editar comisiones";
                this.chkModificacion.Visible = true;
            }
            else if (this.cbxModulos.SelectedItem.ToString().Equals("Inscripciones"))
            {
                this.chkAlta.Text = "Inscribirse a cursos";
                this.chkAlta.Visible = true;
                this.chkBaja.Text = "Eliminar inscripciones";
                this.chkBaja.Visible = true;
                this.chkConsulta.Text = "";
                this.chkConsulta.Visible = false;
                this.chkModificacion.Text = "";
                this.chkModificacion.Visible = false;
            }
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }
    }
}
