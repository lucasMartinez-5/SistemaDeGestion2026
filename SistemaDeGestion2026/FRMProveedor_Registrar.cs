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
    public partial class FRMProveedor_Registrar : DevComponents.DotNetBar.Office2007Form
    {
        #region Variables
        private aproved proveedor = new aproved();
        private aperson persona = new aperson();
        private bool personaOk = false;
        private xnumcor correlativo = new xnumcor();
        public bool modificar = false;
        public String codPveMod = "";
        public bool actualizar = false;
        #endregion

        #region Constructor
        public FRMProveedor_Registrar()
        {
            InitializeComponent();
            //DetectarCamaras();
        }
        #endregion

        #region Métodos

        private bool VerificarIntegridad()
        {
            bool respuesta = true;
            aproved proveedor2 = new aproved();
            proveedor2.caprnitpro = TXTNIT.Text;
            aperson persona2 = new aperson();
            persona2.capsnumcel = TXTCelular.Text;
            //string cianterior = persona.capsnumcid;                           
            //persona.capsnumcid = TXTCI.Text;

            if (TXTCelular.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Introduzca el celular de la proveedor", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTCelular.Focus();
                respuesta = false;
            }
            else if (TXTNIT.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Introduzca el NIT del proveedor", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTNIT.Focus();
                respuesta = false;
            }// condicion para retringir NIT ajeno al modificar o registrar
            else if (proveedor2.ObtenerDatosNIT(modificar, proveedor.caprnitpro))
            {
                MessageBox.Show("Ya existe un proveedor con ese NIT", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTNIT.Focus();
                respuesta = false;
            }
            else if (TXTRazonSocial.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Introduzca el nombre completo del proveedor", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTRazonSocial.Focus();
                respuesta = false;
            }
            else if (TXTDireccion.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Introduzca la Direccion del proveedor", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTDireccion.Focus();
                respuesta = false;
            }

            return respuesta;
        }

        private void LimpiarCasillas()
        {
            SWBEstado.Value = true;
            TXTCelular.Text = "";
            TXTRazonSocial.Text = "";
            TXTNIT.Text = "";
            TXTNIT.Focus();
        }

        private void JalarDatos()
        {
            proveedor.paprcodpro = this.codPveMod;
            proveedor.ObtenerDatos();
            persona.papscodper = proveedor.faprcntpro;
            persona.ObtenerDatos();
            SWBEstado.Value = proveedor.caprestpro;
            TXTCelular.Text = persona.capsnumcel;
            TXTRazonSocial.Text = persona.capsapepat + " " +
                                    persona.capsapemat + " " +
                                    persona.capsnomper;
            TXTNIT.Text = proveedor.caprnitpro;
            TXTDireccion.Text = persona.capsdirper;
            //METODO PARA CARGAR LA FOTO DEL PROVEEDOR
            /*if (proveedor.caprfotpro == "")
            {
                TieneFoto = false;
                PCBFotografia.Image = Resources.no_image;
            }
            else
            {
                TieneFoto = true;
                PCBFotografia.Image = MetodosGenerales.ConvertBase64StringToImage(proveedor.caprfotpro);
            } */
        }

        #endregion

        #region Eventos
        private void BTNSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FRMProveedor_Registrar_FormClosing(object sender, FormClosingEventArgs e)
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

        private void TXTNIT_Enter(object sender, EventArgs e)
        {
            TextBoxX a = (TextBoxX)sender;
            a.SelectAll();
        }

        private void FRMProveedor_Registrar_Load(object sender, EventArgs e)
        {
            //IniciarCamara();
            if (this.modificar)
            {
                JalarDatos();
                BTNGrabar.Text = "&Modificar";
                this.Text = "Modificar Proveedor";
                GPPanelPrincipal.Text = "Modificar Proveedor";
                TXTNIT.Focus();
            }
            else
            {
                LimpiarCasillas();
                BTNGrabar.Text = "&Guardar";
                this.Text = "Registrar Proveedor";
                GPPanelPrincipal.Text = "Registrar Proveedor";
                TXTNIT.Focus();
            }
        }

        private void TXTCelular_KeyDown(object sender, KeyEventArgs e)
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

        private void TXTNIT_KeyDown(object sender, KeyEventArgs e)
        {
            bool teclaValida = false;

            if ((e.KeyCode >= Keys.NumPad0) && (e.KeyCode <= Keys.NumPad9))
                teclaValida = true;
            else if ((e.KeyCode >= Keys.D0) && (e.KeyCode <= Keys.D9) && !e.Shift)
                teclaValida = true;
            else if ((e.KeyCode >= Keys.A) && (e.KeyCode <= Keys.Z) && (!e.Alt))
                teclaValida = true;
            else if ((e.KeyCode == Keys.Subtract) ||
                (e.KeyCode == Keys.Back) ||
                (e.KeyCode == Keys.Delete) ||
                (e.KeyCode == Keys.Left) ||
                (e.KeyCode == Keys.Right) ||
                ((e.KeyCode == Keys.OemMinus) && !e.Shift))
                teclaValida = true;

            if (!teclaValida)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void TXTRazonSocial_KeyDown(object sender, KeyEventArgs e)
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

        private void BTNGrabar_Click(object sender, EventArgs e)
        {
            if (VerificarIntegridad())
            {

                if (!this.modificar)
                {
                    //Generar el correlativo
                    correlativo.pxnctipcor = "aproved";
                    if (correlativo.ObtenerSiguiente())
                    {
                        proveedor.paprcodpro = correlativo.pxnctipcor + "-" +
                                                correlativo.cxncnumcor.ToString("D12");
                    }
                }
                else
                {
                    proveedor.caprestpro = SWBEstado.Value;
                }
                proveedor.caprnitpro = TXTNIT.Text;

                if (!modificar)
                {
                    //.causactpas = true;
                }
                //usuario.causmashue = DPECHuellas.EnrolledFingerMask;
                proveedor.faprcntpro = persona.papscodper;

                if (!this.modificar)
                {
                    if (proveedor.Grabar())
                    {
                        MessageBox.Show("Proveedor guardado correctamente!!",
                                        "Mensaje",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                        LimpiarCasillas();
                        this.actualizar = true;
                        this.FormClosing -= FRMProveedor_Registrar_FormClosing;
                        //ApagarCamara();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Proveedor no se pudo guardar!!",
                                        "Error",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    if (proveedor.Modificar())
                    {
                        MessageBox.Show("Proveedor modificado correctamente!!",
                                        "Mensaje",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                        LimpiarCasillas();
                        this.actualizar = true;
                        this.FormClosing -= FRMProveedor_Registrar_FormClosing;
                        //ApagarCamara();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Proveedor no se pudo modificar!!",
                                            "Error",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void BTNLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCasillas();
        }
        #endregion

        private void BTNBuscarProveedor_Click(object sender, EventArgs e)
        {
            FRMPersona_Buscar a = new FRMPersona_Buscar();
            a.ShowDialog();
            if (a.seleccionadoOk)
            {
                this.persona = a.persona;
                this.personaOk = true;
                TXTCelular.Text = persona.capsnumcid;
                TXTRazonSocial.Text = persona.capsapepat + " " +
                                  persona.capsapemat + " " +
                                  persona.capsnomper;
                TXTDireccion.Text = persona.capsdirper;
                /*TXTContacto.Text = persona.capsapepat + " " +
                                  persona.capsapemat + " " +
                                  persona.capsnomper;
                */
            }
            else
            {
                this.personaOk = false;
                TXTCelular.Text = "";
                TXTRazonSocial.Text = "Nombre Completo";
                TXTDireccion.Text = "Dirección";
                //TXTContacto.Text = "Contacto";
            }
        }
    }
}
