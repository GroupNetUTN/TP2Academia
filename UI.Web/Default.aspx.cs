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
            this.lblMensage2.Visible = true;
            this.lblMensage.Visible = true;
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
                    Session["UsuarioActual"] = usuarioActual;
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