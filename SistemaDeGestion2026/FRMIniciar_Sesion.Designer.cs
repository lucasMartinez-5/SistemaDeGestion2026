namespace SistemaDeGestion2026
{
    partial class FRMIniciar_Sesion
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
            this.BTNMostrarPassword = new DevComponents.DotNetBar.ButtonX();
            this.BTNCancelar = new DevComponents.DotNetBar.ButtonX();
            this.BTNIngresar = new DevComponents.DotNetBar.ButtonX();
            this.TXTNombreLogin = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.BTNSalir = new DevComponents.DotNetBar.ButtonX();
            this.BTNLimpiar = new DevComponents.DotNetBar.ButtonX();
            this.BTNGrabar = new DevComponents.DotNetBar.ButtonX();
            this.TXTPassword = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.GPPanelPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // GPPanelPrincipal
            // 
            this.GPPanelPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.GPPanelPrincipal.CanvasColor = System.Drawing.SystemColors.Control;
            this.GPPanelPrincipal.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.GPPanelPrincipal.Controls.Add(this.BTNMostrarPassword);
            this.GPPanelPrincipal.Controls.Add(this.BTNCancelar);
            this.GPPanelPrincipal.Controls.Add(this.BTNIngresar);
            this.GPPanelPrincipal.Controls.Add(this.TXTNombreLogin);
            this.GPPanelPrincipal.Controls.Add(this.BTNSalir);
            this.GPPanelPrincipal.Controls.Add(this.BTNLimpiar);
            this.GPPanelPrincipal.Controls.Add(this.BTNGrabar);
            this.GPPanelPrincipal.Controls.Add(this.TXTPassword);
            this.GPPanelPrincipal.DisabledBackColor = System.Drawing.Color.Empty;
            this.GPPanelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GPPanelPrincipal.Location = new System.Drawing.Point(0, 0);
            this.GPPanelPrincipal.Name = "GPPanelPrincipal";
            this.GPPanelPrincipal.Size = new System.Drawing.Size(460, 435);
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
            this.GPPanelPrincipal.TabIndex = 2;
            this.GPPanelPrincipal.Text = "Usuario";
            // 
            // BTNMostrarPassword
            // 
            this.BTNMostrarPassword.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BTNMostrarPassword.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BTNMostrarPassword.Image = global::SistemaDeGestion2026.Properties.Resources.ic_ver_password;
            this.BTNMostrarPassword.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.BTNMostrarPassword.Location = new System.Drawing.Point(231, 35);
            this.BTNMostrarPassword.Name = "BTNMostrarPassword";
            this.BTNMostrarPassword.Size = new System.Drawing.Size(26, 23);
            this.BTNMostrarPassword.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.BTNMostrarPassword.TabIndex = 19;
            this.BTNMostrarPassword.Click += new System.EventHandler(this.BTNMostrarPassword_Click);
            // 
            // BTNCancelar
            // 
            this.BTNCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BTNCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BTNCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BTNCancelar.Image = global::SistemaDeGestion2026.Properties.Resources.ic_salir_app;
            this.BTNCancelar.ImageFixedSize = new System.Drawing.Size(40, 40);
            this.BTNCancelar.Location = new System.Drawing.Point(136, 64);
            this.BTNCancelar.Name = "BTNCancelar";
            this.BTNCancelar.Size = new System.Drawing.Size(121, 51);
            this.BTNCancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.BTNCancelar.TabIndex = 18;
            this.BTNCancelar.Text = "&Cancelar";
            this.BTNCancelar.Click += new System.EventHandler(this.BTNCancelar_Click);
            // 
            // BTNIngresar
            // 
            this.BTNIngresar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BTNIngresar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BTNIngresar.Image = global::SistemaDeGestion2026.Properties.Resources.ic_ingresar;
            this.BTNIngresar.ImageFixedSize = new System.Drawing.Size(40, 40);
            this.BTNIngresar.Location = new System.Drawing.Point(9, 64);
            this.BTNIngresar.Name = "BTNIngresar";
            this.BTNIngresar.Size = new System.Drawing.Size(121, 51);
            this.BTNIngresar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.BTNIngresar.TabIndex = 17;
            this.BTNIngresar.Text = "&Ingresar";
            this.BTNIngresar.Click += new System.EventHandler(this.BTNIngresar_Click);
            // 
            // TXTNombreLogin
            // 
            this.TXTNombreLogin.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.TXTNombreLogin.Border.Class = "TextBoxBorder";
            this.TXTNombreLogin.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.TXTNombreLogin.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TXTNombreLogin.DisabledBackColor = System.Drawing.Color.White;
            this.TXTNombreLogin.ForeColor = System.Drawing.Color.Black;
            this.TXTNombreLogin.Location = new System.Drawing.Point(9, 3);
            this.TXTNombreLogin.Name = "TXTNombreLogin";
            this.TXTNombreLogin.PreventEnterBeep = true;
            this.TXTNombreLogin.Size = new System.Drawing.Size(248, 23);
            this.TXTNombreLogin.TabIndex = 16;
            this.TXTNombreLogin.WatermarkText = "Login";
            // 
            // BTNSalir
            // 
            this.BTNSalir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BTNSalir.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BTNSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BTNSalir.Image = global::SistemaDeGestion2026.Properties.Resources.ic_salir;
            this.BTNSalir.ImageFixedSize = new System.Drawing.Size(40, 40);
            this.BTNSalir.Location = new System.Drawing.Point(377, 412);
            this.BTNSalir.Name = "BTNSalir";
            this.BTNSalir.Size = new System.Drawing.Size(121, 51);
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
            this.BTNLimpiar.Location = new System.Drawing.Point(192, 412);
            this.BTNLimpiar.Name = "BTNLimpiar";
            this.BTNLimpiar.Size = new System.Drawing.Size(121, 51);
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
            this.BTNGrabar.Location = new System.Drawing.Point(3, 412);
            this.BTNGrabar.Name = "BTNGrabar";
            this.BTNGrabar.Size = new System.Drawing.Size(121, 51);
            this.BTNGrabar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.BTNGrabar.TabIndex = 11;
            this.BTNGrabar.Text = "&Grabar";
            // 
            // TXTPassword
            // 
            this.TXTPassword.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.TXTPassword.Border.Class = "TextBoxBorder";
            this.TXTPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.TXTPassword.DisabledBackColor = System.Drawing.Color.White;
            this.TXTPassword.ForeColor = System.Drawing.Color.Black;
            this.TXTPassword.Location = new System.Drawing.Point(9, 35);
            this.TXTPassword.Name = "TXTPassword";
            this.TXTPassword.PasswordChar = '*';
            this.TXTPassword.PreventEnterBeep = true;
            this.TXTPassword.Size = new System.Drawing.Size(216, 23);
            this.TXTPassword.TabIndex = 4;
            this.TXTPassword.WatermarkText = "Password";
            // 
            // FRMIniciar_Sesion
            // 
            this.AcceptButton = this.BTNIngresar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BTNCancelar;
            this.ClientSize = new System.Drawing.Size(460, 435);
            this.Controls.Add(this.GPPanelPrincipal);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FRMIniciar_Sesion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Iniciar_Sesion";
            this.Load += new System.EventHandler(this.FRMIniciar_Sesion_Load);
            this.GPPanelPrincipal.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel GPPanelPrincipal;
        private DevComponents.DotNetBar.Controls.TextBoxX TXTNombreLogin;
        private DevComponents.DotNetBar.ButtonX BTNSalir;
        private DevComponents.DotNetBar.ButtonX BTNLimpiar;
        private DevComponents.DotNetBar.ButtonX BTNGrabar;
        private DevComponents.DotNetBar.Controls.TextBoxX TXTPassword;
        private DevComponents.DotNetBar.ButtonX BTNMostrarPassword;
        private DevComponents.DotNetBar.ButtonX BTNCancelar;
        private DevComponents.DotNetBar.ButtonX BTNIngresar;
    }
}