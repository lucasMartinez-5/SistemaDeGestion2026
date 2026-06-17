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
    public partial class FRMPersona_Lista : DevComponents.DotNetBar.Office2007Form
    {
        #region Variables
           private aperson persona = new aperson();
           private List<aperson> lista_personas = new List<aperson>();
        #endregion

        #region Constructor
        public FRMPersona_Lista()
        {
            InitializeComponent();
        }
        #endregion

        #region Métodos
        private void ActualizarGrid()
        {
            DTGLista.Rows.Clear();
            lista_personas.Clear();
            lista_personas = persona.Lista("capsnumcid like '%" + TXTFiltrar.Text + "%' or " +
                                           "capsapepat like '%" + TXTFiltrar.Text + "%' or " +
                                           "capsapemat like '%" + TXTFiltrar.Text + "%' or " +
                                           "capsnomper like '%" + TXTFiltrar.Text + "%' limit " +
                                           IINFilas.Value.ToString()
                                           );
            foreach (aperson a in lista_personas)
            {
                DTGLista.Rows.Add();
                DTGLista[0, DTGLista.Rows.Count - 1].Value = a.papscodper;
                DTGLista[1, DTGLista.Rows.Count - 1].Value = a.capsestper;
                DTGLista[2, DTGLista.Rows.Count - 1].Value = a.capsnumcid;
                DTGLista[3, DTGLista.Rows.Count - 1].Value = a.capsapepat;
                DTGLista[4, DTGLista.Rows.Count - 1].Value = a.capsapemat;
                DTGLista[5, DTGLista.Rows.Count - 1].Value = a.capsnomper;
                DTGLista[6, DTGLista.Rows.Count - 1].Value = a.capsfecnac;
                if (a.capssexper)
                {
                    DTGLista[7, DTGLista.Rows.Count - 1].Value = "M";
                }
                else
                {
                    DTGLista[7, DTGLista.Rows.Count - 1].Value = "F";
                }

                DTGLista[8, DTGLista.Rows.Count - 1].Value = a.capsnumcel;

            }

        }
        #endregion

        #region Eventos
        private void FRMPersona_Lista_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            ActualizarGrid();
        }

        private void BTNRegistrar_Click(object sender, EventArgs e)
        {
            FRMPersona_Registrar a = new FRMPersona_Registrar();
            a.ShowDialog();
        }        

        private void BTNReporte_Click(object sender, EventArgs e)
        {

        }

        private void BTNModificar_Click(object sender, EventArgs e)
        {
            if (DTGLista.SelectedRows.Count > 0)
            {
                FRMPersona_Registrar F1 = new FRMPersona_Registrar();
                F1.modificar = true;
                F1.codPerMod = DTGLista[0, DTGLista.SelectedRows[0].Index].Value.ToString();
                F1.ShowDialog();
                if (F1.actualizar)
                {
                    ActualizarGrid();
                }
            }
        }

        private void DTGLista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (DTGLista.SelectedRows.Count > 0)
                {
                    FRMPersona_Registrar F1 = new FRMPersona_Registrar();
                    F1.modificar = true;
                    F1.codPerMod = DTGLista[0, e.RowIndex].Value.ToString();
                    F1.ShowDialog();
                    if (F1.actualizar)
                    {
                        ActualizarGrid();
                    }
                }
            }
        }

        private void BTNFiltrar_Click(object sender, EventArgs e)
        {
            ActualizarGrid();
        }
        #endregion
    }
}
