﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class MainMenu : Form
    {
        public MainMenu(Usuario u)
        {
            InitializeComponent();
            this._UsuarioActual = u;
        }

        private Usuario _UsuarioActual;

        public Usuario UsuarioActual
        {
            get { return _UsuarioActual; }
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            this.tsbsUsuario.Text = this.UsuarioActual.NombreUsuario;
            ModuloUsuarioLogic mul = new ModuloUsuarioLogic();
            UsuarioActual.ModulosUsuarios = mul.GetPermisos(UsuarioActual.ID);
            
            if (UsuarioActual.Persona.TipoPersona == "Alumno")
            {
                this.inscripcionACursoToolStripMenuItem.Visible = true;
            }
            else if (UsuarioActual.Persona.TipoPersona == "Docente")
            {
                this.registrarNotasToolStripMenuItem.Visible = true;
            }

            foreach (ModuloUsuario mu in UsuarioActual.ModulosUsuarios)
            {
                if (mu.Modulo.Descripcion == "Usuarios")
                {
                    if (mu.PermiteAlta == true || mu.PermiteBaja == true || mu.PermiteConsulta == true || mu.PermiteModificacion == true) 
                        this.ddToolStripMenuItem.Visible = true;
                }
                else if (mu.Modulo.Descripcion == "Personas")
                {
                    if (mu.PermiteAlta == true || mu.PermiteBaja == true || mu.PermiteConsulta == true || mu.PermiteModificacion == true) 
                        this.gestionDePersonasToolStripMenuItem.Visible = true;
                }
                else if (mu.Modulo.Descripcion == "Planes")
                {
                    if (mu.PermiteAlta == true || mu.PermiteBaja == true || mu.PermiteConsulta == true || mu.PermiteModificacion == true)
                        this.planesToolStripMenuItem.Visible = true;
                }
                else if (mu.Modulo.Descripcion == "Materias")
                {
                    if (mu.PermiteAlta == true || mu.PermiteBaja == true || mu.PermiteConsulta == true || mu.PermiteModificacion == true)
                        this.materiasToolStripMenuItem.Visible = true;
                }
                else if (mu.Modulo.Descripcion == "Especialidades")
                {
                    if (mu.PermiteAlta == true || mu.PermiteBaja == true || mu.PermiteConsulta == true || mu.PermiteModificacion == true)
                        this.especialidadesToolStripMenuItem.Visible = true;
                }
                else if (mu.Modulo.Descripcion == "Cursos")
                {
                    if (mu.PermiteAlta == true || mu.PermiteBaja == true || mu.PermiteConsulta == true || mu.PermiteModificacion == true)
                        this.cursosToolStripMenuItem.Visible = true;
                }
                else if (mu.Modulo.Descripcion == "Comisiones")
                {
                    if (mu.PermiteAlta == true || mu.PermiteBaja == true || mu.PermiteConsulta == true || mu.PermiteModificacion == true)
                        this.comisionesToolStripMenuItem.Visible = true;
                }
            }
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Login login = new Login();
            if (login.ShowDialog() == DialogResult.OK)
            {
                this._UsuarioActual = login.UsuarioActual;
                this.Visible = true; 
                this.tsbsUsuario.Text = this._UsuarioActual.NombreUsuario;
                
            }
            else
            {
                this.Close();
            }

        }

        private void ddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Usuarios usu = new Usuarios(UsuarioActual);
            usu.MdiParent = this;
            usu.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.tsbsFecha.Text = DateTime.Now.ToString("dd/MM/yyyy - hh:mm:ss");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gestionDePersonasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Personas per = new Personas(UsuarioActual);
            per.MdiParent = this;
            per.Show();
        }

        private void planesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Planes pl = new Planes(UsuarioActual);
            pl.MdiParent = this;
            pl.Show();
        }

        private void materiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Materias mat = new Materias(UsuarioActual);
            mat.MdiParent = this;
            mat.Show();
        }

        private void especialidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Especialidades esp = new Especialidades(UsuarioActual);
            esp.MdiParent = this;
            esp.Show();
        }

        private void cursosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursos cur = new Cursos(UsuarioActual);
            cur.MdiParent = this;
            cur.Show();
        }

        private void comisionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Comisiones com = new Comisiones(UsuarioActual);
            com.MdiParent = this;
            com.Show();
        }

        private void inscripcionACursoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inscripciones ins = new Inscripciones(_UsuarioActual);
            ins.MdiParent = this;
            ins.Show();
        }

        private void registrarNotasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistroNotas reg = new RegistroNotas(_UsuarioActual);
            reg.MdiParent = this;
            reg.Show();
        }

        
    }
}
