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
        private aproduc producto = new aproduc();
        private xnumcor correlativo = new xnumcor();
        public bool modificar = false;
        public String codProMod = "";
        public bool actualizar = false;
        //Variables para la camara
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
            producto2.capdcodbar = TXTProductoCodigoDeBarra.Text;
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
            if (TXTProductoNombre.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Introduzca el NOMBRE del producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTProductoNombre.Focus();
                respuesta = false;
            }
            else if (DTIProductoFechaCreacion.Value > DateTime.Now)
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
            }
            else if (TXTProductoMarca.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Introduzca la MARCA del producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTProductoMarca.Focus();
                respuesta = false;
            }
            else if (TXTProductoColor.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Introduzca la COLOR del producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTProductoColor.Focus();
                respuesta = false;
            }
            else if (TXTProductoTalla.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Introduzca la TALLA del producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTProductoTalla.Focus();
                respuesta = false;
            }
            else if (TXTProductoMaterial.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Introduzca el MATERIAL del producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTProductoMaterial.Focus();
                respuesta = false;
            }
            else if (TXTProductoModelo.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Introduzca el MODELO del producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTProductoModelo.Focus();
                respuesta = false;
            }
            else if (TXTProductoGenero.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Introduzca el GÉNERO del producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTProductoGenero.Focus();
                respuesta = false;
            }
            else if (TXTProductoCodigoDeBarra.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Introduzca el CÓDIGO DE BARRA del producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTProductoCodigoDeBarra.Focus();
                respuesta = false;
            }
            else if (producto.ObtenerDatosCodBarra(modificar,producto.capdcodbar))
            {
                MessageBox.Show("Ya existe un producto con ese código de barras", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTProductoCodigoDeBarra.Focus();
                respuesta = false;
            }
            else if (TXTProductoStock.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Introduzca el STOCK del producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTProductoStock.Focus();
                respuesta = false;
            }
            else if (TXTProductoPrecioVenta.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Introduzca el PRECIO DE VENTA del producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTProductoPrecioVenta.Focus();
                respuesta = false;
            }
            else if (TXTProductoPrecioMinimo.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Introduzca el PRECIO MÍNIMO del producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTProductoPrecioMinimo.Focus();
                respuesta = false;
            }
            else if (TXTProductoCategoria.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Introduzca la CATEGORÍA del producto", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTProductoCategoria.Focus();
                respuesta = false;
            }
            return respuesta;
        }
        private void LimpiarCasillas()
        {
            SWBProductoEstadoStock.Value = true;
            TXTProductoCodigoDeBarra.Text = "";
        }

        private void JalarDatos()
        {
            producto.papdcodpro = this.codProMod;
            producto.ObtenerDatos();
            SWBProductoEstadoStock.Value = producto.capdestpro;
            TXTProductoCodigo.Text = producto.papdcodpro;
            TXTProductoNombre.Text = producto.capdnompro;
            DTIProductoFechaCreacion.Value = producto.capdfeccre;
            DTIProductoFechaModificacion.Value = producto.capdfecmod;
            TXTProductoMarca.Text = producto.capdmarpro;
            TXTProductoColor.Text = producto.capdcolpro;
            TXTProductoTalla.Text = producto.capdtalpro;
            TXTProductoMaterial.Text = producto.capdmatpro;
            TXTProductoModelo.Text = producto.capdmodpro;
            TXTProductoGenero.Text = producto.capdgenpro;
            TXTProductoCodigoDeBarra.Text = producto.capdcodbar;
            // CORRECCIÓN: Asignar los valores del objeto producto a los TextBox
            TXTProductoStock.Text = producto.capdstopro.ToString();
            TXTProductoPrecioMinimo.Text = producto.capdpremin.ToString();
            TXTProductoPrecioVenta.Text = producto.capdpreven.ToString();
            TXTProductoCategoria.Text = producto.capdcatpro;
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
                TXTProductoCodigoDeBarra.Focus();
            }
            else
            {
                LimpiarCasillas();
                BTNGrabar.Text = "&Guardar";
                this.Text = "Registrar Producto";
                GPPanelPrincipal.Text = "Registrar Producto";
                TXTProductoCodigoDeBarra.Focus();
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
                producto.capdgenpro = TXTProductoGenero.Text;
                producto.capdnompro = TXTProductoNombre.Text;
                producto.capddespro = TXTProductoDescripcion.Text;
                producto.capdpreven = decimal.TryParse(TXTProductoPrecioVenta.Text, out decimal precioVenta) ? precioVenta : 0.0m;
                producto.capdpremin = decimal.TryParse(TXTProductoPrecioMinimo.Text, out decimal precioMinimo) ? precioMinimo : 0.0m;
                producto.capdstopro = int.TryParse(TXTProductoStock.Text, out int stock) ? stock : 0;
                producto.capdfeccre = DTIProductoFechaCreacion.Value;
                producto.capdfecmod = DTIProductoFechaModificacion.Value;
                producto.capdmarpro = TXTProductoMarca.Text;
                producto.capdcolpro = TXTProductoColor.Text;
                producto.capdtalpro = TXTProductoTalla.Text;
                producto.capdmatpro = TXTProductoMaterial.Text;
                producto.capdmodpro = TXTProductoModelo.Text;
                producto.capdcodbar = TXTProductoCodigoDeBarra.Text;
                producto.capdcatpro = TXTProductoCategoria.Text;

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
            if (TXTProductoStock.Text == "0") TXTProductoStock.Enabled = false; else TXTProductoStock.Enabled = true;
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
    }
}
