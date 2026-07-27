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
    public partial class FRMIniciar_Sesion : DevComponents.DotNetBar.Office2007Form
    {
        #region Variables
        aususis usuario = new aususis();
        #endregion

        #region Constructor
        public FRMIniciar_Sesion()
        {
            InitializeComponent();
        }
        #endregion

        #region Eventos
        
        private void BTNCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTNMostrarPassword_Click(object sender, EventArgs e)
        {
            if (TXTPassword.PasswordChar == '*')
            {
                TXTPassword.PasswordChar = '\0';
            }
            else
            {
                TXTPassword.PasswordChar = '*';
            }
        }

        #endregion
    }
}
