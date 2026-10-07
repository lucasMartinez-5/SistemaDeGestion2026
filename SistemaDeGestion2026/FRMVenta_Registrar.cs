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
        private List<aclient> lista_clientes = new List<aclient>();
        public bool seleccionadoOk = false;
        private bool clienteOk = false;
        #endregion
        public FRMVenta_Registrar()
        {
            InitializeComponent();
        }

        private void DTGLista_Leave(object sender, EventArgs e)
        {
            
        }

        private void BTNBuscarCliente_Click(object sender, EventArgs e)
        {
            FRMCliente_Buscar a = new FRMCliente_Buscar();
            a.ShowDialog();
            if (a.seleccionadoOk)
            {
                this.cliente = a.cliente;
                this.clienteOk = true;
                TXTNIT.Text = cliente.caclnitcli;
                TXTRazonSocial.Text = cliente.caclsoccli;
            }
            else
            {
                this.clienteOk = false;
                TXTNIT.Text = "";
                TXTRazonSocial.Text = "";
                
            }
        }
    }
}
