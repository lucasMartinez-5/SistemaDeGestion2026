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
    public partial class FRMModificarPassword : Form
    {
        #region Variables
        public aususis usuario = new aususis();
        public aperson persona = new aperson();
        public bool loginExitoso = false;
        #endregion

        #region Constructor        
        public FRMModificarPassword()
        {
            InitializeComponent();
        }
        #endregion

        #region Metodos
        private bool VerificarIntegridad()
        {
            bool respuesta = true;

            if (TXTNombreLogin.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Introduzca el LOGIN del usuario", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTNombreLogin.Focus();
                respuesta = false;
            }
            else if (TXTPassword.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Introduzca el PASSWORD del usuario", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TXTPassword.Focus();
                respuesta = false;
            }

            return respuesta;
        }
        #endregion

        #region Eventos
        private void BTNConfirmarPassword_Click(object sender, EventArgs e)
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

        private void BTNPassword_Click(object sender, EventArgs e)
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

        private void BTNCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
