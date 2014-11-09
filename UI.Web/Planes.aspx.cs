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
    public partial class Planes : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LoadGrid();
            if (this.GridView.SelectedIndex == -1)
            {
                ShowButtons(false);
            }
        }

        PlanLogic _logic;

        private PlanLogic Logic
        {
            get
            {
                if (_logic == null)
                    _logic = new PlanLogic();
                return _logic;
            }
        }

        Plan _Entity;

        private Plan Entity
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

        private void ShowButtons(bool enable)
        {
            this.lbEliminar.Visible = enable;
            this.lbEditar.Visible = enable;
            this.lbNuevo.Visible = !enable;
        }

        private void LoadDDL()
        {
            EspecialidadLogic el = new EspecialidadLogic();
            this.ddlEspecialidades.DataSource = el.GetAll();
            this.ddlEspecialidades.DataTextField = "Descripcion";
            this.ddlEspecialidades.DataValueField = "ID";
            this.ddlEspecialidades.DataBind();
            ListItem init = new ListItem();
            init.Text = "--Seleccionar Especialidad--";
            init.Value = "-1";
            this.ddlEspecialidades.Items.Add(init);
            this.ddlEspecialidades.SelectedValue = "-1";
        }

        private void EnableForm(bool enable)
        {
            this.lblDescripcionPlan.Visible = enable;
            this.txtDescripcionPlan.Visible = enable;
            this.lblEspecialidad.Visible = enable;
            this.ddlEspecialidades.Visible = enable;
        }

        private void ClearForm()
        {
            this.txtDescripcionPlan.Text = string.Empty;
            this.GridView.SelectedIndex = -1;
        }

        private void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }

        private void LoadForm(int id)
        {
            this.Entity = this.Logic.GetOne(id);
            this.txtDescripcionPlan.Text = this.Entity.Descripcion;
            this.ddlEspecialidades.SelectedValue = this.Entity.Especialidad.ID.ToString();
        }

        private void LoadEntity(Plan plan)
        {
            plan.Descripcion = this.txtDescripcionPlan.Text;
            plan.Especialidad.ID = Convert.ToInt32(this.ddlEspecialidades.SelectedValue);
        }

        private void SaveEntity(Plan plan)
        {
            this.Logic.Save(plan);
        }

        private void ClearSession()
        {
            Session["SelectedID"] = null;
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.GridView.SelectedValue;
            this.ShowButtons(true);
        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.LoadDDL();
                this.formPanel.Visible = true;
                this.gridActionsPanel.Visible = false;
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
            this.LoadDDL();
            this.formPanel.Visible = true;
            this.gridActionsPanel.Visible = false;
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
                    this.Entity = new Plan();
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    this.ClearSession();
                    break;
            }

            this.formPanel.Visible = false;
            this.ShowButtons(false);
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.ClearForm();
            this.formPanel.Visible = false;
            this.gridActionsPanel.Visible = true;
            this.ShowButtons(false);
        }
    }
}