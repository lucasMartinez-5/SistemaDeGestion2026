using CapaRN;
using DevComponents.DotNetBar.Controls;
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
    public partial class FRMCliente_Lista : DevComponents.DotNetBar.Office2007Form
    {
        #region Variables

        private aclient cliente = new aclient();
        private List<aclient> lista = new List<aclient>();

        #endregion

        #region Constructor
        public FRMCliente_Lista()
        {
            InitializeComponent();
        }
        #endregion

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

        private void FRMCliente_Lista_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            ActualizarGrid();
        }

        private void BTNRegistrar_Click(object sender, EventArgs e)
        {
            FRMCliente_Registrar a = new FRMCliente_Registrar();
            a.ShowDialog();
            if (a.actualizar)
            {
                ActualizarGrid();
            }
        }

        private void BTNModificar_Click(object sender, EventArgs e)
        {
            if (DTGLista.SelectedRows.Count > 0)
            {
                FRMCliente_Registrar F1 = new FRMCliente_Registrar();
                F1.modificar = true;
                F1.codCliMod = DTGLista[0, DTGLista.SelectedRows[0].Index].Value.ToString();
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
                    FRMCliente_Registrar F1 = new FRMCliente_Registrar();
                    F1.modificar = true;
                    F1.codCliMod = DTGLista[0, e.RowIndex].Value.ToString();
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

        private void inhabilitarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DTGLista.SelectedRows.Count > 0)
            {
                cliente.paclcodcli = DTGLista[0, DTGLista.SelectedRows[0].Index].Value.ToString();
                if (cliente.ObtenerDatos())
                {
                    cliente.caclestcli = false;
                    if (cliente.Modificar())
                    {
                        MessageBox.Show("Cliente inhabilitado correctamente");
                        ActualizarGrid();
                    }
                }
            }
        }

        private void habilitarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DTGLista.SelectedRows.Count > 0)
            {
                cliente.paclcodcli = DTGLista[0, DTGLista.SelectedRows[0].Index].Value.ToString();
                if (cliente.ObtenerDatos())
                {
                    cliente.caclestcli = true;
                    if (cliente.Modificar())
                    {
                        MessageBox.Show("Cliente habilitado correctamente");
                        ActualizarGrid();
                    }
                }
            }
        }

        private void CMSMenu_Opening(object sender, CancelEventArgs e)
        {
            if (DTGLista.SelectedRows.Count > 0)
            {
                cliente.paclcodcli = DTGLista[0, DTGLista.SelectedRows[0].Index].Value.ToString();
                if (cliente.ObtenerDatos())
                {
                    if (cliente.caclestcli)
                    {
                        CMSMenu.Items[2].Visible = false;
                        CMSMenu.Items[1].Visible = true;

                    }
                    else
                    {
                        CMSMenu.Items[2].Visible = true;
                        CMSMenu.Items[1].Visible = false;
                    }
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void TXTFiltrar_Enter(object sender, EventArgs e)
        {
            TXTFiltrar.SelectAll();
        }

        private void DTGLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ActualizarGrid();
        }
    }
}
