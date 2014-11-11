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
    public partial class Default : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         
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

        protected void lbIngresar_Click(object sender, EventArgs e)
        {
            Usuario usuarioActual = Logic.GetUsuarioForLogin(this.txtUsuario.Text, this.txtContraseña.Text);
            if (usuarioActual.ID != 0)
            {
                if (usuarioActual.Habilitado)
                {
                    ModuloUsuarioLogic mul = new ModuloUsuarioLogic();
                    usuarioActual.ModulosUsuarios = mul.GetPermisos(usuarioActual.ID);
                    Session["UsuarioActual"] = usuarioActual;
                    Page.Response.Redirect("~/Home.aspx");
                }
                else
                {
                    this.lblMensage2.Visible = true;
                }
            }
            else
            {
                this.lblMensage.Visible = true;
            }
        }
    }
}