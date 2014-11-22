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
    public partial class DocentesCursos : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LoadGrid();
            this.GridView.Columns[3].Visible = true;
            if (this.GridView.SelectedIndex == -1)
            {
                ShowButtons(false);
                gridActionsPanel.Visible = true;
            }
        }

        private void ShowButtons(bool enable)
        {
            this.lbEliminar.Visible = enable;
            this.lbEditar.Visible = enable;
        }

        DocenteCursoLogic _logic;

        private DocenteCursoLogic Logic
        {
            get
            {
                if (_logic == null)
                    _logic = new DocenteCursoLogic();
                return _logic;
            }
        }

        DocenteCurso _Entity;

        private DocenteCurso Entity
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

        private int SelectedIDCurso
        {
            get
            {
                if (Session["ID_Curso"] != null)
                    return (int)this.Session["ID_Curso"];
                else
                    return 0;
            }
            set
            {
                this.Session["ID_Curso"] = value;
            }
        }

        private int SelectedIDDocenteCurso
        {
            get
            {
                if (this.ViewState["ID_DocenteCurso"] != null)
                    return (int)this.ViewState["ID_DocenteCurso"];
                else
                    return 0;
            }
            set
            {
                this.ViewState["ID_DocenteCurso"] = value;
            }
        }

        private int SelectedIDDocente
        {
            get
            {
                if (this.ViewState["ID_Docente"] != null)
                    return (int)this.ViewState["ID_Docente"];
                else
                    return 0;
            }
            set
            {
                this.ViewState["ID_Docente"] = value;
            }
        }

        private bool IsEntitySelected
        {
            get
            {
                return (this.SelectedIDDocenteCurso != 0);
            }
        }

        private void LoadGrid()
        {
            DocenteCursoLogic dcl = new DocenteCursoLogic();
            List<DocenteCurso> docentes = new List<DocenteCurso>();
            foreach (DocenteCurso dc in dcl.GetAll())
            {
                if (dc.Curso.ID == this.SelectedIDCurso)
                    docentes.Add(dc);
            }
            GridView.DataSource = docentes;
            GridView.DataBind();
        }

        private void LoadGridDocentes()
        {
            PersonaLogic pl = new PersonaLogic();
            this.GridViewDocentes.DataSource = pl.GetDocentes();
            this.GridViewDocentes.DataBind();
        }

        private void EnableForm(bool enable)
        {
            this.lblCargo.Visible = enable;
            this.ddlCargo.Visible = enable;
        }

        private void ClearForm()
        {
            this.ddlCargo.SelectedValue = "Mensaje";
            this.GridView.SelectedIndex = -1;
            this.GridViewDocentes.SelectedIndex = -1;
        }

        private void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }

        private void LoadForm(int id)
        {
            this.Entity = this.Logic.GetOne(id);
            this.ddlCargo.SelectedValue = this.Entity.Cargo;    
        }

        private void LoadEntity(DocenteCurso docCurso)
        {
            docCurso.Cargo = this.ddlCargo.SelectedValue;
            if (this.FormMode == FormModes.Alta)
            {
                docCurso.Curso.ID = this.SelectedIDCurso;
                docCurso.Docente.ID = this.SelectedIDDocente;
            }
        }

        private void SaveEntity(DocenteCurso docCurso)
        {
            if (!Logic.Existe(docCurso.Curso.ID, docCurso.Docente.ID, docCurso.Cargo))
            {
                this.Logic.Save(docCurso);
            }
            else
                Response.Write("<script>window.alert('Ya se asignó a ese docente, en este curso, para ese cargo.');</script>");
        }

        private void ClearSession()
        {
            Session["SelectedID"] = null;
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedIDDocenteCurso = (int)this.GridView.SelectedValue;
            this.ShowButtons(true);
        }

        protected void gridViewDocentes_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedIDDocente = (int)this.GridViewDocentes.SelectedValue;
            this.ShowButtons(true);
        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.gridActionsPanel.Visible = false;
                this.GridViewDocentes.Visible = false;
                this.FormMode = FormModes.Modificacion;
                this.EnableForm(true);
                this.LoadForm(this.SelectedIDDocenteCurso);
            }
        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.DeleteEntity(this.SelectedIDDocenteCurso);
                this.LoadGrid();
                this.ShowButtons(false);
            }
        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            this.GridView.Columns[3].Visible = false;
            this.formPanel.Visible = true;
            this.gridActionsPanel.Visible = false;
            this.GridViewDocentes.Visible = true;
            this.LoadGridDocentes();
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
                        this.Entity = this.Logic.GetOne(this.SelectedIDDocenteCurso);
                        this.Entity.State = BusinessEntity.States.Modified;
                        this.LoadEntity(this.Entity);
                        this.SaveEntity(this.Entity);
                        this.LoadGrid();
                        this.ClearSession();
                    }
                    break;
                case FormModes.Alta:
                    this.Entity = new DocenteCurso();
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    this.ClearSession();
                    break;
            }
            this.ClearForm();
            this.formPanel.Visible = false;
            this.gridActionsPanel.Visible = true;
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