using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    public partial class PersonaDesktop : ApplicationForm
    {
        public PersonaDesktop()
        {
            InitializeComponent();
        }

        private void PersonaDesktop_Load(object sender, EventArgs e)
        {

        }

        Persona _PersonaActual;

        public PersonaDesktop(ModoForm modo) : this()    
        {
            this._Modo = modo;
        }

        public PersonaDesktop(int ID, ModoForm modo) : this()
        {
            this._Modo = modo;
            PersonaLogic PersonaNegocio = new PersonaLogic();
            _PersonaActual = PersonaNegocio.GetOne(ID);
            this.MapearDeDatos();
        }
    }
}
