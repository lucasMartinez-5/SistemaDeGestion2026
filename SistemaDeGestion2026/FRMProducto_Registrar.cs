using AForge.Video;
using AForge.Video.DirectShow;
using CapaRN;
using DevComponents.DotNetBar.Controls;
using SistemaDeGestion2026.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaDeGestion2026
{
    public partial class FRMProducto_Registrar : DevComponents.DotNetBar.Office2007Form
    {
        #region Variables
        private bool lectorCBHabilitado = false;

        private aproduc producto = new aproduc();
        private xnumcor correlativo = new xnumcor();
        public bool modificar = false;
        public String codProMod = "";
        public bool actualizar = false;
        //Variables para la camara*/
        private FilterInfoCollection CaptureDevice; // list of webcam
        private VideoCaptureDevice FinalFrame;
        private bool TieneFoto = false;
        #endregion

        #region Constructor
        public FRMProducto_Registrar()
        {
            InitializeComponent();
            DetectarCamaras();
        }
        #endregion

        #region Metodos
        private bool VerificarIntegridad()
        {
            bool respuesta = true;
            aproduc producto2 = new aproduc();
            producto2.capdcodbar = LBLCodigoDeBarras.Text;
            //string cianterior = persona.capdnumcid;                           
            //persona.capdnumcid = TXTCI.Text;

            /*if (TXTProductoCodigo.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Introduzca el codigo dek producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTProductoCodigo.Focus();
                respuesta = false;
            }
            if (producto.ObtenerDatos())
            {
                MessageBox.Show("Ya existe un producto con ese código", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTProductoCodigo.Focus();
                respuesta = false;
            }*/
            if (TBDProductoNombre.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Introduzca el NOMBRE del producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBDProductoNombre.Focus();
                respuesta = false;
            }
            /*else if (DTIProductoFechaCreacion.Value > DateTime.Now)
            {
                MessageBox.Show("Introduzca FECHA DE CREACION válido del prductp", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DTIProductoFechaCreacion.Focus();
                respuesta = false;
            }
            else if (DTIProductoFechaModificacion.Value > DateTime.Now)
            {
                MessageBox.Show("Introduzca FECHA DE MODIFICACION válido del prducto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DTIProductoFechaModificacion.Focus();
                respuesta = false;
            }*/
            else if (TBDProductoMarca.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Introduzca la MARCA del producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBDProductoMarca.Focus();
                respuesta = false;
            }
            else if (TBDProductoColor.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Introduzca la COLOR del producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBDProductoColor.Focus();
                respuesta = false;
            }
            else if (TBDProductoTalla.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Introduzca la TALLA del producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBDProductoTalla.Focus();
                respuesta = false;
            }
            else if (TBDProductoMaterial.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Introduzca el MATERIAL del producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBDProductoMaterial.Focus();
                respuesta = false;
            }
            else if (TXTProductoModelo.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Introduzca el MODELO del producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTProductoModelo.Focus();
                respuesta = false;
            }
            else if (CMBGenero.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Introduzca el GÉNERO del producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CMBGenero.Focus();
                respuesta = false;
            }
            else if (LBLCodigoDeBarras.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Introduzca el CÓDIGO DE BARRA del producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LBLCodigoDeBarras.Focus();
                respuesta = false;
            }
            else if (producto2.ObtenerDatosCodBarra(modificar,producto.capdcodbar))
            {
                MessageBox.Show("Ya existe un producto con ese código de barras", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LBLCodigoDeBarras.Focus();
                respuesta = false;
            }
            else if (NUDStockActual.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Introduzca el STOCK del producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                NUDStockActual.Focus();
                respuesta = false;
            }
            else if (NUDPrecioVenta.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Introduzca el PRECIO DE VENTA del producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                NUDPrecioVenta.Focus();
                respuesta = false;
            }
            else if (NUDPrecioMinVenta.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Introduzca el PRECIO MÍNIMO del producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                NUDPrecioMinVenta.Focus();
                respuesta = false;
            }
            else if (CMBCategoria.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Introduzca la CATEGORÍA del producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CMBCategoria.Focus();
                respuesta = false;
            }
            return respuesta;
        }
        //Nuevo
        private void CargarComboCategorias()
        {
            List<acatpro> ListaCategorias= new List<acatpro>();
            acatpro categoria=new acatpro();
            ListaCategorias= categoria.Lista("cacpestcat=true order by cacpnomcat");
            CMBCategoria.Items.Clear();
            CMBCategoria.DisplayMember = "cacpnomcat";
            CMBCategoria.ValueMember = "pacpcodcat";
            CMBCategoria.DataSource = ListaCategorias;
            CMBCategoria.SelectedIndex = -1;
        }
        //Nuevo
        private void CargarComboNombreProducto()
        {
            List<acatpro> ListaCategorias = new List<acatpro>();
            acatpro categoria = new acatpro();
            ListaCategorias = categoria.Lista("cacpestcat=true order by cacpnomcat");
            CMBCategoria.Items.Clear();
            CMBCategoria.DisplayMember = "cacpnomcat";
            CMBCategoria.ValueMember = "pacpcodcat";
            CMBCategoria.DataSource = ListaCategorias;
            CMBCategoria.SelectedIndex = -1;
        }

        private void LimpiarCasillas()
        {
            SWBProductoEstadoStock.Value = true;
            LBLCodigoDeBarras.Text = "";
            /*
            TXTProductoNombre.Text = "";
            DTIProductoFechaCreacion.Text = "";
            DTIProductoFechaCreacion.Text = "";
            DTIProductoFechaModificacion.Text = "";
            TXTProductoMarca.Text = "";
            TXTProductoColor.Text = "";
            TXTProductoTalla.Text = "";
            TXTProductoMaterial.Text = "";
            TXTProductoModelo.Text = "";
            TXTProductoGenero.Text = "";
            TXTProductoStock.Text = "";
            TXTProductoPrecioVenta.Text = "";
            TXTProductoPrecioMinimo.Text = "";
            TXTProductoCategoria.Text = "";
            TXTProductoDescripcion.Text = "";
            */
        }

        private void JalarDatos()
        {
            producto.papdcodpro = this.codProMod;
            producto.ObtenerDatos();
            SWBProductoEstadoStock.Value = producto.capdestpro;
            //TXTProductoCodigo.Text = producto.papdcodpro;
            TBDProductoNombre.Text = producto.capdnompro;
            //DTIProductoFechaCreacion.Value = producto.capdfeccre;
            //DTIProductoFechaModificacion.Value = producto.capdfecmod;
            TBDProductoMarca.Text = producto.capdmarpro;
            TBDProductoColor.Text = producto.capdcolpro;
            TBDProductoTalla.Text = producto.capdtalpro;
            TBDProductoMaterial.Text = producto.capdmatpro;
            TXTProductoModelo.Text = producto.capdmodpro;
            TBDProductoGenero.Text = producto.capdgenpro;
            LBLCodigoDeBarras.Text = producto.capdcodbar;
            // CORRECCIÓN: Asignar los valores del objeto producto a los TextBox
            NUDStockActual.Text = producto.capdstopro.ToString();
            NUDPrecioMinVenta.Text = producto.capdpremin.ToString();
            NUDPrecioVenta.Text = producto.capdpreven.ToString();
            TBDProductoCategoria.Text = producto.capdcatpro;
            TXTProductoDescripcion.Text = producto.capddespro;

            if (producto.capdfotpro == "")
            {
                TieneFoto = false;
                PCBFotografia.Image = Resources.no_image;
            }
            else
            {
                TieneFoto = true;
                PCBFotografia.Image = MetodosGenerales.ConvertBase64StringToImage(producto.capdfotpro);
            }
        }
        #endregion

        #region Eventos
        private void BTNSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FRMProducto_Registrar_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea cerrar el formulario?",
                                "Pregunta",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question,
                                MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                ApagarCamara();
            }
        }

        private void TXTProductoCodigo_Enter(object sender, EventArgs e)
        {
            TextBoxX a = (TextBoxX)sender;
            a.SelectAll();
        }

        private void FRMProducto_Registrar_Load(object sender, EventArgs e)
        {
            IniciarCamara();
            if (this.modificar)
            {
                JalarDatos();
                BTNGrabar.Text = "&Modificar";
                this.Text = "Modificar Producto";
                GPPanelPrincipal.Text = "Modificar Producto";
                LBLCodigoDeBarras.Focus();
            }
            else
            {
                LimpiarCasillas();
                BTNGrabar.Text = "&Guardar";
                this.Text = "Registrar Producto";
                GPPanelPrincipal.Text = "Registrar Producto";
                LBLCodigoDeBarras.Focus();
            }
        }

        private void BTNGrabar_Click(object sender, EventArgs e)
        {
            if (VerificarIntegridad())
            {
                producto = new aproduc();

                if (!this.modificar)
                {
                    //Generar el correlativo
                    correlativo.pxnctipcor = "aproduc";
                    if (correlativo.ObtenerSiguiente())
                    {
                        producto.papdcodpro = correlativo.pxnctipcor + "-" +
                                               correlativo.cxncnumcor.ToString("D12");
                    }
                }
                else
                {
                    producto.papdcodpro = this.codProMod;
                }
                producto.capdestpro = SWBProductoEstadoStock.Value;
                producto.capdgenpro = TBDProductoGenero.Text;
                producto.capdnompro = TBDProductoNombre.Text;
                producto.capddespro = TXTProductoDescripcion.Text;
                producto.capdpreven = decimal.TryParse(NUDPrecioVenta.Text, out decimal precioVenta) ? precioVenta : 0.0m;
                producto.capdpremin = decimal.TryParse(NUDPrecioMinVenta.Text, out decimal precioMinimo) ? precioMinimo : 0.0m;
                producto.capdstopro = int.TryParse(NUDStockActual.Text, out int stock) ? stock : 0;
                //producto.capdfeccre = DTIProductoFechaCreacion.Value;
                //producto.capdfecmod = DTIProductoFechaModificacion.Value;
                producto.capdmarpro = TBDProductoMarca.Text;
                producto.capdcolpro = TBDProductoColor.Text;
                producto.capdtalpro = TBDProductoTalla.Text;
                producto.capdmatpro = TBDProductoMaterial.Text;
                producto.capdmodpro = TXTProductoModelo.Text;
                producto.capdcodbar = LBLCodigoDeBarras.Text;
                producto.capdcatpro = TBDProductoCategoria.Text;

                //Fotografia del producto
                if (TieneFoto)
                {
                    producto.capdfotpro = MetodosGenerales.ConvertImageToBase64String(PCBFotografia.Image);
                }
                else
                {
                    producto.capdfotpro = "";
                }

                if (!this.modificar)
                {
                    if (producto.Grabar())
                    {
                        MessageBox.Show("Producto guardado correctamente!!",
                                        "Mensaje",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                        LimpiarCasillas();
                        this.actualizar = true;
                        this.FormClosing -= FRMProducto_Registrar_FormClosing;
                        ApagarCamara();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Producto no se pudo guardar!!",
                                        "Error",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    if (producto.Modificar())
                    {
                        MessageBox.Show("Producto modificado correctamente!!",
                                        "Mensaje",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                        LimpiarCasillas();
                        this.actualizar = true;
                        this.FormClosing -= FRMProducto_Registrar_FormClosing;
                        ApagarCamara();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Producto no se pudo modificar!!",
                                            "Error",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void BTNAbrirFoto_Click(object sender, EventArgs e)
        {
            if (OFDElegirImagen.ShowDialog() == DialogResult.OK)
            {
                PCBFotografia.ImageLocation = OFDElegirImagen.FileName;
                TieneFoto = true;
            }
        }
        #endregion

        #region Metodos para la Cámara
        private void DetectarCamaras()
        {
            CaptureDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);//constructor            
            FinalFrame = new VideoCaptureDevice();
        }
        
        private void IniciarCamara()
        {
            try
            {
                FinalFrame = new VideoCaptureDevice(CaptureDevice[1].MonikerString);// specified web cam and its filter moniker string
                FinalFrame.NewFrame += new NewFrameEventHandler(FinalFrame_NewFrame);// click button event is fired, 
                FinalFrame.Start();
            }
            catch
            {
                MessageBox.Show("No se tiene una cámara conectada al equipo",
                    "Error de cámara",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ApagarCamara()
        {
            if (FinalFrame.IsRunning == true) FinalFrame.Stop();
        }
        #endregion

        private void BTNLimpiarFoto_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea borrar la imagen?",
                            "Pregunta",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question,
                            MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                TieneFoto = false;
                PCBFotografia.Image = Resources.no_image;
            }
        }
        void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs) // must be void so that it can be accessed everywhere.
                                                                             // New Frame Event Args is an constructor of a class
        {
            PCBCamara.Image = (Bitmap)eventArgs.Frame.Clone();// clone the bitmap
        }

        private void BTNCapturarFoto_Click(object sender, EventArgs e)
        {
            PCBFotografia.Image = PCBCamara.Image;
            TieneFoto = true;
        }

        private void TXTProductoNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void TXTProductoStock_KeyDown(object sender, KeyEventArgs e)
        {
            bool teclaValida = false;

            if ((e.KeyCode >= Keys.NumPad0) && (e.KeyCode <= Keys.NumPad9))
                teclaValida = true;
            else if ((e.KeyCode >= Keys.D0) && (e.KeyCode <= Keys.D9) && !e.Shift)
                teclaValida = true;
            else if
                ((e.KeyCode == Keys.Back) ||
                (e.KeyCode == Keys.Delete) ||
                (e.KeyCode == Keys.Left) ||
                (e.KeyCode == Keys.Right))
                teclaValida = true;

            if (!teclaValida)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void TXTNombres_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void TXTProductoMarca_KeyDown(object sender, KeyEventArgs e)
        {
            bool teclaValida = false;

            if ((e.KeyCode >= Keys.A) && (e.KeyCode <= Keys.Z) && (!e.Alt))
                teclaValida = true;
            else if ((e.KeyCode == Keys.Space) ||
                (e.KeyCode == Keys.Back) ||
                (e.KeyCode == Keys.Delete) ||
                (e.KeyCode == Keys.Left) ||
                (e.KeyCode == Keys.Right) ||
                ((e.KeyCode == Keys.Oem4) && !e.Shift))
                teclaValida = true;
            if (!teclaValida)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void TXTProductoNombre_KeyDown(object sender, KeyEventArgs e)
        {
            bool teclaValida = false;

            if ((e.KeyCode >= Keys.A) && (e.KeyCode <= Keys.Z) && (!e.Alt))
                teclaValida = true;
            else if ((e.KeyCode == Keys.Space) ||
                (e.KeyCode == Keys.Back) ||
                (e.KeyCode == Keys.Delete) ||
                (e.KeyCode == Keys.Left) ||
                (e.KeyCode == Keys.Right) ||
                ((e.KeyCode == Keys.Oem4) && !e.Shift))
                teclaValida = true;
            if (!teclaValida)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void TXTProductoMaterial_KeyDown(object sender, KeyEventArgs e)
        {
            bool teclaValida = false;

            if ((e.KeyCode >= Keys.A) && (e.KeyCode <= Keys.Z) && (!e.Alt))
                teclaValida = true;
            else if ((e.KeyCode == Keys.Space) ||
                (e.KeyCode == Keys.Back) ||
                (e.KeyCode == Keys.Delete) ||
                (e.KeyCode == Keys.Left) ||
                (e.KeyCode == Keys.Right) ||
                ((e.KeyCode == Keys.Oem4) && !e.Shift))
                teclaValida = true;
            if (!teclaValida)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void TXTProductoColor_KeyDown(object sender, KeyEventArgs e)
        {
            bool teclaValida = false;

            if ((e.KeyCode >= Keys.A) && (e.KeyCode <= Keys.Z) && (!e.Alt))
                teclaValida = true;
            else if ((e.KeyCode == Keys.Space) ||
                (e.KeyCode == Keys.Back) ||
                (e.KeyCode == Keys.Delete) ||
                (e.KeyCode == Keys.Left) ||
                (e.KeyCode == Keys.Right) ||
                ((e.KeyCode == Keys.Oem4) && !e.Shift))
                teclaValida = true;
            if (!teclaValida)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void TXTProductoCategoria_KeyDown(object sender, KeyEventArgs e)
        {
            bool teclaValida = false;

            if ((e.KeyCode >= Keys.A) && (e.KeyCode <= Keys.Z) && (!e.Alt))
                teclaValida = true;
            else if ((e.KeyCode == Keys.Space) ||
                (e.KeyCode == Keys.Back) ||
                (e.KeyCode == Keys.Delete) ||
                (e.KeyCode == Keys.Left) ||
                (e.KeyCode == Keys.Right) ||
                ((e.KeyCode == Keys.Oem4) && !e.Shift))
                teclaValida = true;
            if (!teclaValida)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void TXTProductoCodigoDeBarra_TextChanged(object sender, EventArgs e)
        {

        }

        private void TXTProductoCodigoDeBarra_KeyDown(object sender, KeyEventArgs e)
        {
            bool teclaValida = false;

            if ((e.KeyCode >= Keys.NumPad0) && (e.KeyCode <= Keys.NumPad9))
                teclaValida = true;
            else if ((e.KeyCode >= Keys.D0) && (e.KeyCode <= Keys.D9) && !e.Shift)
                teclaValida = true;
            else if
                ((e.KeyCode == Keys.Back) ||
                (e.KeyCode == Keys.Delete) ||
                (e.KeyCode == Keys.Left) ||
                (e.KeyCode == Keys.Right))
                teclaValida = true;

            if (!teclaValida)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void SWBProductoEstadoStock_ValueChanged(object sender, EventArgs e)
        {
            if (NUDStockActual.Text == "0") SWBProductoEstadoStock.Enabled = false; else SWBProductoEstadoStock.Enabled = true;
        }

        private void TXTProductoDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void TXTProductoStock_TextChanged(object sender, EventArgs e)
        {

        }

        private void TXTProductoColor_TextChanged(object sender, EventArgs e)
        {

        }

        private void TXTProductoGenero_TextChanged(object sender, EventArgs e)
        {

        }

        private void TXTProductoPrecioVenta_TextChanged(object sender, EventArgs e)
        {

        }

        private void BTNLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCasillas();
        }

        private void BTNCodigoDeBarras_Click(object sender, EventArgs e)
        {

        }

        private void TBDProductoGenero_TextChanged(object sender, EventArgs e)
        {

        }
        //nuevo
        private void BTNCodigoDeBarras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (LBLCodigoDeBarras.Text == "LECTOR ACTIVO")
            {
                LBLCodigoDeBarras.Text = "" + e.KeyChar;
            }
            else
            {
                LBLCodigoDeBarras.Text += e.KeyChar;
            }
        }

        private void NUDStockActual_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
