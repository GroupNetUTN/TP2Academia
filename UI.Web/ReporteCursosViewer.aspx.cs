using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class ReporteCursosViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CrystalDecisions.CrystalReports.Engine.ReportDocument rd = new Util.ReporteCursos();
            this.CRViewerCursos.ReportSource = rd;
            this.CRViewerCursos.DataBind();
        }
    }
}