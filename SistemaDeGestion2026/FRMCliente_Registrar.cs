using CapaRN;
using DevComponents.DotNetBar.Controls;
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
    public partial class FRMCliente_Registrar : DevComponents.DotNetBar.Office2007Form
    {
        #region Variables
        private aclient cliente = new aclient();
        private aperson persona = new aperson();
        private bool personaOk = false;
        private xnumcor correlativo = new xnumcor();
        public bool modificar = false;
        public String codCliMod = "";
        public bool actualizar = false;
        #endregion

        #region Constructor
        public FRMCliente_Registrar()
        {
            InitializeComponent();
        }
        #endregion

        #region Métodos
        private bool VerificarIntegridad()
        {
            bool respuesta = true;

            aclient cliente2 = new aclient();
            cliente2.caclnitcli = TXTNIT.Text;
            aperson persona2 = new aperson();
            persona2.capsnumcel = TXTCelular.Text;

            if (TXTCelular.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Introduzca el celular de la persona", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTCelular.Focus();
                respuesta = false;
            }
            else if (TXTNIT.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Introduzca el NIT del cliente", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTNIT.Focus();
                respuesta = false;
            }// condicion para retringir NIT ajeno al modificar o registrar
            else if (cliente2.ObtenerDatosNIT(modificar, cliente.caclnitcli))
            {
                MessageBox.Show("Ya existe un cliente con ese NIT", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTNIT.Focus();
                respuesta = false;
            }
            else if (TXTRazonSocial.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Introduzca el nombre completo del cliente", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTRazonSocial.Focus();
                respuesta = false;
            }
            else if (TXTDireccion.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Introduzca la Direccion del cliente", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            cliente.paclcodcli = this.codCliMod;
            cliente.ObtenerDatos();
            persona.papscodper = cliente.faclcntcli;
            persona.ObtenerDatos();
            SWBEstado.Value = cliente.caclestcli;
            TXTCelular.Text = persona.capsnumcel;
            TXTRazonSocial.Text = persona.capsapepat + " " +
                                    persona.capsapemat + " " +
                                    persona.capsnomper;
            TXTNIT.Text = cliente.caclnitcli;
            TXTDireccion.Text = persona.capsdirper;
        }
        #endregion

        #region Eventos
        private void BTNSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FRMCliente_Registrar_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea cerrar el formulario?",
                                "Pregunta",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question,
                                MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void TXTCelular_Enter(object sender, EventArgs e)
        {
            TextBoxX a = (TextBoxX)sender;
            a.SelectAll();
        }

        private void FRMCliente_Registrar_Load(object sender, EventArgs e)
        {
            if (this.modificar)
            {
                JalarDatos();
                BTNGrabar.Text = "&Modificar";
                this.Text = "Modificar Cliente";
                GPPanelPrincipal.Text = "Modificar Cliente";
                TXTCelular.Focus();
            }
            else
            {
                LimpiarCasillas();
                BTNGrabar.Text = "&Guardar";
                this.Text = "Registrar Cliente";
                GPPanelPrincipal.Text = "Registrar Cliente";
                TXTCelular.Focus();
            }
        }

        private void TXTRazonSocial_KeyDown(object sender, KeyEventArgs e)
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

        private void TXTNIT_KeyDown(object sender, KeyEventArgs e)
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

        #endregion

        private void BTNBuscarCliente_Click(object sender, EventArgs e)
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
            }
            else
            {
                this.personaOk = false;
                TXTCelular.Text = "";
                TXTRazonSocial.Text = "Nombre Completo";
                TXTDireccion.Text = "Dirección";
            }
        }

        private void BTNGrabar_Click(object sender, EventArgs e)
        {
            if (VerificarIntegridad())
            {

                if (!this.modificar)
                {
                    //Generar el correlativo
                    correlativo.pxnctipcor = "aclient";
                    if (correlativo.ObtenerSiguiente())
                    {
                        cliente.paclcodcli = correlativo.pxnctipcor + "-" +
                                             correlativo.cxncnumcor.ToString("D12");
                    }
                }
                else
                {
                    cliente.caclestcli = SWBEstado.Value;
                }
                //usuario.causactpas = false;
                cliente.caclnitcli = TXTNIT.Text;

                if (!modificar)
                {
                    //.causactpas = true;
                }
                //usuario.causmashue = DPECHuellas.EnrolledFingerMask;
                cliente.faclcntcli = persona.papscodper;

                if (!this.modificar)
                {
                    if (cliente.Grabar())
                    {
                        MessageBox.Show("Cliente guardado correctamente!!",
                                        "Mensaje",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                        LimpiarCasillas();
                        this.actualizar = true;
                        this.FormClosing -= FRMCliente_Registrar_FormClosing;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Cliente no se pudo guardar!!",
                                        "Error",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    if (cliente.Modificar())
                    {
                        MessageBox.Show("Cliente modificado correctamente!!",
                                        "Mensaje",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                        LimpiarCasillas();
                        this.actualizar = true;
                        this.FormClosing -= FRMCliente_Registrar_FormClosing;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Cliente no se pudo modificar!!",
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
    }
}
