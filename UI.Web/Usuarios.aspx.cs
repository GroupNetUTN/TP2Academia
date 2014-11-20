using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;
using Util;

namespace UI.Web
{
    public partial class Usuarios : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LoadGrid();
            this.GridView.Columns[5].Visible = true;
           /* this.gridPermisosPanel.Visible = false;*/
            if (this.GridView.SelectedIndex == -1)
            {
                ShowButtons(false);
                gridActionsPanel.Visible = true;
            }
            if (Session["Habilitado"] != null)
            {
                if (Session["Tipo_Persona"].ToString() == "No docente")
                    this.gridPermisosPanel.Visible = true;
                this.formPanel.Visible = true;
                this.txtNombreUsuario.Text = Session["Nombre_Usuario"].ToString();
                this.chxHabilitado.Checked = Convert.ToBoolean(Session["Habilitado"]);
                if (Session["ApeNom_Persona"] != null)
                    this.txtPersona.Text = Session["ApeNom_Persona"].ToString();
                if (Session["SelectedID"]!=null)
                {
                    this.SelectedID = (int)Session["SelectedID"];
                    this.FormMode = FormModes.Modificacion;
                }
                else
                    this.FormMode = FormModes.Alta;
                if (this.FormMode == FormModes.Modificacion)
                {
                    this.LoadGridPermisos(SelectedID);
                }
                else
                    this.LoadGridPermisos(0);
            }
        }

        UsuarioLogic _logic;

        public UsuarioLogic Logic
        {
            get
            {
                if (_logic == null)
                    _logic = new UsuarioLogic();
                return _logic;
            }
        }

        private void LoadGrid()
        {
            this.GridView.DataSource = this.Logic.GetAll();
            this.GridView.DataBind();
        }

        private void LoadGridPermisos(int id)
        {
            ModuloUsuarioLogic mul = new ModuloUsuarioLogic();
            this.GridViewPermisos.DataSource = mul.GetAll(id);
            this.GridViewPermisos.DataBind();
        }

        Usuario _Entity;    
        
        private Usuario Entity
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

        private void ShowButtons(bool enable)
        {
            this.lbEliminar.Visible = enable;
            this.lbEditar.Visible = enable;
        }

        private void LoadForm(int id)
        {
            this.Entity = this.Logic.GetOne(id);
            this.chxHabilitado.Checked = this.Entity.Habilitado;
            this.txtNombreUsuario.Text = this.Entity.NombreUsuario;
            this.txtPersona.Text = this.Entity.Persona.Apellido + " " + this.Entity.Persona.Nombre;
            if (this.Entity.TipoPersona == "No docente")
            {
                this.LoadGridPermisos(this.Entity.ID);
                this.gridPermisosPanel.Visible = true;
            }
        }

        private void LoadEntity(Usuario usuario)
        {
            usuario.NombreUsuario = this.txtNombreUsuario.Text;
            usuario.Clave = this.txtClave.Text;
            usuario.Habilitado = this.chxHabilitado.Checked;
            if (Session["ID_Persona"] != null)
                usuario.Persona.ID = Convert.ToInt32(Session["ID_Persona"]);
            foreach (GridViewRow row in this.GridViewPermisos.Rows)
            {
                usuario.ModulosUsuarios.Add((ModuloUsuario)row.DataItem);
            }
        }

        private void SaveEntity(Usuario usuario)
        {
            this.Logic.Save(usuario);
        }

        private void EnableForm(bool enable)
        {
            this.txtNombreUsuario.Enabled = enable;
            this.txtClave.Visible = enable;
            this.lblClave.Visible = enable;
            this.lblRepetirClave.Visible = enable;
            this.txtRepetirClave.Visible = enable;
        }

        private void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }

        private void ClearForm()
        {
            this.txtNombreUsuario.Text = string.Empty;
            this.chxHabilitado.Checked = false;
            this.GridView.SelectedIndex = -1;
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
                this.formPanel.Visible = true;
                this.formActionsPanel.Visible = true;
                this.gridActionsPanel.Visible = false;
                this.FormMode = FormModes.Modificacion;
                this.EnableForm(true);
                this.LoadForm(this.SelectedID);
            }
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            switch(this.FormMode)
            {
                case FormModes.Modificacion:
                    if (Page.IsValid)
                    {
                        this.Entity = this.Logic.GetOne(this.SelectedID);
                        this.Entity.State = BusinessEntity.States.Modified;
                        this.LoadEntity(this.Entity);
                        this.SaveEntity(this.Entity);
                        this.LoadGrid();
                    }
                    break;
                case FormModes.Alta:
                    this.Entity = new Usuario();
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
            }
            this.ClearForm();
            this.ClearSession();
            this.formPanel.Visible = false;
            this.gridActionsPanel.Visible = true;
            this.ShowButtons(false);
        }

        private void ClearSession()
        {
            Session["Nombre_Usuario"] =
                 Session["Habilitado"] =
                 Session["ApeNom_Persona"] =
                 Session["SelectedID"] =
                 Session["ID_Persona"] = 
                 Session["Tipo_Persona"] = null;
        }
            

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.DeleteEntity(this.SelectedID);
                this.LoadGrid();
                this.ShowButtons(false);
            }
        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            this.GridView.Columns[5].Visible = false;
            this.formPanel.Visible = true;
            this.formActionsPanel.Visible = true;
            this.gridActionsPanel.Visible = false;
            this.FormMode = FormModes.Alta;
            this.ClearForm();
            this.EnableForm(true);
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.ClearForm();
            this.ClearSession();
            this.formPanel.Visible = false;
            this.gridActionsPanel.Visible = true;
            this.ShowButtons(false);
        }

        protected void lbSeleccionarPersona_Click(object sender, EventArgs e)
        {
            Session["Nombre_Usuario"] = this.txtNombreUsuario.Text;
            Session["Habilitado"] = this.chxHabilitado.Checked;
            
            if(FormMode == FormModes.Modificacion)
            {
                Session["SelectedID"] = this.SelectedID;
            }
            Page.Response.Redirect("~/SeleccionarPersona.aspx");
        }

        protected void GridViewPermisos_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

    }
}