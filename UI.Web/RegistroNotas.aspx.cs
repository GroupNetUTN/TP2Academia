using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

namespace UI.Web
{
    public partial class RegistroNotas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LoadGridCursos();
            this.GridViewCursos.Columns[3].Visible = true;
            if (this.GridViewCursos.SelectedIndex == -1)
            {
                formPanel.Visible = false;
            }
        }

        AlumnoInscripcionLogic _logic;

        private AlumnoInscripcionLogic Logic
        {
            get
            {
                if (_logic == null)
                    _logic = new AlumnoInscripcionLogic();
                return _logic;
            }
        }

        AlumnoInscripcion _Entity;

        private AlumnoInscripcion Entity
        {
            get
            {
                if (_Entity != null)
                    return _Entity;
                else
                    return null;
            }
            set
            {
                _Entity = value;
            }
        }

        public Usuario UsuarioActual
        {
            get { return (Usuario)Session["UsuarioActual"]; }
        }

        private int SelectedIDCursos
        {
            get
            {
                if (this.ViewState["SelectedIDCursos"] != null)
                    return (int)this.ViewState["SelectedIDCursos"];
                else
                    return 0;
            }
            set
            {
                this.ViewState["SelectedIDCursos"] = value;
            }
        }

        private int SelectedIDInscripciones
        {
            get
            {
                if (this.ViewState["SelectedIDInscripciones"] != null)
                    return (int)this.ViewState["SelectedIDInscripciones"];
                else
                    return 0;
            }
            set
            {
                this.ViewState["SelectedIDInscripciones"] = value;
            }
        }

        private bool IsEntitySelected
        {
            get
            {
                return (this.SelectedIDInscripciones != 0);
            }
        }

        private void LoadGridCursos()
        {
            try
            {
                CursoLogic curlog = new CursoLogic();
                this.GridViewCursos.DataSource = curlog.GetCursosDocente(UsuarioActual.Persona.ID);
                this.GridViewCursos.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>window.alert('" + ex.Message + "');</script>");
            }
        }

        private void LoadGridAlumnos()
        {
            try
            {
                List<AlumnoInscripcion> alumnosInscriptos = new List<AlumnoInscripcion>();
                foreach (AlumnoInscripcion ai in Logic.GetAll())
                {
                    if (ai.Curso.ID == this.SelectedIDCursos)
                        alumnosInscriptos.Add(ai);
                }
                this.GridViewAlumnos.DataSource = alumnosInscriptos;
                this.GridViewAlumnos.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>window.alert('" + ex.Message + "');</script>");
            }
        }


        private void EnableForm(bool enable)
        {
            this.GridViewAlumnos.Visible = enable;
        }

        private void ClearForm()
        {
            this.GridViewCursos.SelectedIndex = -1;
            this.GridViewAlumnos.DataSource = null;
            this.GridViewAlumnos.DataBind();
            this.lblAlumnos.Visible = false;
        }

        private void DeleteEntity(int id)
        {
            try
            {
                this.Logic.Delete(id);
            }
            catch (Exception ex)
            {
                Response.Write("<script>window.alert('" + ex.Message + "');</script>");
            }
        }

        private void LoadEntity(AlumnoInscripcion ins)
        {
            ins.Nota = Convert.ToInt32(this.ddlNota.SelectedValue);
            ins.Condicion = this.ddlCondicion.SelectedValue;
        }

        private void SaveEntity(AlumnoInscripcion ins)
        {
            this.Logic.Save(ins);
        }

        protected void GridViewCursos_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedIDCursos = (int)this.GridViewCursos.SelectedValue;
            this.LoadGridAlumnos();
            this.formPanel.Visible = true;
        }

        protected void GridViewAlumnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedIDInscripciones = (int)this.GridViewAlumnos.SelectedValue;
        }


        protected void lbBorrarNota_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.Entity = Logic.GetOne(SelectedIDInscripciones);
                this.Entity.Nota = 0;
                this.Entity.Condicion = "Inscripto";
                this.Entity.State = BusinessEntity.States.Modified;
                this.SaveEntity(this.Entity);
                this.LoadGridAlumnos();
            }
        }

        private bool Validar()
        {
            if (this.SelectedIDInscripciones == 0)
                return false;
            else return true;
        }


        protected void lbAceptar_Click(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                this.Entity = Logic.GetOne(SelectedIDInscripciones);
                this.Entity.State = BusinessEntity.States.Modified;
                this.LoadEntity(this.Entity);
                this.SaveEntity(this.Entity);
            }
            this.LoadGridAlumnos();
        }

    }
}