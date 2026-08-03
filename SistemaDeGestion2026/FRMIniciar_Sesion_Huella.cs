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
    public partial class FRMIniciar_Sesion_Huella : DevComponents.DotNetBar.Office2007Form
    {
        #region Variables
        public aususis usuario = new aususis();
        public aperson persona = new aperson();
        public bool loginExitoso = false;
        #endregion

        #region Constructor
        public FRMIniciar_Sesion_Huella()
        {
            InitializeComponent();
        }
        #endregion

        private void PVCHuella_OnComplete(object Control, DPFP.FeatureSet FeatureSet, ref DPFP.Gui.EventHandlerStatus EventHandlerStatus)
        {
            MessageBox.Show("Huella digital capturada correctamente.","Información",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void PVCHuella_Load(object sender, EventArgs e)
        {

        }
    }
}
