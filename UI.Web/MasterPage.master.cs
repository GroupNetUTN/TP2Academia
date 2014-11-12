using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void lbCerrarSesion_Click(object sender, EventArgs e)
    {
        Session["UsuarioActual"] = null;
        Page.Response.Redirect("~/Login.aspx");
    }
}