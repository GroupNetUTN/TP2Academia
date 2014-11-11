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
    public partial class DocentesCursos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LoadGrid();
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

        private bool IsEntitySelected
        {
            get
            {
                return (this.SelectedIDDocenteCurso != 0);
            }
        }

        private void LoadGridDocentes()
        {
            PersonaLogic pl = new PersonaLogic();
            this.GridViewDocentes.DataSource = pl.GetDocentes();
            this.GridViewDocentes.DataBind();
        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = true;
            this.gridActionsPanel.Visible = false;
            this.LoadGridDocentes();
            this.GridView.Columns[3].Visible = false;
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedIDCurso = (int)this.GridView.SelectedValue;
            this.ShowButtons(true);
        }

        private void ShowButtons(bool enable)
        {
            this.lbEliminar.Visible = enable;
            this.lbEditar.Visible = enable;
        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {

        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {

        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {

        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {

        }
    }
}