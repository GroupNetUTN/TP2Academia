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
    public partial class DocentesCursos : Form
    {
        public DocentesCursos(Curso c)
        {
            InitializeComponent();
            dgvDocentesCursos.AutoGenerateColumns = false;
            this._CursoActual = c;
        }

        private Curso _CursoActual;

        public void Listar()
        {
            DocenteCursoLogic dcl = new DocenteCursoLogic();
            List<DocenteCurso> docentes = new List<DocenteCurso>();
            foreach (DocenteCurso dc in dcl.GetAll())
            {
                if (dc.IDCurso == _CursoActual.ID)
                    docentes.Add(dc);
            }
            dgvDocentesCursos.DataSource = docentes;
        }

        private void DocentesCursos_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
