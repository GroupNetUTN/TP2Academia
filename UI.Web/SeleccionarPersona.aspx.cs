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
    public partial class SeleccionarPersona : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LoadGrid();
        }

        PersonaLogic _logic;

        public PersonaLogic Logic
        {
            get
            {
                if (_logic == null)
                    _logic = new PersonaLogic();
                return _logic;
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

        private void LoadGrid()
        {
            this.dgvPersonas.DataSource = this.Logic.GetAll();
            this.dgvPersonas.DataBind();
        }

        protected void dgvPersonas_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.dgvPersonas.SelectedValue;
        }

        protected void lbSeleccionar_Click(object sender, EventArgs e)
        {
            Session["ID_Persona"] = this.SelectedID;
            Persona SelectedPersona = this.Logic.GetOne(SelectedID);
            Session["ApeNom_Persona"] = SelectedPersona.Apellido + SelectedPersona.Nombre;
            Session["Tipo_Persona"] = SelectedPersona.TipoPersona;
            Page.Response.Redirect("~/Usuarios.aspx");
        }

        protected void lbCancelar_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("~/Usuarios.aspx");
        }

    }
}