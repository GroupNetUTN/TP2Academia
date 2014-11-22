using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class ReportePlanesViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CrystalDecisions.CrystalReports.Engine.ReportDocument rd = new Util.ReportePlanes();
            this.CRViewerPlanes.ReportSource = rd;
            this.CRViewerPlanes.DataBind();
        }
    }
}