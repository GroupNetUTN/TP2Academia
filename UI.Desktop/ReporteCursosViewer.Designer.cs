namespace UI.Desktop
{
    partial class ReporteCursosViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CRViewerCursos = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CRViewerCursos
            // 
            this.CRViewerCursos.ActiveViewIndex = -1;
            this.CRViewerCursos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CRViewerCursos.Cursor = System.Windows.Forms.Cursors.Default;
            this.CRViewerCursos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CRViewerCursos.Location = new System.Drawing.Point(0, 0);
            this.CRViewerCursos.Name = "CRViewerCursos";
            this.CRViewerCursos.Size = new System.Drawing.Size(780, 487);
            this.CRViewerCursos.TabIndex = 0;
            this.CRViewerCursos.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // ReporteCursosViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 487);
            this.Controls.Add(this.CRViewerCursos);
            this.Name = "ReporteCursosViewer";
            this.Text = "ReporteCursosViewer";
            this.Load += new System.EventHandler(this.ReporteCursosViewer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CRViewerCursos;
    }
}