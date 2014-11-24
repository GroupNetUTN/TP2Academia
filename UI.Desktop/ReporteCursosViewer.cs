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
using CrystalDecisions.Shared;

namespace UI.Desktop
{
    public partial class ReporteCursosViewer : ApplicationForm
    {
        public ReporteCursosViewer()
        {
            InitializeComponent();
        }

        private void ReporteCursosViewer_Load(object sender, EventArgs e)
        {
            this.LlenarComboEspecialidades();
        }

        private void LlenarComboEspecialidades()
        {
            try
            {
                EspecialidadLogic EspecialidadNegocio = new EspecialidadLogic();
                cbxEspecialidades.DataSource = EspecialidadNegocio.GetAll();
                cbxEspecialidades.DisplayMember = "Descripcion";
                cbxEspecialidades.ValueMember = "ID";
                cbxEspecialidades.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LlenarComboPlanes()
        {
            try
            {
                PlanLogic pl = new PlanLogic();
                List<Plan> planes = new List<Plan>();
                foreach (Plan p in pl.GetAll())
                {
                    if (p.Especialidad.ID == Convert.ToInt32(cbxEspecialidades.SelectedValue))
                    {
                        planes.Add(p);
                    }
                }
                cbxPlanes.DataSource = planes;
                cbxPlanes.DisplayMember = "Descripcion";
                cbxPlanes.ValueMember = "ID";
                cbxPlanes.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LlenarComboMaterias()
        {
            try
            {
                MateriaLogic ml = new MateriaLogic();
                List<Materia> materias = new List<Materia>();
                foreach (Materia m in ml.GetAll())
                {
                    if (m.Plan.ID == Convert.ToInt32(cbxPlanes.SelectedValue))
                        materias.Add(m);
                }
                cbxMaterias.DataSource = materias;
                cbxMaterias.DisplayMember = "Descripcion";
                cbxMaterias.ValueMember = "ID";
                cbxMaterias.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LlenarComboComisiones()
        {
            try
            {
                ComisionLogic cl = new ComisionLogic();
                List<Comision> comisiones = new List<Comision>();
                foreach (Comision c in cl.GetAll())
                {
                    if (c.Plan.ID == Convert.ToInt32(cbxPlanes.SelectedValue))
                        comisiones.Add(c);
                }
                cbxComisiones.DataSource = comisiones;
                cbxComisiones.DisplayMember = "Descripcion";
                cbxComisiones.ValueMember = "ID";
                cbxComisiones.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LlenarComboAnios()
        {
            try
            {
                CursoLogic cl = new CursoLogic();
                List<Curso> cursos = new List<Curso>();
                foreach (Curso c in cl.GetAll())
                {
                    if (c.Materia.ID == Convert.ToInt32(cbxMaterias.SelectedValue) && c.Comision.ID == Convert.ToInt32(cbxComisiones.SelectedValue))
                        cursos.Add(c);
                }
                cbxAnios.DataSource = cursos;
                cbxAnios.DisplayMember = "AnioCalendario";
                cbxAnios.ValueMember = "ID";
                cbxAnios.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                this.Notificar("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbxEspecialidades_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.cbxPlanes.SelectedIndex = -1;
            this.LlenarComboPlanes();
        }

        private void cbxPlanes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.cbxMaterias.SelectedIndex = this.cbxComisiones.SelectedIndex = -1;
            this.LlenarComboMaterias();
            this.LlenarComboComisiones();
        }

        private void cbxComisiones_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.LlenarComboAnios();
        }

        private void OcultarControles()
        {
            cbxAnios.Visible =
                cbxComisiones.Visible =
                cbxEspecialidades.Visible =
                cbxMaterias.Visible =
                cbxPlanes.Visible =
                label1.Visible =
                label2.Visible =
                label3.Visible =
                label4.Visible =
                label5.Visible =
                btnGenerarInforme.Visible = false;
        }

        private void cbxGenerarInforme_Click(object sender, EventArgs e)
        {
            ParameterField parametro = new ParameterField();
            ParameterFields parametros = new ParameterFields();
            parametro.ParameterValueType = ParameterValueKind.NumberParameter;
            parametro.Name = "@id_curso";
            ParameterDiscreteValue valor = new ParameterDiscreteValue();
            valor.Value = Convert.ToInt32(cbxAnios.SelectedValue);
            parametro.CurrentValues.Add(valor);
            parametros.Add(parametro);
            CRViewerCursos.ParameterFieldInfo = parametros;
            Util.ReporteCursos rep = new Util.ReporteCursos();
            rep.SetDatabaseLogon("net", "net");
            this.CRViewerCursos.ReportSource = rep;
            this.CRViewerCursos.Show();
            this.OcultarControles();
            this.WindowState = FormWindowState.Maximized;
        }

        private void cbxAnios_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.btnGenerarInforme.Visible = true;
        }
    }
}
