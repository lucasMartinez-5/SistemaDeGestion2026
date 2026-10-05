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
        aclient cliente = new aclient();
        #endregion
        public FRMVenta_Registrar()
        {
            InitializeComponent();
        }

        private void DTGLista_Leave(object sender, EventArgs e)
        {
            
        }
    }
}
