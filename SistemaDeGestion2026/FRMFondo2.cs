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
    

    public partial class FRMFondo2 : DevComponents.DotNetBar.Office2007Form
    {
        #region Variables
        public aususis usuario = new aususis();
        public aperson persona = new aperson();
        #endregion

        #region Constructor
        public FRMFondo2()
        {
            InitializeComponent();
        }
        #endregion

        #region Eventos
        private void timer1_Tick(object sender, EventArgs e)
        {
            LBLFecha.Text = DateTime.Now.ToString("F");
        }

        private void FRMFondo2_Load(object sender, EventArgs e)
        {
            TMReloj.Enabled = true;
            LBLUsuario.Text = "Usuario: " +
                            persona.capsapepat + " " +
                            persona.capsapemat + " " +
                            persona.capsnomper;
        }

        private void FRMFondo2_FormClosing(object sender, FormClosingEventArgs e)
        {
            TMReloj.Enabled = false;
        }
        #endregion
    }
}
