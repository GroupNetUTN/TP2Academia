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
    public partial class Materias : BasePage
    {
       protected void Page_Load(object sender, EventArgs e)
        {
            this.LoadGrid();
        }

        MateriaLogic _logic;

        private MateriaLogic Logic
        {
            get
            {
                if (_logic == null)
                    _logic = new MateriaLogic();
                return _logic;
            }
        }

        Materia _Entity;

        private Materia Entity
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
            this.GridView.DataSource = this.Logic.GetAll();
            this.GridView.DataBind();
        }

        private void LoadDdlEspecialidades()
        {
            EspecialidadLogic el = new EspecialidadLogic();
            this.ddlEspecialidades.DataSource = el.GetAll();
            this.ddlEspecialidades.DataTextField = "Descripcion";
            this.ddlEspecialidades.DataValueField = "ID";
            this.ddlEspecialidades.DataBind();
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
        }

        private void EnableForm(bool enable)
        {
            this.lblDescripcion.Visible = enable;
            this.txtDescripcion.Visible = enable;
            this.lblHsSemanales.Visible = enable;
            this.txtHsSemanales.Visible = enable;
            this.lblHsTotales.Visible = enable;
            this.txtHsTotales.Visible = enable;
            this.lblEspecialidad.Visible = enable;
            this.ddlEspecialidades.Visible = enable;
            this.lblPlan.Visible = enable;
            this.ddlPlanes.Visible = enable;
        }

        private void ClearForm()
        {
            this.txtDescripcion.Text = string.Empty;
            this.txtHsSemanales.Text = string.Empty;
            this.txtHsTotales.Text = string.Empty;
        }

        private void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }

        private void LoadForm(int id)
        {
            this.Entity = this.Logic.GetOne(id);
            this.txtDescripcion.Text = this.Entity.Descripcion;
            this.txtHsSemanales.Text = this.Entity.HSSemanales.ToString();
            this.txtHsTotales.Text = this.Entity.HSTotales.ToString();
            this.ddlEspecialidades.SelectedValue = this.Entity.Plan.Especialidad.ID.ToString();
            if (FormMode == FormModes.Modificacion)
                this.LoadDdlPlanes();
            this.ddlPlanes.SelectedValue = this.Entity.Plan.ID.ToString();
        }

        private void LoadEntity(Materia mat)
        {
            mat.Descripcion = this.txtDescripcion.Text;
            mat.HSSemanales = Convert.ToInt32(this.txtHsSemanales.Text);
            mat.HSTotales = Convert.ToInt32(this.txtHsTotales.Text);
            mat.Plan.Especialidad.ID = Convert.ToInt32(this.ddlEspecialidades.SelectedValue);
            mat.Plan.ID = Convert.ToInt32(this.ddlPlanes.SelectedValue);
        }

        private void SaveEntity(Materia mat)
        {
            this.Logic.Save(mat);
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
                    this.Entity = new Materia();
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
    }
}