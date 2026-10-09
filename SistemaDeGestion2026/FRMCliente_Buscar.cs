using SistemaDeGestion2026;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaRN
{
    public partial class FRMCliente_Buscar : Form
    {
        #region Variables
        public aclient cliente = new aclient();
        private List<aclient> lista_clientes = new List<aclient>();
        public bool seleccionadoOk = false;
        #endregion
        public FRMCliente_Buscar()
        {
            InitializeComponent();
        }
        #region Métodos
        private void ActualizarGrid()
        {
            DTGLista.Rows.Clear();
            lista_clientes.Clear();
            lista_clientes = cliente.Lista("(caclnitcli like '%" + TXTFiltrar.Text + "%' or " +
                                           "caclsoccli like '%" + TXTFiltrar.Text + "%') and caclestcli=true limit " +
                                           IINFilas.Value.ToString()
                                           );
            foreach (aclient a in lista_clientes)
            {
                DTGLista.Rows.Add();

                if (a.caclestcli)
                {
                    if (DTGLista.Rows.Count % 2 == 0)
                    {
                        DTGLista.Rows[DTGLista.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightSkyBlue;
                    }
                }
                else
                {
                    DTGLista.Rows[DTGLista.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Salmon;
                }
                //
                DTGLista[0, DTGLista.Rows.Count - 1].Value = a.paclcodcli;
                DTGLista[1, DTGLista.Rows.Count - 1].Value = a.caclsoccli;
                DTGLista[2, DTGLista.Rows.Count - 1].Value = a.caclnitcli;
                DTGLista[3, DTGLista.Rows.Count - 1].Value = a.caclnumcel;
                DTGLista[4, DTGLista.Rows.Count - 1].Value = a.cacldircli;
            }
        }
        #endregion
        private void FRMCliente_Buscar_Load(object sender, EventArgs e)
        {
            ActualizarGrid();
        }

        private void BTNFiltrar_Click(object sender, EventArgs e)
        {
            ActualizarGrid();
        }

        private void TXTFiltrar_Enter(object sender, EventArgs e)
        {
            TXTFiltrar.SelectAll();
        }

        private void BTNAgregarCliente_Click(object sender, EventArgs e)
        {
            FRMCliente_Registrar a = new FRMCliente_Registrar();
            a.ShowDialog();
            if (a.actualizar)
            {
                ActualizarGrid();
            }
        }

        private void BTNAceptar_Click(object sender, EventArgs e)
        {
            if (DTGLista.SelectedRows.Count == 1)
            {
                cliente.paclcodcli = DTGLista[0, DTGLista.SelectedRows[0].Index].Value?.ToString();
                if (cliente.ObtenerDatos())
                {
                    seleccionadoOk = true;
                    this.Close();
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
    }
}
