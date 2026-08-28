using AForge.Video.DirectShow;
using CapaRN;
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
    public partial class FRMCategoria_Registrar : DevComponents.DotNetBar.Office2007Form
    {
        #region Variables
        private acatpro categoria = new acatpro();
        private xnumcor correlativo = new xnumcor();
        public bool modificar = false;
        public String codCatMod = "";
        public bool actualizar = false;
        //Variables para la camara
        /*private FilterInfoCollection CaptureDevice; // list of webcam
        private VideoCaptureDevice FinalFrame;
        private bool TieneFoto = false;
        */
        #endregion

        #region Constructor
        public FRMCategoria_Registrar()
        {
            InitializeComponent();
        }
        #endregion

        #region Metodos
        private bool VerificarIntegridad()
        {
            bool respuesta = true;
            acatpro categoria2 = new acatpro();
            

            
            if (TXTCategoriaProductoNombre.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Introduzca el NOMBRE de la categoría", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTCategoriaProductoNombre.Focus();
                respuesta = false;
            }
            return respuesta;
        }
        private void LimpiarCasillas()
        {
            SWBCategoriaProductoEstadoStock.Value = true;
            TXTCategoriaProductoNombre.Text = "";
        }
        private void JalarDatos()
        {
            categoria.pacpcodcat = this.codCatMod;
            categoria.ObtenerDatos();
            SWBCategoriaProductoEstadoStock.Value = categoria.cacpestcat;
            TXTCategoriaProductoNombre.Text = categoria.cacpnomcat;
            TXTCategoriaProductoCodigo.Text = categoria.pacpcodcat;
        }
        #endregion

        #region Eventos
        #endregion

        private void BTNGrabar_Click(object sender, EventArgs e)
        {
            if (VerificarIntegridad())
            {
                categoria = new acatpro();

                if (!this.modificar)
                {
                    //Generar el correlativo
                    correlativo.pxnctipcor = "acatpro";
                    if (correlativo.ObtenerSiguiente())
                    {
                        categoria.pacpcodcat = correlativo.pxnctipcor + "-" +
                                                correlativo.cxncnumcor.ToString("D5");
                    }
                }
                else
                {
                    categoria.pacpcodcat = this.codCatMod;
                }
                categoria.cacpestcat = SWBCategoriaProductoEstadoStock.Value;
                categoria.cacpnomcat = TXTCategoriaProductoNombre.Text;

                //Fotografia del producto
                /*if (TieneFoto)
                {
                    producto.capdfotpro = MetodosGenerales.ConvertImageToBase64String(PCBFotografia.Image);
                }
                else
                {
                    producto.capdfotpro = "";
                }
                */

                if (!this.modificar)
                {
                    if (categoria.Grabar())
                    {
                        MessageBox.Show("Categoría guardada correctamente!!",
                                        "Mensaje",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                        LimpiarCasillas();
                        this.actualizar = true;
                        this.FormClosing -= FRMCategoria_Registrar_FormClosing;
                        //ApagarCamara();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Categoría no se pudo guardar!!",
                                        "Error",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    if (categoria.Modificar())
                    {
                        MessageBox.Show("Categoría modificada correctamente!!",
                                        "Mensaje",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                        LimpiarCasillas();
                        this.actualizar = true;
                        this.FormClosing -= FRMCategoria_Registrar_FormClosing;
                        //ApagarCamara();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Categoría no se pudo modificar!!",
                                            "Error",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void BTNSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FRMCategoria_Registrar_FormClosing(object sender, FormClosingEventArgs e)
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
                //ApagarCamara();
            }
        }

        private void FRMCategoria_Registrar_Load(object sender, EventArgs e)
        {
            if (this.modificar)
            {
                JalarDatos();
                BTNGrabar.Text = "&Modificar";
                this.Text = "Modificar Categoría";
                GPPanelPrincipal.Text = "Modificar Categoría";
                TXTCategoriaProductoNombre.Focus();
            }
            else
            {
                LimpiarCasillas();
                BTNGrabar.Text = "&Guardar";
                this.Text = "Registrar Categoría";
                GPPanelPrincipal.Text = "Registrar Categoría";
                TXTCategoriaProductoNombre.Focus();
            }
        }

        private void BTNLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCasillas();
        }

        private void TXTCategoriaProductoNombre_KeyDown(object sender, KeyEventArgs e)
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
    }
}
