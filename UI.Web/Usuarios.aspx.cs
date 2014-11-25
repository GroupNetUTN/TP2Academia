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
            if(!IsPostBack) this.LoadGrid();
            this.GridView.Columns[6].Visible = true;
            this.gridPermisosPanel.Visible = false;
            if (this.GridView.SelectedIndex == -1)
            {
                ShowButtons(false);
                gridActionsPanel.Visible = true;
            }
            if (Session["Habilitado"] != null)
            {
                this.formPanel.Visible = true;
                this.formActionsPanel.Visible = true;
                this.txtNombreUsuario.Text = Session["Nombre_Usuario"].ToString();
                this.chxHabilitado.Checked = Convert.ToBoolean(Session["Habilitado"]);
                if (Session["ApeNom_Persona"] != null)
                    this.txtPersona.Text = Session["ApeNom_Persona"].ToString();
                if (Session["SelectedID"] != null)
                {
                    this.SelectedID = (int)Session["SelectedID"];
                    this.FormMode = FormModes.Modificacion;
                }
                else
                    this.FormMode = FormModes.Alta;
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
            try
            {
                this.GridView.DataSource = this.Logic.GetAll();
                this.GridView.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>window.alert('" + ex.Message + "');</script>");
            }
        }

        private void LoadGridPermisos(int id)
        {
            try
            {
                ModuloUsuarioLogic mul = new ModuloUsuarioLogic();
                this.GridViewPermisos.DataSource = mul.GetAll(id);
                this.GridViewPermisos.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>window.alert('" + ex.Message + "');</script>");
            }
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
            try
            {
                this.Entity = this.Logic.GetOne(id);
                this.chxHabilitado.Checked = this.Entity.Habilitado;
                this.txtNombreUsuario.Text = this.Entity.NombreUsuario;
                this.txtPersona.Text = this.Entity.Persona.Apellido + " " + this.Entity.Persona.Nombre;
            }
            catch (Exception ex)
            {
                Response.Write("<script>window.alert('" + ex.Message + "');</script>");
            }
        }

        private void LoadEntity(Usuario usuario)
        {
            usuario.NombreUsuario = this.txtNombreUsuario.Text;
            usuario.Clave = this.txtClave.Text;
            usuario.Habilitado = this.chxHabilitado.Checked;
            if (Session["ID_Persona"] != null)
                usuario.Persona.ID = Convert.ToInt32(Session["ID_Persona"]);
            if (Session["Tipo_Persona"].ToString() == "No docente")
            {
                ModuloUsuarioLogic log = new ModuloUsuarioLogic();
                usuario.ModulosUsuarios = log.GetAll(0);
            }
        }

        private void SaveEntity(Usuario usuario)
        {
            try
            {
                this.Logic.Save(usuario);
            }
            catch (Exception ex)
            {
                Response.Write("<script>window.alert('" + ex.Message + "');</script>");
            }
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
            try
            {
                this.Logic.Delete(id);
            }
            catch (Exception ex)
            {
                Response.Write("<script>window.alert('" + ex.Message + "');</script>");
            }
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
            this.gridActionsPanel.Visible = true;
            this.lbAsignarPermisos.Visible = false;
            this.ShowButtons(true);
            Label tipo = (Label)(GridView.Rows[GridView.SelectedIndex].FindControl("lblTipoPersona"));
            if (tipo.Text == "No docente")
            {
                this.lbAsignarPermisos.Visible = true;
            }
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
            switch (this.FormMode)
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
                    if (!Logic.Existe(Entity.NombreUsuario))
                    {
                        this.SaveEntity(Entity);
                    }
                    else
                        Response.Write("<script>window.alert('El Usuario ya existente.');</script>");
                    this.LoadGrid();
                    break;
            }
            this.ClearForm();
            this.ClearSession();
            this.formPanel.Visible = false;
            this.formActionsPanel.Visible = false;
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
            this.GridView.Columns[6].Visible = false;
            this.formPanel.Visible = true;
            this.formActionsPanel.Visible = true;
            this.gridActionsPanel.Visible = false;
            this.gridPermisosPanel.Visible = false;
            this.FormMode = FormModes.Alta;
            this.ClearForm();
            this.EnableForm(true);
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.ClearForm();
            this.ClearSession();
            this.formPanel.Visible = false;
            this.gridPermisosPanel.Visible = false;
            formActionsPanel.Visible = false;
            this.gridActionsPanel.Visible = true;
            this.ShowButtons(false);
        }

        protected void lbSeleccionarPersona_Click(object sender, EventArgs e)
        {
            Session["Nombre_Usuario"] = this.txtNombreUsuario.Text;
            Session["Habilitado"] = this.chxHabilitado.Checked;

            if (FormMode == FormModes.Modificacion)
            {
                Session["SelectedID"] = this.SelectedID;
            }
            Page.Response.Redirect("~/SeleccionarPersona.aspx");
        }

        protected void GridViewPermisos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            this.gridPermisosPanel.Visible = true;
            int ID = int.Parse(GridViewPermisos.DataKeys[e.RowIndex].Value.ToString());
            ModuloUsuarioLogic mul = new ModuloUsuarioLogic();
            ModuloUsuario _ModuloUsuarioActual = mul.GetOne(ID);
            _ModuloUsuarioActual.PermiteAlta = ((CheckBox)(GridViewPermisos.Rows[e.RowIndex].FindControl("chxAlta"))).Checked;
            _ModuloUsuarioActual.PermiteBaja = ((CheckBox)(GridViewPermisos.Rows[e.RowIndex].FindControl("chxBaja"))).Checked;
            _ModuloUsuarioActual.PermiteModificacion = ((CheckBox)(GridViewPermisos.Rows[e.RowIndex].FindControl("chxModificacion"))).Checked;
            _ModuloUsuarioActual.PermiteConsulta = ((CheckBox)(GridViewPermisos.Rows[e.RowIndex].FindControl("chxConsulta"))).Checked;
            _ModuloUsuarioActual.State = BusinessEntity.States.Modified;
            mul.Save(_ModuloUsuarioActual);
            GridViewPermisos.EditIndex = -1;
            this.LoadGridPermisos(this.SelectedID);
        }

        protected void GridViewPermisos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            this.gridPermisosPanel.Visible = true;
            GridViewPermisos.EditIndex = e.NewEditIndex;
            this.LoadGridPermisos(this.SelectedID);
        }

        protected void lbAsignarPermisos_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.gridActionsPanel.Visible = false;
                this.gridPermisosPanel.Visible = true;
                this.LoadGridPermisos(this.SelectedID);
            }
        }

        protected void GridViewPermisos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.gridPermisosPanel.Visible = true;
            GridViewPermisos.EditIndex = -1;
            this.LoadGridPermisos(this.SelectedID);
        }
    }
}