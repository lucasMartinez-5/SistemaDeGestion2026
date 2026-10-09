using CapaRN;
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
    public partial class FRMVenta_Registrar : DevComponents.DotNetBar.Office2007Form
    {
        #region Variables
        private aclient cliente = new aclient();
        private bool clienteok = false;
        private bool lectorCBHabilitado = false;
        public aproduc producto = new aproduc();
        #endregion

        #region Constructor
        public FRMVenta_Registrar()
        {
            InitializeComponent();
        }

        #endregion

        private void TXTNITCliente_Leave(object sender, EventArgs e)
        {
            cliente.caclnitcli = TXTNITCliente.Text;
            if (cliente.ObtenerDatosNIT())
            {
                TXTNombreCliente.Text = cliente.caclrazcli;
                clienteok = true;
            }
            else
            {
                TXTNombreCliente.Text = "Nombre del cliente";
                clienteok = false;
            }
        }

        private void BTNBuscarUsuario_Click(object sender, EventArgs e)
        {
            FRMCliente_Buscar a = new FRMCliente_Buscar();
            a.ShowDialog();
            if (a.seleccionadoOk)
            {
                this.cliente = a.cliente;
                this.clienteok = true;
                TXTNITCliente.Text = cliente.caclnitcli;
                TXTNombreCliente.Text = cliente.caclrazcli;
            }
            else
            {
                this.clienteok = false;
                TXTNITCliente.Text = "";
                TXTNombreCliente.Text = "Nombre del cliente";
            }
        }

        private void BTNCodigoDeBarras_Click(object sender, EventArgs e)
        {
            if (!lectorCBHabilitado)
            {
                lectorCBHabilitado = true;
                LBLCodigoDeBarras.Text = "LECTOR ACTIVO";
                LBLCodigoDeBarras.BackColor = Color.PaleGreen;
            }
            else
            {
                if (LBLCodigoDeBarras.Text == "LECTOR ACTIVO")
                {
                    LBLCodigoDeBarras.Text = "SIN CÓDIGO";
                    LBLCodigoDeBarras.BackColor = Color.Salmon;
                }
                else
                {
                    producto.capdcodbar = LBLCodigoDeBarras.Text;
                    if (producto.ObtenerDatosCodigo(false, producto.capdcodbar))
                    {
                        MessageBox.Show("Producto encontrado " + producto.capddespro);
                    }
                }
                lectorCBHabilitado = false;
            }
        }

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
    }
}
