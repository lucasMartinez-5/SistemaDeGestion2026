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
    public partial class FRMVenta_Lista : DevComponents.DotNetBar.Office2007Form
    {
        #region Variables

        private aclient cliente = new aclient();
        private List<aclient> lista = new List<aclient>();

        #endregion
        public FRMVenta_Lista()
        {
            InitializeComponent();
        }
        #region Metodos
        private void ActualizarGrid()
        {
            DTGLista.Rows.Clear();
            lista.Clear();
            lista = cliente.Lista("(caclrazcli like '%" + TXTFiltrar.Text + "%' or " +
                                            "caclnitcli like '%" + TXTFiltrar.Text + "%' or " +
                                            "cacldircli like '%" + TXTFiltrar.Text + "%' or " +
                                            "cacltelcli like '%" + TXTFiltrar.Text + "%') limit " +
                                           IINFilas.Value.ToString()
                                           );

            foreach (aclient a in lista)
            {
                DTGLista.Rows.Add();

                if (a.caclestcli)
                {
                    if (DTGLista.Rows.Count % 2 == 0)
                    {
                        DTGLista.Rows[DTGLista.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Gainsboro;
                    }
                }
                else
                {
                    DTGLista.Rows[DTGLista.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Tomato;
                    DTGLista.Rows[DTGLista.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.White;
                }
                DTGLista[0, DTGLista.Rows.Count - 1].Value = a.faclcodper;
                DTGLista[1, DTGLista.Rows.Count - 1].Value = a.caclestcli;
                DTGLista[2, DTGLista.Rows.Count - 1].Value = a.caclrazcli;
                DTGLista[3, DTGLista.Rows.Count - 1].Value = a.caclnitcli;

                DTGLista[4, DTGLista.Rows.Count - 1].Value = a.cacldircli;
                DTGLista[5, DTGLista.Rows.Count - 1].Value = a.cacltelcli;


            }

        }

        #endregion

        private void BTNRegistrar_Click(object sender, EventArgs e)
        {
            FRMCliente_Registrar a = new FRMCliente_Registrar();
            a.ShowDialog();
            if (a.actualizar)
            {
                ActualizarGrid();
            }
        }
    }
}
