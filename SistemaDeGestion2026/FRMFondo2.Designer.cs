namespace SistemaDeGestion2026
{
    partial class FRMFondo2
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
            this.components = new System.ComponentModel.Container();
            this.PNLBarraInferior = new DevComponents.DotNetBar.PanelEx();
            this.LBLUsuario = new DevComponents.DotNetBar.LabelX();
            this.LBLFecha = new DevComponents.DotNetBar.LabelX();
            this.TMReloj = new System.Windows.Forms.Timer(this.components);
            this.PNLBarraInferior.SuspendLayout();
            this.SuspendLayout();
            // 
            // PNLBarraInferior
            // 
            this.PNLBarraInferior.CanvasColor = System.Drawing.SystemColors.Control;
            this.PNLBarraInferior.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.PNLBarraInferior.Controls.Add(this.LBLFecha);
            this.PNLBarraInferior.Controls.Add(this.LBLUsuario);
            this.PNLBarraInferior.DisabledBackColor = System.Drawing.Color.Empty;
            this.PNLBarraInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PNLBarraInferior.Location = new System.Drawing.Point(0, 393);
            this.PNLBarraInferior.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PNLBarraInferior.Name = "PNLBarraInferior";
            this.PNLBarraInferior.Size = new System.Drawing.Size(767, 48);
            this.PNLBarraInferior.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.PNLBarraInferior.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.PNLBarraInferior.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.PNLBarraInferior.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.PNLBarraInferior.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.PNLBarraInferior.Style.GradientAngle = 90;
            this.PNLBarraInferior.TabIndex = 0;
            // 
            // LBLUsuario
            // 
            // 
            // 
            // 
            this.LBLUsuario.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LBLUsuario.Dock = System.Windows.Forms.DockStyle.Left;
            this.LBLUsuario.Location = new System.Drawing.Point(0, 0);
            this.LBLUsuario.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LBLUsuario.Name = "LBLUsuario";
            this.LBLUsuario.PaddingLeft = 10;
            this.LBLUsuario.Size = new System.Drawing.Size(327, 48);
            this.LBLUsuario.TabIndex = 0;
            this.LBLUsuario.Text = "Usuario";
            // 
            // LBLFecha
            // 
            // 
            // 
            // 
            this.LBLFecha.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LBLFecha.Dock = System.Windows.Forms.DockStyle.Right;
            this.LBLFecha.Location = new System.Drawing.Point(448, 0);
            this.LBLFecha.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LBLFecha.Name = "LBLFecha";
            this.LBLFecha.PaddingRight = 10;
            this.LBLFecha.Size = new System.Drawing.Size(319, 48);
            this.LBLFecha.TabIndex = 1;
            this.LBLFecha.Text = "Bermejo 12 de Agosto de 2026 14:02:10";
            this.LBLFecha.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // TMReloj
            // 
            this.TMReloj.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FRMFondo2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 441);
            this.Controls.Add(this.PNLBarraInferior);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FRMFondo2";
            this.Text = "FRMFondo2";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FRMFondo2_FormClosing);
            this.Load += new System.EventHandler(this.FRMFondo2_Load);
            this.PNLBarraInferior.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx PNLBarraInferior;
        private DevComponents.DotNetBar.LabelX LBLFecha;
        private DevComponents.DotNetBar.LabelX LBLUsuario;
        private System.Windows.Forms.Timer TMReloj;
    }
}