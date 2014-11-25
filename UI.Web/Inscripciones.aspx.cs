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
    public partial class Inscripciones : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LoadGridInscripciones();
            this.GridViewInscripciones.Columns[5].Visible = true;
            if (this.GridViewInscripciones.SelectedIndex == -1)
            {
                this.lbEliminar.Visible = false;
                gridActionsPanel.Visible = true;
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

        private int SelectedIDMaterias
        {
            get
            {
                if (this.ViewState["SelectedIDMaterias"] != null)
                    return (int)this.ViewState["SelectedIDMaterias"];
                else
                    return 0;
            }
            set
            {
                this.ViewState["SelectedIDMaterias"] = value;
            }
        }

        private int SelectedIDComisiones
        {
            get
            {
                if (this.ViewState["SelectedIDComisiones"] != null)
                    return (int)this.ViewState["SelectedIDComisiones"];
                else
                    return 0;
            }
            set
            {
                this.ViewState["SelectedIDComisiones"] = value;
            }
        }

        private bool IsEntitySelected
        {
            get
            {
                return (this.SelectedIDInscripciones != 0);
            }
        }

        private void LoadGridInscripciones()
        {
            try
            {
                this.GridViewInscripciones.DataSource = Logic.GetAll(UsuarioActual.Persona.ID);
                this.GridViewInscripciones.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>window.alert('" + ex.Message + "');</script>");
            }
        }

        private void LoadGridMaterias()
        {
            try
            {
                MateriaLogic matlog = new MateriaLogic();
                this.GridViewMaterias.DataSource = matlog.GetMateriasParaInscripcion(UsuarioActual.Persona.Plan.ID, UsuarioActual.Persona.ID);
                this.GridViewMaterias.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>window.alert('" + ex.Message + "');</script>");
            }
        }

        private void LoadGridComisiones()
        {
            try
            {
                ComisionLogic comlog = new ComisionLogic();
                this.GridViewComisiones.DataSource = comlog.GetComisionesDisponibles(SelectedIDMaterias);
                this.GridViewComisiones.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>window.alert('" + ex.Message + "');</script>");
            }
        }

        private void EnableForm(bool enable)
        {
            this.GridViewMaterias.Visible = enable;
            this.GridViewComisiones.Visible = enable;
        }

        private void ClearForm()
        {
            this.GridViewInscripciones.SelectedIndex = -1;
            this.GridViewMaterias.SelectedIndex = -1;
            this.GridViewComisiones.DataSource = null;
            this.GridViewComisiones.DataBind();
            this.lblComisiones.Visible = false;
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
            try
            {
                ins.Alumno = UsuarioActual.Persona;
                ins.Condicion = "Inscripto";
                CursoLogic curlog = new CursoLogic();
                foreach (Curso c in curlog.GetAll())
                {
                    if (c.Comision.ID == SelectedIDComisiones && c.Materia.ID == SelectedIDMaterias)
                    {
                        c.Cupo--;
                        ins.Curso = c;
                        ins.Curso.State = BusinessEntity.States.Modified;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>window.alert('" + ex.Message + "');</script>");
            }
        }

        private void SaveEntity(AlumnoInscripcion ins)
        {
            try
            {
                this.Logic.Save(ins);
            }
            catch (Exception ex)
            {
                Response.Write("<script>window.alert('" + ex.Message + "');</script>");
            }
        }

        private void ClearSession()
        {
            Session["SelectedID"] = null;
        }

        protected void GridViewInscripciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedIDInscripciones = (int)this.GridViewInscripciones.SelectedValue;
            this.lbEliminar.Visible = true;
        }

        protected void GridViewMaterias_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedIDMaterias = (int)this.GridViewMaterias.SelectedValue;
            this.LoadGridComisiones();
            this.lblComisiones.Visible = true;
        }

        protected void GridViewComisiones_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedIDComisiones = (int)this.GridViewComisiones.SelectedValue;
        }

        protected void lbEliminar_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.DeleteEntity(this.SelectedIDInscripciones);
                this.LoadGridInscripciones();
                this.lbEliminar.Visible = false;
            }
        }

        protected void lbNuevo_Click(object sender, EventArgs e)
        {
            this.GridViewInscripciones.Columns[5].Visible = false;
            this.formPanel.Visible = true;
            this.gridActionsPanel.Visible = false;
            this.GridViewMaterias.Visible = true;
            this.LoadGridMaterias();
            this.ClearForm();
            this.EnableForm(true);
        }

        private bool Validar()
        {
            if (this.SelectedIDComisiones == 0 || this.SelectedIDMaterias == 0)
                return false;
            else return true;
        }


        protected void lbAceptar_Click(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                this.Entity = new AlumnoInscripcion();
                this.LoadEntity(this.Entity);
                if (!Logic.Existe(Entity.Alumno.ID, Entity.Curso.ID))
                {
                    this.SaveEntity(Entity);
                }
                else
                    Response.Write("<script>window.alert('Ya se encuentra inscripto a ese cursado.');</script>");
            }
            this.ClearSession();
            this.ClearForm();
            this.formPanel.Visible = false;
            this.gridActionsPanel.Visible = true;
            this.lbEliminar.Visible = false;
            this.LoadGridInscripciones();
        }

        protected void lbCancelar_Click(object sender, EventArgs e)
        {
            this.ClearForm();
            this.formPanel.Visible = false;
            this.gridActionsPanel.Visible = true;
            this.lbEliminar.Visible = false;
        }
    }
}