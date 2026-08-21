namespace SistemaDeGestion2026
{
    partial class FRMCategoria_Registrar
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
            this.BTNSalir = new DevComponents.DotNetBar.ButtonX();
            this.BTNLimpiar = new DevComponents.DotNetBar.ButtonX();
            this.BTNGrabar = new DevComponents.DotNetBar.ButtonX();
            this.TXTCategoriaProductoCodigo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.TXTCategoriaProductoNombre = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.SWBCategoriaProductoEstadoStock = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.BLTAyuda = new DevComponents.DotNetBar.BalloonTip();
            this.GPPanelPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // GPPanelPrincipal
            // 
            this.GPPanelPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.GPPanelPrincipal.CanvasColor = System.Drawing.SystemColors.Control;
            this.GPPanelPrincipal.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.GPPanelPrincipal.Controls.Add(this.BTNSalir);
            this.GPPanelPrincipal.Controls.Add(this.BTNLimpiar);
            this.GPPanelPrincipal.Controls.Add(this.BTNGrabar);
            this.GPPanelPrincipal.Controls.Add(this.TXTCategoriaProductoCodigo);
            this.GPPanelPrincipal.Controls.Add(this.TXTCategoriaProductoNombre);
            this.GPPanelPrincipal.Controls.Add(this.SWBCategoriaProductoEstadoStock);
            this.GPPanelPrincipal.DisabledBackColor = System.Drawing.Color.Empty;
            this.GPPanelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GPPanelPrincipal.Location = new System.Drawing.Point(0, 0);
            this.GPPanelPrincipal.Name = "GPPanelPrincipal";
            this.GPPanelPrincipal.Size = new System.Drawing.Size(383, 198);
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
            this.GPPanelPrincipal.TabIndex = 1;
            this.GPPanelPrincipal.Text = "Categoria";
            // 
            // BTNSalir
            // 
            this.BTNSalir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BTNSalir.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BTNSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BTNSalir.Image = global::SistemaDeGestion2026.Properties.Resources.ic_salir;
            this.BTNSalir.ImageFixedSize = new System.Drawing.Size(40, 40);
            this.BTNSalir.Location = new System.Drawing.Point(250, 86);
            this.BTNSalir.Name = "BTNSalir";
            this.BTNSalir.Size = new System.Drawing.Size(110, 51);
            this.BTNSalir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.BTNSalir.TabIndex = 20;
            this.BTNSalir.Text = "&Salir";
            this.BTNSalir.Click += new System.EventHandler(this.BTNSalir_Click);
            // 
            // BTNLimpiar
            // 
            this.BTNLimpiar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BTNLimpiar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BTNLimpiar.Image = global::SistemaDeGestion2026.Properties.Resources.ic_limpiar;
            this.BTNLimpiar.ImageFixedSize = new System.Drawing.Size(40, 40);
            this.BTNLimpiar.Location = new System.Drawing.Point(125, 86);
            this.BTNLimpiar.Name = "BTNLimpiar";
            this.BTNLimpiar.Size = new System.Drawing.Size(119, 51);
            this.BTNLimpiar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.BTNLimpiar.TabIndex = 19;
            this.BTNLimpiar.Text = "&Limpiar";
            this.BTNLimpiar.Click += new System.EventHandler(this.BTNLimpiar_Click);
            // 
            // BTNGrabar
            // 
            this.BTNGrabar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BTNGrabar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BTNGrabar.Image = global::SistemaDeGestion2026.Properties.Resources.ic_guardar;
            this.BTNGrabar.ImageFixedSize = new System.Drawing.Size(40, 40);
            this.BTNGrabar.Location = new System.Drawing.Point(8, 86);
            this.BTNGrabar.Name = "BTNGrabar";
            this.BTNGrabar.Size = new System.Drawing.Size(111, 51);
            this.BTNGrabar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.BTNGrabar.TabIndex = 18;
            this.BTNGrabar.Text = "&Grabar";
            this.BTNGrabar.Click += new System.EventHandler(this.BTNGrabar_Click);
            // 
            // TXTCategoriaProductoCodigo
            // 
            this.TXTCategoriaProductoCodigo.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.TXTCategoriaProductoCodigo.Border.Class = "TextBoxBorder";
            this.TXTCategoriaProductoCodigo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.TXTCategoriaProductoCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TXTCategoriaProductoCodigo.DisabledBackColor = System.Drawing.Color.White;
            this.TXTCategoriaProductoCodigo.Enabled = false;
            this.TXTCategoriaProductoCodigo.ForeColor = System.Drawing.Color.Black;
            this.TXTCategoriaProductoCodigo.Location = new System.Drawing.Point(177, 14);
            this.TXTCategoriaProductoCodigo.Name = "TXTCategoriaProductoCodigo";
            this.TXTCategoriaProductoCodigo.PreventEnterBeep = true;
            this.TXTCategoriaProductoCodigo.Size = new System.Drawing.Size(184, 23);
            this.TXTCategoriaProductoCodigo.TabIndex = 17;
            this.TXTCategoriaProductoCodigo.WatermarkText = "Codigo de la Categoria";
            // 
            // TXTCategoriaProductoNombre
            // 
            this.TXTCategoriaProductoNombre.BackColor = System.Drawing.Color.White;
            this.BLTAyuda.SetBalloonCaption(this.TXTCategoriaProductoNombre, "Ayuda");
            this.BLTAyuda.SetBalloonText(this.TXTCategoriaProductoNombre, "Nombre de la categoria");
            // 
            // 
            // 
            this.TXTCategoriaProductoNombre.Border.Class = "TextBoxBorder";
            this.TXTCategoriaProductoNombre.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.TXTCategoriaProductoNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TXTCategoriaProductoNombre.DisabledBackColor = System.Drawing.Color.White;
            this.TXTCategoriaProductoNombre.ForeColor = System.Drawing.Color.Black;
            this.TXTCategoriaProductoNombre.Location = new System.Drawing.Point(9, 46);
            this.TXTCategoriaProductoNombre.Name = "TXTCategoriaProductoNombre";
            this.TXTCategoriaProductoNombre.PreventEnterBeep = true;
            this.TXTCategoriaProductoNombre.Size = new System.Drawing.Size(352, 23);
            this.TXTCategoriaProductoNombre.TabIndex = 0;
            this.TXTCategoriaProductoNombre.WatermarkText = "Nombre de la Categoria";
            this.TXTCategoriaProductoNombre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TXTCategoriaProductoNombre_KeyDown);
            // 
            // SWBCategoriaProductoEstadoStock
            // 
            // 
            // 
            // 
            this.SWBCategoriaProductoEstadoStock.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.SWBCategoriaProductoEstadoStock.Location = new System.Drawing.Point(9, 14);
            this.SWBCategoriaProductoEstadoStock.Name = "SWBCategoriaProductoEstadoStock";
            this.SWBCategoriaProductoEstadoStock.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.SWBCategoriaProductoEstadoStock.OffText = "Inhabilitado";
            this.SWBCategoriaProductoEstadoStock.OffTextColor = System.Drawing.Color.White;
            this.SWBCategoriaProductoEstadoStock.OnBackColor = System.Drawing.Color.LimeGreen;
            this.SWBCategoriaProductoEstadoStock.OnText = "Habilitado";
            this.SWBCategoriaProductoEstadoStock.OnTextColor = System.Drawing.Color.White;
            this.SWBCategoriaProductoEstadoStock.Size = new System.Drawing.Size(149, 23);
            this.SWBCategoriaProductoEstadoStock.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.SWBCategoriaProductoEstadoStock.TabIndex = 16;
            this.SWBCategoriaProductoEstadoStock.Value = true;
            this.SWBCategoriaProductoEstadoStock.ValueObject = "Y";
            // 
            // FRMCategoria_Registrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 198);
            this.Controls.Add(this.GPPanelPrincipal);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FRMCategoria_Registrar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRMCategoria_Registrar";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FRMCategoria_Registrar_FormClosing);
            this.Load += new System.EventHandler(this.FRMCategoria_Registrar_Load);
            this.GPPanelPrincipal.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel GPPanelPrincipal;
        private DevComponents.DotNetBar.ButtonX BTNSalir;
        private DevComponents.DotNetBar.ButtonX BTNLimpiar;
        private DevComponents.DotNetBar.ButtonX BTNGrabar;
        private DevComponents.DotNetBar.Controls.TextBoxX TXTCategoriaProductoCodigo;
        private DevComponents.DotNetBar.Controls.TextBoxX TXTCategoriaProductoNombre;
        private DevComponents.DotNetBar.Controls.SwitchButton SWBCategoriaProductoEstadoStock;
        private DevComponents.DotNetBar.BalloonTip BLTAyuda;
    }
}