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
    public partial class ReporteCursosViewer : Form
    {
        public ReporteCursosViewer()
        {
            InitializeComponent();
        }

        private void ReporteCursosViewer_Load(object sender, EventArgs e)
        {
            CrystalDecisions.CrystalReports.Engine.ReportDocument rd = new Util.ReporteCursos();
            this.CRViewerCursos.ReportSource = rd;
            this.CRViewerCursos.Show();
        }
    }
}
