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
    public partial class FRMProveedor_Lista : DevComponents.DotNetBar.Office2007Form
    {
        #region Variables
        private aproved proveedor = new aproved();
        private List<aproved> lista_proveedores = new List<aproved>();
        #endregion

        #region Constructor
        public FRMProveedor_Lista()
        {
            InitializeComponent();
        }
        #endregion

        #region Métodos
        private void ActualizarGrid()
        {
            DTGLista.Rows.Clear();
            lista_proveedores.Clear();
            lista_proveedores = proveedor.Lista("caprnitpro like '%" + TXTFiltrar.Text + "%' or " +
                                                "caprsocpro like '%" + TXTFiltrar.Text + "%' limit " +
                                           IINFilas.Value.ToString()
                                           );
            foreach (aproved a in lista_proveedores)
            {
                DTGLista.Rows.Add();

                if (a.caprestpro)
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

                DTGLista[0, DTGLista.Rows.Count - 1].Value = a.paprcodpro;
                DTGLista[1, DTGLista.Rows.Count - 1].Value = a.caprestpro;
                DTGLista[2, DTGLista.Rows.Count - 1].Value = a.caprnitpro;
                DTGLista[3, DTGLista.Rows.Count - 1].Value = a.caprsocpro;
                DTGLista[4, DTGLista.Rows.Count - 1].Value = a.caprnumcel;
                
            }
        }
        #endregion

        private void FRMProveedor_Lista_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            ActualizarGrid();
        }

        private void BTNRegistrar_Click(object sender, EventArgs e)
        {
            FRMProveedor_Registrar a = new FRMProveedor_Registrar();
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
                FRMProveedor_Registrar F1 = new FRMProveedor_Registrar();
                F1.modificar = true;
                F1.codPveMod = DTGLista[0, DTGLista.SelectedRows[0].Index].Value.ToString();
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
                    FRMProveedor_Registrar F1 = new FRMProveedor_Registrar();
                    F1.modificar = true;
                    F1.codPveMod = DTGLista[0, e.RowIndex].Value.ToString();
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

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DTGLista.SelectedRows.Count > 0)
            {
                FRMProveedor_Registrar F1 = new FRMProveedor_Registrar();
                F1.modificar = true;
                F1.codPveMod = DTGLista[0, DTGLista.SelectedRows[0].Index].Value.ToString();
                F1.ShowDialog();
                if (F1.actualizar)
                {
                    ActualizarGrid();
                }
            }
        }

        private void DTGLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ActualizarGrid();
        }

        private void inhabilitarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DTGLista.SelectedRows.Count > 0)
            {
                proveedor.paprcodpro = DTGLista[0, DTGLista.SelectedRows[0].Index].Value.ToString();
                if (proveedor.ObtenerDatos())
                {
                    proveedor.caprestpro = false;
                    if (proveedor.Modificar())
                    {
                        MessageBox.Show("Proveedor Inhabilitado correctamente");
                        ActualizarGrid();
                    }
                }
            }
        }

        private void CMSMenu_Opening(object sender, CancelEventArgs e)
        {
            if (DTGLista.SelectedRows.Count > 0)
            {
                proveedor.paprcodpro = DTGLista[0, DTGLista.SelectedRows[0].Index].Value.ToString();
                if (proveedor.ObtenerDatos())
                {

                    if (proveedor.caprestpro)
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
        }

        private void habilitarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DTGLista.SelectedRows.Count > 0)
            {
                proveedor.paprcodpro = DTGLista[0, DTGLista.SelectedRows[0].Index].Value.ToString();
                if (proveedor.ObtenerDatos())
                {
                    proveedor.caprestpro = true;
                    if (proveedor.Modificar())
                    {
                        MessageBox.Show("Proveedor Habilitado correctamente");
                        ActualizarGrid();
                    }
                }
            }
        }

        private void TXTFiltrar_Enter(object sender, EventArgs e)
        {
            TXTFiltrar.SelectAll();
        }
    }
}
