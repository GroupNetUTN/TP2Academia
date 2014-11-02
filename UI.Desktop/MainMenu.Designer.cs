namespace UI.Desktop
{
    partial class MainMenu
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modulosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ddToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionDePersonasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.planesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.materiasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.especialidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cursosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comisionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inscripcionACursoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarNotasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteCursosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.planesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsbsUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsbsFecha = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.modulosToolStripMenuItem,
            this.helpMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(632, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cerrarSesionToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
            this.fileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(60, 20);
            this.fileMenu.Text = "&Archivo";
            // 
            // cerrarSesionToolStripMenuItem
            // 
            this.cerrarSesionToolStripMenuItem.Name = "cerrarSesionToolStripMenuItem";
            this.cerrarSesionToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.cerrarSesionToolStripMenuItem.Text = "Cerrar Sesion";
            this.cerrarSesionToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesionToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(140, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.exitToolStripMenuItem.Text = "&Salir";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // modulosToolStripMenuItem
            // 
            this.modulosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ddToolStripMenuItem,
            this.gestionDePersonasToolStripMenuItem,
            this.planesToolStripMenuItem,
            this.materiasToolStripMenuItem,
            this.especialidadesToolStripMenuItem,
            this.cursosToolStripMenuItem,
            this.comisionesToolStripMenuItem,
            this.inscripcionACursoToolStripMenuItem,
            this.registrarNotasToolStripMenuItem,
            this.reportesToolStripMenuItem});
            this.modulosToolStripMenuItem.Name = "modulosToolStripMenuItem";
            this.modulosToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.modulosToolStripMenuItem.Text = "Modulos";
            // 
            // ddToolStripMenuItem
            // 
            this.ddToolStripMenuItem.Name = "ddToolStripMenuItem";
            this.ddToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.ddToolStripMenuItem.Text = "Usuarios";
            this.ddToolStripMenuItem.Visible = false;
            this.ddToolStripMenuItem.Click += new System.EventHandler(this.ddToolStripMenuItem_Click);
            // 
            // gestionDePersonasToolStripMenuItem
            // 
            this.gestionDePersonasToolStripMenuItem.Name = "gestionDePersonasToolStripMenuItem";
            this.gestionDePersonasToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.gestionDePersonasToolStripMenuItem.Text = "Personas";
            this.gestionDePersonasToolStripMenuItem.Visible = false;
            this.gestionDePersonasToolStripMenuItem.Click += new System.EventHandler(this.gestionDePersonasToolStripMenuItem_Click);
            // 
            // planesToolStripMenuItem
            // 
            this.planesToolStripMenuItem.Name = "planesToolStripMenuItem";
            this.planesToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.planesToolStripMenuItem.Text = "Planes";
            this.planesToolStripMenuItem.Visible = false;
            this.planesToolStripMenuItem.Click += new System.EventHandler(this.planesToolStripMenuItem_Click);
            // 
            // materiasToolStripMenuItem
            // 
            this.materiasToolStripMenuItem.Name = "materiasToolStripMenuItem";
            this.materiasToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.materiasToolStripMenuItem.Text = "Materias";
            this.materiasToolStripMenuItem.Visible = false;
            this.materiasToolStripMenuItem.Click += new System.EventHandler(this.materiasToolStripMenuItem_Click);
            // 
            // especialidadesToolStripMenuItem
            // 
            this.especialidadesToolStripMenuItem.Name = "especialidadesToolStripMenuItem";
            this.especialidadesToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.especialidadesToolStripMenuItem.Text = "Especialidades";
            this.especialidadesToolStripMenuItem.Visible = false;
            this.especialidadesToolStripMenuItem.Click += new System.EventHandler(this.especialidadesToolStripMenuItem_Click);
            // 
            // cursosToolStripMenuItem
            // 
            this.cursosToolStripMenuItem.Name = "cursosToolStripMenuItem";
            this.cursosToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.cursosToolStripMenuItem.Text = "Cursos";
            this.cursosToolStripMenuItem.Visible = false;
            this.cursosToolStripMenuItem.Click += new System.EventHandler(this.cursosToolStripMenuItem_Click);
            // 
            // comisionesToolStripMenuItem
            // 
            this.comisionesToolStripMenuItem.Name = "comisionesToolStripMenuItem";
            this.comisionesToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.comisionesToolStripMenuItem.Text = "Comisiones";
            this.comisionesToolStripMenuItem.Visible = false;
            this.comisionesToolStripMenuItem.Click += new System.EventHandler(this.comisionesToolStripMenuItem_Click);
            // 
            // inscripcionACursoToolStripMenuItem
            // 
            this.inscripcionACursoToolStripMenuItem.Name = "inscripcionACursoToolStripMenuItem";
            this.inscripcionACursoToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.inscripcionACursoToolStripMenuItem.Text = "Inscripcion a Curso";
            this.inscripcionACursoToolStripMenuItem.Visible = false;
            this.inscripcionACursoToolStripMenuItem.Click += new System.EventHandler(this.inscripcionACursoToolStripMenuItem_Click);
            // 
            // registrarNotasToolStripMenuItem
            // 
            this.registrarNotasToolStripMenuItem.Name = "registrarNotasToolStripMenuItem";
            this.registrarNotasToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.registrarNotasToolStripMenuItem.Text = "Registrar Notas";
            this.registrarNotasToolStripMenuItem.Visible = false;
            this.registrarNotasToolStripMenuItem.Click += new System.EventHandler(this.registrarNotasToolStripMenuItem_Click);
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reporteCursosToolStripMenuItem,
            this.planesToolStripMenuItem1});
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.reportesToolStripMenuItem.Text = "Reportes";
            this.reportesToolStripMenuItem.Visible = false;
            // 
            // reporteCursosToolStripMenuItem
            // 
            this.reporteCursosToolStripMenuItem.Name = "reporteCursosToolStripMenuItem";
            this.reporteCursosToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.reporteCursosToolStripMenuItem.Text = "Cursos";
            this.reporteCursosToolStripMenuItem.Click += new System.EventHandler(this.reportesCursosToolStripMenuItem_Click);
            // 
            // planesToolStripMenuItem1
            // 
            this.planesToolStripMenuItem1.Name = "planesToolStripMenuItem1";
            this.planesToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.planesToolStripMenuItem1.Text = "Planes";
            // 
            // helpMenu
            // 
            this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpMenu.Name = "helpMenu";
            this.helpMenu.Size = new System.Drawing.Size(53, 20);
            this.helpMenu.Text = "Ay&uda";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.aboutToolStripMenuItem.Text = "Acerca de...";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.tsbsUsuario,
            this.tsbsFecha});
            this.statusStrip.Location = new System.Drawing.Point(0, 431);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(632, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(42, 17);
            this.toolStripStatusLabel.Text = "Estado";
            // 
            // tsbsUsuario
            // 
            this.tsbsUsuario.Name = "tsbsUsuario";
            this.tsbsUsuario.Size = new System.Drawing.Size(0, 17);
            // 
            // tsbsFecha
            // 
            this.tsbsFecha.Name = "tsbsFecha";
            this.tsbsFecha.Size = new System.Drawing.Size(0, 17);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 453);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modulosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ddToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionDePersonasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem planesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem materiasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem especialidadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cursosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comisionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inscripcionACursoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrarNotasToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel tsbsUsuario;
        private System.Windows.Forms.ToolStripStatusLabel tsbsFecha;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteCursosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem planesToolStripMenuItem1;
    }
}



