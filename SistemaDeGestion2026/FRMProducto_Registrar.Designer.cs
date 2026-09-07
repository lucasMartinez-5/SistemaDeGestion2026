namespace SistemaDeGestion2026
{
    partial class FRMProducto_Registrar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRMProducto_Registrar));
            this.GPPanelPrincipal = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.LBLCodigoDeBarras = new DevComponents.DotNetBar.LabelX();
            this.LBLPrecioMinVenta = new DevComponents.DotNetBar.LabelX();
            this.LBLPrecioVenta = new DevComponents.DotNetBar.LabelX();
            this.LBLStockActual = new DevComponents.DotNetBar.LabelX();
            this.BTNCodigoDeBarras = new DevComponents.DotNetBar.ButtonX();
            this.NUDStockActual = new System.Windows.Forms.NumericUpDown();
            this.NUDPrecioVenta = new System.Windows.Forms.NumericUpDown();
            this.NUDPrecioMinVenta = new System.Windows.Forms.NumericUpDown();
            this.TBDProductoTalla = new DevComponents.DotNetBar.Controls.TextBoxDropDown();
            this.TBDProductoColor = new DevComponents.DotNetBar.Controls.TextBoxDropDown();
            this.TBDProductoMaterial = new DevComponents.DotNetBar.Controls.TextBoxDropDown();
            this.TBDProductoMarca = new DevComponents.DotNetBar.Controls.TextBoxDropDown();
            this.TBDProductoNombre = new DevComponents.DotNetBar.Controls.TextBoxDropDown();
            this.TBDProductoCategoria = new DevComponents.DotNetBar.Controls.TextBoxDropDown();
            this.TBDProductoGenero = new DevComponents.DotNetBar.Controls.TextBoxDropDown();
            this.TXTProductoDescripcion = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.TXTProductoModelo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.GPFotografia = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.PCBFotografia = new System.Windows.Forms.PictureBox();
            this.BTNAbrirFoto = new DevComponents.DotNetBar.ButtonX();
            this.BTNLimpiarFoto = new DevComponents.DotNetBar.ButtonX();
            this.BTNCapturarFoto = new DevComponents.DotNetBar.ButtonX();
            this.PCBCamara = new System.Windows.Forms.PictureBox();
            this.BTNSalir = new DevComponents.DotNetBar.ButtonX();
            this.BTNLimpiar = new DevComponents.DotNetBar.ButtonX();
            this.BTNGrabar = new DevComponents.DotNetBar.ButtonX();
            this.SWBProductoEstadoStock = new DevComponents.DotNetBar.Controls.SwitchButton();
            this.OFDElegirImagen = new System.Windows.Forms.OpenFileDialog();
            this.BLTAyuda = new DevComponents.DotNetBar.BalloonTip();
            this.GPPanelPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDStockActual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDPrecioVenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDPrecioMinVenta)).BeginInit();
            this.GPFotografia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PCBFotografia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PCBCamara)).BeginInit();
            this.SuspendLayout();
            // 
            // GPPanelPrincipal
            // 
            this.GPPanelPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.GPPanelPrincipal.CanvasColor = System.Drawing.SystemColors.Control;
            this.GPPanelPrincipal.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.GPPanelPrincipal.Controls.Add(this.LBLCodigoDeBarras);
            this.GPPanelPrincipal.Controls.Add(this.LBLPrecioMinVenta);
            this.GPPanelPrincipal.Controls.Add(this.LBLPrecioVenta);
            this.GPPanelPrincipal.Controls.Add(this.LBLStockActual);
            this.GPPanelPrincipal.Controls.Add(this.BTNCodigoDeBarras);
            this.GPPanelPrincipal.Controls.Add(this.NUDStockActual);
            this.GPPanelPrincipal.Controls.Add(this.NUDPrecioVenta);
            this.GPPanelPrincipal.Controls.Add(this.NUDPrecioMinVenta);
            this.GPPanelPrincipal.Controls.Add(this.TBDProductoTalla);
            this.GPPanelPrincipal.Controls.Add(this.TBDProductoColor);
            this.GPPanelPrincipal.Controls.Add(this.TBDProductoMaterial);
            this.GPPanelPrincipal.Controls.Add(this.TBDProductoMarca);
            this.GPPanelPrincipal.Controls.Add(this.TBDProductoNombre);
            this.GPPanelPrincipal.Controls.Add(this.TBDProductoCategoria);
            this.GPPanelPrincipal.Controls.Add(this.TBDProductoGenero);
            this.GPPanelPrincipal.Controls.Add(this.TXTProductoDescripcion);
            this.GPPanelPrincipal.Controls.Add(this.TXTProductoModelo);
            this.GPPanelPrincipal.Controls.Add(this.GPFotografia);
            this.GPPanelPrincipal.Controls.Add(this.BTNSalir);
            this.GPPanelPrincipal.Controls.Add(this.BTNLimpiar);
            this.GPPanelPrincipal.Controls.Add(this.BTNGrabar);
            this.GPPanelPrincipal.Controls.Add(this.SWBProductoEstadoStock);
            this.GPPanelPrincipal.DisabledBackColor = System.Drawing.Color.Empty;
            this.GPPanelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GPPanelPrincipal.Location = new System.Drawing.Point(0, 0);
            this.GPPanelPrincipal.Name = "GPPanelPrincipal";
            this.GPPanelPrincipal.Size = new System.Drawing.Size(601, 460);
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
            this.GPPanelPrincipal.TabIndex = 0;
            this.GPPanelPrincipal.Text = "Producto";
            // 
            // LBLCodigoDeBarras
            // 
            this.LBLCodigoDeBarras.BackColor = System.Drawing.Color.LightGreen;
            // 
            // 
            // 
            this.LBLCodigoDeBarras.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LBLCodigoDeBarras.Location = new System.Drawing.Point(190, 15);
            this.LBLCodigoDeBarras.Name = "LBLCodigoDeBarras";
            this.LBLCodigoDeBarras.Size = new System.Drawing.Size(143, 23);
            this.LBLCodigoDeBarras.TabIndex = 35;
            this.LBLCodigoDeBarras.Text = "Sin codigo";
            // 
            // LBLPrecioMinVenta
            // 
            // 
            // 
            // 
            this.LBLPrecioMinVenta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LBLPrecioMinVenta.Location = new System.Drawing.Point(10, 320);
            this.LBLPrecioMinVenta.Name = "LBLPrecioMinVenta";
            this.LBLPrecioMinVenta.Size = new System.Drawing.Size(174, 23);
            this.LBLPrecioMinVenta.TabIndex = 34;
            this.LBLPrecioMinVenta.Text = "Precio Min. Venta:";
            // 
            // LBLPrecioVenta
            // 
            // 
            // 
            // 
            this.LBLPrecioVenta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LBLPrecioVenta.Location = new System.Drawing.Point(10, 349);
            this.LBLPrecioVenta.Name = "LBLPrecioVenta";
            this.LBLPrecioVenta.Size = new System.Drawing.Size(172, 23);
            this.LBLPrecioVenta.TabIndex = 33;
            this.LBLPrecioVenta.Text = "Precio Venta:";
            // 
            // LBLStockActual
            // 
            // 
            // 
            // 
            this.LBLStockActual.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LBLStockActual.Location = new System.Drawing.Point(9, 291);
            this.LBLStockActual.Name = "LBLStockActual";
            this.LBLStockActual.Size = new System.Drawing.Size(174, 22);
            this.LBLStockActual.TabIndex = 32;
            this.LBLStockActual.Text = "Stock Actual:";
            // 
            // BTNCodigoDeBarras
            // 
            this.BTNCodigoDeBarras.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BTNCodigoDeBarras.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BTNCodigoDeBarras.Location = new System.Drawing.Point(339, 14);
            this.BTNCodigoDeBarras.Name = "BTNCodigoDeBarras";
            this.BTNCodigoDeBarras.Size = new System.Drawing.Size(25, 23);
            this.BTNCodigoDeBarras.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.BTNCodigoDeBarras.TabIndex = 31;
            this.BTNCodigoDeBarras.Click += new System.EventHandler(this.BTNCodigoDeBarras_Click);
            // 
            // NUDStockActual
            // 
            this.NUDStockActual.DecimalPlaces = 2;
            this.NUDStockActual.Location = new System.Drawing.Point(190, 291);
            this.NUDStockActual.Name = "NUDStockActual";
            this.NUDStockActual.Size = new System.Drawing.Size(174, 23);
            this.NUDStockActual.TabIndex = 30;
            this.NUDStockActual.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // NUDPrecioVenta
            // 
            this.NUDPrecioVenta.DecimalPlaces = 2;
            this.NUDPrecioVenta.Location = new System.Drawing.Point(190, 349);
            this.NUDPrecioVenta.Name = "NUDPrecioVenta";
            this.NUDPrecioVenta.Size = new System.Drawing.Size(174, 23);
            this.NUDPrecioVenta.TabIndex = 29;
            this.NUDPrecioVenta.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // NUDPrecioMinVenta
            // 
            this.NUDPrecioMinVenta.DecimalPlaces = 2;
            this.NUDPrecioMinVenta.Location = new System.Drawing.Point(190, 320);
            this.NUDPrecioMinVenta.Name = "NUDPrecioMinVenta";
            this.NUDPrecioMinVenta.Size = new System.Drawing.Size(174, 23);
            this.NUDPrecioMinVenta.TabIndex = 28;
            this.NUDPrecioMinVenta.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // TBDProductoTalla
            // 
            // 
            // 
            // 
            this.TBDProductoTalla.BackgroundStyle.Class = "TextBoxBorder";
            this.TBDProductoTalla.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.BLTAyuda.SetBalloonCaption(this.TBDProductoTalla, "Ayuda");
            this.BLTAyuda.SetBalloonText(this.TBDProductoTalla, "Talla o Medida del producto");
            this.TBDProductoTalla.ButtonDropDown.Visible = true;
            this.TBDProductoTalla.Location = new System.Drawing.Point(190, 184);
            this.TBDProductoTalla.Name = "TBDProductoTalla";
            this.TBDProductoTalla.Size = new System.Drawing.Size(174, 22);
            this.TBDProductoTalla.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.TBDProductoTalla.TabIndex = 27;
            this.TBDProductoTalla.Text = "";
            this.TBDProductoTalla.WatermarkText = "Talla";
            // 
            // TBDProductoColor
            // 
            // 
            // 
            // 
            this.TBDProductoColor.BackgroundStyle.Class = "TextBoxBorder";
            this.TBDProductoColor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.BLTAyuda.SetBalloonCaption(this.TBDProductoColor, "Ayuda");
            this.BLTAyuda.SetBalloonText(this.TBDProductoColor, "Color del producto");
            this.TBDProductoColor.ButtonDropDown.Visible = true;
            this.TBDProductoColor.Location = new System.Drawing.Point(9, 184);
            this.TBDProductoColor.Name = "TBDProductoColor";
            this.TBDProductoColor.Size = new System.Drawing.Size(174, 22);
            this.TBDProductoColor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.TBDProductoColor.TabIndex = 26;
            this.TBDProductoColor.Text = "";
            this.TBDProductoColor.WatermarkText = "Color";
            // 
            // TBDProductoMaterial
            // 
            // 
            // 
            // 
            this.TBDProductoMaterial.BackgroundStyle.Class = "TextBoxBorder";
            this.TBDProductoMaterial.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.BLTAyuda.SetBalloonCaption(this.TBDProductoMaterial, "Ayuda");
            this.BLTAyuda.SetBalloonText(this.TBDProductoMaterial, "Material del producto");
            this.TBDProductoMaterial.ButtonDropDown.Visible = true;
            this.TBDProductoMaterial.Location = new System.Drawing.Point(10, 156);
            this.TBDProductoMaterial.Name = "TBDProductoMaterial";
            this.TBDProductoMaterial.Size = new System.Drawing.Size(354, 22);
            this.TBDProductoMaterial.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.TBDProductoMaterial.TabIndex = 25;
            this.TBDProductoMaterial.Text = "";
            this.TBDProductoMaterial.WatermarkText = "Material";
            // 
            // TBDProductoMarca
            // 
            // 
            // 
            // 
            this.TBDProductoMarca.BackgroundStyle.Class = "TextBoxBorder";
            this.TBDProductoMarca.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.BLTAyuda.SetBalloonCaption(this.TBDProductoMarca, "Ayuda");
            this.BLTAyuda.SetBalloonText(this.TBDProductoMarca, "Marca del producto");
            this.TBDProductoMarca.ButtonDropDown.Visible = true;
            this.TBDProductoMarca.Location = new System.Drawing.Point(10, 128);
            this.TBDProductoMarca.Name = "TBDProductoMarca";
            this.TBDProductoMarca.Size = new System.Drawing.Size(354, 22);
            this.TBDProductoMarca.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.TBDProductoMarca.TabIndex = 24;
            this.TBDProductoMarca.Text = "";
            this.TBDProductoMarca.WatermarkText = "Marca";
            // 
            // TBDProductoNombre
            // 
            // 
            // 
            // 
            this.TBDProductoNombre.BackgroundStyle.Class = "TextBoxBorder";
            this.TBDProductoNombre.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.BLTAyuda.SetBalloonCaption(this.TBDProductoNombre, "Ayuda");
            this.BLTAyuda.SetBalloonText(this.TBDProductoNombre, "Nombre del producto");
            this.TBDProductoNombre.ButtonDropDown.Visible = true;
            this.TBDProductoNombre.Location = new System.Drawing.Point(10, 100);
            this.TBDProductoNombre.Name = "TBDProductoNombre";
            this.TBDProductoNombre.Size = new System.Drawing.Size(354, 22);
            this.TBDProductoNombre.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.TBDProductoNombre.TabIndex = 23;
            this.TBDProductoNombre.Text = "";
            this.TBDProductoNombre.WatermarkText = "Nombre del Producto";
            // 
            // TBDProductoCategoria
            // 
            // 
            // 
            // 
            this.TBDProductoCategoria.BackgroundStyle.Class = "TextBoxBorder";
            this.TBDProductoCategoria.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.BLTAyuda.SetBalloonCaption(this.TBDProductoCategoria, "Ayuda");
            this.BLTAyuda.SetBalloonText(this.TBDProductoCategoria, "Tipo de Producto");
            this.TBDProductoCategoria.ButtonDropDown.Visible = true;
            this.TBDProductoCategoria.Location = new System.Drawing.Point(10, 72);
            this.TBDProductoCategoria.Name = "TBDProductoCategoria";
            this.TBDProductoCategoria.Size = new System.Drawing.Size(354, 22);
            this.TBDProductoCategoria.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.TBDProductoCategoria.TabIndex = 22;
            this.TBDProductoCategoria.Text = "";
            this.TBDProductoCategoria.WatermarkText = "Categoría";
            // 
            // TBDProductoGenero
            // 
            // 
            // 
            // 
            this.TBDProductoGenero.BackgroundStyle.Class = "TextBoxBorder";
            this.TBDProductoGenero.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.BLTAyuda.SetBalloonCaption(this.TBDProductoGenero, "Ayuda");
            this.BLTAyuda.SetBalloonText(this.TBDProductoGenero, "Genero de Persona");
            this.TBDProductoGenero.ButtonDropDown.Visible = true;
            this.TBDProductoGenero.Location = new System.Drawing.Point(190, 44);
            this.TBDProductoGenero.Name = "TBDProductoGenero";
            this.TBDProductoGenero.Size = new System.Drawing.Size(174, 22);
            this.TBDProductoGenero.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.TBDProductoGenero.TabIndex = 21;
            this.TBDProductoGenero.Text = "";
            this.TBDProductoGenero.WatermarkText = "Género";
            // 
            // TXTProductoDescripcion
            // 
            this.TXTProductoDescripcion.BackColor = System.Drawing.Color.White;
            this.BLTAyuda.SetBalloonCaption(this.TXTProductoDescripcion, "Ayuda");
            this.BLTAyuda.SetBalloonText(this.TXTProductoDescripcion, "Descripción breve del producto (Detalles)");
            // 
            // 
            // 
            this.TXTProductoDescripcion.Border.Class = "TextBoxBorder";
            this.TXTProductoDescripcion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.TXTProductoDescripcion.DisabledBackColor = System.Drawing.Color.White;
            this.TXTProductoDescripcion.ForeColor = System.Drawing.Color.Black;
            this.TXTProductoDescripcion.Location = new System.Drawing.Point(9, 212);
            this.TXTProductoDescripcion.Multiline = true;
            this.TXTProductoDescripcion.Name = "TXTProductoDescripcion";
            this.TXTProductoDescripcion.PreventEnterBeep = true;
            this.TXTProductoDescripcion.Size = new System.Drawing.Size(355, 73);
            this.TXTProductoDescripcion.TabIndex = 14;
            this.TXTProductoDescripcion.WatermarkText = "Descripcion del Producto";
            this.TXTProductoDescripcion.TextChanged += new System.EventHandler(this.TXTProductoDescripcion_TextChanged);
            // 
            // TXTProductoModelo
            // 
            this.TXTProductoModelo.BackColor = System.Drawing.Color.White;
            this.BLTAyuda.SetBalloonCaption(this.TXTProductoModelo, "Ayuda");
            this.BLTAyuda.SetBalloonText(this.TXTProductoModelo, "Modelo o Confeccion del producto");
            // 
            // 
            // 
            this.TXTProductoModelo.Border.Class = "TextBoxBorder";
            this.TXTProductoModelo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.TXTProductoModelo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TXTProductoModelo.DisabledBackColor = System.Drawing.Color.White;
            this.TXTProductoModelo.ForeColor = System.Drawing.Color.Black;
            this.TXTProductoModelo.Location = new System.Drawing.Point(9, 43);
            this.TXTProductoModelo.Name = "TXTProductoModelo";
            this.TXTProductoModelo.PreventEnterBeep = true;
            this.TXTProductoModelo.Size = new System.Drawing.Size(175, 23);
            this.TXTProductoModelo.TabIndex = 7;
            this.TXTProductoModelo.WatermarkText = "Modelo";
            // 
            // GPFotografia
            // 
            this.GPFotografia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            this.GPFotografia.CanvasColor = System.Drawing.SystemColors.Control;
            this.GPFotografia.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.GPFotografia.Controls.Add(this.PCBFotografia);
            this.GPFotografia.Controls.Add(this.BTNAbrirFoto);
            this.GPFotografia.Controls.Add(this.BTNLimpiarFoto);
            this.GPFotografia.Controls.Add(this.BTNCapturarFoto);
            this.GPFotografia.Controls.Add(this.PCBCamara);
            this.GPFotografia.DisabledBackColor = System.Drawing.Color.Empty;
            this.GPFotografia.Location = new System.Drawing.Point(370, 14);
            this.GPFotografia.Name = "GPFotografia";
            this.GPFotografia.Size = new System.Drawing.Size(213, 415);
            // 
            // 
            // 
            this.GPFotografia.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.GPFotografia.Style.BackColorGradientAngle = 90;
            this.GPFotografia.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.GPFotografia.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.GPFotografia.Style.BorderBottomWidth = 1;
            this.GPFotografia.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.GPFotografia.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.GPFotografia.Style.BorderLeftWidth = 1;
            this.GPFotografia.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.GPFotografia.Style.BorderRightWidth = 1;
            this.GPFotografia.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.GPFotografia.Style.BorderTopWidth = 1;
            this.GPFotografia.Style.CornerDiameter = 4;
            this.GPFotografia.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.GPFotografia.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.GPFotografia.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.GPFotografia.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.GPFotografia.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.GPFotografia.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.GPFotografia.TabIndex = 15;
            this.GPFotografia.Text = "Fotografía";
            // 
            // PCBFotografia
            // 
            this.BLTAyuda.SetBalloonCaption(this.PCBFotografia, "Ayuda");
            this.BLTAyuda.SetBalloonText(this.PCBFotografia, "Foto registrado del producto");
            this.PCBFotografia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PCBFotografia.Image = ((System.Drawing.Image)(resources.GetObject("PCBFotografia.Image")));
            this.PCBFotografia.Location = new System.Drawing.Point(3, 227);
            this.PCBFotografia.Name = "PCBFotografia";
            this.PCBFotografia.Size = new System.Drawing.Size(198, 161);
            this.PCBFotografia.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PCBFotografia.TabIndex = 14;
            this.PCBFotografia.TabStop = false;
            // 
            // BTNAbrirFoto
            // 
            this.BTNAbrirFoto.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BTNAbrirFoto.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BTNAbrirFoto.Image = global::SistemaDeGestion2026.Properties.Resources.ic_camara_abrir;
            this.BTNAbrirFoto.ImageFixedSize = new System.Drawing.Size(40, 40);
            this.BTNAbrirFoto.Location = new System.Drawing.Point(139, 170);
            this.BTNAbrirFoto.Name = "BTNAbrirFoto";
            this.BTNAbrirFoto.Size = new System.Drawing.Size(62, 51);
            this.BTNAbrirFoto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.BTNAbrirFoto.TabIndex = 2;
            this.BTNAbrirFoto.Click += new System.EventHandler(this.BTNAbrirFoto_Click);
            // 
            // BTNLimpiarFoto
            // 
            this.BTNLimpiarFoto.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BTNLimpiarFoto.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BTNLimpiarFoto.Image = global::SistemaDeGestion2026.Properties.Resources.ic_camara_Limpiar;
            this.BTNLimpiarFoto.ImageFixedSize = new System.Drawing.Size(40, 40);
            this.BTNLimpiarFoto.Location = new System.Drawing.Point(71, 170);
            this.BTNLimpiarFoto.Name = "BTNLimpiarFoto";
            this.BTNLimpiarFoto.Size = new System.Drawing.Size(62, 51);
            this.BTNLimpiarFoto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.BTNLimpiarFoto.TabIndex = 1;
            this.BTNLimpiarFoto.Click += new System.EventHandler(this.BTNLimpiarFoto_Click);
            // 
            // BTNCapturarFoto
            // 
            this.BTNCapturarFoto.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BTNCapturarFoto.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BTNCapturarFoto.Image = global::SistemaDeGestion2026.Properties.Resources.ic_camara_tomar;
            this.BTNCapturarFoto.ImageFixedSize = new System.Drawing.Size(40, 40);
            this.BTNCapturarFoto.Location = new System.Drawing.Point(3, 170);
            this.BTNCapturarFoto.Name = "BTNCapturarFoto";
            this.BTNCapturarFoto.Size = new System.Drawing.Size(62, 51);
            this.BTNCapturarFoto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.BTNCapturarFoto.TabIndex = 0;
            this.BTNCapturarFoto.Click += new System.EventHandler(this.BTNCapturarFoto_Click);
            // 
            // PCBCamara
            // 
            this.BLTAyuda.SetBalloonCaption(this.PCBCamara, "Ayuda");
            this.BLTAyuda.SetBalloonText(this.PCBCamara, "Cámara para ingresar foto del producto");
            this.PCBCamara.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PCBCamara.Image = ((System.Drawing.Image)(resources.GetObject("PCBCamara.Image")));
            this.PCBCamara.Location = new System.Drawing.Point(3, 3);
            this.PCBCamara.Name = "PCBCamara";
            this.PCBCamara.Size = new System.Drawing.Size(198, 161);
            this.PCBCamara.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PCBCamara.TabIndex = 0;
            this.PCBCamara.TabStop = false;
            // 
            // BTNSalir
            // 
            this.BTNSalir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BTNSalir.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BTNSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BTNSalir.Image = global::SistemaDeGestion2026.Properties.Resources.ic_salir;
            this.BTNSalir.ImageFixedSize = new System.Drawing.Size(40, 40);
            this.BTNSalir.Location = new System.Drawing.Point(254, 378);
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
            this.BTNLimpiar.Location = new System.Drawing.Point(129, 378);
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
            this.BTNGrabar.Location = new System.Drawing.Point(12, 378);
            this.BTNGrabar.Name = "BTNGrabar";
            this.BTNGrabar.Size = new System.Drawing.Size(111, 51);
            this.BTNGrabar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.BTNGrabar.TabIndex = 18;
            this.BTNGrabar.Text = "&Grabar";
            this.BTNGrabar.Click += new System.EventHandler(this.BTNGrabar_Click);
            // 
            // SWBProductoEstadoStock
            // 
            // 
            // 
            // 
            this.SWBProductoEstadoStock.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.SWBProductoEstadoStock.Location = new System.Drawing.Point(9, 14);
            this.SWBProductoEstadoStock.Name = "SWBProductoEstadoStock";
            this.SWBProductoEstadoStock.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.SWBProductoEstadoStock.OffText = "Inhabilitado";
            this.SWBProductoEstadoStock.OffTextColor = System.Drawing.Color.White;
            this.SWBProductoEstadoStock.OnBackColor = System.Drawing.Color.LimeGreen;
            this.SWBProductoEstadoStock.OnText = "Habilitado";
            this.SWBProductoEstadoStock.OnTextColor = System.Drawing.Color.White;
            this.SWBProductoEstadoStock.Size = new System.Drawing.Size(175, 23);
            this.SWBProductoEstadoStock.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.SWBProductoEstadoStock.TabIndex = 16;
            this.SWBProductoEstadoStock.Value = true;
            this.SWBProductoEstadoStock.ValueObject = "Y";
            this.SWBProductoEstadoStock.ValueChanged += new System.EventHandler(this.SWBProductoEstadoStock_ValueChanged);
            // 
            // OFDElegirImagen
            // 
            this.OFDElegirImagen.Filter = "Archivos de Imagen|*.jpg;*.jpeg;*.png";
            this.OFDElegirImagen.Title = "Elegir fotografía";
            // 
            // FRMProducto_Registrar
            // 
            this.AcceptButton = this.BTNGrabar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BTNSalir;
            this.ClientSize = new System.Drawing.Size(601, 460);
            this.Controls.Add(this.GPPanelPrincipal);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FRMProducto_Registrar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRMProducto_Registrar";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FRMProducto_Registrar_FormClosing);
            this.Load += new System.EventHandler(this.FRMProducto_Registrar_Load);
            this.GPPanelPrincipal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NUDStockActual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDPrecioVenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDPrecioMinVenta)).EndInit();
            this.GPFotografia.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PCBFotografia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PCBCamara)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel GPPanelPrincipal;
        private DevComponents.DotNetBar.Controls.GroupPanel GPFotografia;
        private System.Windows.Forms.PictureBox PCBFotografia;
        private DevComponents.DotNetBar.ButtonX BTNAbrirFoto;
        private DevComponents.DotNetBar.ButtonX BTNLimpiarFoto;
        private DevComponents.DotNetBar.ButtonX BTNCapturarFoto;
        private System.Windows.Forms.PictureBox PCBCamara;
        private DevComponents.DotNetBar.ButtonX BTNSalir;
        private DevComponents.DotNetBar.ButtonX BTNLimpiar;
        private DevComponents.DotNetBar.ButtonX BTNGrabar;
        private DevComponents.DotNetBar.Controls.SwitchButton SWBProductoEstadoStock;
        private DevComponents.DotNetBar.Controls.TextBoxX TXTProductoModelo;
        private DevComponents.DotNetBar.Controls.TextBoxX TXTProductoDescripcion;
        private System.Windows.Forms.OpenFileDialog OFDElegirImagen;
        private DevComponents.DotNetBar.BalloonTip BLTAyuda;
        private DevComponents.DotNetBar.Controls.TextBoxDropDown TBDProductoGenero;
        private DevComponents.DotNetBar.Controls.TextBoxDropDown TBDProductoNombre;
        private DevComponents.DotNetBar.Controls.TextBoxDropDown TBDProductoCategoria;
        private DevComponents.DotNetBar.Controls.TextBoxDropDown TBDProductoMarca;
        private DevComponents.DotNetBar.Controls.TextBoxDropDown TBDProductoTalla;
        private DevComponents.DotNetBar.Controls.TextBoxDropDown TBDProductoColor;
        private DevComponents.DotNetBar.Controls.TextBoxDropDown TBDProductoMaterial;
        private System.Windows.Forms.NumericUpDown NUDPrecioMinVenta;
        private System.Windows.Forms.NumericUpDown NUDStockActual;
        private System.Windows.Forms.NumericUpDown NUDPrecioVenta;
        private DevComponents.DotNetBar.ButtonX BTNCodigoDeBarras;
        private DevComponents.DotNetBar.LabelX LBLCodigoDeBarras;
        private DevComponents.DotNetBar.LabelX LBLPrecioMinVenta;
        private DevComponents.DotNetBar.LabelX LBLPrecioVenta;
        private DevComponents.DotNetBar.LabelX LBLStockActual;
    }
}