using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;
using CrystalDecisions.Shared;

namespace UI.Web
{
    public partial class ReporteCursosViewer : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            this.LoadDdlEspecialidades();
        }

        private void LoadDdlEspecialidades()
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
            ListItem init = new ListItem();
            init.Text = "--Seleccionar Plan--";
            init.Value = "-1";
            this.ddlPlanes.Items.Add(init);
            this.ddlPlanes.SelectedValue = "-1";
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
            ListItem init = new ListItem();
            init.Text = "--Seleccionar Materia--";
            init.Value = "-1";
            this.ddlMaterias.Items.Add(init);
            this.ddlMaterias.SelectedValue = "-1";
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
            ListItem init = new ListItem();
            init.Text = "--Seleccionar Comisión--";
            init.Value = "-1";
            this.ddlComisiones.Items.Add(init);
            this.ddlComisiones.SelectedValue = "-1";
        }

        private void LoadDdlAnios()
        {
            CursoLogic cl = new CursoLogic();
            List<Curso> cursos = new List<Curso>();
            foreach (Curso c in cl.GetAll())
            {
                if (c.Materia.ID == Convert.ToInt32(this.ddlMaterias.SelectedValue) && c.Comision.ID == Convert.ToInt32(this.ddlComisiones.SelectedValue))
                    cursos.Add(c);
            }
            this.ddlAnios.DataSource = cursos;
            this.ddlAnios.DataTextField = "AnioCalendario";
            this.ddlAnios.DataValueField = "ID";
            this.ddlAnios.DataBind();
            ListItem init = new ListItem();
            init.Text = "--Seleccionar Año--";
            init.Value = "-1";
            this.ddlAnios.Items.Add(init);
            this.ddlAnios.SelectedValue = "-1";
        }

        protected void ddlEspecialidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadDdlPlanes();
        }

        protected void ddlPlanes_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadDdlMaterias();
            this.LoadDdlComisiones();
        }

        protected void ddlComisiones_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadDdlAnios();
        }

        protected void ddlAnios_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lbGenerarInforme.Visible = true;
        }

        protected void lbGenerarInforme_Click(object sender, EventArgs e)
        {
            ParameterField parametro = new ParameterField();
            ParameterFields parametros = new ParameterFields();
            parametro.ParameterValueType = ParameterValueKind.NumberParameter;
            parametro.Name = "@id_curso";
            ParameterDiscreteValue valor = new ParameterDiscreteValue();
            valor.Value = Convert.ToInt32(ddlAnios.SelectedValue);
            parametro.CurrentValues.Add(valor);
            parametros.Add(parametro);
            CRViewerCursos.ParameterFieldInfo = parametros;
            Util.ReporteCursos rep = new Util.ReporteCursos();
            rep.SetDatabaseLogon("net", "net");
            this.CRViewerCursos.ReportSource = rep;
            this.CRViewerCursos.DataBind();
            this.ReportViewerPanel.Visible = true;
            this.formPanel.Visible = false;
        }
    }
}