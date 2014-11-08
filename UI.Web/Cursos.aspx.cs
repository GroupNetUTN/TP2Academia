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
    public partial class Cursos : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LoadGrid();
        }

        CursoLogic _logic;

        private CursoLogic Logic
        {
            get
            {
                if (_logic == null)
                    _logic = new CursoLogic();
                return _logic;
            }
        }

        Curso _Entity;

        private Curso Entity
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

        Usuario _UsuarioActual;

        public Usuario UsuarioActual
        {
            get { return _UsuarioActual; }
            set { _UsuarioActual = value; }
        }

        private int SelectedID
        {
            get
            {
                if (this.ViewState["SelectedID"] != null)
                    return (int)this.ViewState["SelectedID"];
                else
                    return 0;
            }
            set
            {
                this.ViewState["SelectedID"] = value;
            }
        }

        private bool IsEntitySelected
        {
            get
            {
                return (this.SelectedID != 0);
            }
        }

        private void LoadGrid()
        {
            this.GridView.DataSource = Logic.GetAll();
            this.GridView.DataBind();
        }

        private void LoadDdlEspecialidades()
        {
            EspecialidadLogic el = new EspecialidadLogic();
            this.ddlEspecialidades.DataSource = el.GetAll();
            this.ddlEspecialidades.DataTextField = "Descripcion";
            this.ddlEspecialidades.DataValueField = "ID";
            this.ddlEspecialidades.DataBind();
            this.ddlEspecialidades.SelectedIndex = -1;
        }

        private void LoadDdlPlanes()
        {
            PlanLogic pl = new PlanLogic();
            List<Plan> planes = new List<Plan>();
            foreach (Plan p in pl.GetAll())
            {
                if (p.Especialidad.ID == Convert.ToInt32(this.ddlEspecialidades.SelectedValue))
                {
                    planes.Add(p);
                }
            }
            this.ddlPlanes.DataSource = planes;
            this.ddlPlanes.DataTextField = "Descripcion";
            this.ddlPlanes.DataValueField = "ID";
            this.ddlPlanes.DataBind();
            this.ddlPlanes.SelectedIndex = -1;
        }

        private void LoadDdlMaterias()
        {
            MateriaLogic ml = new MateriaLogic();
            List<Materia> materias = new List<Materia>();
            foreach (Materia m in ml.GetAll())
            {
                if (m.Plan.ID == Convert.ToInt32(this.ddlPlanes.SelectedValue))
                    materias.Add(m);
            }
            this.ddlMaterias.DataSource = materias;
            this.ddlMaterias.DataTextField = "Descripcion";
            this.ddlMaterias.DataValueField = "ID";
            this.ddlMaterias.DataBind();
            this.ddlMaterias.SelectedIndex = -1;
        }

        private void LoadDdlComisiones()
        {
            ComisionLogic cl = new ComisionLogic();
            List<Comision> comisiones = new List<Comision>();
            foreach (Comision c in cl.GetAll())
            {
                if (c.Plan.ID == Convert.ToInt32(this.ddlPlanes.SelectedValue))
                    comisiones.Add(c);
            }
            this.ddlComisiones.DataSource = comisiones;
            this.ddlComisiones.DataTextField = "Descripcion";
            this.ddlComisiones.DataValueField = "ID";
            this.ddlComisiones.DataBind();
            this.ddlComisiones.SelectedIndex = -1;
        }

        private void EnableForm(bool enable)
        {
            this.lblEspecialidad.Visible = enable;
            this.ddlEspecialidades.Visible = enable;
            this.lblPlan.Visible = enable;
            this.ddlPlanes.Visible = enable;
            this.lblMateria.Visible = enable;
            this.ddlMaterias.Visible = enable;
            this.lblComision.Visible = enable;
            this.ddlComisiones.Visible = enable;
            this.lblAnioCalendario.Visible = enable;
            this.txtAnioCalendario.Visible = enable;
            this.lblCupo.Visible = enable;
            this.txtCupo.Visible = enable;
        }

        private void ClearForm()
        {
            this.txtAnioCalendario.Text = string.Empty;
            this.txtCupo.Text = string.Empty;
        }

        private void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }

        private void LoadForm(int id)
        {
            this.Entity = this.Logic.GetOne(id);
            this.ddlEspecialidades.SelectedValue = this.Entity.Comision.Plan.Especialidad.ID.ToString();
            this.LoadDdlPlanes();
            this.ddlPlanes.SelectedValue = this.Entity.Comision.Plan.ID.ToString();
            this.LoadDdlMaterias();
            this.ddlMaterias.SelectedValue = this.Entity.Materia.ID.ToString();
            this.LoadDdlComisiones();
            this.ddlComisiones.SelectedValue = this.Entity.Comision.ID.ToString();
            this.txtAnioCalendario.Text = this.Entity.AnioCalendario.ToString();
            this.txtCupo.Text = this.Entity.Cupo.ToString();
        }

        private void LoadEntity(Curso curso)
        {
            curso.AnioCalendario = Convert.ToInt32(this.txtAnioCalendario.Text);
            curso.Cupo = Convert.ToInt32(this.txtCupo.Text);
            curso.Comision.Plan.Especialidad.ID = Convert.ToInt32(this.ddlEspecialidades.SelectedValue);
            curso.Comision.Plan.ID = Convert.ToInt32(this.ddlPlanes.SelectedValue);
            curso.Comision.ID = Convert.ToInt32(this.ddlComisiones.SelectedValue);
            curso.Materia.ID = Convert.ToInt32(this.ddlMaterias.SelectedValue);
        }

        private void SaveEntity(Curso curso)
        {
            this.Logic.Save(curso);
        }

        private void ClearSession()
        {
            Session["SelectedID"] = null;
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.GridView.SelectedValue;
        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.LoadDdlEspecialidades();
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.EnableForm(true);
                this.LoadForm(this.SelectedID);
            }
        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.DeleteEntity(this.SelectedID);
                this.LoadGrid();
            }
        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            this.LoadDdlEspecialidades();
            this.formPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            this.ClearForm();
            this.EnableForm(true);
        }

        protected void lbDocente_Click(object sender, EventArgs e)
        {

        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Modificacion:
                    if (Page.IsValid)
                    {
                        this.Entity = this.Logic.GetOne(this.SelectedID);
                        this.Entity.State = BusinessEntity.States.Modified;
                        this.LoadEntity(this.Entity);
                        this.SaveEntity(this.Entity);
                        this.LoadGrid();
                        this.ClearSession();
                    }
                    break;
                case FormModes.Alta:
                    this.Entity = new Curso();
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    this.ClearSession();
                    break;
            }

            this.formPanel.Visible = false;
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.ClearForm();
            this.formPanel.Visible = false;
        }

        protected void ddlEspecialidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadDdlPlanes();
            this.formPanel.Visible = true;
        }

        protected void ddlPlanes_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadDdlMaterias();
            this.LoadDdlComisiones();
            this.formPanel.Visible = true;
        }        
    }
}