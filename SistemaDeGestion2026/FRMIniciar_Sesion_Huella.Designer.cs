namespace SistemaDeGestion2026
{
    partial class FRMIniciar_Sesion_Huella
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
            this.GPPanelPrincipal = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.PVCHuella = new DPFP.Gui.Verification.VerificationControl();
            this.LBLMensaje = new System.Windows.Forms.PictureBox();
            this.LBLMensajeHuella = new DevComponents.DotNetBar.LabelX();
            this.BTNSalir = new DevComponents.DotNetBar.ButtonX();
            this.BTNLimpiar = new DevComponents.DotNetBar.ButtonX();
            this.BTNGrabar = new DevComponents.DotNetBar.ButtonX();
            this.GPPanelPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LBLMensaje)).BeginInit();
            this.SuspendLayout();
            // 
            // GPPanelPrincipal
            // 
            this.GPPanelPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.GPPanelPrincipal.CanvasColor = System.Drawing.SystemColors.Control;
            this.GPPanelPrincipal.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.GPPanelPrincipal.Controls.Add(this.PVCHuella);
            this.GPPanelPrincipal.Controls.Add(this.LBLMensaje);
            this.GPPanelPrincipal.Controls.Add(this.LBLMensajeHuella);
            this.GPPanelPrincipal.Controls.Add(this.BTNSalir);
            this.GPPanelPrincipal.Controls.Add(this.BTNLimpiar);
            this.GPPanelPrincipal.Controls.Add(this.BTNGrabar);
            this.GPPanelPrincipal.DisabledBackColor = System.Drawing.Color.Empty;
            this.GPPanelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GPPanelPrincipal.Location = new System.Drawing.Point(0, 0);
            this.GPPanelPrincipal.Margin = new System.Windows.Forms.Padding(4);
            this.GPPanelPrincipal.Name = "GPPanelPrincipal";
            this.GPPanelPrincipal.Size = new System.Drawing.Size(1067, 554);
            // 
            // 
            // 
            this.GPPanelPrincipal.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.GPPanelPrincipal.Style.BackColorGradientAngle = 90;
            this.GPPanelPrincipal.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.GPPanelPrincipal.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.GPPanelPrincipal.Style.BorderBottomWidth = 1;
            this.GPPanelPrincipal.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.GPPanelPrincipal.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.GPPanelPrincipal.Style.BorderLeftWidth = 1;
            this.GPPanelPrincipal.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.GPPanelPrincipal.Style.BorderRightWidth = 1;
            this.GPPanelPrincipal.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.GPPanelPrincipal.Style.BorderTopWidth = 1;
            this.GPPanelPrincipal.Style.CornerDiameter = 4;
            this.GPPanelPrincipal.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.GPPanelPrincipal.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.GPPanelPrincipal.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.GPPanelPrincipal.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.GPPanelPrincipal.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.GPPanelPrincipal.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.GPPanelPrincipal.TabIndex = 3;
            this.GPPanelPrincipal.Text = "Usuario";
            // 
            // PVCHuella
            // 
            this.PVCHuella.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PVCHuella.Location = new System.Drawing.Point(549, 82);
            this.PVCHuella.Margin = new System.Windows.Forms.Padding(4);
            this.PVCHuella.Name = "PVCHuella";
            this.PVCHuella.ReaderSerialNumber = "00000000-0000-0000-0000-000000000000";
            this.PVCHuella.Size = new System.Drawing.Size(48, 47);
            this.PVCHuella.TabIndex = 21;
            this.PVCHuella.OnComplete += new DPFP.Gui.Verification.VerificationControl._OnComplete(this.PVCHuella_OnComplete);
            this.PVCHuella.Load += new System.EventHandler(this.PVCHuella_Load);
            // 
            // LBLMensaje
            // 
            this.LBLMensaje.Image = global::SistemaDeGestion2026.Properties.Resources.ic_login_huella;
            this.LBLMensaje.Location = new System.Drawing.Point(619, 29);
            this.LBLMensaje.Margin = new System.Windows.Forms.Padding(4);
            this.LBLMensaje.Name = "LBLMensaje";
            this.LBLMensaje.Size = new System.Drawing.Size(100, 100);
            this.LBLMensaje.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.LBLMensaje.TabIndex = 20;
            this.LBLMensaje.TabStop = false;
            // 
            // LBLMensajeHuella
            // 
            // 
            // 
            // 
            this.LBLMensajeHuella.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LBLMensajeHuella.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLMensajeHuella.Location = new System.Drawing.Point(55, 25);
            this.LBLMensajeHuella.Margin = new System.Windows.Forms.Padding(4);
            this.LBLMensajeHuella.Name = "LBLMensajeHuella";
            this.LBLMensajeHuella.Size = new System.Drawing.Size(523, 28);
            this.LBLMensajeHuella.TabIndex = 19;
            this.LBLMensajeHuella.Text = "Coloque su huella en el lector biométrico";
            // 
            // BTNSalir
            // 
            this.BTNSalir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BTNSalir.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BTNSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BTNSalir.Image = global::SistemaDeGestion2026.Properties.Resources.ic_salir;
            this.BTNSalir.ImageFixedSize = new System.Drawing.Size(40, 40);
            this.BTNSalir.Location = new System.Drawing.Point(503, 507);
            this.BTNSalir.Margin = new System.Windows.Forms.Padding(4);
            this.BTNSalir.Name = "BTNSalir";
            this.BTNSalir.Size = new System.Drawing.Size(161, 63);
            this.BTNSalir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.BTNSalir.TabIndex = 13;
            this.BTNSalir.Text = "&Salir";
            // 
            // BTNLimpiar
            // 
            this.BTNLimpiar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BTNLimpiar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BTNLimpiar.Image = global::SistemaDeGestion2026.Properties.Resources.ic_limpiar;
            this.BTNLimpiar.ImageFixedSize = new System.Drawing.Size(40, 40);
            this.BTNLimpiar.Location = new System.Drawing.Point(256, 507);
            this.BTNLimpiar.Margin = new System.Windows.Forms.Padding(4);
            this.BTNLimpiar.Name = "BTNLimpiar";
            this.BTNLimpiar.Size = new System.Drawing.Size(161, 63);
            this.BTNLimpiar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.BTNLimpiar.TabIndex = 12;
            this.BTNLimpiar.Text = "&Limpiar";
            // 
            // BTNGrabar
            // 
            this.BTNGrabar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BTNGrabar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BTNGrabar.Image = global::SistemaDeGestion2026.Properties.Resources.ic_guardar;
            this.BTNGrabar.ImageFixedSize = new System.Drawing.Size(40, 40);
            this.BTNGrabar.Location = new System.Drawing.Point(4, 507);
            this.BTNGrabar.Margin = new System.Windows.Forms.Padding(4);
            this.BTNGrabar.Name = "BTNGrabar";
            this.BTNGrabar.Size = new System.Drawing.Size(161, 63);
            this.BTNGrabar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.BTNGrabar.TabIndex = 11;
            this.BTNGrabar.Text = "&Grabar";
            // 
            // FRMIniciar_Sesion_Huella
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.GPPanelPrincipal);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FRMIniciar_Sesion_Huella";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRMIniciar_Sesion_Huella";
            this.Load += new System.EventHandler(this.FRMIniciar_Sesion_Huella_Load);
            this.GPPanelPrincipal.ResumeLayout(false);
            this.GPPanelPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LBLMensaje)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel GPPanelPrincipal;
        private DevComponents.DotNetBar.ButtonX BTNSalir;
        private DevComponents.DotNetBar.ButtonX BTNLimpiar;
        private DevComponents.DotNetBar.ButtonX BTNGrabar;
        private DevComponents.DotNetBar.LabelX LBLMensajeHuella;
        private System.Windows.Forms.PictureBox LBLMensaje;
        private DPFP.Gui.Verification.VerificationControl PVCHuella;
    }
}